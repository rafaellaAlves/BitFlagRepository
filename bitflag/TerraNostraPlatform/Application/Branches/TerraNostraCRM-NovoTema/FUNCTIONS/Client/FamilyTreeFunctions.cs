using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DB;
using DTO.Client;
using FUNCTIONS.Utils;

namespace FUNCTIONS.Client
{
    public class FamilyTreeFunctions : BasicFunctions<DB.FamilyTree, DTO.Client.FamilyTreeViewModel>
    {
        public FamilyTreeFunctions(TerraNostraContext context)
            : base(context, "FamilyTreeId")
        {
        }

        public override int Create(FamilyTreeViewModel model)
        {
            var familyTree = new FamilyTree
            {
                ClientId = model.ClientId,
                LastHandler = model.LastHandler,
                Name = model.Name,
                ParentId = model.ParentId,
                Title = model.Title,
                MarriedWith = model.MarriedWith,
                IsClient = model.IsClient,
                MarriedWithName = model.MarriedWithName,
                MarriedWithTitle = model.MarriedWithTitle,
            };
            this.dbSet.Add(familyTree);

            this.context.SaveChanges();

            return familyTree.FamilyTreeId;
        }

        public override void Delete(object id)
        {
            var familyTree = GetDataByID(id);

            if (familyTree.IsClient) return;

            familyTree.IsDeleted = true;
            familyTree.DeletedDate = DateTime.Now;

            this.dbSet.Update(familyTree);

            this.context.SaveChanges();
        }

        public void Delete(object id, int userID)
        {
            var familyTree = GetDataByID(id);

            if (familyTree.IsClient) return;

            familyTree.IsDeleted = true;
            familyTree.DeletedDate = DateTime.Now;
            familyTree.LastHandler = userID;
            FamilyTree marriedWith = this.dbSet.SingleOrDefault(x => x.MarriedWith == familyTree.FamilyTreeId && !x.IsDeleted);
                if (familyTree.MarriedWith.HasValue) {
                marriedWith = this.dbSet.SingleOrDefault(x => x.FamilyTreeId == familyTree.MarriedWith && !x.IsDeleted);
            }

            this.dbSet.Update(familyTree);

            foreach (var item in this.dbSet.Where(x => x.ParentId == familyTree.FamilyTreeId))
            {
                item.ParentId = null;
                if (marriedWith != null)
                {
                    item.ParentId = marriedWith.FamilyTreeId;
                    item.SecondParentId = null;
                }
                this.dbSet.Update(item);
            }
            this.context.SaveChanges();

            foreach (var item in this.dbSet.Where(x => x.SecondParentId == familyTree.FamilyTreeId))
            {
                item.SecondParentId = null;
                this.dbSet.Update(item);
            }
            foreach (var item in this.dbSet.Where(x => x.MarriedWith == familyTree.FamilyTreeId))
            {
                item.MarriedWith = null;
                if (!item.ParentId.HasValue && !item.SecondParentId.HasValue && !this.dbSet.Any(x => x.ParentId == item.FamilyTreeId && !x.IsDeleted)) item.IsDeleted = true; //deleta o item que não tiver pai e for casado com o item recem excluido

                this.dbSet.Update(item);
            }

            this.context.SaveChanges();
        }

        public List<FamilyTree> GetDataByClientId(int clientId, bool checkIsDeleted = false)
        {
            return this.dbSet.Where(x => x.ClientId == clientId && (!checkIsDeleted || (checkIsDeleted && !x.IsDeleted))).ToList();
        }

        public FamilyTree GetClientAsFamilyTreeItem(int clientId)
        {
            var client = this.context.Client.Single(x => x.ClientId == clientId);

            return new FamilyTree
            {
                ClientId = clientId,
                FamilyTreeId = 0,
                Name = client.FirstName + " " + client.LastName,
                Title = "Cliente",
                ParentId = null,
                IsClient = true
            };
        }

        public override List<FamilyTreeViewModel> GetDataViewModel(IEnumerable<FamilyTree> data)
        {
            return (from y in data
                    select new FamilyTreeViewModel
                    {
                        ClientId = y.ClientId,
                        LastHandler = y.LastHandler,
                        CreatedDate = y.CreatedDate,
                        DeletedDate = y.DeletedDate,
                        FamilyTreeId = y.FamilyTreeId,
                        IsDeleted = y.IsDeleted,
                        ModifiedDate = y.ModifiedDate,
                        Name = y.Name,
                        ParentId = y.ParentId,
                        Title = y.Title,
                        MarriedWith = y.MarriedWith,
                        IsClient = y.IsClient,
                        MarriedWithName = y.MarriedWithName,
                        MarriedWithTitle = y.MarriedWithTitle,
                        SecondParentId = y.SecondParentId
                    }).ToList();
        }

