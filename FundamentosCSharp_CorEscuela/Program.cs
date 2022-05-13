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
            //AppDomain.CurrentDomain.ProcessExit += AccionDelEvento;
           // AppDomain.CurrentDomain.ProcessExit += (o, s) => Printer.Beep(2000, 1000, 1);

            var engine = new EscuelaEngine();
            engine.Inicializar();
            Printer.WriteTitle("Bienvenidos a la Escuela");
            //  Printer.Beep(10000, cantidad:1);
            ImprimirCursosEscuela(engine.Escuela);

            var reporteador = new Reporteador(engine.GetDiccionarioObjetos());
            var evaList = reporteador.GetListaEvaluaciones();
            var lisaAsig = reporteador.GetListaAsignaturas();
            var listaEvalXAsig = reporteador.GetDicEvaluaXAsig();
            var listaPromXSig = reporteador.GetDicEvaluaXAsig();
            //var listaTopPromedio = reporteador.GetPromedioPorAsignaturaTop();


        }

        private static void AccionDelEvento(object sender, EventArgs e)
        {
            Printer.WriteTitle("SALIENDO");
          //  Printer.Beep(3000, 1000, 3);
            Printer.WriteTitle("SALIÓ");
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
