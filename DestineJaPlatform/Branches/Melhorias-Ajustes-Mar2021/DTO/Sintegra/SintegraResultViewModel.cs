using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Sintegra
{
    public class SintegraResultViewModel
    {
        public class Sintegra_Cnae
        {
            public string Code { get; set; }
            public string Text { get; set; }
        }
        public class Sintegra_Ibge
        {
            public string Codigo_municipio { get; set; }
            public string Codigo_uf { get; set; }
        }

        public int Code { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public string Nome_empresarial { get; set; }
        public string Cnpj { get; set; }
        public string Inscricao_estadual { get; set; }
        public string Tipo_inscricao { get; set; }
        public string Data_situacao_cadastral { get; set; }
        public string Situacao_cnpj { get; set; }
        public string Situacao_ie { get; set; }
        public string Nome_fantasia { get; set; }
        public string Data_inicio_atividade { get; set; }
        public string Regime_tributacao { get; set; }
        public string Informacao_ie_como_destinatario { get; set; }
        public string Porte_empresa { get; set; }
        public Sintegra_Cnae Cnae_principal { get; set; }
        public string Data_fim_atividade { get; set; }
        public string Uf { get; set; }
        public string Municipio { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public Sintegra_Ibge Ibge { get; set; }
    }
}
