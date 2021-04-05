using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;

namespace AMaisImob_WEB.Utils
{
    public static class ClaimUtils
    {
        public static bool IsInRealEstate(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.IsInRole("ImobiliariaOperacional") || claimsPrincipal.IsInRole("ImobiliariaFinanceiro") || claimsPrincipal.IsInRole("ImobiliarioAdministrativo") || claimsPrincipal.IsInRole("ImobiliarioSocio")/* || claimsPrincipal.IsInRole("ImobiliariaVendas")*/;
        }
        public const string AllRolesExceptSeller = "ImobiliariaOperacional, ImobiliariaFinanceiro, ImobiliarioAdministrativo, ImobiliarioSocio, Corretor, Administrator";
        public static List<AMaisImob_DB.Models.Role> GetRealEstateRoles()
        {
            return new List<AMaisImob_DB.Models.Role> {
                new AMaisImob_DB.Models.Role { Name = "ImobiliariaOperacional", Description = "Imobiliária - Operacional" },
                new AMaisImob_DB.Models.Role { Name = "ImobiliariaFinanceiro", Description = "Imobiliária - Financeiro" },
                new AMaisImob_DB.Models.Role { Name = "ImobiliarioAdministrativo", Description = "Imobiliário - Administrativo" },
                new AMaisImob_DB.Models.Role { Name = "ImobiliariaVendas", Description = "Imobiliária - Vendas" },
                new AMaisImob_DB.Models.Role { Name = "ImobiliarioSocio", Description = "Imobiliária - Sócio" }
                };
        }
    }
}
