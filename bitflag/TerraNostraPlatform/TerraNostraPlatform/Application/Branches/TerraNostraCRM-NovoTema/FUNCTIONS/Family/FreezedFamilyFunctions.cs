using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DB;
using DTO.FreezedFamily;
using FUNCTIONS.Utils;

namespace FUNCTIONS.Family
{
    public class FreezedFamilyFunctions : BasicListFunctions<DB.FreezedFamily, DTO.FreezedFamily.FreezedFamilyViewModel>
    {
        public FreezedFamilyFunctions(TerraNostraContext context)
            : base(context, "FreezedFamilyId")
        {
        }

        /// <summary>
        /// Obtem os dados de membros de família e insere-os em classes "FreezedFamilyItem" para serem inseridos no banco
        /// </summary>
        /// <param name="familyMemberIds">Ids dos membros de família</param>
        /// <returns></returns>
        public List<DB.FreezedFamilyItem> GetFreezedFamilyItemByFamilyMemberIds(IEnumerable<int> familyMemberIds)
        {
            return (from x in context.FamilyMember
                    where familyMemberIds.Contains(x.FamilyMemberId)
                    select new DB.FreezedFamilyItem
                    {
                        BirthDate = x.BirthDate,
                        BirthPlace = x.BirthPlace,
                        ClientApplicantId = x.ClientApplicantId,
                        DeathDate = x.DeathDate,
                        DeathPlace = x.DeathPlace,
                        FamilyStructureId = x.FamilyStructureId,
                        FullName = x.FullName,
                        ConsortFullName = x.ConsortFullName,
                        MarriageDate = x.MarriageDate,
                        MarriagePlace = x.MarriagePlace,
                    }).ToList();
        }

        /// <summary>
        /// Obtem os dados de requerentes e insere-os em classes "FreezedFamilyItem" para serem inseridos no banco
        /// </summary>
        /// <param name="clientApplicantIds">Ids dos requerentes</param>
        /// <returns></returns>
        public List<DB.FreezedFamilyItem> GetFreezedFamilyItemByclientApplicantIds(IEnumerable<int> clientApplicantIds)
        {
            return (from x in context.ClientApplicant
                    where clientApplicantIds.Contains(x.ClientApplicantId)
                    select new DB.FreezedFamilyItem
                    {
                        ClientApplicantId = x.ClientApplicantId,
                        FamilyStructureId = 1,
                        FullName = x.FullName,
                        ConsortFullName = x.ConsortFullName,
                        BirthDate = x.BirthDate,
                        BirthPlace = x.BirthPlace,
                        MarriageDate = x.MarriageDate,
                        MarriagePlace = x.MarriagePlace,
                    }).ToList();
        }

        public int CreateFreezedFamily(List<DB.FreezedFamilyItem> itens, int clientId, int createdBy)
        {
            var freezedFamily = new DB.FreezedFamily
            {
                ClientId = clientId,
                CreatedBy = createdBy
            };

            context.FreezedFamily.Add(freezedFamily);
            context.SaveChanges();

            itens.ForEach(x => x.FreezedFamilyId = freezedFamily.FreezedFamilyId);

            context.FreezedFamilyItem.AddRange(itens);
            context.SaveChanges();

            return freezedFamily.FreezedFamilyId;
        }

        public DB.FreezedFamily GetFreezedFamily(int freezedFamilyId)
        {
            return context.FreezedFamily.Single(x => x.FreezedFamilyId == freezedFamilyId);
        }

