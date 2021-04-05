using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Web.Utils;

namespace Web.Controllers
{
    
    [Authorize(Roles = "Administrator, Salesman, Financial, Administrative, Administrative Assistant, Contact Manager")]
    public class FamilyController : Controller
    {
        private FUNCTIONS.Family.FamilyFunctions familyFunctions;
        private FUNCTIONS.Client.ClientFunctions clientFunctions;
        private FUNCTIONS.Client.ClientArchiveFunctions clientArchiveFunctions;
        private FUNCTIONS.Family.ClientApplicantFunctions clientApplicantFunctions;
        private FUNCTIONS.Family.FreezedFamilyFunctions freezedFamilyFunctions;
        private FUNCTIONS.Client.ClientStatusFunctions clientStatusFunctions;

        private UserManager<TerraNostraIdentityDbContext.User> userManager;

        private readonly string folderDrive;// = "1MqpBUJXq7M6jVhLNGbF1zNaP6EV7XA4o";
        private readonly GoogleDriveAPI.GoogleDriveAPI googleDriveAPI;

        public FamilyController(FUNCTIONS.Family.FamilyFunctions familyFunctions, FUNCTIONS.Family.ClientApplicantFunctions clientApplicantFunctions, FUNCTIONS.Client.ClientArchiveFunctions clientArchiveFunctions, FUNCTIONS.Client.ClientFunctions clientFunctions, FUNCTIONS.Family.FreezedFamilyFunctions freezedFamilyFunctions, FUNCTIONS.Client.ClientStatusFunctions clientStatusFunctions, UserManager<TerraNostraIdentityDbContext.User> userManager, IConfiguration Configuration)
        {
            this.familyFunctions = familyFunctions;
            this.clientApplicantFunctions = clientApplicantFunctions;
            this.clientArchiveFunctions = clientArchiveFunctions;
            this.clientFunctions = clientFunctions;
            this.freezedFamilyFunctions = freezedFamilyFunctions;
            this.clientStatusFunctions = clientStatusFunctions;
            this.userManager = userManager;
            folderDrive = Configuration.GetValue<string>("GoogleDriveFolder");


            this.googleDriveAPI = new GoogleDriveAPI.GoogleDriveAPI("MyProject-66223163b12b.json");
        }

        [Authorize]
        public IActionResult Index(int clientId, int? clientApplicantId = null)
        {
            List<DB.ClientApplicant> clientApplicants = new List<DB.ClientApplicant>();
            if (!clientApplicantFunctions.AnyByClientId(clientId))
            {
                var _clientApplicantId = clientApplicantFunctions.Create(new DTO.Family.ClientApplicant
                {
                    ClientId = clientId,
                    FullName = "Requerente"
                });
                clientApplicants.Add(clientApplicantFunctions.GetDataByID(_clientApplicantId));
            }
            else
            {
                clientApplicants = clientApplicantFunctions.GetDataByClientId(clientId);
            }

            ViewBag.ClientApplicants = clientApplicants;
            ViewBag.ClientApplicantId = clientApplicantId ?? clientApplicants[0].ClientApplicantId;

            return View(clientFunctions.GetDataViewModel(clientFunctions.GetDataByID(clientId)));
        }

        [AllowAnonymous]
        public IActionResult View(string token, int? clientApplicantId = null)
        {
            int clientId = clientFunctions.GetByToken(token).ClientId;

            List<DB.ClientApplicant> clientApplicants = new List<DB.ClientApplicant>();
            if (!clientApplicantFunctions.AnyByClientId(clientId))
            {
                var _clientApplicantId = clientApplicantFunctions.Create(new DTO.Family.ClientApplicant
                {
                    ClientId = clientId,
                    FullName = "Requerente"
                });
                clientApplicants.Add(clientApplicantFunctions.GetDataByID(_clientApplicantId));
            }
            else
            {
                clientApplicants = clientApplicantFunctions.GetDataByClientId(clientId);
            }

            ViewBag.ClientApplicants = clientApplicants;
            ViewBag.ClientApplicantId = clientApplicantId ?? clientApplicants[0].ClientApplicantId;

            return View(clientId);
        }

        [Authorize]
        public IActionResult Freeze(int clientId)
        {
            return View(clientFunctions.GetDataViewModel(clientFunctions.GetDataByID(clientId)));
        }

        [AllowAnonymous]
        public IActionResult NewClientApplicant(int clientId)
        {
            var clientApplicantId = clientApplicantFunctions.Create(new DTO.Family.ClientApplicant
            {
                ClientId = clientId,
                FullName = "Requerente"
            });

            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", new { clientId, clientApplicantId });
            else
            {
                var client = clientFunctions.GetDataByID(clientId);
                return RedirectToAction("View", new { client.Token, clientApplicantId });
            }
        }

