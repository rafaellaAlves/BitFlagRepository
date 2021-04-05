using System;
using System.Collections.Generic;
using System.Text;

namespace FUNCTIONS.Utils
{
    public static class StringUtils
    {
        public static void GetName(string name, out string firstName, out string lastName)
        {
            var _name = name.Split(" ");
            firstName = name;
            lastName = "";

            if (_name.Length > 0)
            {
                firstName = _name[0];
                for (int i = 1; i < _name.Length; i++)
                {
                    lastName += _name[i] + " ";
                }
            }
        }

        /// <summary>
        /// Substitui o texto "Você" caso exista no parentesco pelo nome do requerente
        /// </summary>
        /// <param name="clientApplicant"></param>
        /// <param name="kinship"></param>
        /// <returns></returns>
        public static string FormatKinship(DB.ClientApplicant clientApplicant, string kinship)
        {
            if (clientApplicant == null) return kinship;
            if (kinship == "Você") return "Requerente";
            FUNCTIONS.Utils.StringUtils.GetName(clientApplicant.FullName, out string firstName, out string lastName);
            return kinship.Contains("Você") ? kinship.Replace("Você", firstName) : kinship;
        }
    }
}