        public DTO.FreezedFamily.FreezedFamilyListViewModel GetFreezedFamilyListViewModel(DB.FreezedFamily freezedFamily)
        {
            var client = context.Client.Single(x => x.ClientId == freezedFamily.ClientId);
            var createdBy = context.User.SingleOrDefault(x => x.UserId == freezedFamily.CreatedBy);
            DB.User acceptedBy = freezedFamily.AcceptedBy.HasValue ? context.User.SingleOrDefault(x => x.UserId == freezedFamily.AcceptedBy.Value) : null;
            int memberCount = context.FreezedFamilyItem.Count(x => x.FreezedFamilyId == freezedFamily.FreezedFamilyId);

            return new DTO.FreezedFamily.FreezedFamilyListViewModel
            {
                FreezedFamilyId = freezedFamily.FreezedFamilyId,
                ClientId = freezedFamily.ClientId,
                ClientName = client.FirstName + " " + client.LastName,
                MemberCount = memberCount,
                CreatedBy = freezedFamily.CreatedBy,
                _CreatedBy = createdBy == null ? "-" : createdBy.FirstName + " " + createdBy.LastName,
                CreatedDate = freezedFamily.CreatedDate,
                Accepted = freezedFamily.Accepted,
                AcceptedBy = freezedFamily.AcceptedBy,
                _AcceptedBy = acceptedBy == null ? "-" : acceptedBy.FirstName + " " + acceptedBy.LastName,
                AcceptedDate = freezedFamily.AcceptedDate
            };
        }

        public List<DTO.FreezedFamily.FreezedFamilyListViewModel> GetFreezedFamilyListViewModel(IEnumerable<DB.FreezedFamily> datas)
        {
            return (from x in datas
                    join c in context.Client on x.ClientId equals c.ClientId
                    from u in context.User.Where(_u => _u.UserId == x.CreatedBy).DefaultIfEmpty()
                    from u2 in context.User.Where(_u2 => _u2.UserId == x.AcceptedBy).DefaultIfEmpty()
                    join ffi in context.FreezedFamilyItem on x.FreezedFamilyId equals ffi.FreezedFamilyId into ffiCount
                    select new DTO.FreezedFamily.FreezedFamilyListViewModel
                    {
                        FreezedFamilyId = x.FreezedFamilyId,
                        ClientId = x.ClientId,
                        ClientName = c.FirstName + " " + c.LastName,
                        MemberCount = ffiCount.Count(),
                        CreatedBy = x.CreatedBy,
                        _CreatedBy = u == null ? "-" : u.FirstName + " " + u.LastName,
                        CreatedDate = x.CreatedDate,
                        Accepted = x.Accepted,
                        AcceptedBy = x.AcceptedBy,
                        _AcceptedBy = u2 == null ? "-" : u2.FirstName + " " + u2.LastName,
                        AcceptedDate = x.AcceptedDate
                    }).ToList();
        }


        public List<DB.FreezedFamilyItem> GetFreezedFamilyItems(int freezedFamilyId)
        {
            return context.FreezedFamilyItem.Where(x => x.FreezedFamilyId == freezedFamilyId).ToList();
        }

        public List<DTO.FreezedFamily.FreezedFamilyItemViewModel> GetFreezedFamilyItemViewModel(List<DB.FreezedFamilyItem> freezedFamilyItem)
        {
            return (from x in freezedFamilyItem
                    join fs in context.FamilyStructure on x.FamilyStructureId equals fs.FamilyStructureId
                    join fm in context.FamilyMemberType on fs.FamilyMemberTypeId equals fm.FamilyMemberTypeId
                    join ca in context.ClientApplicant on x.ClientApplicantId equals ca.ClientApplicantId into _ca
                    from __ca in _ca.DefaultIfEmpty()
                    select new DTO.FreezedFamily.FreezedFamilyItemViewModel
                    {
                        BirthDate = x.BirthDate,
                        BirthPlace = x.BirthPlace,
                        ClientApplicantId = x.ClientApplicantId,
                        DeathDate = x.DeathDate,
                        DeathPlace = x.DeathPlace,
                        Email = x.Email,
                        FamilyMemberId = x.FamilyMemberId,
                        FamilyStructureId = x.FamilyStructureId,
                        FreezedFamilyId = x.FreezedFamilyId,
                        FreezedFamilyItemId = x.FreezedFamilyItemId,
                        FullName = x.FullName,
                        ConsortFullName = x.ConsortFullName,
                        MarriageDate = x.MarriageDate,
                        MarriagePlace = x.MarriagePlace,
                        FamilyStructureDescription = StringUtils.FormatKinship(__ca, fs.Description),
                        FamilyMemberTypeId = fm.FamilyMemberTypeId,
                        FamilyMemberTypeName = fm.Name
                    }).ToList();
        }

