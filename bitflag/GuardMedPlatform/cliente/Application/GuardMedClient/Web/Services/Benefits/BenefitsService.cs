using DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.DTO.Benefits;
using Web.Services.Shared;

namespace Web.Services.Benefits
{
    public class BenefitsService : InsuranceBaseListService<Benefit, BenefitsViewModel, int>
    {
        public BenefitsService(Insurance_HomologContext context) : base(context, "BenefitId")
        {
        }
    }
}
