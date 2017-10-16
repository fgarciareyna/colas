using System;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Windows.Forms;

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

        private void btn_simular_Click(object sender, EventArgs e)
        {
            if (FormularioValido())
            {
                HabilitarComparacion();
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
                porcentaje = Math.Round(Math.Abs(atendidosB / atendidosA * 100), Decimales);
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
                porcentaje = Math.Round(Math.Abs(noAtendidosB / noAtendidosA * 100), Decimales);
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
                porcentaje = Math.Round(Math.Abs(permanenciaB / permanenciaA * 100), Decimales);
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

            return ValidarDias(txt_desde, txt_hasta, txt_cantidad);
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

        private bool ValidarDias(Control txtDesde, Control txtHasta, Control txtTotal)
        {
            var mensaje = "El total de simulaciones debe ser un entero positivo";

            if (string.IsNullOrEmpty(txtTotal.Text))
            {
                MensajeError(mensaje, txtTotal);
                return false;
            }

            int total;

            if (!int.TryParse(txtTotal.Text, out total) || total <= 0)
            {
                MensajeError(mensaje, txtTotal);
                return false;
            }

            mensaje = "El día inicial debe ser un entero positivo";

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

            mensaje = "El día inicial no puede ser superior al total de simulaciones";

            if (desde > total)
            {
                MensajeError(mensaje, txtDesde);
                return false;
            }

            mensaje = "El día final debe ser un entero positivo";

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

            mensaje = "El día final no puede ser superior al total de simulaciones";

            if (hasta > total)
            {
                MensajeError(mensaje, txtHasta);
                return false;
            }

            mensaje = "El día final no puede ser inferior al inicial";

            if (hasta > desde)
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
