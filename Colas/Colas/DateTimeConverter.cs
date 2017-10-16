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
    }
}
