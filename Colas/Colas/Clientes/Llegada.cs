using System;
using NumerosAleatorios.VariablesAleatorias;

namespace Colas.Clientes
{
    public class Llegada
    {
        public Llegada(IDistribucion distribucion, DateTime proximaLlegada)
        {
            DistribucionLlegadas = distribucion;
            ProximaLlegada = proximaLlegada;
        }

        public void ActualizarLlegada()
        {
            if (!ProximaLlegada.HasValue)
                return;

            var demora = DistribucionLlegadas.Generar();

            ProximaLlegada = ProximaLlegada.Value.AddMinutes(demora);
        }

        public void Cerrar()
        {
            ProximaLlegada = null;
        }

        public bool Abierto()
        {
            return ProximaLlegada.HasValue;
        }

        public IDistribucion DistribucionLlegadas { get; protected set; }
        public DateTime? ProximaLlegada { get; protected set; }
    }
}
