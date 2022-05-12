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
            if (_diccionario.TryGetValue(LlaveDiccionario.Evaluacion, out IEnumerable<ObjetoEscuelaBase>lista))
            {
                return  lista.Cast<Evaluacion>();
            }
            {
                 return new List<Evaluacion>();
            }          
        }

        public IEnumerable<string> GetListaAsignaturas()
        {
            var listaEvaluaciones = GetListaEvaluaciones();

            return (from Evaluacion ev in listaEvaluaciones select ev.Asignatura.Nombre).Distinct();
        }

        public Dictionary<string, IEnumerable<Evaluacion>> GetDicListaEvaluaXAsig()
        {
            var dictaRta = new Dictionary<string, IEnumerable<Evaluacion>>();

            return dictaRta;
        }
    }
}
