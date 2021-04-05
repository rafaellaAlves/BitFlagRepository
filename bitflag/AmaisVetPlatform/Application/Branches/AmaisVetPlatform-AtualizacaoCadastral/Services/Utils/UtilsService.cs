using DTO.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Utils
{
    public class UtilsService
    {
        public static List<StateViewModel> GetStates()
        {
            var states = new List<StateViewModel>();

            states.Add(new StateViewModel() { Code = "AC", Description = "Acre" });
            states.Add(new StateViewModel() { Code = "AL", Description = "Alagoas" });
            states.Add(new StateViewModel() { Code = "AP", Description = "Amapá" });
            states.Add(new StateViewModel() { Code = "AM", Description = "Amazonas" });
            states.Add(new StateViewModel() { Code = "BA", Description = "Bahia" });
            states.Add(new StateViewModel() { Code = "CE", Description = "Ceará" });
            states.Add(new StateViewModel() { Code = "DF", Description = "Distrito Federal" });
            states.Add(new StateViewModel() { Code = "ES", Description = "Espírito Santo" });
            states.Add(new StateViewModel() { Code = "GO", Description = "Goiás" });
            states.Add(new StateViewModel() { Code = "MA", Description = "Maranhão" });
            states.Add(new StateViewModel() { Code = "MT", Description = "Mato Grosso" });
            states.Add(new StateViewModel() { Code = "MS", Description = "Mato Grosso do Sul" });
            states.Add(new StateViewModel() { Code = "MG", Description = "Minas Gerais" });
            states.Add(new StateViewModel() { Code = "PA", Description = "Pará" });
            states.Add(new StateViewModel() { Code = "PB", Description = "Paraíba" });
            states.Add(new StateViewModel() { Code = "PR", Description = "Paraná" });
            states.Add(new StateViewModel() { Code = "PE", Description = "Pernambuco" });
            states.Add(new StateViewModel() { Code = "PI", Description = "Piauí" });
            states.Add(new StateViewModel() { Code = "RJ", Description = "Rio de Janeiro" });
            states.Add(new StateViewModel() { Code = "RN", Description = "Rio Grande do Norte" });
            states.Add(new StateViewModel() { Code = "RS", Description = "Rio Grande do Sul" });
            states.Add(new StateViewModel() { Code = "RO", Description = "Rondônia" });
            states.Add(new StateViewModel() { Code = "RR", Description = "Roraima" });
            states.Add(new StateViewModel() { Code = "SC", Description = "Santa Catarina" });
            states.Add(new StateViewModel() { Code = "SP", Description = "São Paulo" });
            states.Add(new StateViewModel() { Code = "SE", Description = "Sergipe" });
            states.Add(new StateViewModel() { Code = "TO", Description = "Tocantins" });

            return states;
        }
    }
}
