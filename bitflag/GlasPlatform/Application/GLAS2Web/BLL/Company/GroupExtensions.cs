using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Company
{
    public static class GroupExtensions
    {
        public static void GetGroupModelHierarchized(this List<DTO.Company.GroupModel> me, int? parentId, DTO.Company.GroupModel groupModel)
        {
            if (groupModel.IsCompany) return;
            groupModel.Children = me.Where(x => x.ParentId.Equals(parentId)).ToList();
            for (int i = 0; i < groupModel.Children.Count; i++)
                me.GetGroupModelHierarchized(groupModel.Children[i].GroupId, groupModel.Children[i]);
        }

    }
}
