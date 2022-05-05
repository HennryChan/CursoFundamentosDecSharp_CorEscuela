using System;
using FundamentosCSharp_CorEscuela.Entidades;

namespace FundamentosCSharp_CorEscuela
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var escuela = new Escuela("Platzi Acedemy", 2021);
            escuela.Paris = "Colombia";
            escuela.Cuidad = "Bogota";
            Console.WriteLine(escuela.Nombre);
         }
    }
}
