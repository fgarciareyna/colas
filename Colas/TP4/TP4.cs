using System.Windows.Forms;

namespace TP4
{
    public partial class Tp4 : Form
    {
        public Tp4()
        {
            InitializeComponent();
        }

        private void rb_estrategia_a_CheckedChanged(object sender, System.EventArgs e)
        {
            btn_simular.Enabled = true;
        }

        private void rb_estrategia_b_CheckedChanged(object sender, System.EventArgs e)
        {
            btn_simular.Enabled = true;
        }

        private void btn_simular_Click(object sender, System.EventArgs e)
        {
            if (FormularioValido())
            {
                HabilitarComparacion();
            }
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

            return true;
        }

        private bool ValidarExponencial(Control txtLambda)
        {
            var mensaje = "Lambda debe ser un número positivo";

            if (string.IsNullOrEmpty(txtLambda.Text))
            {
                MensajeError(mensaje, txtLambda);
                return false;
            }
            else
            {
                double lambda;
                if (!double.TryParse(txtLambda.Text, out lambda) || lambda <= 0)
                {
                    MensajeError(mensaje, txtLambda);
                    return false;
                }
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
            else
            {
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
                else
                {
                    double b;
                    if (!double.TryParse(txtB.Text, out b))
                    {
                        MensajeError(mensaje, txtB);
                        return false;
                    }
                    else
                    {
                        mensaje = "B debe ser mayor que A";
                        if (b <= a)
                        {
                            MensajeError(mensaje, txtB);
                            return false;
                        }
                    }
                }
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
            else
            {
                double media;
                if (!double.TryParse(txtMedia.Text, out media))
                {
                    MensajeError(mensaje, txtMedia);
                    return false;
                }
            }

            mensaje = "Ingrese un número válido para la desviación estándar";

            if (string.IsNullOrEmpty(txtVarianza.Text))
            {
                MensajeError(mensaje, txtVarianza);
                return false;
            }
            else
            {
                double varianza;
                if (!double.TryParse(txtVarianza.Text, out varianza))
                {
                    MensajeError(mensaje, txtVarianza);
                    return false;
                }
                else
                {
                    mensaje = "La varianza no puede ser negativa";

                    if (varianza < 0)
                    {
                        MensajeError(mensaje, txtVarianza);
                        return false;
                    }
                }
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
