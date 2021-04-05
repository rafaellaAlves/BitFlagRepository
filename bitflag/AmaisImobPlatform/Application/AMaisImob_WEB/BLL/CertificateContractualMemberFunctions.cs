using AMaisImob_DB.Models;
using AMaisImob_WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using AMaisImob_WEB.Utils;

namespace AMaisImob_WEB.BLL
{
    public class CertificateContractualMemberFunctions : BLLBasicFunctions<CertificateContractualMember, CertificateContractualMemberViewModel>
    {
        public CertificateContractualMemberFunctions(AMaisImob_HomologContext context) : base(context, "CertificateContractualMemberId")
        {
        }

        public override int Create(CertificateContractualMemberViewModel model)
        {
            var entity = model.CopyToEntity<CertificateContractualMember>();

            this.dbSet.Add(entity);
            this.context.SaveChanges();

            return entity.CertificateContractualMemberId;
        }

        public void CreateRange(List<CertificateContractualMemberViewModel> model)
        {
            var entities = model.Select(x => x.CopyToEntity<CertificateContractualMember>());

            this.dbSet.AddRange(entities);
            this.context.SaveChanges();
        }

        public override void Delete(object id)
        {
            var entity = GetDataByID(id);

            this.dbSet.Remove(entity);
            this.context.SaveChanges();
        }

        public void DeleteByCertificateContractualId(int certificateContractualId)
        {
            var entities = this.dbSet.Where(x => x.CertificateContractualId == certificateContractualId);

            this.dbSet.RemoveRange(entities);
            this.context.SaveChanges();
        }
        public IEnumerable<CertificateContractualMember> GetByCertificateContractualId(int certificateContractualId)
        {
            return this.dbSet.Where(x => x.CertificateContractualId == certificateContractualId);
        }

        public override List<CertificateContractualMemberViewModel> GetDataViewModel(IEnumerable<CertificateContractualMember> data)
        {
            return data.Select(x => x.CopyToEntity<CertificateContractualMemberViewModel>()).ToList();
        }

        public override CertificateContractualMemberViewModel GetDataViewModel(CertificateContractualMember data)
        {
            return data.CopyToEntity<CertificateContractualMemberViewModel>();
        }

        public override void Update(CertificateContractualMemberViewModel model)
        {
            throw new NotImplementedException();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.CertificateContractualMember;
        }
    }
}
