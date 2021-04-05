using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using DB;
using DTO.Invoice;
using DTO.Utils;

namespace FUNCTIONS.Invoice
{
    public class InvoiceFunctions : BasicFunctions<DB.Invoice, DTO.Invoice.InvoiceViewModel>
    {
        FUNCTIONS.SystemVariable.SystemVariableFunctions systemVariableFunctions;
        FUNCTIONS.Family.FreezedFamilyFunctions freezedFamilyFunctions;
        FUNCTIONS.Family.FamilyFunctions familyFunctions;
        FUNCTIONS.Job.JobFunctions jobFunctions;
        FUNCTIONS.Invoice.InvoiceViewFunctions invoiceViewFunctions;
        public InvoiceFunctions(TerraNostraContext context, FUNCTIONS.SystemVariable.SystemVariableFunctions systemVariableFunctions, FUNCTIONS.Family.FreezedFamilyFunctions freezedFamilyFunctions, FUNCTIONS.Family.FamilyFunctions familyFunctions, FUNCTIONS.Job.JobFunctions jobFunctions, FUNCTIONS.Invoice.InvoiceViewFunctions invoiceViewFunctions)
            : base(context, "InvoiceId")
        {
            this.systemVariableFunctions = systemVariableFunctions;
            this.freezedFamilyFunctions = freezedFamilyFunctions;
            this.familyFunctions = familyFunctions;
            this.jobFunctions = jobFunctions;
            this.invoiceViewFunctions = invoiceViewFunctions;
        }

        public List<DTO.Invoice.InvoiceListViewModel> List(DTO.Shared.DataTablesAjaxPostModel filter, out int recordsTotal, out int recordsFiltered, string whereSQL, params SqlParameter[] whereParameter)
        {
            var data = this.invoiceViewFunctions.GetDataFiltered(filter, out recordsTotal, out recordsFiltered, whereSQL, whereParameter);

            return (from d in data select d.CopyToEntity<InvoiceListViewModel>()).ToList();
        }

        public override int Create(DTO.Invoice.InvoiceViewModel model)
        {
            int? maxExternalCode = this.context.Invoice.Max(x => x.ExternalCode);
            if (maxExternalCode != null)
            {
                maxExternalCode = maxExternalCode + 1;
            }
            else
            {
                maxExternalCode = 1;
            }
            var invoice = new DB.Invoice
            {
                BrazilianCertificateCost = model.BrazilianCertificateCost,
                ClientId = model.ClientId,
                Cost = model.Cost,
                CreatedBy = model.CreatedBy,
                EuroExchange = model.EuroExchange,
                FreezedFamilyId = model.FreezedFamilyId,
                GrandTotal = model.GrandTotal,
                InvoiceServiceTypeId = model.InvoiceServiceTypeId,
                ItalianCertificateCost = model.ItalianCertificateCost,
                Tax = model.Tax,
                HaiaHandoutCost = model.HaiaHandoutCost,
                TranslationCost = model.TranslationCost,
                Cnncost = model.CNNCost,
                ApplicantCost = model.ApplicantCost,
                LetterOfAttorneyCost = model.LetterOfAttorneyCost,
                ProcessCost = model.ProcessCost,
                InvoiceStatusId = model.InvoiceStatusId,
                Comments = model.Comments,
                IsLocked = model.IsLocked,
                InvoicePaymentTypeId = model.InvoicePaymentTypeId,
                InvoicePaymentWayId = model.InvoicePaymentWayId,
                ExternalCode = maxExternalCode
            };

            this.dbSet.Add(invoice);
            this.context.SaveChanges();

            return invoice.InvoiceId;
        }

        public override void Delete(object id)
        {
            this.dbSet.Remove(this.dbSet.Find(id));
            this.context.SaveChanges();
        }

