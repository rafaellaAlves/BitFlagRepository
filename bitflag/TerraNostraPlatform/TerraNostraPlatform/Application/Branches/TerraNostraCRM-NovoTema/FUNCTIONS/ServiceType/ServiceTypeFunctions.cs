using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DB;
using DTO.ServiceType;

namespace FUNCTIONS.ServiceType
{
    public class ServiceTypeFunctions : BasicFunctions<DB.ServiceType, ServiceTypeViewModel>
    {
        public ServiceTypeFunctions(TerraNostraContext context)
            : base(context, "ServiceTypeId")
        {
        }

        public override int Create(ServiceTypeViewModel model)
        {
            var serviceType = new DB.ServiceType
            {
                Name = model.Name,
                ExternalCode = model.ExternalCode,
                Description = model.Description
            };

            this.dbSet.Add(serviceType);
            this.context.SaveChanges();

            return serviceType.ServiceTypeId;
        }

        public override void Delete(object id)
        {
            var serviceType = GetDataByID(id);

            serviceType.IsDeleted = true;

            this.dbSet.Update(serviceType);
            this.context.SaveChanges();
        }

        public override List<ServiceTypeViewModel> GetDataViewModel(IEnumerable<DB.ServiceType> data)
        {
            return (from y in data
                    select new ServiceTypeViewModel
                    {
                        ExternalCode = y.ExternalCode,
                        Name = y.Name,
                        ServiceTypeId = y.ServiceTypeId,
                        Description = y.Description
                    }).ToList();
        }

        public override ServiceTypeViewModel GetDataViewModel(DB.ServiceType data)
        {
            return new ServiceTypeViewModel
            {
                ExternalCode = data.ExternalCode,
                Name = data.Name,
                ServiceTypeId = data.ServiceTypeId,
                Description = data.Description
            };
        }

        public override void Update(ServiceTypeViewModel model)
        {
            var serviceType = GetDataByID(model.ServiceTypeId);

            serviceType.Name = model.Name;
            serviceType.ExternalCode = model.ExternalCode;
            serviceType.Description = model.Description;

            this.dbSet.Update(serviceType);
            this.context.SaveChanges();
        }

        public bool ExistExternalCode(string ec, int? id)
        {
            return this.dbSet.Any(x => x.ServiceTypeId != id && x.ExternalCode == ec && !x.IsDeleted);
        }

        public bool CanDelete(int? id)
        {
            return !this.context.Indication.Any(x => x.ServiceTypeId == id && !x.IsDeleted);
        }
        public string GetServiceName(int id)
        {
            return this.GetDataByID(id).Name;
        }
        protected override void SetDbSet()
        {
            this.dbSet = context.ServiceType;
        }
    }
}
