using AMaisImob_DB.Models;
using AMaisImob_WEB.Models;
using AMaisImob_WEB.Utils;
using BLL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.BLL
{
    public class CategoryGuarantorProductTaxFunctions : BLLBasicFunctions<CategoryGuarantorProductTax, CategoryGuarantorProductTaxViewModel>
    {
        private readonly CategoryFunctions categoryFunctions;
        private readonly GuarantorProductFunctions guarantorProductFunctions;
        private readonly GuarantorFunctions guarantorFunctions;
        public CategoryGuarantorProductTaxFunctions(AMaisImob_DB.Models.AMaisImob_HomologContext context)
            : base(context, "CategoryGuarantorProductTaxId")
        {
            this.categoryFunctions = new BLL.CategoryFunctions(context);
            this.guarantorProductFunctions = new BLL.GuarantorProductFunctions(context);
            this.guarantorFunctions = new BLL.GuarantorFunctions(context);
        }
        public override int Create(CategoryGuarantorProductTaxViewModel model)
        {
            var categoryGuarantorProductTax = model.CopyToEntity<CategoryGuarantorProductTax>();

            this.dbSet.Add(categoryGuarantorProductTax);
            this.context.SaveChanges();

            return categoryGuarantorProductTax.CategoryGuarantorProductTaxId;
        }

        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public override List<Models.CategoryGuarantorProductTaxViewModel> GetDataViewModel(IEnumerable<CategoryGuarantorProductTax> data)
        {
            var categories = categoryFunctions.GetData().AsNoTracking();
            var guarantorProducts = guarantorProductFunctions.GetData().AsNoTracking();
            var guarantor = guarantorFunctions.GetData().AsNoTracking();

            var q = (from y in data
                     join g in guarantorProducts on y.GuarantorProductId equals g.GuarantorProductId
                     join gua in guarantor on y.GuarantorId equals gua.GuarantorId
                     join gt in this.context.GuarantorType.AsNoTracking() on gua.GuarantorTypeId equals gt.GuarantorTypeId
                     join __c in categories on y.CategoryId equals __c.CategoryId into _c
                     from c in _c.DefaultIfEmpty()
                     select new Models.CategoryGuarantorProductTaxViewModel()
                     {
                         CategoryGuarantorProductTaxId = y.CategoryGuarantorProductTaxId,
                         GuarantorId = y.GuarantorId,
                         GuarantorName = gua.NomeFantasia,
                         GuarantorLogoTipo = gua.Logotipo,
                         GuarantorLogoTipoMimeType = gua.LogoTipoMimeType,
                         CategoryId = y.CategoryId,
                         CategoryName = c?.Description,
                         GuarantorProductId = y.GuarantorProductId,
                         GuarantorProductName = g.Description,
                         TaxaMes = y.TaxaMes,
                         TipoImovel = y.TipoImovel,
                         GuarantorPaymentTypeId = gua.TipoPagamento,
                         Description = y.Description,
                         GuarantorTypeId = gua.GuarantorTypeId,
                         GuarantorTypeName = gt.Name,
                         MaxRentPrice = y.MaxRentPrice,
                         MaxRentAndChargesPrice = y.MaxRentAndChargesPrice,
                         GuarantorPrintFooterText = gua.PrintFooterText,
                     }).ToList();

            return q;

        }

        public override CategoryGuarantorProductTaxViewModel GetDataViewModel(CategoryGuarantorProductTax data)
        {
            return data.CopyToEntity<CategoryGuarantorProductTaxViewModel>();
        }

        public override void Update(CategoryGuarantorProductTaxViewModel model)
        {
            //Deixa o produto garantidor antigo sem modifica-lo, para não atrapalhar as cotações existentes que já utilizam deste produto garantidor
            var categoryGuarantorProductTax = GetDataByID(model.CategoryGuarantorProductTaxId);
            categoryGuarantorProductTax.Edited = true;

            this.context.Update(categoryGuarantorProductTax);

            //Cria um novo produto garantidor com os novos dado
            var newCategoryGuarantorProductTax = new CategoryGuarantorProductTax();

            newCategoryGuarantorProductTax.GuarantorId = model.GuarantorId;
            newCategoryGuarantorProductTax.CategoryId = model.CategoryId;
            newCategoryGuarantorProductTax.GuarantorProductId = model.GuarantorProductId;
            newCategoryGuarantorProductTax.TaxaMes = model.TaxaMes;
            newCategoryGuarantorProductTax.TipoImovel = model.TipoImovel;
            newCategoryGuarantorProductTax.Description = model.Description;
            newCategoryGuarantorProductTax.MaxRentPrice = model.MaxRentPrice;
            newCategoryGuarantorProductTax.MaxRentAndChargesPrice = model.MaxRentAndChargesPrice;

            this.context.Add(newCategoryGuarantorProductTax);
            this.context.SaveChanges();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.CategoryGuarantorProductTax;
        }

        public List<GarantidoraViewModel> GetTaxas(int categoryId)
        {
            var taxas = this.dbSet.Where(x => x.CategoryId == categoryId); // obter taxas da categoria da imobiliaria
            var garantidoras = taxas.GroupBy(x => x.GuarantorId); // agrupar por garantidora

            
            var r = new List<GarantidoraViewModel>();
            foreach (var garantidora in garantidoras)
            {
                var nomeGarantidora = guarantorFunctions.GetData().FirstOrDefault(x => x.GuarantorId == garantidora.Key).NomeFantasia;
                var garantidoraViewModel = new GarantidoraViewModel();
                foreach (var taxa in garantidora)
                {
                    var nomeProduto = guarantorProductFunctions.GetData().FirstOrDefault(x => x.GuarantorProductId == taxa.GuarantorProductId).Description;
                    garantidoraViewModel.GuarantorId = garantidora.Key;
                    garantidoraViewModel.GuarantorName = nomeGarantidora;
                    garantidoraViewModel.Taxas.Add(new TaxaGarantidora()
                    {
                        CategoryGuarantorProductTaxId = taxa.CategoryGuarantorProductTaxId,
                        GuarantorProductId = taxa.GuarantorProductId,
                        GuarantorProductName = nomeProduto,
                        TaxaMes = taxa.TaxaMes,
                        
                    });
                }
                r.Add(garantidoraViewModel);
            }

            return r;
        }

        public int ObterCategoryGuarantoProductTaxId(int guarantorId, int? categoryId, int guarantorProductId)
        {
          var categoryGuarantorProductTaxId = this.GetData().FirstOrDefault(x => x.GuarantorId == guarantorId && x.CategoryId == categoryId && x.GuarantorProductId == guarantorProductId).CategoryGuarantorProductTaxId;

            return categoryGuarantorProductTaxId;
        }
    }
}
