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

            var arregloCursos = new Curso[3];

            arregloCursos[0] = new Curso()
            {
                Nombre = "101"
            };

            var curso2 = new Curso()
            {
                Nombre = "201"
            };

            arregloCursos[1] = curso2;

            arregloCursos[2] = new Curso()
            {
                Nombre = "301"
            };

            Console.WriteLine(escuela);
            Console.WriteLine("===============================");
            ImprimirCursos(arregloCursos);

        }   

        private static void ImprimirCursos(Curso[] arregloCursos)
        {
            int contador = 0;
            while (contador <arregloCursos.Length)
            {
                Console.WriteLine($"Nombre{arregloCursos[contador].Nombre}, Id {arregloCursos[contador].UniqueId}");
                contador++;
            }

        }
         
    }
}
