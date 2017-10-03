using System;
using System.Collections.Generic;
using NumerosAleatorios.NumerosAleatorios;

namespace NumerosAleatorios.VariablesAleatorias
{
    public class DistribucionNormal : IDistribucion
    {
        public double Media { get; protected set; }
        public double Varianza { get; protected set; }
        public IGeneradorNumerosAleatorios Generador { get; protected set; }

        public DistribucionNormal(double media, double varianza)
        {
            if (varianza < 0)
                throw new NotSupportedException("La varianza no puede ser negativa");

            Media = media;
            Varianza = varianza;
            Generador = new GeneradorDelSistema();
        }
        public DistribucionNormal(double media, double varianza, IGeneradorNumerosAleatorios generador)
        {
            if (varianza < 0)
                throw new NotSupportedException("La varianza no puede ser negativa");

            Media = media;
            Varianza = varianza;
            Generador = generador;
        }

        public void AsignarGenerador(IGeneradorNumerosAleatorios generador)
        {
            Generador = generador;
        }

        public double Generar()
        {
            var aleatorio1 = Generador.Generar();
            var aleatorio2 = Generador.Generar();

            var z = Math.Sqrt(-2 * Math.Log(aleatorio1)) * Math.Cos(2 * Math.PI * aleatorio2);

            var variable = Media + z * Varianza;

            return variable;
        }

        public List<double> Generar(int cantidad)
        {
            var variables = new List<double>(cantidad);

            for (int i = 0; i < cantidad; i++)
            {
                variables.Add(Generar());
            }

            return variables;
        }
    }
}
