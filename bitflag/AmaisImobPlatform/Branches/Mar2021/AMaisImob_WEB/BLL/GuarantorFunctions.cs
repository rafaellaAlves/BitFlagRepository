using AMaisImob_DB.Models;
using AMaisImob_WEB.Models;
using AMaisImob_WEB.Utils;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.BLL
{
    public class GuarantorFunctions : BLLBasicFunctions<Guarantor, GuarantorViewModel>
    {
        public GuarantorFunctions(AMaisImob_DB.Models.AMaisImob_HomologContext context)
            : base(context, "GuarantorId")
        {

        }

        public override int Create(GuarantorViewModel model)
        {
            var guarantor = model.CopyToEntity<Guarantor>();

            this.dbSet.Add(guarantor);
            this.context.SaveChanges();

            return guarantor.GuarantorId;
        }

        public override void Delete(object id)
        {
            var guarantor = this.GetDataByID(id);

            guarantor.IsDeleted = true;

            this.context.Update(guarantor);
            this.context.SaveChanges();
        }

        public override List<Models.GuarantorViewModel> GetDataViewModel(IEnumerable<Guarantor> data)
        {
            return data.Select(x => x.CopyToEntity<Models.GuarantorViewModel>()).ToList();
        }

        public override Models.GuarantorViewModel GetDataViewModel(Guarantor data)
        {
            return data.CopyToEntity<GuarantorViewModel>();
        }

        public override void Update(GuarantorViewModel model)
        {
            var guarantor = this.GetDataByID(model.GuarantorId);

            guarantor.NomeFantasia = model.NomeFantasia;
            guarantor.RazaoSocial = model.RazaoSocial;
            guarantor.IsActive = model.IsActive;
            guarantor.TipoPagamento = model.TipoPagamento;
            guarantor.GuarantorTypeId = model.GuarantorTypeId;
            guarantor.PrintFooterText = model.PrintFooterText;

            if (model.Logotipo != null)
            {
                guarantor.Logotipo = model.Logotipo;
                guarantor.LogoTipoMimeType = model.LogoTipoMimeType;
            }

            this.context.Update(guarantor);
            this.context.SaveChanges();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.Guarantor;
        }
    }
}
