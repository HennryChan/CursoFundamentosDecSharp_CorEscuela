using System;
using System.Collections.Generic;
using System.Text;
using FundamentosCSharp_CorEscuela.Entidades;

namespace FundamentosCSharp_CorEscuela.App
{
    public class EscuelaEngine
    {
        public Escuela Escuela { get; set; }

        public EscuelaEngine()
        {

        }

        public void Inicializar()
        {
            Escuela = new Escuela("Platzi Acedemy", 2021, TiposEscuela.Primaria, cuidad: "Bogota", pais: "colombia");

            Escuela.Cursos = new List<Curso>()
            {
                new Curso(){Nombre = "101", Jornada = TiposJornada.Tarde },
                new Curso(){Nombre = "201", Jornada = TiposJornada.Tarde },
                new Curso(){Nombre = "301", Jornada = TiposJornada.Tarde },
                new Curso(){Nombre = "401", Jornada = TiposJornada.Tarde },
                new Curso(){Nombre = "501", Jornada = TiposJornada.Tarde }
            };

        }
    }

}
