using System;
using System.Diagnostics.CodeAnalysis;
using Colas.Clientes;
using Colas.Colas;
using NumerosAleatorios.VariablesAleatorias;

namespace Colas.Servidores
{
    public class Servidor
    {
        public Servidor(IDistribucion atencion, ICola cola, string nombre)
        {
            DistribucionAtencion = atencion;
            Cola = cola;
            Nombre = nombre;
            Estado = "Libre";
            CantidadAtendidos = 0;
        }
        public Servidor(IDistribucion atencion, ICola cola, string nombre, IDistribucion bloqueo)
        {
            DistribucionAtencion = atencion;
            Cola = cola;
            Nombre = nombre;
            Estado = "Libre";
            DistribucionBloqueo = bloqueo;
            CantidadAtendidos = 0;
        }

        public bool EstaLibre()
        {
            return Estado.Equals("Libre");
        }

        public bool EstaBloqueado()
        {
            return Estado.Equals("Bloqueado");
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
            }
        }

        [SuppressMessage("ReSharper", "PossibleInvalidOperationException")]
        public Cliente FinAtencion()
        {
            var cliente = ClienteActual;

            if (cliente != null)
            {
                cliente.FinalizarAtencion(ProximoFinAtencion.Value);
                CantidadAtendidos++;
            }

            if (DistribucionBloqueo != null && CantidadAtendidos % 15 == 0 && !EstaBloqueado())
            {
                Estado = "Bloqueado";
                ClienteActual = null;
                ActualizarFinBloqueo(ProximoFinAtencion.Value);
            }
            else
            {
                if (Cola.Vacia())
                {
                    Estado = "Libre";
                    ClienteActual = null;
                    ProximoFinAtencion = null;
                }
                else
                {
                    ClienteActual = Cola.ProximoCliente();
                    ActualizarFinAtencion(ProximoFinAtencion.Value);
                }
            }
            
            return cliente;
        }

        public void ActualizarFinBloqueo(DateTime hora)
        {
            var demora = DistribucionBloqueo.Generar();

            ProximoFinAtencion = hora.AddMinutes(demora);
        }

        public IDistribucion DistribucionAtencion { get; protected set; }
        public IDistribucion DistribucionBloqueo { get; protected set; }
        public string Nombre { get; protected set; }
        public DateTime? ProximoFinAtencion { get; protected set; }
        public string Estado { get; protected set; }
        public ICola Cola { get; protected set; }
        public Cliente ClienteActual { get; protected set; }
        public int CantidadAtendidos { get; protected set; }
    }
}
