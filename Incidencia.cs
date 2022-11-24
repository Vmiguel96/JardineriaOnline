﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ProyectoFinal
{
   public class Incidencia
    {
        DateTime hora;
        string operacion;

        public DateTime Hora { get => hora; set => hora = value; }
        public string Operacion { get => operacion; set => operacion = value; }


        public Incidencia(DateTime hora, string operacion)
        {
            this.hora = hora;
            this.operacion = operacion;
        }

        public override bool Equals(object obj)
        {
            return obj is Incidencia incidencia &&
                   hora == incidencia.hora &&
                   operacion == incidencia.operacion;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(hora, operacion);
        }

        public override string ToString()
        {
            return $"{hora}: {operacion}";
        }


    }
}
