using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using FundamentosCSharp_CorEscuela.Entidades;
using FundamentosCSharp_CorEscuela.Util;

namespace FundamentosCSharp_CorEscuela.App
{
    public class Reporteador
    {
        Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> _diccionario;

        public Reporteador(Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> dicObjEsc)
        {
            if (dicObjEsc == null)
            {
                throw new ArgumentNullException(nameof(dicObjEsc));

            }
            _diccionario = dicObjEsc;
        }

        public IEnumerable<Evaluacion> GetListaEvaluaciones()
        {
            if (_diccionario.TryGetValue(LlaveDiccionario.Evaluacion, out IEnumerable<ObjetoEscuelaBase> lista))
            {
                return lista.Cast<Evaluacion>();
            }
            {
                return new List<Evaluacion>();
            }
        }

        public IEnumerable<string> GetListaAsignaturas()
        {
            return GetListaAsignaturas(out var dummy);
        }
        public IEnumerable<string> GetListaAsignaturas(out IEnumerable<Evaluacion> listaEvaluaciones)
        {
            listaEvaluaciones = GetListaEvaluaciones();

            return (from Evaluacion ev in listaEvaluaciones select ev.Asignatura.Nombre).Distinct();
        }

        public Dictionary<string, IEnumerable<Evaluacion>> GetDicEvaluaXAsig()
        {
            var dictaRta = new Dictionary<string, IEnumerable<Evaluacion>>();
            var listaAsig = GetListaAsignaturas(out var listaEval);

            foreach (var asig in listaAsig)
            {
                var evalsAsig = from eval in listaEval
                                where eval.Asignatura.Nombre == asig
                                select eval;

                dictaRta.Add(asig, evalsAsig);
            }
            return dictaRta;
        }

        public Dictionary<string, IEnumerable<object>> GetPromedioAlumnoPorAsignatura()
        {
            var rta = new Dictionary<string, IEnumerable<object>>();
            var dicEvalXAsig = GetDicEvaluaXAsig();

            foreach (var asigConEval in dicEvalXAsig)
            {
                var dummy = from eval in asigConEval.Value
                            group eval by eval.Alumno.UniqueId
                            into grupoEvalsAlumno
                            select new
                            {
                                AlumnoId = grupoEvalsAlumno.Key,
                                Promedio = grupoEvalsAlumno.Average(evaluacion=>evaluacion.Nota)
                            };
            }
            return rta;
        }
    }
}
