using System;
using System.Collections.Generic;

namespace DAL
{
    public partial class SeguroProfissionalPreco
    {
        public int SeguroProfissionalPrecoId { get; set; }
        public int IdadeMin { get; set; }
        public int IdadeMax { get; set; }
        public int PlanoSeguroProfissionalId { get; set; }
        public double Custo { get; set; }
        public double CustoAssociado { get; set; }
        public double CustoMensal { get; set; }
        public string CodIugu { get; set; }
        public double CustoAssociadoMensal { get; set; }
        public string CodIuguassociado { get; set; }
        public double CustoPanMensal { get; set; }
        public double CustoPanAnual { get; set; }
        public double CustoPanMensalAssociado { get; set; }
        public double CustoPanAnualAssociado { get; set; }
    }
}
