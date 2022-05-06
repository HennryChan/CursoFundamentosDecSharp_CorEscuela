using System;
using System.Collections.Generic;
using FundamentosCSharp_CorEscuela.Entidades;
using static System.Console;

namespace FundamentosCSharp_CorEscuela
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var escuela = new Escuela("Platzi Acedemy", 2021, TiposEscuela.Primaria, cuidad: "Bogota", pais: "colombia");

            escuela.Cursos = new List<Curso>()
            {
                new Curso(){Nombre = "101", Jornada = TiposJornada.Tarde },
                new Curso(){Nombre = "201", Jornada = TiposJornada.Tarde },
                new Curso(){Nombre = "301", Jornada = TiposJornada.Tarde }
            };

            escuela.Cursos.Add(new Curso() { Nombre = "102", Jornada = TiposJornada.Maniana });
            escuela.Cursos.Add(new Curso() { Nombre = "202", Jornada = TiposJornada.Maniana });

            var otrColeccion = new List<Curso>()
            {
                new Curso(){Nombre = "401", Jornada = TiposJornada.Tarde },
                new Curso(){Nombre = "501", Jornada = TiposJornada.Tarde },
                new Curso(){Nombre = "501", Jornada = TiposJornada.Tarde }
            };

            escuela.Cursos.AddRange(otrColeccion);
            //escuela.Cursos.Add(temp);

            ImprimirCursosEscuela(escuela);

            Predicate<Curso> miAlgoritmo = Predicado;
            escuela.Cursos.RemoveAll(miAlgoritmo);
            WriteLine("--------------------------------");

            ImprimirCursosEscuela(escuela);

        }

        private static bool Predicado(Curso curobj)
        {
            return curobj.Nombre == "301";
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
