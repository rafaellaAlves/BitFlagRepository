using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GLAS2Web.Utils
{
    public class UFUtils
    {
        public static IEnumerable<DTO.Shared.UF> GetUFs()
        {
            yield return new DTO.Shared.UF() { UFID = "AC", Description = "Acre" };
            yield return new DTO.Shared.UF() { UFID = "AL", Description = "Alagoas" };
            yield return new DTO.Shared.UF() { UFID = "AP", Description = "Amapá" };
            yield return new DTO.Shared.UF() { UFID = "AM", Description = "Amazonas" };
            yield return new DTO.Shared.UF() { UFID = "BA", Description = "Bahia" };
            yield return new DTO.Shared.UF() { UFID = "CE", Description = "Ceará" };
            yield return new DTO.Shared.UF() { UFID = "DF", Description = "Distrito Federal" };
            yield return new DTO.Shared.UF() { UFID = "ES", Description = "Espírito Santo" };
            yield return new DTO.Shared.UF() { UFID = "GO", Description = "Goiás" };
            yield return new DTO.Shared.UF() { UFID = "MA", Description = "Maranhão" };
            yield return new DTO.Shared.UF() { UFID = "MT", Description = "Mato Grosso" };
            yield return new DTO.Shared.UF() { UFID = "MS", Description = "Mato Grosso do Sul" };
            yield return new DTO.Shared.UF() { UFID = "MG", Description = "Minas Gerais" };
            yield return new DTO.Shared.UF() { UFID = "PA", Description = "Pará" };
            yield return new DTO.Shared.UF() { UFID = "PB", Description = "Paraíba" };
            yield return new DTO.Shared.UF() { UFID = "PR", Description = "Paraná" };
            yield return new DTO.Shared.UF() { UFID = "PE", Description = "Pernambuco" };
            yield return new DTO.Shared.UF() { UFID = "PI", Description = "Piauí" };
            yield return new DTO.Shared.UF() { UFID = "RJ", Description = "Rio de Janeiro" };
            yield return new DTO.Shared.UF() { UFID = "RN", Description = "Rio Grande do Norte" };
            yield return new DTO.Shared.UF() { UFID = "RS", Description = "Rio Grande do Sul" };
            yield return new DTO.Shared.UF() { UFID = "RO", Description = "Rondônia" };
            yield return new DTO.Shared.UF() { UFID = "RR", Description = "Roraima" };
            yield return new DTO.Shared.UF() { UFID = "SC", Description = "Santa Catarina" };
            yield return new DTO.Shared.UF() { UFID = "SP", Description = "São Paulo" };
            yield return new DTO.Shared.UF() { UFID = "SE", Description = "Sergipe" };
            yield return new DTO.Shared.UF() { UFID = "TO", Description = "Tocantins" };
        }
    }
}
