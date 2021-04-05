using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AMaisImob_DB.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AMaisImob_WEB.Controllers
{
    public class CategoryGuarantorProductController : Controller
    {
        private readonly UserManager<AMaisImob_DB.Models.User> userManager;
        private readonly BLL.CompanyFunctions companyFunctions;
        private readonly BLL.GuarantorFunctions guarantorFunctions;
        private readonly BLL.CategoryGuarantorProductTaxFunctions categoryGuarantorProductTaxFunctions;
        private readonly BLL.CategoryFunctions categoryFunctions;
        private readonly BLL.GuarantorProductFunctions guarantorProductFunctions;
        private readonly BLL.CategoryProductFunctions categoryProductFunctions;

        public CategoryGuarantorProductController(AMaisImob_DB.Models.AMaisImob_HomologContext context, UserManager<AMaisImob_DB.Models.User> userManager)
        {
            this.companyFunctions = new BLL.CompanyFunctions(context);
            this.userManager = userManager;
            this.guarantorFunctions = new BLL.GuarantorFunctions(context);
            this.categoryGuarantorProductTaxFunctions = new BLL.CategoryGuarantorProductTaxFunctions(context);
            this.categoryFunctions = new BLL.CategoryFunctions(context);
            this.guarantorProductFunctions = new BLL.GuarantorProductFunctions(context);
            this.categoryProductFunctions = new BLL.CategoryProductFunctions(context);
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Manage(int? id)
        {
            return View(id);
        }

        [HttpPost]
        [ActionName("Manage")]
        public async Task<IActionResult> _Manage(Models.CategoryGuarantorProductTaxViewModel model)
        {
            var _user = await userManager.GetUserAsync(User);

            Utils.DBActionType dbActionType;
            if (model.CategoryGuarantorProductTaxId != null) dbActionType = Utils.DBActionType.UPDATE;
            else dbActionType = Utils.DBActionType.CREATE;

            
            if (dbActionType == Utils.DBActionType.CREATE)
            {
                var verificacao = categoryGuarantorProductTaxFunctions.GetData().Any(x => x.CategoryId == model.CategoryId && x.GuarantorProductId == model.GuarantorProductId && x.GuarantorId == model.GuarantorId);

                if (verificacao)
                {
                    return Json(new BLL.Shared.ReturnResult(0, "Já existem taxas para essa Categoria e Produto", true));
                }
            }

            var categoryGuarantorProduct = categoryGuarantorProductTaxFunctions.CreateOrUpdate(model);

            //if (guarantorId != null)
            //{ 
            //auditLogFunctions.Log("GuarantorViewModel", guarantorId, "GuarantorId", dbActionType, guarantorFunctions.GetDataViewModel(guarantorFunctions.GetDataByID(guarantorId)), _user.Id);
            //}

            return Json(categoryGuarantorProduct);
        }
        [HttpPost]
        [ActionName("List")]
        public async Task<IActionResult> List(Models.DataTablesAjaxPostModel filter)
        {
            int recordsTotal = 0;
            int recordsFiltered = 0;

            var d = this.categoryGuarantorProductTaxFunctions.GetDataViewModel(this.categoryGuarantorProductTaxFunctions.GetDataFiltered(filter, out recordsTotal, out recordsFiltered, "Edited = 0", whereParameters: null).ToList());
            
            return await Task.Run<IActionResult>(() => Json(new
            {
                recordsTotal = recordsTotal,
                recordsFiltered = recordsFiltered,
                data = d
            }));
        }

        public IActionResult BuscarProdutosGarantidores(int? id)
        {
            IEnumerable<GuarantorProduct> guarantorProducts;

            if (id.HasValue)
            {
                var produtos = categoryProductFunctions.GetData(x => x.CategoryId == id);
                guarantorProducts = guarantorProductFunctions.GetData(x => produtos.Select(c => c.GuarantorProductId).Contains(x.GuarantorProductId));
                //var listProdutos = categoryProductFunctions.GetDataViewModel(produtos);
            }
            else
            {
                guarantorProducts = guarantorProductFunctions.GetData();
            }

            return Json(guarantorProducts);
        }

        public IActionResult CategoryGuarantorProductComponent()
        {
            return ViewComponent(typeof(ViewComponents.CategoryGuarantorProduct.CategoryGuarantorProductViewComponent));
        }
        public IActionResult CategoryGuarantorProductManageComponent(int? id)
        {
            Models.CategoryGuarantorProductTaxViewModel model = new Models.CategoryGuarantorProductTaxViewModel();

            if (id.HasValue)
                model = categoryGuarantorProductTaxFunctions.GetDataViewModel(categoryGuarantorProductTaxFunctions.GetDataByID(id));

            ViewData["guarantor"] = guarantorFunctions.GetData().ToList();
            ViewData["Categorias"] = categoryFunctions.GetData().ToList();
            ViewData["ProdutosGarantidores"] = guarantorProductFunctions.GetData().ToList();

            return ViewComponent(typeof(ViewComponents.CategoryGuarantorProduct.CategoryGuarantorProductManageViewComponent), new { model = model });
        }


       
    }
}