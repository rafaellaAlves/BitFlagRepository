using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FUNCTIONS.Utils
{
    public static class FamilyTreeUtils
    {
        public static DTO.Client.FamilyTreeHierarchizedViewModel GetFamilyTreeModelHierarchized(this DTO.Client.FamilyTreeHierarchizedViewModel me , int? parentId, List<DTO.Client.FamilyTreeHierarchizedViewModel> all)
        {
            //checking spouse and bellow code is checking the childrens that are associated with the spouse
            DTO.Client.FamilyTreeHierarchizedViewModel spouse = null;
            if (parentId.HasValue)
            {
                spouse = all.SingleOrDefault(x => x.MarriedWith.Equals(parentId));
            }
            if (me.MarriedWith.HasValue && spouse == null)
            {
                spouse = all.SingleOrDefault(x => x.FamilyTreeId == me.MarriedWith);
            }
            me.Spouse = spouse;

            if (spouse != null)
            {
                me.MarriedWith = spouse.FamilyTreeId;
                if (all.Any(x => x.ParentId == spouse.FamilyTreeId))
                {
                    me.Childrens = all.Where(x => x.ParentId.Equals(spouse.FamilyTreeId)).ToList();
                    for (int i = 0; i < me.Childrens.Count; i++)
                        me.Childrens[i].GetFamilyTreeModelHierarchized(me.Childrens[i].FamilyTreeId, all);
                }
                me.Spouse.Childrens = new List<DTO.Client.FamilyTreeHierarchizedViewModel>();
            }

            //childrens
            if (!all.Any(x => x.ParentId == me.FamilyTreeId)) return me;
            var childrens = all.Where(x => x.ParentId.Equals(parentId)).ToList();
            
            for (int i = 0; i < childrens.Count; i++)
                me.Childrens.Add(childrens[i].GetFamilyTreeModelHierarchized(childrens[i].FamilyTreeId, all));

            return me;
        }
    }
}
