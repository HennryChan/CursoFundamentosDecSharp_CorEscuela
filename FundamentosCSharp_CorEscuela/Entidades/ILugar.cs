using System;
using System.Collections.Generic;
using System.Text;

namespace FundamentosCSharp_CorEscuela.Entidades
{
    public interface ILugar
    {
        string Direccion { get; set; }
        void LimpiarLugar();
    }
}
