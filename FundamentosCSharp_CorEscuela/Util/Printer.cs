using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace FundamentosCSharp_CorEscuela.Util
{
    public static class Printer
    {
        public static void DibujarLinea(int tam = 10)
        {
            WriteLine("".PadLeft(tam, '-'));
        }

        public static void WriteTitle(string titulo)
        {
            var tamanio = titulo.Length + 4;
            DibujarLinea(tamanio);
            WriteLine($"| {titulo} |");
            DibujarLinea(tamanio);
        }

        public static void Beep(int hz=1000, int tiempo=500, int cantidad = 1)
        {
            while(cantidad-- > 0)
            {
                Console.Beep(hz, tiempo);
            }
        }
    }
}
