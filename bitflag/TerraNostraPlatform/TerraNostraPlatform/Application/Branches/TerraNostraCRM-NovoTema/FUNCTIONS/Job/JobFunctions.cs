using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FUNCTIONS.Job
{
    public class JobFunctions
    {
        public DB.TerraNostraContext context;
        public JobFunctions(DB.TerraNostraContext context)
        {
            this.context = context;
        }

        public int Create(int clientId, int workflowId, int invoiceId)
        {
            var workflowStep = this.context.WorkflowStep.OrderBy(x => x.Order).First();
            if (workflowId == 2)
            {
                workflowStep = this.context.WorkflowStep.First(x => x.WorkflowId == workflowId);
            }

            var job = new DB.Job()
            {
                ClientId = clientId,
                InvoiceId = invoiceId,
                WorkflowId = workflowId,
                CurrentStepId = workflowStep.WorkflowStepId,
                CreatedDate = DateTime.Now,

            };
            this.context.Job.Add(job);
            this.context.SaveChanges();

            var jobInteraction = new DB.JobInteraction()
            {
                JobId = job.JobId,
                StepId = workflowStep.WorkflowStepId,
                Message = "Passo inicial feito pelo sistema.",
                UserId = null,
                CreatedDate = DateTime.Now
            };
            this.context.JobInteraction.Add(jobInteraction);
            this.context.SaveChanges();

            return job.JobId;
        }

        public List<DTO.Workbench.ActiveJobsViewModel> GetActiveJobs()
        {
            return (from j in this.context.Job
                    join w in this.context.Workflow on j.WorkflowId equals w.WorkflowId
                    join c in this.context.Client on j.ClientId equals c.ClientId
                    orderby j.JobId descending
                    select new DTO.Workbench.ActiveJobsViewModel
                    {
                        JobId = j.JobId,
                        ClientName = c.FirstName + " " + c.LastName,
                        JobDescription = w.Name,
                        CreatedDate = j.CreatedDate,
                        JobInteractionViewModel = (from ji in this.context.JobInteraction.Where(x => x.JobId == j.JobId)
                                                   join w in this.context.Workflow on j.WorkflowId equals w.WorkflowId
                                                   join ws in this.context.WorkflowStep on new { w.WorkflowId, WorkflowStepId = ji.StepId } equals new { ws.WorkflowId, ws.WorkflowStepId }
                                                   join ju in this.context.User on ji.UserId equals ju.UserId
                                                   orderby ji.CreatedDate descending
                                                   select new DTO.Job.JobInteractionViewModel
                                                   {
                                                       WorkflowStepId = ws.WorkflowStepId,
                                                       UserName = ju.FirstName + " " + ju.LastName,
                                                       CreatedDate = ji.CreatedDate,
                                                       StepDescription = ws.Name,
                                                       Message = ji.Message
                                                   }).FirstOrDefault()
                    }).ToList();
        }
        public int GetClientIdByJobId(int jobId)
        {
            return this.context.Job.Single(x => x.JobId.Equals(jobId)).ClientId;
        }
        public int GetInvoiceIdByJobId(int jobId)
        {
            return this.context.Job.Single(x => x.JobId.Equals(jobId)).InvoiceId.Value;
        }
        public int? GetWorkflowIdByJobId(int jobId)
        {
            return this.context.Job.Single(x => x.JobId.Equals(jobId)).WorkflowId;
        }
        public int? GetCurrentStepIdByJob(int jobId)
        {
            return this.context.JobInteraction.Where(x => x.JobId.Equals(jobId)).OrderByDescending(x => x.CreatedDate).Select(x => x.StepId).FirstOrDefault();
        }
        public int? GetNextStepIdByJob(int jobId)
        {
            var currentStepId = GetCurrentStepIdByJob(jobId);
            var workflowStep = this.context.WorkflowStep.Single(x => x.WorkflowStepId == currentStepId);
            var nextWorkflowStep = this.context.WorkflowStep.Where(x => x.WorkflowId == workflowStep.WorkflowId && x.Order > workflowStep.Order).FirstOrDefault();

            return nextWorkflowStep == null ? null : (int?)nextWorkflowStep.WorkflowStepId;
        }
        public int? GetPreviousStepIdByJob(int jobId)
        {
            var currentStepId = GetCurrentStepIdByJob(jobId);
            var workflowStep = this.context.WorkflowStep.Single(x => x.WorkflowStepId == currentStepId);
            var nextWorkflowStep = this.context.WorkflowStep.OrderByDescending(x => x.Order).Where(x => x.WorkflowId == workflowStep.WorkflowId && x.Order < workflowStep.Order).FirstOrDefault();

            return nextWorkflowStep == null ? null : (int?)nextWorkflowStep.WorkflowStepId;
        }
        public DTO.Job.JobInteractionViewModel GetCurrentStepDetails(int jobId)
        {
            return (from j in this.context.Job
                    join ji in this.context.JobInteraction on j.JobId equals ji.JobId
                    join w in this.context.Workflow on j.WorkflowId equals w.WorkflowId
                    join ws in this.context.WorkflowStep on new { w.WorkflowId, WorkflowStepId = ji.StepId } equals new { ws.WorkflowId, ws.WorkflowStepId }
                    join __u in this.context.User on ji.UserId equals __u.UserId into _u
                    from u in _u.DefaultIfEmpty()
                    where j.JobId == jobId
                    orderby ji.CreatedDate descending
                    select new DTO.Job.JobInteractionViewModel
                    {
                        WorkflowStepId = ws.WorkflowStepId,
                        EnableJobFreezedFamilyInfo = ws.EnableJobFreezedFamilyInfo,
                        UserName = u == null ? "Sistema" : u.FirstName + " " + u.LastName,
                        CreatedDate = ji.CreatedDate,
                        StepDescription = ws.Name,
                        Message = ji.Message
                    }).FirstOrDefault();
        }
        public List<DTO.Job.JobInteractionViewModel> GetJobStepsDetails(int jobId)
        {
            return (from j in this.context.Job
                    join ji in this.context.JobInteraction on j.JobId equals ji.JobId
                    join w in this.context.Workflow on j.WorkflowId equals w.WorkflowId
                    join ws in this.context.WorkflowStep on new { w.WorkflowId, WorkflowStepId = ji.StepId } equals new { ws.WorkflowId, ws.WorkflowStepId }
                    join u in this.context.User on ji.UserId equals u.UserId
                    where j.JobId == jobId
                    orderby ji.CreatedDate descending
                    select new DTO.Job.JobInteractionViewModel
                    {
                        WorkflowStepId = ws.WorkflowStepId,
                        UserName = u.FirstName + " " + u.LastName,
                        CreatedDate = ji.CreatedDate,
                        StepDescription = ws.Name,
                        Message = ji.Message
                    }).ToList();
        }
        public bool SaveCurrentStepMessage(int jobId, int userId, string message)
        {
            try
            {
                var currentStepId = GetCurrentStepIdByJob(jobId);
                var jobInteraction = new DB.JobInteraction()
                {
                    JobId = jobId,
                    UserId = userId,
                    StepId = currentStepId.Value,
                    CreatedDate = DateTime.Now,
                    Message = message
                };

                this.context.JobInteraction.Add(jobInteraction);
                this.context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool GoToNextStep(int jobId, int userId, string message)
        {
            try
            {
                //var administrativeProfile = User.IsInRole("Administrativo");
                //var stepID = jobFunctions.GetCurrentStepIdByJob(jobId);
                //var perfil = User.IsInRole("Administrativo");
                //var perfil = User.IsInRole("Administrativo");
                //if (perfil && stepID == 1)
                // return Json(false);
                var nextStepId = GetNextStepIdByJob(jobId);
                var jobInteraction = new DB.JobInteraction()
                {
                    JobId = jobId,
                    UserId = userId,
                    StepId = nextStepId.Value,
                    CreatedDate = DateTime.Now,
                    Message = message
                };

                this.context.JobInteraction.Add(jobInteraction);
                this.context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool GoToPreviousStep(int jobId, int userId, string message)
        {
            try
            {
                var previousStepId = GetPreviousStepIdByJob(jobId);
                var jobInteraction = new DB.JobInteraction()
                {
                    JobId = jobId,
                    UserId = userId,
                    StepId = previousStepId.Value,
                    CreatedDate = DateTime.Now,
                    Message = message
                };

                this.context.JobInteraction.Add(jobInteraction);
                this.context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public DB.WorkflowStep GetWorkflowStep(int workflowStepId)
        {
            var workflowStep = this.context.WorkflowStep.SingleOrDefault(x => x.WorkflowStepId == workflowStepId);

            return workflowStep;
        }
        public bool JobExistByInvoiceId(int invoiceId)
        {
            var data = this.context.Job.SingleOrDefault(x => x.InvoiceId == invoiceId);

            if (data != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<DTO.Job.JobFreezedFamilyInfoViewModel> GetJobFreezedFamilyItemInfo(int jobId)
        {
            var jobFreezedFamilyInfoViewModels = new List<DTO.Job.JobFreezedFamilyInfoViewModel>();
            var jobFreezedFamilyItemInfos = new List<DTO.Job.JobFreezedFamilyItemInfoViewModel>();
            var jobFreezedFamilyInfos = (from j in context.Job
                                         join i in context.Invoice on j.InvoiceId equals i.InvoiceId
                                         join iffi in context.InvoiceFreezedFamilyItem on i.InvoiceId equals iffi.InvoiceId
                                         join jffi in context.JobFreezedFamilyItemInfo on iffi.InvoiceFreezedFamilyItemId equals jffi.InvoiceFreezedFamilyItemId
                                         where j.JobId == jobId
                                         select jffi).ToList();

            var items = (from j in context.Job
                         join iffi in context.InvoiceFreezedFamilyItem on j.InvoiceId equals iffi.InvoiceId
                         join fm in context.FreezedFamilyItem on iffi.FreezedFamilyItemId equals fm.FreezedFamilyItemId
                         join fs in context.FamilyStructure on fm.FamilyStructureId equals fs.FamilyStructureId
                         join _fm in context.FamilyMemberType on fs.FamilyMemberTypeId equals _fm.FamilyMemberTypeId
                         where j.JobId == jobId
                         select new { j, iffi, fm, _fm, fs });

            var certificateTypes = context.CertificateType.ToList();

            foreach (var item in items)
            {
                var jobFreezedFamilyInfoViewModel = new DTO.Job.JobFreezedFamilyInfoViewModel()
                {
                    FullFamilyStruct = item.fs.Description,
                    FamilyMemberTypeId = item._fm.FamilyMemberTypeId,
                    FamilyMemberType = item._fm.Name,
                    FullName = item.fm.FullName,
                    ConsortFullName = item.fm.ConsortFullName
                };

                foreach (var certificateType in certificateTypes)
                {
                    if (!(item.iffi.BirthCertificateBra || item.iffi.BirthCertificateHaiaHandout || item.iffi.BirthCertificateIta || item.iffi.BirthCertificateTranslation) && certificateType.CertificateTypeId == 1) continue;
                    if (!(item.iffi.MarriageCertificateBra || item.iffi.MarriageCertificateHaiaHandout || item.iffi.MarriageCertificateIta || item.iffi.MarriageCertificateTranslation) && certificateType.CertificateTypeId == 2) continue;
                    if (!(item.iffi.DeathCertificateBra || item.iffi.DeathCertificateHaiaHandout || item.iffi.DeathCertificateIta || item.iffi.DeathCertificateTranslation) && certificateType.CertificateTypeId == 3) continue;
                    if (!(item.iffi.Cnn) && certificateType.CertificateTypeId == 4) continue;

                    var jobFreezedFamilyInfo = jobFreezedFamilyInfos.SingleOrDefault(x => x.InvoiceFreezedFamilyItemId == item.iffi.InvoiceFreezedFamilyItemId && x.CertificateTypeId == certificateType.CertificateTypeId);

                    jobFreezedFamilyInfoViewModel.Items.Add(new DTO.Job.JobFreezedFamilyItemInfoViewModel()
                    {
                        JobFreezedFamilyItemInfoId = jobFreezedFamilyInfo?.JobFreezedFamilyItemInfoId,
                        InvoiceFreezedFamilyItemId = jobFreezedFamilyInfo == null ? item.iffi.InvoiceFreezedFamilyItemId : jobFreezedFamilyInfo.InvoiceFreezedFamilyItemId,
                        CertificateTypeId = certificateType.CertificateTypeId,
                        CertificateType = certificateType.Name,
                        CertificateDate = (certificateType.CertificateTypeId == 1 ? (DateTime?)item.fm.BirthDate : (certificateType.CertificateTypeId == 2 ? (DateTime?)item.fm.MarriageDate : (certificateType.CertificateTypeId == 3 ? (DateTime?)item.fm.DeathDate : (certificateType.CertificateTypeId == 4 ? jobFreezedFamilyInfo?.CertificateDate : null)))),

                        RegistryOfficeId = jobFreezedFamilyInfo?.RegistryOfficeId,
                        RegistryOfficeBook = jobFreezedFamilyInfo?.RegistryOfficeBook,
                        RegistryOfficePage = jobFreezedFamilyInfo?.RegistryOfficePage,
                        RegistryOfficeTerm = jobFreezedFamilyInfo?.RegistryOfficeTerm,
                        RegistryOfficeRequirementSent = jobFreezedFamilyInfo == null ? false : jobFreezedFamilyInfo.RegistryOfficeRequirementSent,
                        RegistryOfficeRequirementSentDate = jobFreezedFamilyInfo?.RegistryOfficeRequirementSentDate,
                        RegistryOfficeCertificateCheck = jobFreezedFamilyInfo == null ? false : jobFreezedFamilyInfo.RegistryOfficeCertificateCheck,
                        RegistryOfficeRequirementSentEmailDate = jobFreezedFamilyInfo?.RegistryOfficeRequirementSentEmailDate,
                        RegistryOfficeRequirementCheck = jobFreezedFamilyInfo == null ? false : jobFreezedFamilyInfo.RegistryOfficeRequirementCheck,
                        RegistryOfficeCertificatePrice = jobFreezedFamilyInfo?.RegistryOfficeCertificatePrice,
                        RegistryOfficeShippingPrice = jobFreezedFamilyInfo?.RegistryOfficeShippingPrice,
                        RegistryOfficeTotalPrice = jobFreezedFamilyInfo?.RegistryOfficeTotalPrice,
                        RegistryOfficePaymentDate = jobFreezedFamilyInfo?.RegistryOfficePaymentDate,
                        RegistryOfficeShippingDate = jobFreezedFamilyInfo?.RegistryOfficeShippingDate,
                        RegistryOfficeCertificateShippingArrivalDate = jobFreezedFamilyInfo?.RegistryOfficeCertificateShippingArrivalDate,
                        TranslationSentDate = jobFreezedFamilyInfo?.TranslationSentDate,
                        TranslationReceiveDate = jobFreezedFamilyInfo?.TranslationReceiveDate,
                        HaiaHandoutSentDate = jobFreezedFamilyInfo?.HaiaHandoutSentDate,
                        HaiaHandoutReceiveDate = jobFreezedFamilyInfo?.HaiaHandoutReceiveDate,
                        ItalyProtocolTranslationCheck = jobFreezedFamilyInfo == null ? false : jobFreezedFamilyInfo.ItalyProtocolTranslationCheck,
                        ItalyProtocolHaiaCheck = jobFreezedFamilyInfo == null ? false : jobFreezedFamilyInfo.ItalyProtocolHaiaCheck,
                    });
                }

                jobFreezedFamilyInfoViewModels.Add(jobFreezedFamilyInfoViewModel);
            }

            return jobFreezedFamilyInfoViewModels;
        }
        public void SaveJobFreezedFamilyInfo(List<DTO.Job.JobFreezedFamilyItemInfoViewModel> jobFreezedFamilyItemInfoViewModels)
        {
            foreach (var jobFreezedFamilyItemInfoViewModel in jobFreezedFamilyItemInfoViewModels)
            {
                var jobFreezedFamilyItemInfo = jobFreezedFamilyItemInfoViewModel.JobFreezedFamilyItemInfoId.HasValue ? this.context.JobFreezedFamilyItemInfo.Single(x => x.JobFreezedFamilyItemInfoId == jobFreezedFamilyItemInfoViewModel.JobFreezedFamilyItemInfoId.Value) : new DB.JobFreezedFamilyItemInfo();

                jobFreezedFamilyItemInfo.InvoiceFreezedFamilyItemId = jobFreezedFamilyItemInfoViewModel.InvoiceFreezedFamilyItemId;
                jobFreezedFamilyItemInfo.CertificateTypeId = jobFreezedFamilyItemInfoViewModel.CertificateTypeId;
                jobFreezedFamilyItemInfo.CertificateDate = jobFreezedFamilyItemInfoViewModel.CertificateDate;
                jobFreezedFamilyItemInfo.RegistryOfficeId = jobFreezedFamilyItemInfoViewModel.RegistryOfficeId;
                jobFreezedFamilyItemInfo.RegistryOfficeBook = jobFreezedFamilyItemInfoViewModel.RegistryOfficeBook;
                jobFreezedFamilyItemInfo.RegistryOfficePage = jobFreezedFamilyItemInfoViewModel.RegistryOfficePage;
                jobFreezedFamilyItemInfo.RegistryOfficeTerm = jobFreezedFamilyItemInfoViewModel.RegistryOfficeTerm;
                jobFreezedFamilyItemInfo.RegistryOfficeRequirementSent = jobFreezedFamilyItemInfoViewModel.RegistryOfficeRequirementSent;
                jobFreezedFamilyItemInfo.RegistryOfficeRequirementSentDate = jobFreezedFamilyItemInfoViewModel.RegistryOfficeRequirementSentDate;
                jobFreezedFamilyItemInfo.RegistryOfficeCertificateCheck = jobFreezedFamilyItemInfoViewModel.RegistryOfficeCertificateCheck;
                jobFreezedFamilyItemInfo.RegistryOfficeRequirementSentEmailDate = jobFreezedFamilyItemInfoViewModel.RegistryOfficeRequirementSentEmailDate;
                jobFreezedFamilyItemInfo.RegistryOfficeRequirementCheck = jobFreezedFamilyItemInfoViewModel.RegistryOfficeRequirementCheck;
                jobFreezedFamilyItemInfo.RegistryOfficeCertificatePrice = jobFreezedFamilyItemInfoViewModel.RegistryOfficeCertificatePrice;
                jobFreezedFamilyItemInfo.RegistryOfficeShippingPrice = jobFreezedFamilyItemInfoViewModel.RegistryOfficeShippingPrice;
                jobFreezedFamilyItemInfo.RegistryOfficeTotalPrice = jobFreezedFamilyItemInfoViewModel.RegistryOfficeTotalPrice;
                jobFreezedFamilyItemInfo.RegistryOfficePaymentDate = jobFreezedFamilyItemInfoViewModel.RegistryOfficePaymentDate;
                jobFreezedFamilyItemInfo.RegistryOfficeShippingDate = jobFreezedFamilyItemInfoViewModel.RegistryOfficeShippingDate;
                jobFreezedFamilyItemInfo.RegistryOfficeCertificateShippingArrivalDate = jobFreezedFamilyItemInfoViewModel.RegistryOfficeCertificateShippingArrivalDate;
                jobFreezedFamilyItemInfo.TranslationSentDate = jobFreezedFamilyItemInfoViewModel.TranslationSentDate;
                jobFreezedFamilyItemInfo.TranslationReceiveDate = jobFreezedFamilyItemInfoViewModel.TranslationReceiveDate;
                jobFreezedFamilyItemInfo.HaiaHandoutSentDate = jobFreezedFamilyItemInfoViewModel.HaiaHandoutSentDate;
                jobFreezedFamilyItemInfo.HaiaHandoutReceiveDate = jobFreezedFamilyItemInfoViewModel.HaiaHandoutReceiveDate;
                jobFreezedFamilyItemInfo.ItalyProtocolTranslationCheck = jobFreezedFamilyItemInfoViewModel.ItalyProtocolTranslationCheck;
                jobFreezedFamilyItemInfo.ItalyProtocolHaiaCheck = jobFreezedFamilyItemInfoViewModel.ItalyProtocolHaiaCheck;

                if (!jobFreezedFamilyItemInfoViewModel.JobFreezedFamilyItemInfoId.HasValue)
                    this.context.JobFreezedFamilyItemInfo.Add(jobFreezedFamilyItemInfo);
                else
                    this.context.JobFreezedFamilyItemInfo.Update(jobFreezedFamilyItemInfo);
            }

            this.context.SaveChanges();
        }
        public DTO.Workbench.JobFamilyInfoManageViewModel GetJobFamilyInfoManageViewModel(int jobId, int workflowStepId)
        {
            var workflowStep = (from ws in context.WorkflowStep
                                where ws.WorkflowStepId == workflowStepId
                                select ws).SingleOrDefault();

            var jobFamilyInfoManageViewModel = new DTO.Workbench.JobFamilyInfoManageViewModel();

            jobFamilyInfoManageViewModel.JobId = jobId;
            jobFamilyInfoManageViewModel.WorkflowStepId = workflowStepId;
            jobFamilyInfoManageViewModel.Title = workflowStep.JobFreezedFamilyInfoTitle;
            jobFamilyInfoManageViewModel.Modules = string.IsNullOrWhiteSpace(workflowStep.JobFreezedFamilyInfoModules) ? new List<string>() : workflowStep.JobFreezedFamilyInfoModules.Split(';').ToList();
            jobFamilyInfoManageViewModel.Columns = string.IsNullOrWhiteSpace(workflowStep.JobFreezedFamilyInfoColumns) ? new List<string>() : workflowStep.JobFreezedFamilyInfoColumns.Split(';').ToList();

            return jobFamilyInfoManageViewModel;
        }
        public string GetJobFreezedFamilyItemInfoRegistryOffice(int jobFreezedFamilyItemInfoId)
        {
            var jobFreezedFamilyItemInfoRegistryOffice = context.JobFreezedFamilyItemInfoRegistryOffice.SingleOrDefault(x => x.JobFreezedFamilyItemInfoId == jobFreezedFamilyItemInfoId);
            return jobFreezedFamilyItemInfoRegistryOffice == null ? string.Empty : jobFreezedFamilyItemInfoRegistryOffice.Message;
        }
        public void SaveJobFreezedFamilyItemInfoRegistryOffice(int jobFreezedFamilyItemInfoId, string message)
        {
            var jobFreezedFamilyItemInfoRegistryOffice = context.JobFreezedFamilyItemInfoRegistryOffice.SingleOrDefault(x => x.JobFreezedFamilyItemInfoId == jobFreezedFamilyItemInfoId);
            if (jobFreezedFamilyItemInfoRegistryOffice == null)
            {
                jobFreezedFamilyItemInfoRegistryOffice = new DB.JobFreezedFamilyItemInfoRegistryOffice
                {
                    JobFreezedFamilyItemInfoId = jobFreezedFamilyItemInfoId,
                    Message = message
                };

                context.JobFreezedFamilyItemInfoRegistryOffice.Add(jobFreezedFamilyItemInfoRegistryOffice);
                context.SaveChanges();
            }
            else
            {
                jobFreezedFamilyItemInfoRegistryOffice.Message = message;

                context.Update(jobFreezedFamilyItemInfoRegistryOffice);
                context.SaveChanges();
            }
        }
        public void ItalyProtocolModuleSaveSentDate(int jobId, int lastHandler)
        {
            var italyProtocol = context.ItalyProtocolModule.SingleOrDefault(x => x.JobId == jobId);
            if (italyProtocol != null) return;

            context.ItalyProtocolModule.Add(new DB.ItalyProtocolModule()
            {
                JobId = jobId,
                LastHandler = lastHandler,
                SentDate = DateTime.Now
            });
            context.SaveChanges();
        }
        public DateTime? ItalyProtocolModuleGetSentDate(int jobId)
        {
            var italyProtocol = context.ItalyProtocolModule.SingleOrDefault(x => x.JobId == jobId);

            return italyProtocol?.SentDate;
        }
        public string GetItalyProtocolAdditionalDocuments(int jobId)
        {
            var italyProtocolAdditionalDocumentsModule = context.ItalyProtocolAdditionalDocumentsModule.SingleOrDefault(x => x.JobId == jobId);

            return italyProtocolAdditionalDocumentsModule == null ? string.Empty : italyProtocolAdditionalDocumentsModule.Documents;
        }
        public void SaveItalyProtocolAdditionalDocuments(int jobId, string documents)
        {
            var italyProtocolAdditionalDocumentsModule = context.ItalyProtocolAdditionalDocumentsModule.SingleOrDefault(x => x.JobId == jobId);
            if (italyProtocolAdditionalDocumentsModule == null)
            {
                italyProtocolAdditionalDocumentsModule = new DB.ItalyProtocolAdditionalDocumentsModule()
                {
                    JobId = jobId,
                    Documents = documents
                };
                context.ItalyProtocolAdditionalDocumentsModule.Add(italyProtocolAdditionalDocumentsModule);
            }
            else
            {
                italyProtocolAdditionalDocumentsModule.Documents = documents;
                context.ItalyProtocolAdditionalDocumentsModule.Update(italyProtocolAdditionalDocumentsModule);
            }

            context.SaveChanges();
        }
    }
}
