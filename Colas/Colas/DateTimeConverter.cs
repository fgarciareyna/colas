using System;

namespace Colas
{
    public class DateTimeConverter
    {
        public static decimal EnSegundos(DateTime tiempo)
        {
            return tiempo.Hour * 3600 + tiempo.Minute * 60 + tiempo.Second;
        }

        public static decimal EnMinutos(DateTime tiempo)
        {
            return EnSegundos(tiempo) / 60;
        }

        public static decimal EnHoras(DateTime tiempo)
        {
            return EnSegundos(tiempo) / 3600;
        }

        public static string DesdeMinutos(decimal minutos)
        {
            var hh = (int) (minutos / 60);

            var mm = (int) (minutos % 60);

            var ss = (int) (minutos % 1 * 60);

            return $"{hh}:{mm.ToString().PadLeft(2,'0')}:{ss.ToString().PadLeft(2, '0')}";
        }
    }
}
