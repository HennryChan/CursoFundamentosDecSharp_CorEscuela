﻿using System;
using System.Collections.Generic;
using System.Text;
using FundamentosCSharp_CorEscuela.Entidades;
using System.Linq;

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

            CargarCursos();
           // CargarAlumnos();
            CargaraAsignatura();
            CargarEvaluaciones();

        }

        private void CargarEvaluaciones()
        {
            throw new NotImplementedException();
        }

        private void CargaraAsignatura()
        {
            foreach (var cursos in Escuela.Cursos)
            {
                 var listaAsignaturas = new  List<Asignatura>()
            {
                new Asignatura(){Nombre = "Matematicas" },
                new Asignatura(){Nombre = "Educacion Fisica" },
                new Asignatura(){Nombre = "Catellano" },
                new Asignatura(){Nombre = "Ciencias Natirales" }
            };
                cursos.Asignaturas = listaAsignaturas;
            }
        }

        private List<Alumno> GenerarAlumnosAlAzar( int cantidad)
        {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno { Nombre = $"{n1} {n2} {a1}" };

            return listaAlumnos.OrderBy((al) => al.UniqueId).Take(cantidad).ToList();
        }

        private void CargarCursos()
        {
            Escuela.Cursos = new List<Curso>()
            {
                new Curso(){Nombre = "101", Jornada = TiposJornada.Tarde },
                new Curso(){Nombre = "201", Jornada = TiposJornada.Tarde },
                new Curso(){Nombre = "301", Jornada = TiposJornada.Tarde },
                new Curso(){Nombre = "401", Jornada = TiposJornada.Tarde },
                new Curso(){Nombre = "501", Jornada = TiposJornada.Tarde }
            };

            Random rnd = new Random();
            foreach (var c in Escuela.Cursos)
            {
                int cantRandom = rnd.Next(5, 20);
                c.Alumnos = GenerarAlumnosAlAzar(cantRandom);
            }
        }
    }

}
