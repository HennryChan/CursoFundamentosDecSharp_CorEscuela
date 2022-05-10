using System;
using System.Collections.Generic;
using System.Text;

namespace FundamentosCSharp_CorEscuela.Entidades
{
    public class ObjetoEscuelaBase
    {
        public ObjetoEscuelaBase()
        {
            UniqueId = Guid.NewGuid().ToString();
        }

        public string UniqueId { get; set; }
        public string Nombre { get; set; }

        public override string ToString()
        {
            return $"{Nombre},{UniqueId}";
        }
    }
}
