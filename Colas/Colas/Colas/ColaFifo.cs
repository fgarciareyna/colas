using System.Collections.Generic;
using System.Linq;
using Colas.Clientes;

namespace Colas.Colas
{
    public class ColaFifo : ICola
    {
        private readonly List<Cliente> _clientes = new List<Cliente>();

        public ColaFifo(string nombre)
        {
            Nombre = nombre;
        }

        public bool Vacia()
        {
            return _clientes.Count == 0;
        }

        public void AgregarCliente(Cliente cliente)
        {
            _clientes.Add(cliente);
            cliente.AgregarACola(Nombre);
        }

        public Cliente ProximoCliente()
        {
            if (Vacia())
                return null;

            var cliente = _clientes.First();
            _clientes.Remove(cliente);
            return cliente;
        }

        public int Cantidad()
        {
            return _clientes.Count;
        }

        public void Vaciar()
        {
            _clientes.Clear();
        }

        public string Nombre { get; protected set; }
    }
}
