﻿using System;
using NumerosAleatorios.VariablesAleatorias;

namespace Colas.Clientes
{
    public class Llegada
    {
        public Llegada(IDistribucion distribucion)
        {
            DistribucionLlegadas = distribucion;
        }
        public Llegada(IDistribucion distribucion, DateTime proximaLlegada)
        {
            DistribucionLlegadas = distribucion;
            ProximaLLegada = proximaLlegada;
        }

        public void ActualizarLlegada(DateTime hora)
        {
            var demora = DistribucionLlegadas.Generar();

            ProximaLLegada = hora.AddMinutes(demora);
        }

        public IDistribucion DistribucionLlegadas { get; protected set; }
        public DateTime ProximaLLegada { get; protected set; }
    }
}