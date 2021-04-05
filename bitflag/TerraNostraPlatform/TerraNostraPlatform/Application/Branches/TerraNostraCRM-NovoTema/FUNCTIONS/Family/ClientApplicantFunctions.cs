using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DB;
using DTO.Family;

namespace FUNCTIONS.Family
{
    public class ClientApplicantFunctions : BasicFunctions<DB.ClientApplicant, DTO.Family.ClientApplicant>
    {
        public ClientApplicantFunctions(TerraNostraContext context) :
            base(context, "ClientApplicantId")
        {
        }

        public override int Create(DTO.Family.ClientApplicant model)
        {
            var clientApplicant = new DB.ClientApplicant
            {
                ClientId = model.ClientId.Value,
                Email = model.Email,
                FullName = model.FullName
            };

            this.dbSet.Add(clientApplicant);
            this.context.SaveChanges();

            return clientApplicant.ClientApplicantId;
        }

        public override void Delete(object id)
        {
            var clientApplicant = GetDataByID(id);

            this.dbSet.Remove(clientApplicant);
            this.context.SaveChanges();
        }

        public override List<DTO.Family.ClientApplicant> GetDataViewModel(IEnumerable<DB.ClientApplicant> data)
        {
            return (from y in data
                    select new DTO.Family.ClientApplicant
                    {
                        ClientApplicantId = y.ClientApplicantId,
                        ClientId = y.ClientId,
                        Email = y.Email,
                        FullName = y.FullName
                    }).ToList();
        }

        public override DTO.Family.ClientApplicant GetDataViewModel(DB.ClientApplicant data)
        {
            return new DTO.Family.ClientApplicant
            {
                ClientApplicantId = data.ClientApplicantId,
                ClientId = data.ClientId,
                Email = data.Email,
                FullName = data.FullName
            };
        }

        public override void Update(DTO.Family.ClientApplicant model)
        {
            var clientApplicant = GetDataByID(model.ClientApplicantId);

            clientApplicant.ClientId = model.ClientId.Value;
            clientApplicant.Email = model.Email;
            clientApplicant.FullName = model.FullName;

            this.dbSet.Update(clientApplicant);
            this.context.SaveChanges();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.ClientApplicant;
        }

        public List<DB.ClientApplicant> GetDataByClientId(int clientId)
        {
            return this.dbSet.Where(x => x.ClientId == clientId).ToList();
        }

        public bool AnyByClientId(int clientId)
        {
            return this.dbSet.Any(x => x.ClientId == clientId);
        }
    }
}
