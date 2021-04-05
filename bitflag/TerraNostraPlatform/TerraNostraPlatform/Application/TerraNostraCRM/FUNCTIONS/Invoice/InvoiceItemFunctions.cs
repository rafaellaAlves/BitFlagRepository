using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FUNCTIONS.Invoice
{
    public class InvoiceItemFunctions
    {
        private readonly DB.TerraNostraContext context;

        public InvoiceItemFunctions(DB.TerraNostraContext context)
        {
            this.context = context;
        }

        public void CreateInvoiceItem(List<DTO.Invoice.InvoiceItemViewModel> model)
        {
            var datas = model.Select(x => new DB.InvoiceItem
            {
                InvoiceId = x.InvoiceId,
                InvoiceItemServiceTypeId = x.InvoiceItemServiceTypeId,
                Value = x.Value
            });

            this.context.InvoiceItem.AddRange(datas);
            this.context.SaveChanges();
        }

        public List<DB.InvoiceItemServiceType> GetInvoiceItemServices(Func<DB.InvoiceItemServiceType, bool> func = null)
        {
            if (func == null) return this.context.InvoiceItemServiceType.ToList();

            return this.context.InvoiceItemServiceType.Where(func).ToList();
        }

        public List<DB.InvoiceItem> GetInvoiceItemByInvoiceId(int invoiceId)
        {
            return context.InvoiceItem.Where(x => x.InvoiceId == invoiceId).ToList();
        }

        public List<DTO.Invoice.InvoiceItemViewModel> GetInvoiceItemViewModel(IEnumerable<DB.InvoiceItem> model)
        {
            return (from x in model
                    join y in context.InvoiceItemServiceType on x.InvoiceItemServiceTypeId equals y.InvoiceItemServiceTypeId
                    select new DTO.Invoice.InvoiceItemViewModel
                    {
                        InvoiceId = x.InvoiceId,
                        InvoiceItemId = x.InvoiceItemId,
                        InvoiceItemServiceTypeId = x.InvoiceItemServiceTypeId,
                        InvoiceItemServiceTypeIsCredit = y.IsCredit,
                        InvoiceItemServiceTypeName = y.Name,
                        Value = x.Value
                    }).ToList();
        }

        public List<DTO.Invoice.InvoiceItemServiceTypeViewModel> GetInvoiceItemServiceTypeViewModel(IEnumerable<DB.InvoiceItemServiceType> model)
        {
            return model.Select(x => new DTO.Invoice.InvoiceItemServiceTypeViewModel
            {
                InvoiceItemServiceTypeId = x.InvoiceItemServiceTypeId,
                Name = x.Name,
                IsCredit = x.IsCredit,
                IsActive = x.IsActive.Value,
                Value = x.Value.Value,
                Order = x.Order
            }).ToList();
        }

        public void DeleteInvoiceItemByInvoiceId(int invoiceId)
        {
            this.context.InvoiceItem.RemoveRange(this.context.InvoiceItem.Where(x => x.InvoiceId == invoiceId));
            this.context.SaveChanges();
        }
    }
}
