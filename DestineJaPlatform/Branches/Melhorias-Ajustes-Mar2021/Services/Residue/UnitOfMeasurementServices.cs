using ApplicationDbContext.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Residue
{
    public class UnitOfMeasurementServices : Shared.BaseListServices<UnitOfMeasurement, UnitOfMeasurement, int>
    {
        private int toneladaID, quilogramaID, m3ID, litroID;

        public UnitOfMeasurementServices(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext) : base(context, identityContext, "UnitOfMeasurementId")
        {
            var data = GetDataAsNoTrackingAsync().Result;

            quilogramaID = GetDataByExternalCode(data, "KILOGRAMA").UnitOfMeasurementId;
            toneladaID = GetDataByExternalCode(data, "TONELADA").UnitOfMeasurementId;
            m3ID = GetDataByExternalCode(data, "M3").UnitOfMeasurementId;
            litroID = GetDataByExternalCode(data, "LITRO").UnitOfMeasurementId;
        }

        public async Task<UnitOfMeasurement> GetDataByExternalCode(string externalCode) => (await GetDataAsNoTrackingAsync(x => x.ExternalCode == externalCode)).SingleOrDefault();
        public UnitOfMeasurement GetDataByExternalCode(IEnumerable<UnitOfMeasurement> data, string externalCode) => data.SingleOrDefault(x => x.ExternalCode == externalCode);

        public double GetFactor(int inId, int outId)
        {
            if (inId == toneladaID || inId == m3ID) //entrada como tonelada OU entrada como metro cúbico
            {
                if (outId == quilogramaID || outId == litroID) return 0.001d; //de tonelada/metro cúbico para quilograma OU de tonelada/metro cúbico para litro
            }

            if (inId == quilogramaID || inId == litroID) //entrada como quilograma ou entrada como litro
            {
                if (outId == toneladaID || outId == m3ID) return 1000d; //de quilograma/litro para tonelada OU de quilograma/litro para metro cúbico
            }

            return 1d;
        }

        public double GetFactorForWeight(int inId, int outId)
        {
            if (inId == toneladaID || inId == m3ID) //entrada como tonelada OU entrada como metro cúbico
            {
                if (outId == quilogramaID || outId == litroID) return 1000d; //de tonelada/metro cúbico para quilograma OU de tonelada/metro cúbico para litro
            }

            if (inId == quilogramaID || inId == litroID) //entrada como quilograma ou entrada como litro
            {
                if (outId == toneladaID || outId == m3ID) return 0.001d; //de quilograma/litro para tonelada OU de quilograma/litro para metro cúbico
            }

            return 1d;
        }

    }
}