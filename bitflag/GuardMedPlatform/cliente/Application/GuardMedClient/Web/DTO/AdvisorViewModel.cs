using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Web.DTO
{
    public class AdvisorViewModel
    {
        public string UF { get; set; }
        public string Cidade { get; set; }
        public string Nome { get; set; }
        public string LogoUrl { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Site { get; set; }

        public AdvisorViewModel() { }
        public AdvisorViewModel(string nome, string logoUrl, string uf, string cidade, string endereco, string email, string telefone, string site)
        {
            Nome = nome;
            LogoUrl = logoUrl;
            UF = uf;
            Cidade = cidade;
            Endereco = endereco;
            Email = email;
            Telefone = telefone;
            Site = site;
        }
    }
}
