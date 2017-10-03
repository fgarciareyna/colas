using System;
using NumerosAleatorios.VariablesAleatorias;

namespace Colas
{
    public class Servidor
    {
        public Servidor(IDistribucion distribucion)
        {
            DistribucionAtencion = distribucion;
            Estado = EstadoServidor.Libre;
            Cola = 0;
        }

        public Servidor(IDistribucion distribucion, EstadoServidor estado, int cola)
        {
            DistribucionAtencion = distribucion;
            Estado = estado;
            Cola = cola;
        }

        private void ActualizarFinAtencion(DateTime hora)
        {
            var demora = DistribucionAtencion.Generar();

            ProximoFinAtencion = hora.AddMinutes(demora);
        }

        public void LlegadaCliente(DateTime hora)
        {
            switch (Estado)
            {
                case EstadoServidor.Libre:
                    Estado = EstadoServidor.Ocupado;
                    ActualizarFinAtencion(hora);
                    break;
                case EstadoServidor.Ocupado:
                    Cola += 1;
                    break;
                default:
                    throw new NotSupportedException("Estado inválido");
            }
        }

        public void FinAtencion()
        {
            if (Cola == 0)
            {
                Estado = EstadoServidor.Libre;
            }

            else
            {
                Cola -= 1;
                ActualizarFinAtencion(ProximoFinAtencion);
            }
        }

        public IDistribucion DistribucionAtencion { get; protected set; }
        public DateTime ProximoFinAtencion { get; protected set; }
        public EstadoServidor Estado { get; protected set; }
        public int Cola { get; protected set; }
    }
}
