using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace FundamentosCSharp_CorEscuela.Util
{
    public static class Printer
    {
        public static void DrawLine(int tam = 10)
        {
            WriteLine("".PadLeft(tam, '-'));
        }

        public static void WriteTitle(string titulo)
        {
            var tamanio = titulo.Length + 4;
            DrawLine(tamanio);
            WriteLine($"| {titulo} |");
            DrawLine(tamanio);
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