        public override List<DTO.Invoice.InvoiceViewModel> GetDataViewModel(IEnumerable<DB.Invoice> datas)
        {
            return (from data in datas
                    select new DTO.Invoice.InvoiceViewModel
                    {
                        AlteredBy = data.AlteredBy,
                        AlteredDate = data.AlteredDate,
                        BrazilianCertificateCost = data.BrazilianCertificateCost,
                        ClientId = data.ClientId,
                        Cost = data.Cost,
                        CreatedBy = data.CreatedBy,
                        CreatedDate = data.CreatedDate.Value,
                        EuroExchange = data.EuroExchange,
                        FreezedFamilyId = data.FreezedFamilyId,
                        GrandTotal = data.GrandTotal,
                        InvoiceId = data.InvoiceId,
                        InvoiceServiceTypeId = data.InvoiceServiceTypeId,
                        ItalianCertificateCost = data.ItalianCertificateCost,
                        Tax = data.Tax,
                        HaiaHandoutCost = data.HaiaHandoutCost,
                        TranslationCost = data.TranslationCost,
                        InvoiceStatusId = data.InvoiceStatusId,
                        Comments = data.Comments,
                        IsLocked = data.IsLocked,
                        CNNCost = data.Cnncost,
                        ProcessCost = data.ProcessCost,
                        ApplicantCost = data.ApplicantCost,
                        LetterOfAttorneyCost = data.LetterOfAttorneyCost,
                        InvoicePaymentTypeId = data.InvoicePaymentTypeId,
                        InvoicePaymentWayId = data.InvoicePaymentWayId,
                        ExternalCode = data.ExternalCode
                    }).ToList();
        }

