using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.DTO.Shared;

namespace Web.Services.Utils
{
    public class UtilsService
    {
        public static List<Estado> GetEstados()
        {
            var l = new List<Estado>();

            l.Add(new Estado() { EstadoId = "AC", Description = "Acre" });
            l.Add(new Estado() { EstadoId = "AL", Description = "Alagoas" });
            l.Add(new Estado() { EstadoId = "AP", Description = "Amapá" });
            l.Add(new Estado() { EstadoId = "AM", Description = "Amazonas" });
            l.Add(new Estado() { EstadoId = "BA", Description = "Bahia" });
            l.Add(new Estado() { EstadoId = "CE", Description = "Ceará" });
            l.Add(new Estado() { EstadoId = "DF", Description = "Distrito Federal" });
            l.Add(new Estado() { EstadoId = "ES", Description = "Espírito Santo" });
            l.Add(new Estado() { EstadoId = "GO", Description = "Goiás" });
            l.Add(new Estado() { EstadoId = "MA", Description = "Maranhão" });
            l.Add(new Estado() { EstadoId = "MT", Description = "Mato Grosso" });
            l.Add(new Estado() { EstadoId = "MS", Description = "Mato Grosso do Sul" });
            l.Add(new Estado() { EstadoId = "MG", Description = "Minas Gerais" });
            l.Add(new Estado() { EstadoId = "PA", Description = "Pará" });
            l.Add(new Estado() { EstadoId = "PB", Description = "Paraíba" });
            l.Add(new Estado() { EstadoId = "PR", Description = "Paraná" });
            l.Add(new Estado() { EstadoId = "PE", Description = "Pernambuco" });
            l.Add(new Estado() { EstadoId = "PI", Description = "Piauí" });
            l.Add(new Estado() { EstadoId = "RJ", Description = "Rio de Janeiro" });
            l.Add(new Estado() { EstadoId = "RN", Description = "Rio Grande do Norte" });
            l.Add(new Estado() { EstadoId = "RS", Description = "Rio Grande do Sul" });
            l.Add(new Estado() { EstadoId = "RO", Description = "Rondônia" });
            l.Add(new Estado() { EstadoId = "RR", Description = "Roraima" });
            l.Add(new Estado() { EstadoId = "SC", Description = "Santa Catarina" });
            l.Add(new Estado() { EstadoId = "SP", Description = "São Paulo" });
            l.Add(new Estado() { EstadoId = "SE", Description = "Sergipe" });
            l.Add(new Estado() { EstadoId = "TO", Description = "Tocantins" });


            return l;
        }
    }
}
