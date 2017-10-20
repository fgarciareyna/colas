using Colas.Clientes;
using NumerosAleatorios.VariablesAleatorias;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Colas;
using Colas.Colas;
using Colas.Servidores;

namespace TP4
{
    public partial class Tp4 : Form
    {
        private const int Decimales = 2;

        public Tp4()
        {
            var culture = CultureInfo.InvariantCulture;
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            InitializeComponent();
        }

        private void rb_estrategia_a_CheckedChanged(object sender, EventArgs e)
        {
            btn_simular.Enabled = true;
        }

        private void rb_estrategia_b_CheckedChanged(object sender, EventArgs e)
        {
            btn_simular.Enabled = true;
        }

        [SuppressMessage("ReSharper", "LocalVariableHidesMember")]
        private void btn_simular_Click(object sender, EventArgs e)
        {
            if (!FormularioValido()) return;

            lv_simulaciones.Items.Clear();
            var cols = lv_simulaciones.Columns.Count;
            for (var c = cols - 1; c >= 19; c--)
            {
                lv_simulaciones.Columns.RemoveAt(c);
            }


            var recepcionA = double.Parse(txt_recepcion_a.Text);
            var recepcionB = double.Parse(txt_recepcion_b.Text);
            var distribucionRecepcion = new DistribucionUniforme(recepcionA, recepcionB);
            var colaRecepcion = new ColaFifo("Recepción");
            var recepcion = new Servidor(distribucionRecepcion, colaRecepcion, "Recepción");

            var balanzaA = double.Parse(txt_balanza_a.Text);
            var balanzaB = double.Parse(txt_balanza_b.Text);
            var distribucionBalanza = new DistribucionUniforme(balanzaA, balanzaB);
            var colaBalanza = new ColaFifo("Balanza");
            var balanza = new Servidor(distribucionBalanza, colaBalanza, "Balanza");

            var darsenasA = double.Parse(txt_darsenas_a.Text);
            var darsenasB = double.Parse(txt_darsenas_b.Text);
            var distribucionDarsenas = new DistribucionUniforme(darsenasA, darsenasB);
            var colaDarsenas = new ColaFifo("Dársenas");
            var mediaRecalibracion = double.Parse(txt_recalibracion_media.Text);
            var varianzaRecalibracion = double.Parse(txt_recalibracion_varianza.Text);
            var distribucionRecalibracion = new DistribucionNormal(mediaRecalibracion, varianzaRecalibracion);
            var darsena1 = new Servidor(distribucionDarsenas, colaDarsenas, "Dársena 1", distribucionRecalibracion);
            var darsena2 = new Servidor(distribucionDarsenas, colaDarsenas, "Dársena 2", distribucionRecalibracion);


            IDistribucion distribucionLlegadas;
            DateTime horaInicio;

            if (rb_estrategia_a.Checked)
            {
                var lambda = double.Parse(txt_llegadas_lambda.Text);
                distribucionLlegadas = new DistribucionExponencialNegativa(lambda);
                horaInicio = DateTime.Today.AddHours(12);
            }
            else
            {
                distribucionLlegadas = new DistribucionUniforme(7, 8);
                horaInicio = DateTime.Today.AddHours(5);
            }

            var dias = int.Parse(txt_dias.Text);
            var desde = int.Parse(txt_desde.Text);
            var hasta = int.Parse(txt_hasta.Text);

            decimal promedioAtendidos = 0;
            decimal promedioNoAtendidos = 0;
            decimal promedioPermanencia = 0;

            var afuera = 0;
            var simulacion = 0;
            var numCamion = 0;
            var clientes = new List<Cliente>();

            for (var dia = 1; dia <= dias; dia++)
            {
                var llegando = 0;
                var atendidos = 0;
                var noAtendidos = 0;
                decimal permanencia = 0;
                var llegadas = new Llegada(distribucionLlegadas, horaInicio);
                var cierre = new Evento("Cierre", DateTime.Today.AddHours(18));

                while (llegadas.Abierto()
                       || !recepcion.EstaLibre()
                       || !balanza.EstaLibre()
                       || !darsena1.EstaLibre()
                       || !darsena2.EstaLibre())
                {
                    simulacion++;

                    while (llegando < afuera)
                    {
                        llegando++;
                        numCamion++;
                        var clientePendiente = new Cliente($"Camión {numCamion}");
                        clientePendiente.Llegar(horaInicio);
                        recepcion.LlegadaCliente(horaInicio, clientePendiente);
                        if (simulacion < hasta)
                        {
                            clientes.Add(clientePendiente);

                            lv_simulaciones.Columns.Add($"llegada_camion_{numCamion}", $"Llegada Camión {numCamion}", 125);
                            lv_simulaciones.Columns.Add($"estado_camion_{numCamion}", $"Estado Camión {numCamion}", 125);
                            lv_simulaciones.Columns.Add($"permanencia_camion_{numCamion}", $"Permanencia Camión {numCamion}", 140);
                        }
                    }

                    var eventos = new List<Evento>
                    {
                        new Evento("Llegada", llegadas.ProximaLlegada),
                        new Evento("Fin Recepción", recepcion.ProximoFinAtencion),
                        new Evento("Fin Balanza", balanza.ProximoFinAtencion),
                        new Evento("Fin Dársena 1", darsena1.ProximoFinAtencion),
                        new Evento("Fin Dársena 2", darsena2.ProximoFinAtencion),
                        cierre
                    };

                    // ReSharper disable once PossibleInvalidOperationException
                    var reloj = eventos.Where(ev => ev.Hora.HasValue).Min(ev => ev.Hora).Value;
                    var evento = eventos.First(ev => ev.Hora.Equals(reloj)).Nombre;
                        
                    switch (evento)
                    {
                        case "Llegada":
                            llegando++;
                            numCamion++;
                            var clienteLlegando = new Cliente($"Camión {numCamion}");
                            clienteLlegando.Llegar(reloj);
                            recepcion.LlegadaCliente(reloj, clienteLlegando);
                            llegadas.ActualizarLlegada();
                            if (simulacion < hasta)
                            {
                                clientes.Add(clienteLlegando);

                                lv_simulaciones.Columns.Add($"llegada_camion_{numCamion}", $"Llegada Camión {numCamion}", 125);
                                lv_simulaciones.Columns.Add($"estado_camion_{numCamion}", $"Estado Camión {numCamion}", 125);
                                lv_simulaciones.Columns.Add($"permanencia_camion_{numCamion}", $"Permanencia Camión {numCamion}", 140);
                            }
                            break;

                        case "Fin Recepción":
                            var clienteReceptado = recepcion.FinAtencion();
                            balanza.LlegadaCliente(reloj, clienteReceptado);
                            break;

                        case "Fin Balanza":
                            var clientePesado = balanza.FinAtencion();
                            if(darsena1.EstaLibre())
                                darsena1.LlegadaCliente(reloj, clientePesado);
                            else
                                darsena2.LlegadaCliente(reloj, clientePesado);
                            break;

                        case "Fin Dársena 1":
                            var clienteSaliendo1 = darsena1.FinAtencion();
                            if (clienteSaliendo1 != null)
                            {
                                clienteSaliendo1.Salir(reloj);
                                permanencia = (permanencia * atendidos + clienteSaliendo1.TiempoEnSistema) / (atendidos + 1);
                                atendidos++;
                            }
                            break;

                        case "Fin Dársena 2":
                            var clienteSaliendo2 = darsena2.FinAtencion();
                            if (clienteSaliendo2 != null)
                            {
                                clienteSaliendo2.Salir(reloj);
                                permanencia = (permanencia * atendidos + clienteSaliendo2.TiempoEnSistema) / (atendidos + 1);
                                atendidos++;
                            }
                            break;

                        case "Cierre":
                            llegadas.Cerrar();
                            afuera = colaRecepcion.Cantidad();
                            promedioNoAtendidos = (promedioNoAtendidos * (dia - 1) + afuera) / dia;
                            colaRecepcion.Vaciar();
                            noAtendidos = afuera;
                            cierre = new Evento("Cierre", null);
                            break;
                    }

                    if (simulacion >= desde && simulacion <= hasta)
                    {
                        var item = new ListViewItem(reloj.ToString("HH:mm:ss"));
                        item.SubItems.Add(evento);
                        item.SubItems.Add(llegadas.ProximaLlegada?.ToString("HH:mm:ss"));
                        item.SubItems.Add(colaRecepcion.Cantidad().ToString());
                        item.SubItems.Add(recepcion.Estado);
                        item.SubItems.Add(recepcion.ProximoFinAtencion?.ToString("HH:mm:ss"));
                        item.SubItems.Add(colaBalanza.Cantidad().ToString());
                        item.SubItems.Add(balanza.Estado);
                        item.SubItems.Add(balanza.ProximoFinAtencion?.ToString("HH:mm:ss"));
                        item.SubItems.Add(colaDarsenas.Cantidad().ToString());
                        item.SubItems.Add(darsena1.Estado);
                        item.SubItems.Add(darsena1.ProximoFinAtencion?.ToString("HH:mm:ss"));
                        item.SubItems.Add(darsena1.CantidadAtendidos.ToString());
                        item.SubItems.Add(darsena2.Estado);
                        item.SubItems.Add(darsena2.ProximoFinAtencion?.ToString("HH:mm:ss"));
                        item.SubItems.Add(darsena2.CantidadAtendidos.ToString());
                        item.SubItems.Add(atendidos.ToString());
                        item.SubItems.Add(noAtendidos.ToString());
                        item.SubItems.Add(Math.Round(permanencia, Decimales).ToString());

                        foreach (var cliente in clientes)
                        {
                            item.SubItems.Add(cliente.HoraLlegada.ToString("HH:mm:ss"));
                            item.SubItems.Add(cliente.Estado);
                            item.SubItems.Add(Math.Round(cliente.TiempoEnSistema, Decimales).ToString());
                        }

                        lv_simulaciones.Items.Add(item);
                    }
                }

                var permanenciaAnterior = promedioPermanencia * promedioAtendidos * (dia - 1);

                promedioAtendidos = (promedioAtendidos * (dia - 1) + atendidos) / dia;
                promedioNoAtendidos = (promedioNoAtendidos * (dia - 1) + noAtendidos) / dia;
                promedioPermanencia = (permanenciaAnterior + permanencia * atendidos) / (promedioAtendidos * dia);
            }

            if (rb_estrategia_a.Checked)
            {
                txt_atendidos_a.Text = Math.Round(promedioAtendidos, Decimales).ToString();
                txt_no_atendidos_a.Text = Math.Round(promedioNoAtendidos, Decimales).ToString();
                txt_permanencia_a.Text = Math.Round(promedioPermanencia, Decimales).ToString();
            }
            else
            {
                txt_atendidos_b.Text = Math.Round(promedioAtendidos, Decimales).ToString();
                txt_no_atendidos_b.Text = Math.Round(promedioNoAtendidos, Decimales).ToString();
                txt_permanencia_b.Text = Math.Round(promedioPermanencia, Decimales).ToString();
            }

            HabilitarComparacion();
        }