        public void UpdateValues(int invoiceId, out double grandTotal)
        {
            var invoice = this.context.Invoice.Find(invoiceId);
            //var tax = 0.0d;
            //try
            //{
            //    var _tax = systemVariableFunctions.Get("IMPOSTO");
            //    tax = float.Parse(_tax);
            //}
            //catch { }

            int applicantFamilyStructureId = 0;
            try
            {
                var applicantFamilyMemberType = familyFunctions.GetFamilyMemberTypeByExternalCode("APPLICANT").SingleOrDefault();
                if (applicantFamilyMemberType != null)
                    applicantFamilyStructureId = familyFunctions.GetFamilyStructureByFamilyMemberTypeId(applicantFamilyMemberType.FamilyMemberTypeId).Single().FamilyStructureId;
                else
                    applicantFamilyStructureId = 0;
            }
            catch { }



            var invoicePaymentType = context.InvoicePaymentType.SingleOrDefault(x => x.InvoicePaymentTypeId == invoice.InvoicePaymentTypeId);
            var invoicePaymentTypeTaxes = 0.0d;
            if (invoicePaymentType != null && invoicePaymentType.Taxes.HasValue)
            {
                invoicePaymentTypeTaxes = invoicePaymentType.Taxes.Value;
            }

            double freezedFamilyItemsValue = 0.0;
            int applicantQuantity = 0;
            foreach (var invoiceFreezedFamilyItem in this.context.InvoiceFreezedFamilyItem.Where(x => x.InvoiceId == invoice.InvoiceId))
            {
                var freezedFamilyItem = this.context.FreezedFamilyItem.FirstOrDefault(x => x.FreezedFamilyItemId == invoiceFreezedFamilyItem.FreezedFamilyItemId);
                if (freezedFamilyItem != null)
                    if (freezedFamilyItem.FamilyStructureId == applicantFamilyStructureId)
                        applicantQuantity++;

                if (invoiceFreezedFamilyItem.BirthCertificateBra) freezedFamilyItemsValue += invoice.BrazilianCertificateCost.Value;
                if (invoiceFreezedFamilyItem.BirthCertificateIta) freezedFamilyItemsValue += invoice.EuroExchange.Value * invoice.ItalianCertificateCost.Value;
                if (invoiceFreezedFamilyItem.MarriageCertificateBra) freezedFamilyItemsValue += invoice.BrazilianCertificateCost.Value;
                if (invoiceFreezedFamilyItem.MarriageCertificateIta) freezedFamilyItemsValue += invoice.EuroExchange.Value * invoice.ItalianCertificateCost.Value;
                if (invoiceFreezedFamilyItem.DeathCertificateBra) freezedFamilyItemsValue += invoice.BrazilianCertificateCost.Value;
                if (invoiceFreezedFamilyItem.DeathCertificateIta) freezedFamilyItemsValue += invoice.EuroExchange.Value * invoice.ItalianCertificateCost.Value;

                if (invoiceFreezedFamilyItem.BirthCertificateTranslation) freezedFamilyItemsValue += invoice.TranslationCost.Value;
                if (invoiceFreezedFamilyItem.MarriageCertificateTranslation) freezedFamilyItemsValue += invoice.TranslationCost.Value;
                if (invoiceFreezedFamilyItem.DeathCertificateTranslation) freezedFamilyItemsValue += invoice.TranslationCost.Value;

                if (invoiceFreezedFamilyItem.BirthCertificateHaiaHandout) freezedFamilyItemsValue += invoice.HaiaHandoutCost.Value;
                if (invoiceFreezedFamilyItem.MarriageCertificateHaiaHandout) freezedFamilyItemsValue += invoice.HaiaHandoutCost.Value;
                if (invoiceFreezedFamilyItem.DeathCertificateHaiaHandout) freezedFamilyItemsValue += invoice.HaiaHandoutCost.Value;

                if (invoiceFreezedFamilyItem.Cnn) freezedFamilyItemsValue += invoice.Cnncost.Value;
            }

            double custoItalia = 0.0;
            custoItalia += invoice.EuroExchange.Value * (invoice.ProcessCost ?? 0.0d);
            custoItalia += invoice.EuroExchange.Value * (applicantQuantity * (invoice.ApplicantCost ?? 0.0d));
            custoItalia += (applicantQuantity * (invoice.LetterOfAttorneyCost ?? 0.0d));

            var items = (from ii in this.context.InvoiceItem
                         join ist in this.context.InvoiceItemServiceType on ii.InvoiceItemServiceTypeId equals ist.InvoiceItemServiceTypeId
                         where ii.InvoiceId == invoice.InvoiceId
                         select new { ii, ist });

            double invoiceItemsValue = 0.0;
            foreach (var item in items)
                invoiceItemsValue += item.ist.IsCredit ? item.ii.Value : -item.ii.Value;

            invoice.Cost = freezedFamilyItemsValue + custoItalia + invoiceItemsValue;
            //invoice.Tax = tax;
            invoice.GrandTotal = invoice.Cost + (invoice.Cost * ((!invoice.Tax.HasValue ? 0d : invoice.Tax.Value) / 100d));
            invoice.GrandTotal += (invoice.GrandTotal * (invoicePaymentTypeTaxes / 100d));

            grandTotal = invoice.GrandTotal.Value;

            this.context.SaveChanges();
        }

        public bool ShouldLock(int? invoiceStatusId)
        {
            if (!invoiceStatusId.HasValue) return false;

            var invoiceStatus = this.context.InvoiceStatus.Find(invoiceStatusId.Value);
            switch (invoiceStatus.ExternalCode)
            {
                case "APPROVED":
                case "REPPROVED":
                    return true;
                default:
                    return false;
            }
        }

        public void Lock(int invoiceId)
        {
            var invoice = this.context.Invoice.Find(invoiceId);
            invoice.IsLocked = true;

            this.context.SaveChanges();
        }

        public bool IsLocked(int invoiceId)
        {
            var invoice = this.context.Invoice.Find(invoiceId);
            return invoice.IsLocked;
        }

        public void CreateNewJobFromInvoiceIfApproved(int invoiceId)
        {
            var invoice = this.context.Invoice.Find(invoiceId);
            var invoiceServiceType = this.context.InvoiceServiceType.Find(invoice.InvoiceServiceTypeId);
            var invoiceStatus = this.context.InvoiceStatus.Find(invoice.InvoiceStatusId.Value);

            if (invoiceStatus.ExternalCode == "APPROVED")
            {
                jobFunctions.Create(invoice.ClientId, invoiceServiceType.InvoiceServiceTypeId, invoiceId);
            }
        }

