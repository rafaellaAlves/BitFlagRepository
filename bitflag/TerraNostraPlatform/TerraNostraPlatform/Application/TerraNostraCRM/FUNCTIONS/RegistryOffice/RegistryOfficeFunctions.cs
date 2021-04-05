using DB;
using DTO.RegistryOffice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FUNCTIONS.RegistryOffice
{
    public class RegistryOfficeFunctions : BasicFunctions<DB.RegistryOffice, DTO.RegistryOffice.RegistryOfficeViewModel>
    {
        public RegistryOfficeFunctions(TerraNostraContext context) : base(context, "RegistryOfficeId")
        {
        }

        public override int Create(RegistryOfficeViewModel model)
        {
            var registryOffice = new DB.RegistryOffice()
            {
                Name = model.Name,
                Phone = model.Phone,
                Email = model.Email,
                Country = model.Country,
                City = model.City,
                State = model.State,
                CreatedDate = DateTime.Now,
                CreatedBy = model.LastHandler,
                DeletedDate = null,
                DeletedBy = null,
                IsDeleted = false
            };

            this.dbSet.Add(registryOffice);
            this.context.SaveChanges();

            return registryOffice.RegistryOfficeId;
        }
        public override void Delete(object id)
        {
            var registryOffice = this.dbSet.Find(id);
            registryOffice.DeletedDate = DateTime.Now;
            registryOffice.DeletedBy = -1;
            registryOffice.IsDeleted = true;

            this.dbSet.Update(registryOffice);
            this.context.SaveChanges();
        }
        public override List<RegistryOfficeViewModel> GetDataViewModel(IEnumerable<DB.RegistryOffice> data)
        {
            return (from y in data
                    select new RegistryOfficeViewModel()
                    {
                        RegistryOfficeId = y.RegistryOfficeId,
                        Name = y.Name,
                        Phone = y.Phone,
                        Email = y.Email,
                        Country = y.Country,
                        City = y.City,
                        State = y.State
                    }).ToList();
        }
        public override RegistryOfficeViewModel GetDataViewModel(DB.RegistryOffice data)
        {
            return (new RegistryOfficeViewModel()
            {
                RegistryOfficeId = data.RegistryOfficeId,
                Name = data.Name,
                Phone = data.Phone,
                Email = data.Email,
                Country = data.Country,
                City = data.City,
                State = data.State
            });
        }

        public override void Update(RegistryOfficeViewModel model)
        {
            var registryOffice = this.dbSet.Find(model.RegistryOfficeId.Value);

            registryOffice.Name = model.Name;
            registryOffice.Phone = model.Phone;
            registryOffice.Email = model.Email;
            registryOffice.Country = model.Country;
            registryOffice.City = model.City;
            registryOffice.State = model.State;

            this.dbSet.Update(registryOffice);
            this.context.SaveChanges();
        }

        protected override void SetDbSet()
        {
            this.dbSet = this.context.RegistryOffice;
        }
    }
}
