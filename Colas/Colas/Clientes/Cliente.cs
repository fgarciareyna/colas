using System;

namespace Colas.Clientes
{
    public class Cliente
    {
        public Cliente(string nombre)
        {
            Nombre = nombre;
            TiempoAtencion = 0;
        }

        public void Llegar(DateTime horaLlegada)
        {
            Estado = "Llegando";
            HoraLlegada = horaLlegada;
        }
        
        public void ComenzarAtencion(DateTime horaInicioAtencion, string servidor)
        {
            HoraInicioAtencion = horaInicioAtencion;
            Estado = $"En {servidor}";
        }

        public void FinalizarAtencion(DateTime horaFinAtencion)
        {
            var inicioAtencion = DateTimeConverter.EnMinutos(HoraInicioAtencion);
            var finAtencion = DateTimeConverter.EnMinutos(horaFinAtencion);

            TiempoAtencion += finAtencion - inicioAtencion;
        }

        public void AgregarACola(string nombre)
        {
            Estado = $"En cola de {nombre}";
        }

        public void Salir(DateTime horaSalida)
        {
            var ingreso = DateTimeConverter.EnMinutos(HoraLlegada);
            var salida = DateTimeConverter.EnMinutos(horaSalida);

            TiempoEnSistema = salida - ingreso;

            if (horaSalida.Date > HoraLlegada.Date)
            {
                var dias = horaSalida.Day - HoraLlegada.Day;
                TiempoEnSistema += dias * 24 * 60;
            }

            Estado = "Saliendo";
        }

        public decimal TiempoEspera()
        {
            return TiempoEnSistema - TiempoAtencion;
        }
        
        public string Nombre { get; protected set; }
        public DateTime HoraLlegada { get; protected set; }
        public DateTime HoraInicioAtencion { get; protected set; }
        public string Estado { get; protected set; }
        public decimal TiempoAtencion { get; protected set; }
        public decimal TiempoEnSistema { get; protected set; }
    }
}
