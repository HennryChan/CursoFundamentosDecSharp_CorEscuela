using System;
using System.Collections.Generic;
using FundamentosCSharp_CorEscuela.Entidades;
using FundamentosCSharp_CorEscuela.App;
using FundamentosCSharp_CorEscuela.Util;
using static System.Console;

namespace FundamentosCSharp_CorEscuela
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var engine = new EscuelaEngine();
            engine.Inicializar();
            Printer.WriteTitle("Bienvenidos a la Escuela");
            //  Printer.Beep(10000, cantidad:1);
            ImprimirCursosEscuela(engine.Escuela);

            WriteLine("");
            Printer.DrawLine(40);
            WriteLine("Prueba Polomorfismo");
            Printer.DrawLine(40);
            var alumnoTest = new Alumno { Nombre = "clari Underwood" };
            ObjestoEscuelaBase ob = alumnoTest;
            Printer.WriteTitle("Alumno");
            WriteLine($"Alumno: {alumnoTest.Nombre}");
            WriteLine($"Alumno: {alumnoTest.UniqueId}");

            Printer.WriteTitle("Objetos Escuelas");
            WriteLine($"Alumno: {ob.Nombre}");
            WriteLine($"Alumno: {ob.UniqueId}");

            var objDummy = new ObjestoEscuelaBase() { Nombre = "Frank Underwood" };
            Printer.WriteTitle("ObjetosEscualas");
            WriteLine($"Alumno: {objDummy.Nombre}");
            WriteLine($"Alumno: {objDummy.UniqueId}");
        }

        private static void ImprimirCursosEscuela(Escuela escuela)
        {
            Printer.WriteTitle("Curso de la Escuela");
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
