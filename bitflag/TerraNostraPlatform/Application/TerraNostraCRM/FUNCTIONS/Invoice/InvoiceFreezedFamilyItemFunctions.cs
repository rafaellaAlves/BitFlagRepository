using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DB;
using DTO.Invoice;
using FUNCTIONS.Family;
using FUNCTIONS.Utils;

namespace FUNCTIONS.Invoice
{
    public class InvoiceFreezedFamilyItemFunctions : BasicFunctions<DB.InvoiceFreezedFamilyItem, DB.InvoiceFreezedFamilyItem>
    {
        private readonly FreezedFamilyFunctions freezedFamilyFunctions;
        private readonly InvoiceItemFunctions invoiceItemFunctions;
        private readonly InvoicePaymentFunctions invoicePaymentFunctions;

        public InvoiceFreezedFamilyItemFunctions(TerraNostraContext context, FreezedFamilyFunctions freezedFamilyFunctions, InvoiceItemFunctions invoiceItemFunctions, InvoicePaymentFunctions invoicePaymentFunctions)
            : base(context, "InvoiceFreezedFamilyItemId")
        {
            this.freezedFamilyFunctions = freezedFamilyFunctions;
            this.invoiceItemFunctions = invoiceItemFunctions;
            this.invoicePaymentFunctions = invoicePaymentFunctions;
        }

        public override int Create(InvoiceFreezedFamilyItem model)
        {
            this.dbSet.Add(model);
            this.context.SaveChanges();

            return model.FreezedFamilyItemId;
        }

        public void Create(List<InvoiceFreezedFamilyItem> model)
        {
            this.dbSet.AddRange(model);
            this.context.SaveChanges();
        }

        public override void Delete(object id)
        {
            this.dbSet.Remove(this.GetDataByID(id));
            this.context.SaveChanges();
        }

        public void DeleteByInvoiceId(int invoiceId)
        {
            var items = this.context.InvoiceFreezedFamilyItem.Where(x => x.InvoiceId == invoiceId);
            this.dbSet.RemoveRange(items);
            this.context.SaveChanges();
        }

        public override List<InvoiceFreezedFamilyItem> GetDataViewModel(IEnumerable<InvoiceFreezedFamilyItem> data)
        {
            return data.ToList();
        }

        public override InvoiceFreezedFamilyItem GetDataViewModel(InvoiceFreezedFamilyItem data)
        {
            return data;
        }

        public override void Update(InvoiceFreezedFamilyItem model)
        {
            throw new NotImplementedException();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.InvoiceFreezedFamilyItem;
        }

        public FreezedFamilyInvoiceViewModel GetFreezedFamilyInvoiceViewModel(int freezedFamilyId, int invoiceId)
        {
            var data = this.context.FreezedFamily.Single(x => x.FreezedFamilyId == freezedFamilyId);
            var client = context.Client.Single(x => x.ClientId == data.ClientId);
            var createdBy = context.User.SingleOrDefault(x => x.UserId == data.CreatedBy);
            DB.User acceptedBy = data.AcceptedBy.HasValue ? context.User.SingleOrDefault(x => x.UserId == data.AcceptedBy.Value) : null;
            var freezedFamilyItems = GetFreezedFamilyInvoiceItemViewModel(freezedFamilyFunctions.GetFreezedFamilyItems(data.FreezedFamilyId), invoiceId);
            var invoiceItems = invoiceItemFunctions.GetInvoiceItemViewModel(invoiceItemFunctions.GetInvoiceItemByInvoiceId(invoiceId));
            var invoicePayments = invoicePaymentFunctions.GetDataViewModel(invoicePaymentFunctions.GetDataByInvoiceId(invoiceId).OrderBy(x => x.InstallmentDate));

            return new DTO.Invoice.FreezedFamilyInvoiceViewModel
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
                FreezedFamilyItemViewModel = freezedFamilyItems,
                InvoiceItemViewModel = invoiceItems,
                InvoicePaymentViewModel = invoicePayments
            };
        }

        public List<DTO.Invoice.FreezedFamilyInvoiceItemViewModel> GetFreezedFamilyInvoiceItemViewModel(List<DB.FreezedFamilyItem> freezedFamilyItem, int invoiceId)
        {
            return (from x in freezedFamilyItem
                    join fs in context.FamilyStructure on x.FamilyStructureId equals fs.FamilyStructureId
                    join ca in context.ClientApplicant on x.ClientApplicantId equals ca.ClientApplicantId into _ca
                    from __ca in _ca.DefaultIfEmpty()
                    join iffi in context.InvoiceFreezedFamilyItem on x.FreezedFamilyItemId equals iffi.FreezedFamilyItemId into _iffi
                    from __iffi in _iffi.Where(x => x.InvoiceId == invoiceId).DefaultIfEmpty()
                    select new DTO.Invoice.FreezedFamilyInvoiceItemViewModel
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
                        BirthCertificateBRA = __iffi == null? true : __iffi.BirthCertificateBra,
                        BirthCertificateHaiaHandout = __iffi == null? true : __iffi.BirthCertificateHaiaHandout,
                        BirthCertificateITA = __iffi == null? true : __iffi.BirthCertificateIta,
                        BirthCertificateTranslation = __iffi == null? true : __iffi.BirthCertificateTranslation,
                        DeathCertificateBRA = __iffi == null? true : __iffi.DeathCertificateBra,
                        DeathCertificateHaiaHandout = __iffi == null? true : __iffi.DeathCertificateHaiaHandout,
                        DeathCertificateITA = __iffi == null? true : __iffi.DeathCertificateIta,
                        DeathCertificateTranslation = __iffi == null? true : __iffi.DeathCertificateTranslation,
                        MarriageCertificateBRA = __iffi == null? true : __iffi.MarriageCertificateBra,
                        MarriageCertificateHaiaHandout = __iffi == null? true : __iffi.MarriageCertificateHaiaHandout,
                        MarriageCertificateITA = __iffi == null? true : __iffi.MarriageCertificateIta,
                        MarriageCertificateTranslation = __iffi == null? true : __iffi.MarriageCertificateTranslation,
                        CNN = __iffi == null ? true : __iffi.Cnn
                    }).ToList();
        }
    }
}
