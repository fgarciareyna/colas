﻿using System;

namespace Colas.Clientes
{
    public class Cliente
    {
        private readonly DateTime _horaLlegada;

        public Cliente(DateTime horaLlegada)
        {
            _horaLlegada = horaLlegada;
            TiempoAtencion = 0;
            TiempoEnSistema = 0;
        }
        
        public void ComenzarAtencion(DateTime horaInicioAtencion)
        {
            HoraInicioAtencion = horaInicioAtencion;
        }

        public void FinalizarAtencion(DateTime horaFinAtencion)
        {
            TiempoAtencion += (horaFinAtencion.Hour * 3600 + horaFinAtencion.Minute * 60 + horaFinAtencion.Second) -
                             (HoraInicioAtencion.Hour * 3600 + HoraInicioAtencion.Minute * 60 + HoraInicioAtencion.Second);
        }

        public void Salir(DateTime horaSalida)
        {
            TiempoEnSistema = (horaSalida.Hour * 3600 + horaSalida.Minute * 60 + horaSalida.Second) -
                             (_horaLlegada.Hour * 3600 + _horaLlegada.Minute * 60 + _horaLlegada.Second);
        }

        public decimal TiempoEspera()
        {
            return TiempoEnSistema - TiempoAtencion;
        }
        
        public DateTime HoraInicioAtencion { get; protected set; }
        public decimal TiempoAtencion { get; protected set; }
        public decimal TiempoEnSistema { get; protected set; }
    }
}
