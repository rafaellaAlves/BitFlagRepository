using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.Models
{
    public class AssistanceExportViewModel
    {
        public string Referencia { get; set; }
        public DateTime DataDeInclusao { get; set; }
        public DateTime VigencyDate { get; set; }
        public string Imobiliaria { get; set; }
        public string Corretora { get; set; }
        public int ProductId { get; set; }
        public string Produto { get; set; }
        public string Apolice { get; set; }
        public string NomeInquilino { get; set; }
        public string CPFInquilino { get; set; }
        public string NomeProprietario { get; set; }
        public string CPFProprietario { get; set; }
        public string TipoDeImovel { get; set; }
        public string CEP { get; set; }
        public string LocalDeRisco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string Plano { get; set; }
        public double ValorAssistencia { get; set; }
        public int AssistanceId { get; set; }
        public string NomeAssistancia { get; set; }
        public string AssistanceReportCode { get; set; }
    }
}
