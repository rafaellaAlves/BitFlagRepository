using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Services.Advisor
{
    public class AdvisorService
    {
        List<DTO.AdvisorViewModel> data = new List<DTO.AdvisorViewModel>()
        {
            new DTO.AdvisorViewModel("L.C. Olivan Advogados Associados", "~/image/Escritorios_Parceiros/LCOlivanAdvogadosAssociados.png", "SP", "SÃO PAULO", "Rua Iguatemi 448 - 4º andar - Itaim Bibi, CEP 01451-010", "atendimento@lcolivan.adv.br", "+55 (11) 5525-2380 / +55 (11) 2640-7929", "http://lcolivan.adv.br/"),

            new DTO.AdvisorViewModel("Barbosa Ferreira Advogados", "~/image/Escritorios_Parceiros/BarbosaFerreiraAdvogados.png", "SP", "SOROCABA", "Av. Professora Izoraida Marques Peres, 256 - 52 - Parque Campolim, CEP 18048-110", "hugo@barbosaferreira.com.br", "+55 (15) 3411-7281", "https://barbosaferreira.com.br/"),

            new DTO.AdvisorViewModel("Granito, Coppi, Bonelli & Andery Advogados Associados", "~/image/Escritorios_Parceiros/GranitoCoppiBonelli&AnderyAdvogadosAssociados.png", "SP", "CAMPINAS", "Av. Barão de Itapura, 2620, Guanabara - CEP 13073-300", "gcba@gcbaadvogados.com.br", "+55 (19) 3212-1298 / +55 (19) 3212-1937", "https://gcbaadvogados.com.br/"),

            new DTO.AdvisorViewModel("Shilinkert Advogados", "~/image/Escritorios_Parceiros/logo-shilinkert-nowrite.png", "SP", "SÃO PAULO", "Rua São Bento, 365 11° andar - CENTRO, 01011-100", "alan.silva@slkt.adv.br", "+55 (11) 3116-7400", "http://www.shilinkert.adv.br/"),
        };

        public List<DTO.AdvisorViewModel> ObterAdvisor(string nome, string uf, string cidade)
        {
            if (!string.IsNullOrWhiteSpace(nome)) data = data.Where(x => x.Nome.ToUpper().Contains(nome.ToUpper())).ToList();
            if (!string.IsNullOrWhiteSpace(uf)) data = data.Where(x => x.Nome.ToUpper().Equals(uf.ToUpper())).ToList();
            if (!string.IsNullOrWhiteSpace(cidade)) data = data.Where(x => x.Nome.ToUpper().Equals(cidade.ToUpper())).ToList();

            return data;
        }
    }
}
