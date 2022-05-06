using System;
using FundamentosCSharp_CorEscuela.Entidades;

namespace FundamentosCSharp_CorEscuela
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var escuela = new Escuela("Platzi Acedemy", 2021, TiposEscuela.Primaria, cuidad: "Bogota", pais: "colombia");
            //escuela.Pais = "Colombia";
            //escuela.Cuidad = "Bogota";
            //escuela.TipoEscuela = TiposEscuela.Primaria;
            Console.WriteLine(escuela);
         }
    }
}
