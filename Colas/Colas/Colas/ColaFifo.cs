using System.Collections.Generic;
using System.Linq;
using Colas.Clientes;

namespace Colas.Colas
{
    public class ColaFifo : ICola
    {
        private readonly List<Cliente> _clientes = new List<Cliente>();

        public bool Vacia()
        {
            return _clientes.Count == 0;
        }

        public void AgregarCliente(Cliente cliente)
        {
            _clientes.Add(cliente);
        }

        public Cliente ProximoCliente()
        {
            if (Vacia())
                return null;

            var cliente = _clientes.First();
            _clientes.Remove(cliente);
            return cliente;
        }
    }
}
