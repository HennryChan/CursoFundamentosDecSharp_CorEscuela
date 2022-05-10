using System;
using System.Collections.Generic;
using FundamentosCSharp_CorEscuela.Entidades;
using FundamentosCSharp_CorEscuela.App;
using FundamentosCSharp_CorEscuela.Util;
using System.Linq;
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

            var listaObjetos = engine.GetObjetosEscuela();

            //engine.Escuela.LimpiarLugar();

            var listaILugar = from obj in listaObjetos  
                              where obj is Alumno
                              select (Alumno)obj;
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
