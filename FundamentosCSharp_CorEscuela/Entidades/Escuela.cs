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
        public string Pais { get; set; }
        public string Cuidad { get; set; }
        public TiposEscuela TipoEscuela { get; set; }
        public Curso[] Cursos { get; set; }

        //public Escuela(string nombre, int anio)
        //{
        //    this.nombre = nombre;
        //    AnioDeCreacion = anio;
        //}

        public Escuela(string nombre, int anio) => (Nombre, AnioDeCreacion) = (nombre, anio);

        public Escuela(string nombre, int anio, TiposEscuela tipo, string pais = "", string cuidad = "")
        {
            (Nombre, AnioDeCreacion) = (nombre, anio);
            Pais = pais;
            Cuidad = cuidad;
        }

        public override string ToString()
        {
            return $"Nombre: \"{Nombre}\", Tipo: {TipoEscuela}, {System.Environment.NewLine}Pais: {Pais}, Cuidad: {Cuidad}";
        }
    }
}