        #region [ViewComponents]
        [AllowAnonymous]
        public IActionResult FamilyInfoManageViewComponent(int clientId, int clientApplicantId)
        {
            ViewBag.ApplicantFamilyMemberTypeId = familyFunctions.GetFamilyMemberTypeByExternalCode("APPLICANT").First().FamilyMemberTypeId;
            ViewBag.ShowFamilyMemberTypeIds = familyFunctions.GetFamilyMemberTypeByExternalCode("APPLICANT", "FATHER", "MOTHER").Select(x => x.FamilyMemberTypeId).ToList();
            ViewBag.ClientApplicant = clientApplicantFunctions.GetDataByID(clientApplicantId);

            return ViewComponent(typeof(ViewComponents.Family.FamilyInfoManageViewComponent), new { clientId, clientApplicantId });
        }
        public IActionResult FamilyFreezeManageViewComponent(int clientId)
        {
            var applicantFamilyMemberType = familyFunctions.GetFamilyMemberTypeByExternalCode("APPLICANT").SingleOrDefault();

            if(applicantFamilyMemberType != null)
            {
                ViewBag.ApplicantFamilyMemberTypeId = applicantFamilyMemberType.FamilyMemberTypeId;
            }
            else
            {
                ViewBag.ApplicantFamilyMemberTypeId = 0;
            }

            return ViewComponent(typeof(ViewComponents.Family.FamilyFreezeManageViewComponent), new { clientId });
        }
        #endregion

        #region [XHR]
        [AllowAnonymous]
        public IActionResult SaveFamilyMember(DTO.Family.FamilyMemberViewModel familyMemberViewModel)
        {
            if (User.Identity.IsAuthenticated && !User.FreezedFamilyCanAccessEdition()) return Forbid();

            var familyStructure = familyFunctions.GetFamilyStructure(familyMemberViewModel.FamilyStructureId);
            var applicantTypeId = familyFunctions.GetFamilyMemberTypeByExternalCode("APPLICANT").First().FamilyMemberTypeId;

            var currentClientStatusId = clientFunctions.GetDataByID(familyMemberViewModel.ClientId).ClientStatusId;
            if(currentClientStatusId.HasValue && currentClientStatusId.Value == 1)
                clientFunctions.SetStatus(familyMemberViewModel.ClientId, 2);

            if (familyStructure.FamilyMemberTypeId == applicantTypeId)
            {
                familyFunctions.SaveApplicant(familyMemberViewModel);
            }
            else
            {
                familyFunctions.SaveFamilyMember(familyMemberViewModel);
            }

            clientFunctions.TryUpdateStatus(familyMemberViewModel.ClientId, clientStatusFunctions.GetDataByExternalCode("GENEALOGIAPREENCHIDA").First().ClientStatusId);

            return Json(familyMemberViewModel);
        }
        [AllowAnonymous]
        public IActionResult Remove(int clientApplicantId)
        {
            if (!User.FreezedFamilyCanAccessEdition()) return Forbid();

            var clientApplicant = clientApplicantFunctions.GetDataByID(clientApplicantId);

            familyFunctions.DeleteByClientApplicantId(clientApplicant.ClientApplicantId);

            foreach (var item in clientArchiveFunctions.GetByClientApplicantId(clientApplicant.ClientApplicantId))
            {
                try
                {
                    this.googleDriveAPI.RemoveFile(item.FilePath);
                }
                catch { }
            }

            clientArchiveFunctions.DeleteByClientApplicantId(clientApplicant.ClientApplicantId);

            clientApplicantFunctions.Delete(clientApplicantId);

            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", new { clientId = clientApplicant.ClientId });
            else
            {
                var client = clientFunctions.GetDataByID(clientApplicant.ClientId);
                return RedirectToAction("View", new { client.Token });
            }
        }

        [AllowAnonymous]
        public async Task<IActionResult> FreezeFamily(List<DTO.Family.CondensedFamilyStructureItemViewModel> CondensedFamilyStructureItemViewModels, int clientId)
        {
            if (!User.FreezedFamilyCanAccessEdition()) return Forbid();

            try
            {
                var applicantFamilyMemberId = familyFunctions.GetFamilyMemberTypeByExternalCode("APPLICANT").Single().FamilyMemberTypeId;

                var user = await userManager.GetUserAsync(User);

                List<DB.FreezedFamilyItem> freezedFamilyItems = new List<DB.FreezedFamilyItem>();

                freezedFamilyItems.AddRange(freezedFamilyFunctions.GetFreezedFamilyItemByFamilyMemberIds(CondensedFamilyStructureItemViewModels.Where(x => x.FamilyMemberTypeId != applicantFamilyMemberId).Select(x => x.FamilyMemberId)));
                freezedFamilyItems.AddRange(freezedFamilyFunctions.GetFreezedFamilyItemByclientApplicantIds(CondensedFamilyStructureItemViewModels.Where(x => x.FamilyMemberTypeId == applicantFamilyMemberId).Select(x => x.ClientApplicantId)));

                var freezedFamilyId = freezedFamilyFunctions.CreateFreezedFamily(freezedFamilyItems, clientId, user.Id);
                
                return Json(freezedFamilyId);
            }
            catch(Exception ex)
            {
                return Json(-1);
            }
        }
        #endregion
    }
}