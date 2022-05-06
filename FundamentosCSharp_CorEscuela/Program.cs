using System;
using FundamentosCSharp_CorEscuela.Entidades;
using static System.Console;

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

            //var arregloCursos = new Curso[3]
            //{
            //    new Curso(){Nombre = "101"},
            //    new Curso(){Nombre = "201"},
            //    new Curso(){Nombre = "301"}
            //};

            escuela.Cursos = new Curso[]
            {
                new Curso(){Nombre = "101"},
                new Curso(){Nombre = "201"},
                new Curso(){Nombre = "301"}
            };

            ImprimirCursosEscuela(escuela);
        }   

        private static void ImprimirCursosEscuela(Escuela escuela)
        {
            WriteLine("-------------------------------");
            WriteLine("Cursos de la escuela");
            WriteLine("--------------------------------");
            if (escuela.Cursos != null)
            {
                foreach (var curso in escuela.Cursos)
                {
                    WriteLine($"Nombre {curso.Nombre}, Id {curso.UniqueId}");
                }
            }
        }

        private static void ImprimirCursosWhile(Curso[] arregloCursos)
        {
            int contador = 0;
            while (contador < arregloCursos.Length)
            {
                Console.WriteLine($"Nombre{arregloCursos[contador].Nombre}, Id {arregloCursos[contador].UniqueId}");
                contador++;
            }
        }

        private static void ImprimirCursosForeach(Curso[] arregloCursos)
        {
            foreach (var curso in arregloCursos)
            {
                Console.WriteLine($"Nombre{curso.Nombre}, Id {curso.UniqueId}");
            }
        }
    }
}
