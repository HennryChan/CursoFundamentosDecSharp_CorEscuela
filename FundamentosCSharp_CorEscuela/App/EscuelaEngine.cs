using System;
using System.Collections.Generic;
using System.Text;
using FundamentosCSharp_CorEscuela.Entidades;
using System.Linq;
using FundamentosCSharp_CorEscuela.Util;

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
            CargaraAsignatura();
            GenerarEvaluacionesAlAzar();

        }

        public List<ObjetoEscuelaBase> GetObjetosEscuela(
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool traeAsignaturas = true,
            bool traeCursos = true)
        {
            return GetObjetosEscuela(out int dummy, out dummy, out dummy, out dummy);
        }

        public List<ObjetoEscuelaBase> GetObjetosEscuela(
                      out int conteoEvaluaciones, out int conteoCursos,
                      bool traeEvaluaciones = true,
                      bool traeAlumnos = true,
                      bool traeAsignaturas = true,
                      bool traeCursos = true
                      )
        {
            return GetObjetosEscuela(out conteoEvaluaciones, out conteoCursos, out int dummy, out dummy);
        }

        public List<ObjetoEscuelaBase> GetObjetosEscuela(
            out int conteoEvaluaciones,
            out int conteoCursos,
            out int conteoAsignaturas,
            out int conteoAlumnos,
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool traeAsignaturas = true,
            bool traeCursos = true
            )
        {
            conteoEvaluaciones= 0;
            conteoCursos = 0; 
            conteoAsignaturas = 0;
            conteoAlumnos = 0;

            var listaObj = new List<ObjetoEscuelaBase>();
            listaObj.Add(Escuela);

            if(traeCursos)
                listaObj.AddRange(Escuela.Cursos);

            conteoCursos = Escuela.Cursos.Count;
            foreach (var curso in Escuela.Cursos)
            {
                conteoAsignaturas += curso.Asignaturas.Count;
                conteoAlumnos += curso.Alumnos.Count;

                if(traeAsignaturas)
                    listaObj.AddRange(curso.Asignaturas);

                if (traeAlumnos)
                    listaObj.AddRange(curso.Alumnos);

                if (traeEvaluaciones)
                {
                    foreach (var alumno in curso.Alumnos)
                    {
                        listaObj.AddRange(alumno.Evaluaciones);
                        conteoEvaluaciones += alumno.Evaluaciones.Count;
                    }
                }
            }

            return (listaObj, conteoEvaluaciones);
        }

        private void GenerarEvaluacionesAlAzar()
        {
            foreach (var cursos in Escuela.Cursos)
            {
                foreach (var alumno in cursos.Alumnos)
                {
                    Random randm = new Random();

                    foreach (var asignatura in cursos.Asignaturas)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            var listarEvaluaciones = new Evaluacion()
                            {
                                Asignatura = asignatura,
                                Nombre = $"{asignatura.Nombre} Ev#{i + 1}",
                                Nota = (float)(5 * randm.NextDouble()),
                                Alumno = alumno
                            };

                            alumno.Evaluaciones.Add(listarEvaluaciones);
                        }

                    }
                }
            }
        }

        #region Metodos de Carga
        private void CargaraAsignatura()
        {
            foreach (var cursos in Escuela.Cursos)
            {
                var listaAsignaturas = new List<Asignatura>()
            {
                new Asignatura(){Nombre = "Matematicas" },
                new Asignatura(){Nombre = "Educacion Fisica" },
                new Asignatura(){Nombre = "Catellano" },
                new Asignatura(){Nombre = "Ciencias Natirales" }
            };
                cursos.Asignaturas = listaAsignaturas;
            }
        }

        private List<Alumno> GenerarAlumnosAlAzar(int cantidad)
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

        #endregion

    }
}
