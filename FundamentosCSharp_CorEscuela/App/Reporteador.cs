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

        public IEnumerable<Escuela> GetListaEvaluaciones()
        {
            IEnumerable<Escuela> rta;
            if (_diccionario.TryGetValue(LlaveDiccionario.Escuela, out IEnumerable<ObjetoEscuelaBase>lista))
            {
                rta = lista.Cast<Escuela>();
            }
            {
                rta = null;
            }
            return rta;
        }

        //public IEnumerable<Evaluacion> GetEvaluacions()
        //{
        //    _diccionario[LlaveDiccionario.Evaluacion];
        //}
    }
}
