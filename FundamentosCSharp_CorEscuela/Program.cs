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

            var curso1 = new Curso()
            {
                Nombre = "101"
            };

            var curso2 = new Curso()
            {
                Nombre = "201"
            };

            var curso3 = new Curso()
            {
                Nombre = "301"
            };

            Console.WriteLine(escuela);
            Console.WriteLine("===============================");
            Console.WriteLine(curso1.Nombre + curso1.UniqueId);
            Console.WriteLine($"{curso2.Nombre} , {curso2.UniqueId}");
            Console.WriteLine($"{ curso3.Nombre} , { curso3.UniqueId}");
            Console.WriteLine(curso3);
         }
    }
}