        private void btn_comparar_Click(object sender, EventArgs e)
        {
            var sb = new StringBuilder();
            double porcentaje;
            string masMenos;

            var atendidosA = double.Parse(txt_atendidos_a.Text);
            var atendidosB = double.Parse(txt_atendidos_b.Text);

            if (!atendidosA.Equals(atendidosB))
            {
                porcentaje = Math.Round(Math.Abs((atendidosB - atendidosA) / atendidosA * 100), Decimales);
                masMenos = atendidosB > atendidosA ? "Más" : "Menos";

                sb.Append($"Con la estrategia B se atendieron un {porcentaje}% {masMenos} de camiones.");
            }
            else
            {
                sb.Append("Con ambas estrategias se atendieron la misma cantidad de camiones.");
            }
            sb.AppendLine();

            var noAtendidosA = double.Parse(txt_no_atendidos_a.Text);
            var noAtendidosB = double.Parse(txt_no_atendidos_b.Text);

            if (!noAtendidosA.Equals(noAtendidosB))
            {
                porcentaje = Math.Round(Math.Abs((noAtendidosB - noAtendidosA) / noAtendidosA * 100), Decimales);
                masMenos = noAtendidosB > noAtendidosA ? "Más" : "Menos";

                sb.Append($"Con la estrategia B quedaron afuera un {porcentaje}% {masMenos} de camiones.");
            }
            else
            {
                sb.Append("Con ambas estrategias quedaron afuera la misma cantidad de camiones.");
            }
            sb.AppendLine();

            var permanenciaA = double.Parse(txt_permanencia_a.Text);
            var permanenciaB = double.Parse(txt_permanencia_b.Text);

            if (!permanenciaA.Equals(permanenciaB))
            {
                porcentaje = Math.Round(Math.Abs((permanenciaB - permanenciaA) / permanenciaA * 100), Decimales);
                masMenos = permanenciaB > permanenciaA ? "Más" : "Menos";

                sb.Append($"Con la estrategia B los camiones permanecieron un {porcentaje}% {masMenos} de tiempo.");
            }
            else
            {
                sb.Append("Con ambas estrategias los camiones permanecieron la misma cantidad de tiempo.");
            }
            sb.AppendLine();

            if (atendidosA > atendidosB && noAtendidosA < noAtendidosB && permanenciaA < permanenciaB)
            {
                sb.AppendLine();
                sb.Append("La estrategia más conveniente es la A");
            }

            if (atendidosA < atendidosB && noAtendidosA > noAtendidosB && permanenciaA > permanenciaB)
            {
                sb.AppendLine();
                sb.Append("La estrategia más conveniente es la B");
            }

            MessageBox.Show(sb.ToString(), @"Resultado");
        }

