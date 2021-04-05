using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuardMedWeb.DAL
{
    public class SeguroClinicaVeterinariaPreco
    {
        public int SeguroClinicaVeterinariaPrecoId { get; set; }
        public int PlanoClinicaVeterinariaId { get; set; }
        public double Custo { get; set; }
        public double RCPPJCusto { get; set; }
        public double RCPPFCusto { get; set; }
        public double EmpresarialCusto { get; set; }
        public double ServicosADMCusto { get; set; }
    }
}
