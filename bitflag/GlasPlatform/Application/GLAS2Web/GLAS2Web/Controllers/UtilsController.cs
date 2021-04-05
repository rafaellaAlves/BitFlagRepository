using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GLAS2Web.Controllers
{
    public class UtilsController : Controller
    {
        private BLL.Utils.CountryFunctions countryFuncitons;
        private BLL.Utils.RegionFunctions regionFunctions;
        private BLL.Utils.StateFunctions stateFunctions;
        private BLL.Utils.CityFunctions cityFunctions;

        private DAL.GLAS2Context context;

        public UtilsController(DAL.GLAS2Context context)
        {
            this.context = context;
        }

        public IActionResult GetCountries()
        {
            countryFuncitons = new BLL.Utils.CountryFunctions(this.context);
            return Json(countryFuncitons.GetData().ToList());
        }

        public IActionResult GetRegions()
        {
            regionFunctions = new BLL.Utils.RegionFunctions(this.context);
            return Json(regionFunctions.GetData().ToList());
        }

        public IActionResult GetStates(string countryId)
        {
            stateFunctions = new BLL.Utils.StateFunctions(this.context);

            int _countryId;
            if (int.TryParse(countryId, out _countryId))
                return Json(stateFunctions.GetDataFiltered(x => x.CountryId.Equals(_countryId)).ToList());
            else
                return Json(stateFunctions.GetData().ToList());
        }

        public IActionResult GetCities(string stateId)
        {
            cityFunctions = new BLL.Utils.CityFunctions(this.context);
            if (string.IsNullOrWhiteSpace(stateId))
            {
                return Json(cityFunctions.GetData().ToList().OrderBy(x => x.Name));
            }
            else
            {
                int _stateId = -1;
                if(int.TryParse(stateId, out _stateId))
                    return Json(cityFunctions.GetDataFiltered(x => x.StateId == _stateId).OrderBy(x => x.Name));
                else
                    return Json(cityFunctions.GetData().ToList().OrderBy(x => x.Name));
            }
        }
    }
}