        public override DTO.Invoice.InvoiceViewModel GetDataViewModel(DB.Invoice data)
        {
            return new DTO.Invoice.InvoiceViewModel
            {
                AlteredBy = data.AlteredBy,
                AlteredDate = data.AlteredDate,
                BrazilianCertificateCost = data.BrazilianCertificateCost,
                ClientId = data.ClientId,
                Cost = data.Cost,
                CreatedBy = data.CreatedBy,
                CreatedDate = data.CreatedDate.Value,
                EuroExchange = data.EuroExchange,
                FreezedFamilyId = data.FreezedFamilyId,
                GrandTotal = data.GrandTotal,
                InvoiceId = data.InvoiceId,
                InvoiceServiceTypeId = data.InvoiceServiceTypeId,
                ItalianCertificateCost = data.ItalianCertificateCost,
                Tax = data.Tax,
                HaiaHandoutCost = data.HaiaHandoutCost,
                TranslationCost = data.TranslationCost,
                InvoiceStatusId = data.InvoiceStatusId,
                Comments = data.Comments,
                IsLocked = data.IsLocked,
                CNNCost = data.Cnncost,
                ProcessCost = data.ProcessCost,
                ApplicantCost = data.ApplicantCost,
                LetterOfAttorneyCost = data.LetterOfAttorneyCost,
                InvoicePaymentTypeId = data.InvoicePaymentTypeId,
                InvoicePaymentWayId = data.InvoicePaymentWayId,
                ExternalCode = data.ExternalCode
            };
        }

        public override void Update(DTO.Invoice.InvoiceViewModel model)
        {
            var invoice = GetDataByID(model.InvoiceId);

            invoice.BrazilianCertificateCost = model.BrazilianCertificateCost;
            invoice.ClientId = model.ClientId;
            invoice.Cost = model.Cost;
            invoice.EuroExchange = model.EuroExchange;
            invoice.FreezedFamilyId = model.FreezedFamilyId;
            invoice.GrandTotal = model.GrandTotal;
            invoice.InvoiceServiceTypeId = model.InvoiceServiceTypeId;
            invoice.ItalianCertificateCost = model.ItalianCertificateCost;
            invoice.Tax = model.Tax;
            invoice.AlteredBy = model.AlteredBy;
            invoice.AlteredDate = DateTime.Now;
            invoice.HaiaHandoutCost = model.HaiaHandoutCost;
            invoice.TranslationCost = model.TranslationCost;
            invoice.InvoiceStatusId = model.InvoiceStatusId;
            invoice.Comments = model.Comments;
            invoice.IsLocked = model.IsLocked;
            invoice.Cnncost = model.CNNCost;
            invoice.ProcessCost = model.ProcessCost;
            invoice.ApplicantCost = model.ApplicantCost;
            invoice.LetterOfAttorneyCost = model.LetterOfAttorneyCost;
            invoice.InvoicePaymentTypeId = model.InvoicePaymentTypeId;
            invoice.InvoicePaymentWayId = model.InvoicePaymentWayId;

            this.dbSet.Update(invoice);
            this.context.SaveChanges();
        }

        public List<DB.InvoiceServiceType> GetInvoiceServiceTypes()
        {
            return context.InvoiceServiceType.ToList();
        }

        public DB.InvoiceServiceType GetInvoiceServiceTypeById(int invoiceServiceTypeId)
        {
            return context.InvoiceServiceType.Single(x => x.InvoiceServiceTypeId == invoiceServiceTypeId);
        }

        public List<DB.InvoicePaymentWay> GetInvoicePaymentWays()
        {
            return context.InvoicePaymentWay.ToList();
        }


        protected override void SetDbSet()
        {
            this.dbSet = this.context.Invoice;
        }
    }
}
