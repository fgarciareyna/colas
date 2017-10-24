using Colas.Clientes;
using NumerosAleatorios.VariablesAleatorias;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Reflection;
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

        private readonly CultureInfo _culture;

        private Thread _simularThread;

        private delegate void InicioFinDelegate(bool fin);
        private delegate void ColumnasDelegate(int numCamion);
        private delegate void FilaDelegate(DateTime relojActual, string eventoActual, Llegada llegadas,
            ICola colaRecepcion, Servidor recepcion, ICola colaBalanza, Servidor balanza, ICola colaDarsenas, Servidor darsena1,
            Servidor darsena2, int atendidos, int noAtendidos, decimal permanenciaDiaria, IEnumerable<Cliente> clientes);
        private delegate void StatusDelegate(int dia, DateTime relojActual, int simulacion);
        private delegate void ResultadosDelegate(decimal promedioAtendidos, decimal promedioNoAtendidos,
            decimal promedioPermanencia);

        private bool _cancelar;

        public Tp4()
        {
            _culture = CultureInfo.InvariantCulture;
            Thread.CurrentThread.CurrentCulture = _culture;
            Thread.CurrentThread.CurrentUICulture = _culture;

            InitializeComponent();
            DoubleBuffer();
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

            _simularThread = new Thread(Simular)
            {
                CurrentCulture = _culture,
                CurrentUICulture = _culture
            };
            
            _simularThread.Start();
        }

        private void Simular()
        {
            var inicioFinInstance = new InicioFinDelegate(InicioFin);
            var columnasInstance = new ColumnasDelegate(AgregarColumnas);
            var filaInstance = new FilaDelegate(AgregarFila);
            var statusInstance = new StatusDelegate(ActualizarStatus);
            var resultadosInstance = new ResultadosDelegate(MostrarResultados);

            Invoke(inicioFinInstance, false);

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

            var horaFin = DateTime.Today.AddHours(18);

            var llegadas = new Llegada(distribucionLlegadas, horaInicio, horaFin);

            var dias = int.Parse(txt_dias.Text);
            var desde = int.Parse(txt_desde.Text);
            var hasta = int.Parse(txt_hasta.Text);

            decimal promedioAtendidos = 0;
            decimal promedioNoAtendidos = 0;
            decimal promedioPermanencia = 0;

            var afuera = new List<Cliente>();
            var simulacion = 0;
            var numCamion = 0;
            var clientes = new List<Cliente>();

            _cancelar = false;

            for (var dia = 1; dia <= dias; dia++)
            {
                if (_cancelar) break;
                
                var atendidos = 0;
                var noAtendidos = 0;
                decimal permanenciaDiaria = 0;
                llegadas.Abrir();

                while (llegadas.EstaAbierto()
                       || !recepcion.EstaLibre()
                       || !balanza.EstaLibre()
                       || !darsena1.EstaLibre()
                       || !darsena2.EstaLibre())
                {
                    if (_cancelar) break;

                    simulacion++;

                    if (llegadas.EstaAbierto() && afuera.Count > 0)
                    {
                        foreach (var cliente in afuera)
                        {
                            if (_cancelar) break;

                            recepcion.LlegadaCliente(horaInicio, cliente);
                        }

                        afuera = new List<Cliente>();
                    }

                    var eventos = new List<Evento>
                    {
                        new Evento("Llegada", llegadas.ProximaLlegada),
                        new Evento("Cierre", llegadas.Cierre),
                        new Evento("Fin Recepción", recepcion.ProximoFinAtencion),
                        new Evento("Fin Balanza", balanza.ProximoFinAtencion),
                        new Evento("Fin Dársena 1", darsena1.ProximoFinAtencion),
                        new Evento("Fin Dársena 2", darsena2.ProximoFinAtencion)
                    };

                    // ReSharper disable once PossibleInvalidOperationException
                    var relojActual = eventos.Where(ev => ev.Hora.HasValue).Min(ev => ev.Hora).Value;
                    var eventoActual = eventos.First(ev => ev.Hora.Equals(relojActual)).Nombre;

                    switch (eventoActual)
                    {
                        case "Llegada":
                            numCamion++;
                            var clienteLlegando = new Cliente($"Camión {numCamion}");
                            clienteLlegando.Llegar(relojActual);
                            recepcion.LlegadaCliente(relojActual, clienteLlegando);
                            llegadas.ActualizarLlegada();
                            if (simulacion <= hasta)
                            {
                                clientes.Add(clienteLlegando);

                                Invoke(columnasInstance, numCamion);
                            }
                            break;

                        case "Fin Recepción":
                            var clienteReceptado = recepcion.FinAtencion();
                            balanza.LlegadaCliente(relojActual, clienteReceptado);
                            break;

                        case "Fin Balanza":
                            var clientePesado = balanza.FinAtencion();
                            if (darsena1.EstaLibre())
                                darsena1.LlegadaCliente(relojActual, clientePesado);
                            else
                                darsena2.LlegadaCliente(relojActual, clientePesado);
                            break;

                        case "Fin Dársena 1":
                            var clienteSaliendo1 = darsena1.FinAtencion();
                            if (clienteSaliendo1 != null)
                            {
                                clienteSaliendo1.Salir(relojActual);
                                permanenciaDiaria = (permanenciaDiaria * atendidos + clienteSaliendo1.TiempoEnSistema) / (atendidos + 1);
                                atendidos++;
                            }
                            break;

                        case "Fin Dársena 2":
                            var clienteSaliendo2 = darsena2.FinAtencion();
                            if (clienteSaliendo2 != null)
                            {
                                clienteSaliendo2.Salir(relojActual);
                                permanenciaDiaria = (permanenciaDiaria * atendidos + clienteSaliendo2.TiempoEnSistema) / (atendidos + 1);
                                atendidos++;
                            }
                            break;

                        case "Cierre":
                            llegadas.Cerrar();

                            noAtendidos = colaRecepcion.Cantidad();
                            afuera.AddRange(colaRecepcion.Clientes);
                            colaRecepcion.Vaciar();

                            promedioNoAtendidos = (promedioNoAtendidos * (dia - 1) + noAtendidos) / dia;
                            break;
                    }

                    if (simulacion % 10 == 0)
                        Invoke(statusInstance, dia, relojActual, simulacion);

                    if (simulacion >= desde && simulacion <= hasta)
                    {
                        Invoke(filaInstance, relojActual, eventoActual, llegadas, colaRecepcion, recepcion, colaBalanza,
                            balanza, colaDarsenas, darsena1, darsena2, atendidos, noAtendidos, permanenciaDiaria, clientes);
                    }
                }

                var permanenciaAnterior = promedioPermanencia * promedioAtendidos * (dia - 1);

                promedioAtendidos = (promedioAtendidos * (dia - 1) + atendidos) / dia;
                promedioNoAtendidos = (promedioNoAtendidos * (dia - 1) + noAtendidos) / dia;
                promedioPermanencia = (permanenciaAnterior + permanenciaDiaria * atendidos) / (promedioAtendidos * dia);
            }

            Invoke(resultadosInstance, promedioAtendidos, promedioNoAtendidos, promedioPermanencia);

            Invoke(inicioFinInstance, true);

            var resultado = _cancelar ? "interrumpida" : "completa";

            MessageBox.Show($@"Simulación {resultado}", @"Resultado");
        }

        public void InicioFin(bool fin)
        {
            rb_estrategia_a.Enabled = fin;
            rb_estrategia_b.Enabled = fin;
            btn_simular.Enabled = fin;

            btn_detener.Enabled = !fin;

            if (fin)
            {
                HabilitarComparacion();
            }
            else
            {
                dg_simulaciones.Rows.Clear();
                var cols = dg_simulaciones.Columns.Count;
                for (var c = cols - 1; c >= 19; c--)
                {
                    dg_simulaciones.Columns.RemoveAt(c);
                }
            }
                
        }

        private void AgregarColumnas(int numCamion)
        {
            var columns = new DataGridViewColumn[3];

            DataGridViewColumn columnLlegada = new DataGridViewTextBoxColumn();
            columnLlegada.CellTemplate = new DataGridViewTextBoxCell();
            columnLlegada.Name = $"llegada_camion_{numCamion}";
            columnLlegada.HeaderText = $@"Llegada Camión {numCamion}";
            columnLlegada.Width = 80;
            columnLlegada.FillWeight = 1;
            columns[0] = (columnLlegada);

            DataGridViewColumn columnEstado = new DataGridViewTextBoxColumn();
            columnEstado.CellTemplate = new DataGridViewTextBoxCell();
            columnEstado.Name = $"estado_camion_{numCamion}";
            columnEstado.HeaderText = $@"Estado Camión {numCamion}";
            columnEstado.Width = 120;
            columnEstado.FillWeight = 1;
            columns[1] = (columnEstado);

            DataGridViewColumn columnPermanencia = new DataGridViewTextBoxColumn();
            columnPermanencia.CellTemplate = new DataGridViewTextBoxCell();
            columnPermanencia.Name = $"permanencia_camion_{numCamion}";
            columnPermanencia.HeaderText = $@"Permanencia Camión {numCamion}";
            columnPermanencia.Width = 80;
            columnPermanencia.FillWeight = 1;
            columns[2] = (columnPermanencia);

            dg_simulaciones.Columns.AddRange(columns);
        }

        private void AgregarFila(DateTime relojActual, string eventoActual, Llegada llegadas, ICola colaRecepcion,
            Servidor recepcion, ICola colaBalanza, Servidor balanza, ICola colaDarsenas, Servidor darsena1,
            Servidor darsena2, int atendidos, int noAtendidos, decimal permanenciaDiaria, IEnumerable<Cliente> clientes)
        {
            var row = dg_simulaciones.Rows.Add(
                            relojActual.ToString("HH:mm:ss"),
                            eventoActual,
                            llegadas.ProximaLlegada?.ToString("HH:mm:ss"),
                            colaRecepcion.Cantidad(),
                            recepcion.Estado,
                            recepcion.ProximoFinAtencion?.ToString("HH:mm:ss"),
                            colaBalanza.Cantidad(),
                            balanza.Estado,
                            balanza.ProximoFinAtencion?.ToString("HH:mm:ss"),
                            colaDarsenas.Cantidad(),
                            darsena1.Estado,
                            darsena1.ProximoFinAtencion?.ToString("HH:mm:ss"),
                            darsena1.CantidadAtendidos,
                            darsena2.Estado,
                            darsena2.ProximoFinAtencion?.ToString("HH:mm:ss"),
                            darsena2.CantidadAtendidos,
                            atendidos,
                            noAtendidos,
                            DateTimeConverter.DesdeMinutos(permanenciaDiaria)
                        );

            foreach (var cliente in clientes)
            {
                var num = cliente.Nombre.Split(' ')[1];

                dg_simulaciones.Rows[row].Cells[$"llegada_camion_{num}"].Value = cliente.HoraLlegada.ToString("HH:mm:ss");
                dg_simulaciones.Rows[row].Cells[$"estado_camion_{num}"].Value = cliente.Estado;
                dg_simulaciones.Rows[row].Cells[$"permanencia_camion_{num}"].Value = DateTimeConverter.DesdeMinutos(cliente.TiempoEnSistema);
            }
        }

        private void ActualizarStatus(int dia, DateTime relojActual, int simulacion)
        {
            txt_dia.Text = dia.ToString();
            txt_hora.Text = relojActual.ToString("HH:mm:ss");
            txt_evento.Text = simulacion.ToString();
        }

        private void MostrarResultados(decimal promedioAtendidos, decimal promedioNoAtendidos, decimal promedioPermanencia)
        {
            if (rb_estrategia_a.Checked)
            {
                txt_atendidos_a.Text = Math.Round(promedioAtendidos, Decimales).ToString();
                txt_no_atendidos_a.Text = Math.Round(promedioNoAtendidos, Decimales).ToString();
                txt_permanencia_a.Text = DateTimeConverter.DesdeMinutos(promedioPermanencia);
            }
            else
            {
                txt_atendidos_b.Text = Math.Round(promedioAtendidos, Decimales).ToString();
                txt_no_atendidos_b.Text = Math.Round(promedioNoAtendidos, Decimales).ToString();
                txt_permanencia_b.Text = DateTimeConverter.DesdeMinutos(promedioPermanencia);
            }
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
                masMenos = atendidosB > atendidosA ? "más" : "menos";

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
                masMenos = noAtendidosB > noAtendidosA ? "más" : "menos";

                sb.Append($"Con la estrategia B quedaron afuera un {porcentaje}% {masMenos} de camiones.");
            }
            else
            {
                sb.Append("Con ambas estrategias quedaron afuera la misma cantidad de camiones.");
            }
            sb.AppendLine();

            var permanenciaA = (double) DateTimeConverter.EnMinutos(txt_permanencia_a.Text);
            var permanenciaB = (double) DateTimeConverter.EnMinutos(txt_permanencia_b.Text);

            if (!permanenciaA.Equals(permanenciaB))
            {
                porcentaje = Math.Round(Math.Abs((permanenciaB - permanenciaA) / permanenciaA * 100), Decimales);
                masMenos = permanenciaB > permanenciaA ? "más" : "menos";

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

        private void btn_detener_Click(object sender, EventArgs e)
        {
            _cancelar = true;
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

        private static bool ValidarExponencial(Control txtLambda)
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

        private static bool ValidarUniforme(Control txtA, Control txtB)
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

        private static bool ValidarNormal(Control txtMedia, Control txtVarianza)
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

        private static bool ValidarCantidades(Control txtDesde, Control txtHasta, Control txtDias)
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

        private static void MensajeError(string mensaje, Control textBox)
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

        public void DoubleBuffer()
        {
            // ReSharper disable once PossibleNullReferenceException
            dg_simulaciones.GetType()
                .GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic)
                .SetValue(dg_simulaciones, true);
        }

        private void Tp4_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_simularThread == null
                || _simularThread.ThreadState.Equals(ThreadState.Unstarted)
                || _simularThread.ThreadState.Equals(ThreadState.Stopped))
                return;

            _cancelar = true;
            e.Cancel = true;
        }
    }
}
