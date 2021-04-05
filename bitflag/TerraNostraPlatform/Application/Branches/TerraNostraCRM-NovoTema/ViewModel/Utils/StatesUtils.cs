using DTO.State;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Utils
{
    public class StatesUtils
    {
        public static List<StateViewModel> GetEstados()
        {
            var l = new List<StateViewModel>();

            l.Add(new StateViewModel() { StateId = "AC", Description = "Acre" });
            l.Add(new StateViewModel() { StateId = "AL", Description = "Alagoas" });
            l.Add(new StateViewModel() { StateId = "AP", Description = "Amapá" });
            l.Add(new StateViewModel() { StateId = "AM", Description = "Amazonas" });
            l.Add(new StateViewModel() { StateId = "BA", Description = "Bahia" });
            l.Add(new StateViewModel() { StateId = "CE", Description = "Ceará" });
            l.Add(new StateViewModel() { StateId = "DF", Description = "Distrito Federal" });
            l.Add(new StateViewModel() { StateId = "ES", Description = "Espírito Santo" });
            l.Add(new StateViewModel() { StateId = "GO", Description = "Goiás" });
            l.Add(new StateViewModel() { StateId = "MA", Description = "Maranhão" });
            l.Add(new StateViewModel() { StateId = "MT", Description = "Mato Grosso" });
            l.Add(new StateViewModel() { StateId = "MS", Description = "Mato Grosso do Sul" });
            l.Add(new StateViewModel() { StateId = "MG", Description = "Minas Gerais" });
            l.Add(new StateViewModel() { StateId = "PA", Description = "Pará" });
            l.Add(new StateViewModel() { StateId = "PB", Description = "Paraíba" });
            l.Add(new StateViewModel() { StateId = "PR", Description = "Paraná" });
            l.Add(new StateViewModel() { StateId = "PE", Description = "Pernambuco" });
            l.Add(new StateViewModel() { StateId = "PI", Description = "Piauí" });
            l.Add(new StateViewModel() { StateId = "RJ", Description = "Rio de Janeiro" });
            l.Add(new StateViewModel() { StateId = "RN", Description = "Rio Grande do Norte" });
            l.Add(new StateViewModel() { StateId = "RS", Description = "Rio Grande do Sul" });
            l.Add(new StateViewModel() { StateId = "RO", Description = "Rondônia" });
            l.Add(new StateViewModel() { StateId = "RR", Description = "Roraima" });
            l.Add(new StateViewModel() { StateId = "SC", Description = "Santa Catarina" });
            l.Add(new StateViewModel() { StateId = "SP", Description = "São Paulo" });
            l.Add(new StateViewModel() { StateId = "SE", Description = "Sergipe" });
            l.Add(new StateViewModel() { StateId = "TO", Description = "Tocantins" });

            return l;
        }
    }
}
