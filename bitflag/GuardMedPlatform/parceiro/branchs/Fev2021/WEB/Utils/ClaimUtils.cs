using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;

namespace WEB.Utils
{
    public static class ClaimUtils
    {
        public static bool IsInRealEstate(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.IsInRole("ImobiliariaOperacional") || claimsPrincipal.IsInRole("ImobiliariaFinanceiro") || claimsPrincipal.IsInRole("ImobiliarioAdministrativo");
        }

        public static bool IsInCompanyRole(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.IsInRole("ImobiliariaOperacional") || claimsPrincipal.IsInRole("ImobiliariaFinanceiro") || claimsPrincipal.IsInRole("ImobiliarioAdministrativo") || claimsPrincipal.IsInRole("Corretor");
        }
    }
}
