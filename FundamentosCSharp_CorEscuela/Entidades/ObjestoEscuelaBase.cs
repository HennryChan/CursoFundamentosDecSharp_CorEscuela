using System;
using System.Collections.Generic;
using System.Text;

namespace FundamentosCSharp_CorEscuela.Entidades
{
    public class ObjestoEscuelaBase
    {
        public ObjestoEscuelaBase()
        {
            UniqueId = Guid.NewGuid().ToString();
        }

        public string UniqueId { get; set; }
        public string Nombre { get; set; }
    }
}
