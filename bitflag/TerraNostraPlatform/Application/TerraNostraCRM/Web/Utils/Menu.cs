using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Claims;

namespace Web.Utils
{
    public static class Menu
    {
        public readonly static Dictionary<string, List<string>> roleAccess = new Dictionary<string, List<string>>
        {
            { "Indication", new List<string>{ "Administrator", "Administrative", "Administrative Assistant", "Contact Manager" } },
            { "Client", new List<string>{ "Administrator", "Salesman", "Contact Manager", "Administrative", "Administrative Assistant", "Financial" } },
            { "Calendar", new List<string>{ "Administrator", "Salesman", "Administrative", "Administrative Assistant" } },
            { "FreezedFamily", new List<string>{ "Administrator", "Salesman", "Financial", "Administrative", "Administrative Assistant", "Contact Manager" } },
            { "Invoice", new List<string>{ "Administrator", "Salesman", "Financial", "Administrative", "Administrative Assistant" } },
            { "Workbench", new List<string>{ "Administrator", "Salesman", "Financial", "Administrative", "Administrative Assistant" } },
            { "Financial", new List<string>{ "Administrator", "Financial" } },
            { "Bell", new List<string>{ "Administrator", "Salesman" } },
        };

        public readonly static Dictionary<string, List<string>> roleAccessEdition = new Dictionary<string, List<string>>
        {
            { "Indication", new List<string>{ "Administrator", "Administrative", "Administrative Assistant", "Contact Manager" } },
            { "Client", new List<string>{ "Administrator", "Salesman", "Contact Manager", "Administrative", "Administrative Assistant" } },
            { "Calendar", new List<string>{ "Administrator", "Salesman", "Administrative", "Administrative Assistant" } },
            { "FreezedFamily", new List<string>{ "Administrator", "Salesman", "Financial" } },
            { "Invoice", new List<string>{ "Administrator", "Salesman", "Financial" } },
            { "Workbench", new List<string>{ "Administrator", "Salesman", "Financial", "Administrative", "Administrative Assistant" } },
            { "Financial", new List<string>{ "Administrator", "Financial" } }
        };

        private static List<string> GetRolesByPage(string page, bool edition)
        {
            var roles = new List<string> { };
            if (edition)
            {
                if (!roleAccessEdition.ContainsKey(page)) return new List<string>();
                return roleAccessEdition[page];
            }
            else
            {
                if (!roleAccess.ContainsKey(page)) return new List<string>();
                return roleAccess[page];
            }
        }

        private static bool CheckCredential(this ClaimsPrincipal cp, string page, bool edition = false)
        {
            foreach (var item in GetRolesByPage(page, edition))
                if (cp.IsInRole(item)) return true;

            return false;
        }

        public static bool IndicationCanAccess(this ClaimsPrincipal cp)
        {
            return cp.CheckCredential("Indication");
        }
        public static bool ClientCanAccess(this ClaimsPrincipal cp)
        {
            return cp.CheckCredential("Client");
        }
        public static bool FreezedFamilyCanAccess(this ClaimsPrincipal cp)
        {
            return cp.CheckCredential("FreezedFamily");
        }
        public static bool InvoiceCanAccess(this ClaimsPrincipal cp)
        {
            return cp.CheckCredential("Invoice");
        }
        public static bool WorkbenchCanAccess(this ClaimsPrincipal cp)
        {
            return cp.CheckCredential("Workbench");
        }
        public static bool FinancialCanAccess(this ClaimsPrincipal cp)
        {
            return cp.CheckCredential("Financial");
        }
        public static bool CalendarCanAccess(this ClaimsPrincipal cp)
        {
            return cp.CheckCredential("Calendar");
        }
        public static bool BellCanAccess(this ClaimsPrincipal cp)
        {
            return cp.CheckCredential("Bell");
        }


        public static bool IndicationCanAccessEdition(this ClaimsPrincipal cp)
        {
            return cp.CheckCredential("Indication", true);
        }
        public static bool ClientCanAccessEdition(this ClaimsPrincipal cp)
        {
            return cp.CheckCredential("Client", true);
        }
        public static bool FreezedFamilyCanAccessEdition(this ClaimsPrincipal cp)
        {
            return cp.CheckCredential("FreezedFamily", true);
        }
        public static bool InvoiceCanAccessEdition(this ClaimsPrincipal cp)
        {
            return cp.CheckCredential("Invoice", true);
        }
        public static bool WorkbenchCanAccessEdition(this ClaimsPrincipal cp)
        {
            return cp.CheckCredential("Workbench", true);
        }
        public static bool FinancialCanAccessEdition(this ClaimsPrincipal cp)
        {
            return cp.CheckCredential("Financial", true);
        }
        public static bool CalendarCanAccessEdition(this ClaimsPrincipal cp)
        {
            return cp.CheckCredential("Calendar", true);
        }
    }
}