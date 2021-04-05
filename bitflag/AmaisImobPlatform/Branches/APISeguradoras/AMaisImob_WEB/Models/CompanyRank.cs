using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AMaisImob_WEB.Utils;

namespace AMaisImob_WEB.Models
{
    public class CompanyRankData
    {
        public int? RealEstateId { get; set; }
        public string RealEstateName { get; set; }
        public int Count { get; set; }
        public double InquilinoAnual { get; set; }
        public string _InquilinoAnual { get { return InquilinoAnual.ToPtBR(); } }
        public double InquilinoMensal { get; set; }
        public string _InquilinoMensal { get { return InquilinoMensal.ToPtBR(); } }
        public double ProximaFatura { get; set; }
        public string _ProximaFatura { get { return ProximaFatura.ToPtBR(); } }
    }
}
