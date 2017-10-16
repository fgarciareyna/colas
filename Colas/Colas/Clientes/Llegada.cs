using System;
using NumerosAleatorios.VariablesAleatorias;

namespace Colas.Clientes
{
    public class Llegada
    {
        public Llegada(IDistribucion distribucion, DateTime proximaLlegada)
        {
            DistribucionLlegadas = distribucion;
            ProximaLLegada = proximaLlegada;
        }

        public void ActualizarLlegada()
        {
            if (!ProximaLLegada.HasValue)
                return;

            var demora = DistribucionLlegadas.Generar();

            ProximaLLegada = ProximaLLegada.Value.AddMinutes(demora);
        }

        public void Cerrar()
        {
            ProximaLLegada = null;
        }

        public bool Abierto()
        {
            return ProximaLLegada.HasValue;
        }

        public IDistribucion DistribucionLlegadas { get; protected set; }
        public DateTime? ProximaLLegada { get; protected set; }
    }
}
