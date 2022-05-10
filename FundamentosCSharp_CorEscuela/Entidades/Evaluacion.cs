using System;
using System.Collections.Generic;
using System.Text;

namespace FundamentosCSharp_CorEscuela.Entidades
{
    public class Evaluacion:ObjestoEscuelaBase
    {
        public Alumno Alumno { get; set; }
        public Asignatura Asignatura { get; set; }
        public float Nota { get; set; }
    }
}
