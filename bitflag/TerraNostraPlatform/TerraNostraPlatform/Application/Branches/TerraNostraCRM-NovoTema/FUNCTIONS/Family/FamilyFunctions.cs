using FUNCTIONS.Utils;
using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FUNCTIONS.Family
{
    public class FamilyFunctions
    {
        private readonly DB.TerraNostraContext context;
        public FamilyFunctions(DB.TerraNostraContext context)
        {
            this.context = context;
        }

        public void SaveFamilyMember(DTO.Family.FamilyMemberViewModel familyMemberViewModel)
        {
            TryDeleteFamilyMember(familyMemberViewModel.ClientId, familyMemberViewModel.FamilyStructureId, familyMemberViewModel.ClientApplicantId);
            if (this.context.FamilyMember.Any(x => x.ClientId.Equals(familyMemberViewModel.ClientId) && x.FamilyStructureId.Equals(familyMemberViewModel.FamilyStructureId) && x.ClientApplicantId.Equals(familyMemberViewModel.ClientApplicantId))) return;
            var familyMember = new DB.FamilyMember()
            {
                ClientId = familyMemberViewModel.ClientId,
                FamilyStructureId = familyMemberViewModel.FamilyStructureId,
                FullName = familyMemberViewModel.FullName,
                ConsortFullName = familyMemberViewModel.ConsortFullName,
                DeathDate = familyMemberViewModel.DeathDate,
                BirthDate = familyMemberViewModel.BirthDate,
                MarriageDate = familyMemberViewModel.MarriageDate,
                BirthPlace = familyMemberViewModel.BirthPlace,
                MarriagePlace = familyMemberViewModel.MarriagePlace,
                DeathPlace = familyMemberViewModel.DeathPlace,
                ClientApplicantId = familyMemberViewModel.ClientApplicantId
            };
            this.context.Add(familyMember);
            this.context.SaveChanges();
        }
        public void SaveApplicant(DTO.Family.FamilyMemberViewModel familyMemberViewModel)
        {
            var applicant = context.ClientApplicant.SingleOrDefault(x => x.ClientApplicantId == familyMemberViewModel.ClientApplicantId);

            applicant.Email = familyMemberViewModel.Email;
            applicant.FullName = familyMemberViewModel.FullName;
            applicant.ConsortFullName = familyMemberViewModel.ConsortFullName;
            applicant.BirthDate = familyMemberViewModel.BirthDate;
            applicant.BirthPlace = familyMemberViewModel.BirthPlace;
            applicant.MarriageDate = familyMemberViewModel.MarriageDate;
            applicant.MarriagePlace = familyMemberViewModel.MarriagePlace;

            this.context.Update(applicant);
            this.context.SaveChanges();
        }
        public void TryDeleteFamilyMember(int clientId, int familyStructureId, int clientApplicantId)
        {
            var familyMember = this.context.FamilyMember.SingleOrDefault(x => x.ClientId.Equals(clientId) && x.FamilyStructureId.Equals(familyStructureId) && x.ClientApplicantId.Equals(clientApplicantId));

            if (familyMember != null)
            {
                this.context.Remove(familyMember);
                this.context.SaveChanges();
            }
        }
        public DTO.Family.FamilyMemberViewModel GetFamilyMember(int clientId, int familyStructureId)
        {
            var familyMember = this.context.FamilyMember.SingleOrDefault(x => x.ClientId.Equals(clientId) && x.FamilyStructureId.Equals(familyStructureId));

            if (familyMember == null) return null;

            return new DTO.Family.FamilyMemberViewModel()
            {
                ClientId = familyMember.ClientId,
                FamilyStructureId = familyMember.FamilyStructureId,
                FullName = familyMember.FullName,
                ConsortFullName = familyMember.ConsortFullName,
                DeathDate = familyMember.DeathDate,
                BirthDate = familyMember.BirthDate,
                MarriageDate = familyMember.MarriageDate,
                BirthPlace = familyMember.BirthPlace,
                MarriagePlace = familyMember.MarriagePlace,
                DeathPlace = familyMember.DeathPlace,
                ClientApplicantId = familyMember.ClientApplicantId
            };
        }
        public List<DTO.Family.FamilyStructureItemViewModel> GetStructuredFamily(int clientId, int clientApplicantId)
        {
            var q = (from fs in context.FamilyStructure
                     join fmt in context.FamilyMemberType on fs.FamilyMemberTypeId equals fmt.FamilyMemberTypeId
                     from fm in context.FamilyMember.Where(x => x.ClientId.Equals(clientId) && x.FamilyStructureId.Equals(fs.FamilyStructureId) && x.ClientApplicantId == clientApplicantId).DefaultIfEmpty()
                     select new
                     {
                         fs.FamilyStructureId,
                         fmt.FamilyMemberTypeId,
                         fmt.Name,
                         fs.Description,
                         fs.ParentId,
                         FamilyMember = fm,
                         clientId,
                         clientApplicantId
                     }).ToList();



            return BuildFamilyStructure(q, null);
        }
        private List<DTO.Family.FamilyStructureItemViewModel> BuildFamilyStructure(IEnumerable<dynamic> list, int? parentId)
        {
            var items = (from x in list
                         where x.ParentId == parentId
                         select new DTO.Family.FamilyStructureItemViewModel()
                         {
                             FamilyStructureId = x.FamilyStructureId,
                             ClientApplicantId = (int)x.clientApplicantId,
                             ClientId = (int)x.clientId,
                             FamilyMemberId = null,
                             FamilyMemberTypeId = x.FamilyMemberTypeId,
                             FamilyMemberTypeName = x.Name,
                             FamilyMemberTypeDescription = x.Description,
                             FamilyMemberViewModel = (x.FamilyMember == null ? null : new DTO.Family.FamilyMemberViewModel()
                             {
                                 ClientId = (int)x.clientId,
                                 FullName = (string)x.FamilyMember.FullName,
                                 ConsortFullName = (string)x.FamilyMember.ConsortFullName,
                                 DeathDate = (DateTime?)x.FamilyMember.DeathDate,
                                 BirthDate = (DateTime?)x.FamilyMember.BirthDate,
                                 MarriageDate = (DateTime?)x.FamilyMember.MarriageDate,
                                 BirthPlace = (string)x.FamilyMember.BirthPlace,
                                 MarriagePlace = (string)x.FamilyMember.MarriagePlace,
                                 DeathPlace = (string)x.FamilyMember.DeathPlace,
                                 ClientApplicantId = (int)x.FamilyMember.ClientApplicantId
                             })
                         }).ToList();

            foreach (var item in items)
                item.Items = BuildFamilyStructure(list, item.FamilyStructureId);

            return items;
        }
        public List<DTO.Family.CondensedFamilyStructureItemViewModel> GetCondesedFamilyStructure(int clientId)
        {
            var applicantFamilyMemberId = context.FamilyMemberType.Single(x => x.ExternalCode == "APPLICANT").FamilyMemberTypeId;
            var applicantFamilyStructureId = context.FamilyStructure.Single(x => x.FamilyMemberTypeId == applicantFamilyMemberId).FamilyStructureId;

            return (from ca in context.ClientApplicant //Obtem os requerentes
                    where ca.ClientId == clientId
                    select new DTO.Family.CondensedFamilyStructureItemViewModel
                    {
                        FullName = ca.FullName,
                        ConsortFullName = ca.ConsortFullName,
                        BirthDate = ca.BirthDate,
                        BirthPlace = ca.BirthPlace,
                        MarriageDate = ca.MarriageDate,
                        MarriagePlace = ca.MarriagePlace,
                        Kinship = "Requerente",
                        ClientApplicantId = ca.ClientApplicantId,
                        FamilyMemberTypeId = applicantFamilyMemberId,
                        FamilyStructureId = applicantFamilyStructureId,
                        Email = ca.Email
                    }).Union(from fs in context.FamilyStructure //Obtem os membros da familia
                             join fmt in context.FamilyMemberType on fs.FamilyMemberTypeId equals fmt.FamilyMemberTypeId
                             join fm in context.FamilyMember on fs.FamilyStructureId equals fm.FamilyStructureId
                             join ca in context.ClientApplicant on fm.ClientApplicantId equals ca.ClientApplicantId into _ca
                             from __ca in _ca.DefaultIfEmpty()
                             where fm.ClientId == clientId
                             select new DTO.Family.CondensedFamilyStructureItemViewModel
                             {
                                 FamilyMemberId = fm.FamilyMemberId,
                                 ClientApplicantId = fm.ClientApplicantId,
                                 FamilyMemberTypeId = fmt.FamilyMemberTypeId,
                                 FullName = fm.FullName,
                                 ConsortFullName = fm.ConsortFullName,
                                 Kinship = StringUtils.FormatKinship(__ca, fs.Description),
                                 BirthPlace = fm.BirthPlace,
                                 BirthDate = fm.BirthDate,
                                 MarriagePlace = fm.MarriagePlace,
                                 MarriageDate = fm.MarriageDate,
                                 DeathPlace = fm.DeathPlace,
                                 DeathDate = fm.DeathDate,
                                 FamilyStructureId = fs.FamilyStructureId
                             }).ToList();
        }
        
        public DB.FamilyStructure GetFamilyStructure(int familyStructureId)
        {
            return context.FamilyStructure.SingleOrDefault(x => x.FamilyStructureId == familyStructureId);
        }

        public List<DB.FamilyStructure> GetFamilyStructureByFamilyMemberTypeId(int familyMemberTypeId)
        {
            return context.FamilyStructure.Where(x => x.FamilyMemberTypeId == familyMemberTypeId).ToList();
        }

        public void DeleteByClientApplicantId(int clientApplicantId)
        {
            var familyMermbers = this.context.FamilyMember.Where(x => x.ClientApplicantId == clientApplicantId);
            this.context.FamilyMember.RemoveRange(familyMermbers);

            this.context.SaveChanges();
        }

        public List<DB.FamilyMemberType> GetFamilyMemberTypeByExternalCode(params string[] externalCodes)
        {
            return this.context.FamilyMemberType.Where(x => externalCodes.Contains(x.ExternalCode)).ToList();
        }
    }
}
