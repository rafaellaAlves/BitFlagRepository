using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuardMedWeb.BLL.Utils
{
    public static class Utils
    {
        public static List<Models.Estado> GetEstados()
        {
            var l = new List<Models.Estado>();

            l.Add(new Models.Estado() { EstadoId = "AC", Description = "Acre" });
            l.Add(new Models.Estado() { EstadoId = "AL", Description = "Alagoas" });
            l.Add(new Models.Estado() { EstadoId = "AP", Description = "Amapá" });
            l.Add(new Models.Estado() { EstadoId = "AM", Description = "Amazonas" });
            l.Add(new Models.Estado() { EstadoId = "BA", Description = "Bahia" });
            l.Add(new Models.Estado() { EstadoId = "CE", Description = "Ceará" });
            l.Add(new Models.Estado() { EstadoId = "DF", Description = "Distrito Federal" });
            l.Add(new Models.Estado() { EstadoId = "ES", Description = "Espírito Santo" });
            l.Add(new Models.Estado() { EstadoId = "GO", Description = "Goiás" });
            l.Add(new Models.Estado() { EstadoId = "MA", Description = "Maranhão" });
            l.Add(new Models.Estado() { EstadoId = "MT", Description = "Mato Grosso" });
            l.Add(new Models.Estado() { EstadoId = "MS", Description = "Mato Grosso do Sul" });
            l.Add(new Models.Estado() { EstadoId = "MG", Description = "Minas Gerais" });
            l.Add(new Models.Estado() { EstadoId = "PA", Description = "Pará" });
            l.Add(new Models.Estado() { EstadoId = "PB", Description = "Paraíba" });
            l.Add(new Models.Estado() { EstadoId = "PR", Description = "Paraná" });
            l.Add(new Models.Estado() { EstadoId = "PE", Description = "Pernambuco" });
            l.Add(new Models.Estado() { EstadoId = "PI", Description = "Piauí" });
            l.Add(new Models.Estado() { EstadoId = "RJ", Description = "Rio de Janeiro" });
            l.Add(new Models.Estado() { EstadoId = "RN", Description = "Rio Grande do Norte" });
            l.Add(new Models.Estado() { EstadoId = "RS", Description = "Rio Grande do Sul" });
            l.Add(new Models.Estado() { EstadoId = "RO", Description = "Rondônia" });
            l.Add(new Models.Estado() { EstadoId = "RR", Description = "Roraima" });
            l.Add(new Models.Estado() { EstadoId = "SC", Description = "Santa Catarina" });
            l.Add(new Models.Estado() { EstadoId = "SP", Description = "São Paulo" });
            l.Add(new Models.Estado() { EstadoId = "SE", Description = "Sergipe" });
            l.Add(new Models.Estado() { EstadoId = "TO", Description = "Tocantins" });


            return l;
        }

        public static string GetReference()
        {
            var stringBuilder = new StringBuilder();
            var random = new Random();
            for (int j = 1; j <= 4; j++)
            {
                var charCode = random.Next(65, 90);
                stringBuilder.Append((char)charCode);
            }
            stringBuilder.Append(string.Format("{0:0000}", random.Next(0, 9999)));
            return stringBuilder.ToString();
        }

        public static void GetVigencyDate(this DateTime me, out DateTime startDate, out DateTime endDate)
        {
            startDate = new DateTime(me.Year, me.Month, 1);
            endDate = startDate.AddYears(1);
        }
    }
}
