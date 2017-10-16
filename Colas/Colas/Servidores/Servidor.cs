using System;
using Colas.Clientes;
using Colas.Colas;
using NumerosAleatorios.VariablesAleatorias;

namespace Colas.Servidores
{
    public class Servidor
    {
        public Servidor(IDistribucion distribucion, ICola cola)
        {
            DistribucionAtencion = distribucion;
            Cola = cola;
            Estado = "Libre";
        }

        public bool EstaLibre()
        {
            return Estado.Equals("Libre");
        }

        private void ActualizarFinAtencion(DateTime hora)
        {
            var demora = DistribucionAtencion.Generar();

            ProximoFinAtencion = hora.AddMinutes(demora);
        }

        public void LlegadaCliente(DateTime hora, Cliente cliente)
        {
            if (EstaLibre())
            {
                ClienteActual = cliente;
                Estado = $"Atendiendo a {cliente.Nombre}";
                cliente.ComenzarAtencion(hora, Nombre);
                ActualizarFinAtencion(hora);
            }
            else
            {
                Cola.AgregarCliente(cliente);
                cliente.AgregarACola(Nombre);
            }
        }

        public Cliente FinAtencion()
        {
            var cliente = ClienteActual;

            cliente?.FinalizarAtencion(ProximoFinAtencion);

            if (Cola.Vacia())
            {
                Estado = "Libre";
                ClienteActual = null;
            }
            else
            {
                ClienteActual = Cola.ProximoCliente();
                ActualizarFinAtencion(ProximoFinAtencion);
            }
            
            return cliente;
        }

        public void Bloqueo()
        {
            Estado = "Bloqueado";
            ActualizarFinAtencion(ProximoFinAtencion);
        }

        public IDistribucion DistribucionAtencion { get; protected set; }
        public string Nombre { get; protected set; }
        public DateTime ProximoFinAtencion { get; protected set; }
        public string Estado { get; protected set; }
        public ICola Cola { get; protected set; }
        public Cliente ClienteActual { get; protected set; }
    }
}
