using System;
using System.Collections.Generic;
using FundamentosCSharp_CorEscuela.Entidades;
using FundamentosCSharp_CorEscuela.App;
using static System.Console;

namespace FundamentosCSharp_CorEscuela
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var engine = new EscuelaEngine();
            engine.Inicializar();
            ImprimirCursosEscuela(engine.Escuela);
        }

        private static void ImprimirCursosEscuela(Escuela escuela)
        {
            WriteLine("----------------------------------------------------");
            WriteLine("              Cursos de la escuela                  ");
            WriteLine("----------------------------------------------------");
            if (escuela.Cursos != null)
            {
                foreach (var curso in escuela.Cursos)
                {
                    WriteLine($"Nombre {curso.Nombre}, Id {curso.UniqueId}");
                }
            }
        }
    }
}
