using System;
using Colas.Clientes;
using Colas.Colas;
using NumerosAleatorios.VariablesAleatorias;

namespace Colas.Servidores
{
    public class Servidor
    {
        private DateTime _horaInicio;

        public Servidor(IDistribucion distribucion, DateTime horaInicio)
        {
            DistribucionAtencion = distribucion;
            Estado = EstadoServidor.Libre;
            Cola = new ColaFifo();
            _horaInicio = horaInicio;
            TiempoAtencion = 0;
        }

        public Servidor(IDistribucion distribucion, ICola cola, DateTime horaInicio)
        {
            DistribucionAtencion = distribucion;
            Estado = EstadoServidor.Libre;
            Cola = cola;
            _horaInicio = horaInicio;
            TiempoAtencion = 0;
        }

        public Servidor(IDistribucion distribucion, EstadoServidor estado, ICola cola, DateTime horaInicio)
        {
            DistribucionAtencion = distribucion;
            Estado = estado;
            Cola = cola;
            _horaInicio = horaInicio;
            TiempoAtencion = 0;
        }

        private void ActualizarFinAtencion(DateTime hora)
        {
            var demora = DistribucionAtencion.Generar();

            ProximoFinAtencion = hora.AddMinutes(demora);
        }

        public void LlegadaCliente(DateTime hora, Cliente cliente)
        {
            switch (Estado)
            {
                case EstadoServidor.Libre:
                    Estado = EstadoServidor.Ocupado;
                    cliente.ComenzarAtencion(hora);
                    ClienteActual = cliente;
                    ActualizarFinAtencion(hora);
                    break;
                case EstadoServidor.Ocupado:
                    Cola.AgregarCliente(cliente);
                    break;
                default:
                    throw new NotSupportedException("Estado inválido");
            }
        }

        public Cliente FinAtencion()
        {
            var cliente = ClienteActual;
            var inicioAtencion = cliente.HoraInicioAtencion;

            TiempoAtencion = (ProximoFinAtencion.Hour * 3600 + ProximoFinAtencion.Minute * 60 + ProximoFinAtencion.Second) -
                             (inicioAtencion.Hour * 3600 + inicioAtencion.Minute * 60 + inicioAtencion.Second);

            if (Cola.Vacia())
            {
                Estado = EstadoServidor.Libre;
                ClienteActual = null;
            }

            else
            {
                ClienteActual = Cola.ProximoCliente();
                ActualizarFinAtencion(ProximoFinAtencion);
            }
            return cliente;
        }

        public void Cerrar(DateTime horaCierre)
        {
            TiempoOcioso = (horaCierre.Hour * 3600 + horaCierre.Minute * 60 + horaCierre.Second) -
                             (_horaInicio.Hour * 3600 + _horaInicio.Minute * 60 + _horaInicio.Second);
        }

        public IDistribucion DistribucionAtencion { get; protected set; }
        public DateTime ProximoFinAtencion { get; protected set; }
        public EstadoServidor Estado { get; protected set; }
        public ICola Cola { get; protected set; }
        public Cliente ClienteActual { get; protected set; }
        public int TiempoAtencion { get; protected set; }
        public int TiempoOcioso { get; protected set; }
    }
}