        public override FamilyTreeViewModel GetDataViewModel(FamilyTree data)
        {
            return new FamilyTreeViewModel
            {
                ClientId = data.ClientId,
                LastHandler = data.LastHandler,
                CreatedDate = data.CreatedDate,
                DeletedDate = data.DeletedDate,
                FamilyTreeId = data.FamilyTreeId,
                IsDeleted = data.IsDeleted,
                ModifiedDate = data.ModifiedDate,
                Name = data.Name,
                ParentId = data.ParentId,
                Title = data.Title,
                MarriedWith = data.MarriedWith,
                IsClient = data.IsClient,
                MarriedWithName = data.MarriedWithName,
                MarriedWithTitle = data.MarriedWithTitle,
                SecondParentId = data.SecondParentId
            };
        }

        public override void Update(FamilyTreeViewModel model)
        {
            var familyTree = GetDataByID(model.FamilyTreeId);

            //familyTree.ClientId = model.ClientId;
            familyTree.LastHandler = model.LastHandler;
            familyTree.Name = model.Name;
            //familyTree.ParentId = model.ParentId;
            familyTree.Title = model.Title;
            familyTree.ModifiedDate = DateTime.Now;
            //familyTree.MarriedWith = model.MarriedWith;
            familyTree.MarriedWithName = model.MarriedWithName;
            familyTree.MarriedWithTitle = model.MarriedWithTitle;

            this.dbSet.Update(familyTree);
            this.context.SaveChanges();
        }

        public void UpdateParent(int child, int? parent)
        {
            var familyTree = GetDataByID(child);

            familyTree.ParentId = parent;

            this.dbSet.Update(familyTree);
            this.context.SaveChanges();
        }

        public void UpdateSecondParent(int child, int? parent)
        {
            var familyTree = GetDataByID(child);

            familyTree.SecondParentId = parent;

            this.dbSet.Update(familyTree);
            this.context.SaveChanges();
        }

        public void UpdatemarriedWith(int familyTreeId, int? marriedWith)
        {
            var familyTree = GetDataByID(familyTreeId);

            familyTree.MarriedWith = marriedWith;

            this.dbSet.Update(familyTree);
            this.context.SaveChanges();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.FamilyTree;
        }

        public Dictionary<string, object> GetTags(List<FamilyTreeViewModel> models)
        {
            var tagIds = models.Where(x => x.MarriedWith.HasValue).Select(x => x.MarriedWith); // as tags criadas para agrupar os casas são feitas a partir do campo 'MarriedWith'

            Dictionary<string, object> tags = new Dictionary<string, object>();

            foreach (var item in tagIds)
            {
                tags.Add(item.Value.ToString(), new
                {
                    group = true,
                    groupState = 0,
                    template = "group_grey"
                });
            }

            tags.Add("client", new
            {
                template = "clientTemplate"
            });

            //tags.Add("clientMarried", new
            //{
            //    template = "clientTemplateMarried"
            //});

            //tags.Add("married", new
            //{
            //    template = "married"
            //});

            //tags.Add("normal", new
            //{
            //    template = "normal"
            //});

            return tags;
        }

        public List<DTO.Client.FamilyTreeHierarchizedViewModel> GetProductTypeModelHierarchized(int clientId)
        {
            var _familyTrees = (from y in GetDataViewModel(GetData(x => x.ClientId == clientId && !x.IsDeleted))
                                select new DTO.Client.FamilyTreeHierarchizedViewModel
                                {
                                    FamilyTreeId = y.FamilyTreeId.Value,
                                    Name = y.Name,
                                    Title = y.Title,
                                    ParentId = y.ParentId,
                                    MarriedWith = y.MarriedWith,
                                    IsClient = y.IsClient
                                }).ToList();

            var familyTrees = new List<DTO.Client.FamilyTreeHierarchizedViewModel>();

            foreach (var item in _familyTrees.Where(x => !x.ParentId.HasValue && !x.MarriedWith.HasValue))
            {
                familyTrees.Add(item.GetFamilyTreeModelHierarchized(item.FamilyTreeId, _familyTrees));
            }

            return familyTrees;
        }
    }
}
