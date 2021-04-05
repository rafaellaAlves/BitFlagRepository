using DB;
using DTO.Invoice;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace FUNCTIONS.Invoice
{
    public class InvoicePaymentFunctions : BasicFunctions<DB.InvoicePayment, DTO.Invoice.InvoicePaymentViewModel>
    {
        public InvoicePaymentFunctions(TerraNostraContext context) 
            : base(context, "InvoicePaymentId")
        {
        }

        public void Create(IEnumerable<DTO.Invoice.InvoicePaymentViewModel> items)
        {
            context.InvoicePayment.AddRange(items.Select(x => new DB.InvoicePayment
            {
                InstallmentDate = x.InstallmentDate,
                InvoiceId = x.InvoiceId,
                Price = x.Price,
                Paid = x.Paid,
                PaymentDate = x.PaymentDate,
            }));

            context.SaveChanges();
        }

        public void DeleteByInvoiceId(int invoiceId)
        {
            context.RemoveRange(context.InvoicePayment.Where(x => x.InvoiceId == invoiceId));

            context.SaveChanges();
        }

        public override List<DTO.Invoice.InvoicePaymentViewModel> GetDataViewModel(IEnumerable<DB.InvoicePayment> items)
        {
            return items.Select(x => new InvoicePaymentViewModel
            {
                InstallmentDate = x.InstallmentDate,
                InvoiceId = x.InvoiceId,
                Price = x.Price,
                InvoicePaymentId = x.InvoicePaymentId,
                Paid = x.Paid,
                PaymentDate = x.PaymentDate,
            }).ToList();
        }

        public List<DB.InvoicePayment> GetDataByInvoiceId(int invoiceId)
        {
            return context.InvoicePayment.Where(x => x.InvoiceId == invoiceId).ToList();
        }

        public List<DTO.Invoice.InvoicePaymentListViewModel> List(DTO.Shared.DataTablesAjaxPostModel filter, out int recordsTotal, out int recordsFiltered, string whereSQL, params SqlParameter[] whereParameter)
        {
            var data = this.GetDataFiltered(filter, out recordsTotal, out recordsFiltered, whereSQL, whereParameter);

            return (from d in data
                    join i in context.Invoice on d.InvoiceId equals i.InvoiceId
                    join c in context.Client on i.ClientId equals c.ClientId
                    select new DTO.Invoice.InvoicePaymentListViewModel()
                    {
                        InstallmentDate = d.InstallmentDate,
                        InvoiceId = d.InvoiceId,
                        Price = d.Price,
                        InvoicePaymentId = d.InvoicePaymentId,
                        Paid = d.Paid,
                        ClientId = c.ClientId,
                        ClientName = string.IsNullOrWhiteSpace(c.FirstName)? c.RazaoSocial : c.FirstName + " " + c.LastName
                    }).ToList();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.InvoicePayment;
        }

        public override int Create(InvoicePaymentViewModel model)
        {

            var invoicePayment = new DB.InvoicePayment
            {
                InstallmentDate = model.InstallmentDate,
                InvoiceId = model.InvoiceId,
                Price = model.Price,
                Paid = model.Paid,
                PaymentDate = model.PaymentDate,
            };

            context.InvoicePayment.Add(invoicePayment);

            context.SaveChanges();

            return invoicePayment.InvoiceId;
        }

        public override void Update(InvoicePaymentViewModel model)
        {
            throw new NotImplementedException();
        }

        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public override InvoicePaymentViewModel GetDataViewModel(InvoicePayment data)
        {
            throw new NotImplementedException();
        }

        public void UpdateParcela(int parcelaId)
        {
            var parcela = this.GetDataByID(parcelaId);

            parcela.Paid = true;
            parcela.PaymentDate = DateTime.Now;

            this.context.Update(parcela);
            this.context.SaveChanges();
        }
    }
}
