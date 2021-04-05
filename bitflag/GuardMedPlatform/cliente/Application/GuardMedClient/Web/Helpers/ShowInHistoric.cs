using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Helpers
{
    public class ShowInHistoric : Attribute 
    {
        public string PropertyDisplayName { get; }

        public ShowInHistoric(string propertyDisplayName)
        {
            PropertyDisplayName = propertyDisplayName;
        }
        public ShowInHistoric()
        {
        }
    }
}
