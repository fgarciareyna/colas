using System;

namespace NumerosAleatorios.NumerosAleatorios
{
     public class GeneradorDelSistema : IGeneradorNumerosAleatorios
    {
        private readonly Random _random = new Random();

        public double Generar()
        {
            var aleatorio = _random.NextDouble();

            return aleatorio;
        }

        public int Generar(int cifras)
        {
            var aleatorio = Generar();

            return (int)(aleatorio * Math.Pow(10, cifras));
        }
    }
}
