using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utils;

namespace DTO.Company
{
    public class GroupModel
    {
        public int? GroupId { get; set; }
        public int? id { get { return GroupId; } }
        public string Name { get; set; }
        public string name { get { return Name; } }
        public string Description { get; set; }
        public int? ParentId { get; set; }
        public List<GroupModel> Children { get; set; }
        public List<GroupModel> children { get { return Children; } }
        public CompanyViewModel Company { get; set; }
        public bool IsCompany { get { return this.Company != null; } }
        public int CompanyGroupId { get; set; }

        public GroupModel()
        {
            this.Children = new List<GroupModel>();
        }
    }
}
