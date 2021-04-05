using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuardMedWeb.Models
{
    public class ConfirmacaoClinicaVeterinariaViewModel
    {
        //public int? PagamentoTipoId { get; set; }
        public int? SeguradoClinicaVeterinariaId { get; set; }
        public string PrecoTotal { get; set; }
        public string PlanoClinicaVeterinariaPreco { get; set; }
        public string PlanoResponsavelTecnicoPreco { get; set; }
        public string PlanoExtensaoCobertura20Preco { get; set; }
        public string PlanoExtensaoCobertura30Preco { get; set; }
        public string PlanoExtensaoCobertura40Preco { get; set; }
        public string PlanoExtensaoCobertura50Preco { get; set; }
        //public string VezesPagamento { get; set; }

        public string MvReferences { get; set; }
    }
}
