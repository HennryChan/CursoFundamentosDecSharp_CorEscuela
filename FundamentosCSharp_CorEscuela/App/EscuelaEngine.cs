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

        public void ImprimirDiccionario(Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>>dic, bool imprEval=false)
        {
            foreach (var obj in dic)
            {
                Printer.WriteTitle(obj.Key.ToString());

                foreach (var val in obj.Value)
                {
                    switch (obj.Key)
                    {
                        case LlaveDiccionario.Evaluacion:
                            if (imprEval)
                            {
                                Console.WriteLine(val);
                            }
                            break;
                        case LlaveDiccionario.Escuela:
                            if (imprEval)
                            {
                                Console.WriteLine("Escuela: " + val);
                            }
                            break;
                        case LlaveDiccionario.Alumno:
                            if (imprEval)
                            {
                                Console.WriteLine("Alumno: "+ val.Nombre);
                            }
                            break;
                        case LlaveDiccionario.Curso:
                            var curtep = val as Curso;
                            if (curtep!=null)
                            {
                                int count = curtep.Alumnos.Count;
                                Console.WriteLine("Curso: "+ val.Nombre + " Cantidad Alumno: " + count);
                            }
                            break;
                        default:
                            Console.WriteLine(val);
                            break;
                    }
                }
            }
        }

        public Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> GetDiccionarioObjetos()
        {
            var diccionario = new Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>>();
            
            diccionario.Add(LlaveDiccionario.Escuela, new[] { Escuela });
            diccionario.Add(LlaveDiccionario.Curso, Escuela.Cursos.Cast<ObjetoEscuelaBase>());

            var listaTempEvaluacion = new List<Evaluacion>();
            var listaTempAsignatura = new List<Asignatura>();
            var listaTempAlumno = new List<Alumno>();

            foreach (var cur in Escuela.Cursos)
            {
                listaTempAsignatura.AddRange(cur.Asignaturas);
                listaTempAlumno.AddRange(cur.Alumnos);

                foreach (var alum in cur.Alumnos)
                {
                    listaTempEvaluacion.AddRange(alum.Evaluaciones);
                }
            }

            diccionario.Add(LlaveDiccionario.Evaluacion, listaTempEvaluacion.Cast<ObjetoEscuelaBase>());
            diccionario.Add(LlaveDiccionario.Asignatura, listaTempAsignatura.Cast<ObjetoEscuelaBase>());
            diccionario.Add(LlaveDiccionario.Alumno, listaTempAlumno.Cast<ObjetoEscuelaBase>());

            return diccionario;
        }

        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool traeAsignaturas = true,
            bool traeCursos = true)
        {
            return GetObjetosEscuela(out int dummy, out dummy, out dummy, out dummy);
        }

        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(
                      out int conteoEvaluaciones, out int conteoCursos,
                      bool traeEvaluaciones = true,
                      bool traeAlumnos = true,
                      bool traeAsignaturas = true,
                      bool traeCursos = true
                      )
        {
            return GetObjetosEscuela(out conteoEvaluaciones, out conteoCursos, out int dummy, out dummy);
        }

        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(
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

            return listaObj.AsReadOnly();
        }

        private void GenerarEvaluacionesAlAzar()
        {
            Random randm = new Random();

            foreach (var cursos in Escuela.Cursos)
            {
                foreach (var alumno in cursos.Alumnos)
                {
                    foreach (var asignatura in cursos.Asignaturas)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            var listarEvaluaciones = new Evaluacion()
                            {
                                Asignatura = asignatura,
                                Nombre = $"{asignatura.Nombre} Ev#{i + 1}",
                                Nota = MathF.Round(5 * (float)randm.NextDouble(), 2),
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