        public DTO.FreezedFamily.FreezedFamilyItemViewModel GetFreezedFamilyItemViewModel(DB.FreezedFamilyItem freezedFamilyItem)
        {
            var fs = context.FamilyStructure.Single(y => freezedFamilyItem.FamilyStructureId == y.FamilyStructureId);
            var ca = context.ClientApplicant.Single(y => freezedFamilyItem.ClientApplicantId == y.ClientApplicantId);
            var fm = context.FamilyMemberType.Single(y => fs.FamilyMemberTypeId == y.FamilyMemberTypeId);

            return new DTO.FreezedFamily.FreezedFamilyItemViewModel
            {
                BirthDate = freezedFamilyItem.BirthDate,
                BirthPlace = freezedFamilyItem.BirthPlace,
                ClientApplicantId = freezedFamilyItem.ClientApplicantId,
                DeathDate = freezedFamilyItem.DeathDate,
                DeathPlace = freezedFamilyItem.DeathPlace,
                Email = freezedFamilyItem.Email,
                FamilyMemberId = freezedFamilyItem.FamilyMemberId,
                FamilyStructureId = freezedFamilyItem.FamilyStructureId,
                FreezedFamilyId = freezedFamilyItem.FreezedFamilyId,
                FreezedFamilyItemId = freezedFamilyItem.FreezedFamilyItemId,
                FullName = freezedFamilyItem.FullName,
                ConsortFullName = freezedFamilyItem.ConsortFullName,
                MarriageDate = freezedFamilyItem.MarriageDate,
                MarriagePlace = freezedFamilyItem.MarriagePlace,
                FamilyStructureDescription = StringUtils.FormatKinship(ca, fs.Description),
                FamilyMemberTypeId = fm.FamilyMemberTypeId,
                FamilyMemberTypeName = fm.Name
            };
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.FreezedFamily;
        }

        public override FreezedFamilyViewModel GetDataViewModel(FreezedFamily data)
        {
            var client = context.Client.Single(x => x.ClientId == data.ClientId);
            var createdBy = context.User.SingleOrDefault(x => x.UserId == data.CreatedBy);
            DB.User acceptedBy = data.AcceptedBy.HasValue ? context.User.SingleOrDefault(x => x.UserId == data.AcceptedBy.Value) : null;
            var freezedFamilyItemViewModel = GetFreezedFamilyItemViewModel(GetFreezedFamilyItems(data.FreezedFamilyId));

            return new DTO.FreezedFamily.FreezedFamilyViewModel
            {
                FreezedFamilyId = data.FreezedFamilyId,
                ClientId = data.ClientId,
                ClientName = client.FirstName + " " + client.LastName,
                CreatedBy = data.CreatedBy,
                _CreatedBy = createdBy == null ? "-" : createdBy.FirstName + " " + createdBy.LastName,
                CreatedDate = data.CreatedDate,
                Accepted = data.Accepted,
                AcceptedBy = data.AcceptedBy,
                _AcceptedBy = acceptedBy == null ? "-" : acceptedBy.FirstName + " " + acceptedBy.LastName,
                AcceptedDate = data.AcceptedDate,
                FreezedFamilyItemViewModel = freezedFamilyItemViewModel
            };
        }

        public override List<FreezedFamilyViewModel> GetDataViewModel(IEnumerable<FreezedFamily> data)
        {
            throw new NotImplementedException();
        }

        public void AcceptOrReproveFreezedFamily(int freezedFamilyId, bool accept, int acceptedBy)
        {
            var freezedFamily = this.dbSet.Single(x => x.FreezedFamilyId == freezedFamilyId);

            freezedFamily.Accepted = accept;
            freezedFamily.AcceptedBy = acceptedBy;
            freezedFamily.AcceptedDate = DateTime.Now;

            this.dbSet.Update(freezedFamily);
            this.context.SaveChanges();
        }

        public DB.FreezedFamilyItem GetFreezedFamilyItemById(int freezedFamilyItemId)
        {
            return context.FreezedFamilyItem.Single(x => x.FreezedFamilyItemId == freezedFamilyItemId);
        }
    }
}