        private bool FormularioValido()
        {
            if (rb_estrategia_a.Checked && !ValidarExponencial(txt_llegadas_lambda))
                return false;

            if (!ValidarUniforme(txt_recepcion_a, txt_recepcion_b))
                return false;

            if (!ValidarUniforme(txt_balanza_a, txt_balanza_b))
                return false;

            if (!ValidarUniforme(txt_darsenas_a, txt_darsenas_b))
                return false;

            if (!ValidarNormal(txt_recalibracion_media, txt_recalibracion_varianza))
                return false;

            return ValidarCantidades(txt_desde, txt_hasta, txt_dias);
        }

        private bool ValidarExponencial(Control txtLambda)
        {
            var mensaje = "Lambda debe ser un número positivo";

            if (string.IsNullOrEmpty(txtLambda.Text))
            {
                MensajeError(mensaje, txtLambda);
                return false;
            }

            double lambda;

            if (!double.TryParse(txtLambda.Text, out lambda) || lambda <= 0)
            {
                MensajeError(mensaje, txtLambda);
                return false;
            }

            return true;
        }

        private bool ValidarUniforme(Control txtA, Control txtB)
        {
            var mensaje = "Ingrese un número válido para A";

            if (string.IsNullOrEmpty(txtA.Text))
            {
                MensajeError(mensaje, txtA);
                return false;
            }

            double a;

            if (!double.TryParse(txtA.Text, out a))
            {
                MensajeError(mensaje, txtA);
                return false;
            }

            mensaje = "Ingrese un número válido para B";

            if (string.IsNullOrEmpty(txtB.Text))
            {
                MensajeError(mensaje, txtB);
                return false;
            }

            double b;

            if (!double.TryParse(txtB.Text, out b))
            {
                MensajeError(mensaje, txtB);
                return false;
            }

            mensaje = "B debe ser mayor que A";

            if (b <= a)
            {
                MensajeError(mensaje, txtB);
                return false;
            }

            return true;
        }

