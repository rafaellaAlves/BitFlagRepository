using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DTO.Utils
{
    public static class ClaimExtensions
    {
        public static readonly List<string> ClientRoles = new List<string> { "ClientAdministrator", "Cliente" };

        public const string AuthorizationClientRoles = "Cliente, ClientAdministrator";

        public static bool IsClient(this ClaimsPrincipal claimsPrincipal) => ClientRoles.Any(x => claimsPrincipal.IsInRole(x));
    }
}
