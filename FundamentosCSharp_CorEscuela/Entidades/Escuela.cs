using System;
using System.Collections.Generic;
using System.Text;

namespace FundamentosCSharp_CorEscuela.Entidades
{
    public class Escuela
    {
        string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value.ToUpper(); }
        }

        public int AnioDeCreacion { get; set; }

        public string Paris { get; set; }

        public string Cuidad { get; set; }

        private int myVar;

        //public Escuela(string nombre, int anio)
        //{
        //    this.nombre = nombre;
        //    AnioDeCreacion = anio;
        //}

        public Escuela(string nombre, int anio) => (Nombre, AnioDeCreacion) = (nombre, anio);
    }
}