        private bool ValidarNormal(Control txtMedia, Control txtVarianza)
        {
            var mensaje = "Ingrese un número válido para la media";

            if (string.IsNullOrEmpty(txtMedia.Text))
            {
                MensajeError(mensaje, txtMedia);
                return false;
            }

            double media;

            if (!double.TryParse(txtMedia.Text, out media))
            {
                MensajeError(mensaje, txtMedia);
                return false;
            }

            mensaje = "La varianza debe ser un número positivo";

            if (string.IsNullOrEmpty(txtVarianza.Text))
            {
                MensajeError(mensaje, txtVarianza);
                return false;
            }

            double varianza;

            if (!double.TryParse(txtVarianza.Text, out varianza) || varianza < 0)
            {
                MensajeError(mensaje, txtVarianza);
                return false;
            }

            return true;
        }

        private bool ValidarCantidades(Control txtDesde, Control txtHasta, Control txtDias)
        {
            var mensaje = "Los días deben ser un entero positivo";

            if (string.IsNullOrEmpty(txtDias.Text))
            {
                MensajeError(mensaje, txtDias);
                return false;
            }

            int dias;

            if (!int.TryParse(txtDias.Text, out dias) || dias <= 0)
            {
                MensajeError(mensaje, txtDias);
                return false;
            }

            mensaje = "El evento desde debe ser un entero positivo";

            if (string.IsNullOrEmpty(txtDesde.Text))
            {
                MensajeError(mensaje, txtDesde);
                return false;
            }

            int desde;

            if (!int.TryParse(txtDesde.Text, out desde) || desde <= 0)
            {
                MensajeError(mensaje, txtDesde);
                return false;
            }

            mensaje = "El evento hasta debe ser un entero positivo";

            if (string.IsNullOrEmpty(txtHasta.Text))
            {
                MensajeError(mensaje, txtHasta);
                return false;
            }

            int hasta;

            if (!int.TryParse(txtHasta.Text, out hasta) || hasta <= 0)
            {
                MensajeError(mensaje, txtHasta);
                return false;
            }

            mensaje = "El evento hasta no puede ser inferior al desde";

            if (hasta < desde)
            {
                MensajeError(mensaje, txtHasta);
                return false;
            }

            return true;
        }

        private void MensajeError(string mensaje, Control textBox)
        {
            MessageBox.Show(mensaje, @"Error");
            textBox.Focus();
        }

        private void HabilitarComparacion()
        {
            if (!string.IsNullOrEmpty(txt_atendidos_a.Text) &&
                !string.IsNullOrEmpty(txt_atendidos_b.Text))
                btn_comparar.Enabled = true;
        }

        private void lk_estrategia_a_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var lambda = string.IsNullOrEmpty(txt_llegadas_lambda.Text) ? "7,5" : txt_llegadas_lambda.Text;

            MessageBox.Show($@"Llegada de camiones con una distribución Exponencial Negativa de lambda {lambda} a partir de las 12:00 hs",
                @"Estrategia A");
        }

        private void lk_estrategia_b_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(@"Llegada de camiones con una distribución Uniforme entre 7 y 8 minutos, a partir de las 05:00 hs",
                @"Estrategia B");
        }
    }
}
