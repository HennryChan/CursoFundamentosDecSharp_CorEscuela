using System;
using System.Collections.Generic;
using System.Text;

namespace FundamentosCSharp_CorEscuela.Entidades
{
    public class Alumno:ObjestoEscuelaBase
    {
        public List<Evaluacion> Evaluaciones { get; set; } = new List<Evaluacion>();
    }
}
