using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.Models
{
    public class MedicGroupEmailViewModel
    {
        public enum MedicGroupEmailAction
        {
            Create = 1,
            Remove = 2
        }

        public MedicGroupCRMViewModel MedicGroupCRM { get; set; }
        public MedicGroupViewModel MedicGroup { get; set; }
        public UserViewModel User { get; set; }
        public MedicGroupEmailAction Action { get; set; }

        public MedicGroupEmailViewModel(MedicGroupCRMViewModel medicGroupCRM, MedicGroupViewModel medicGroup, UserViewModel user, MedicGroupEmailAction action)
        {
            MedicGroupCRM = medicGroupCRM;
            MedicGroup = medicGroup;
            User = user;
            Action = action;
        }
    }
}
