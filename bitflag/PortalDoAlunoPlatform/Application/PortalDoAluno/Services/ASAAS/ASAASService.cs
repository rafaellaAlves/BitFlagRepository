using DTO.ASAAS.Customer;
using DTO.ASAAS.Payment;
using Microsoft.EntityFrameworkCore;
using RestSharp;
using Services.Helpers;
using Services.Student;
using Services.Class;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Services.ClassStudent;

namespace Services.ASAAS
{
    public class ASAASService
    {
        private readonly RestClient restClient;
        private readonly ApplicationDbContext.ApplicationDbContext context;
        private readonly StudentService studentService;
        private readonly ClassStudentService classStudentService;
        private readonly ClassService classService;

        public ASAASService(ApplicationDbContext.ApplicationDbContext context, StudentService studentService, ClassStudentService classStudentService, ClassService classService)
        {
#if !DEBUG
            this.restClient = new RestClient("https://sandbox.asaas.com/api/v3/");
            this.restClient.AddDefaultHeader("access_token", "42df5af8181eefe4a031ada54f4661f728480de88381dba79d3e97f7ad03b476");
#else
            this.restClient = new RestClient("https://sandbox.asaas.com/api/v3/");
            this.restClient.AddDefaultHeader("access_token", "c7d432bd92d7cc314de5e25d4525014568801487cf8ed902fd871c19db7c231b");
#endif
            this.context = context;
            this.studentService = studentService;
            this.classStudentService = classStudentService;
            this.classService = classService;
        }
        public async Task<string> GetCustomerId(int classStudentId)
        {
            var classStudent = await context.ClassStudent.SingleOrDefaultAsync(x => x.ClassStudentId == classStudentId);

            if (classStudent == null || string.IsNullOrWhiteSpace(classStudent.ASAAS_customer_id)) return await SaveClassStudent(classStudent.ClassStudentId);

            return classStudent.ASAAS_customer_id;
        }
        public async Task<string> SaveClassStudent(int classStudentId)
        {
            var classStudentViewModel = await classStudentService.GetClassStudentInfoViewModel(classStudentId);
            var studentInfoViewModel = await studentService.GetStudentInfo(classStudentViewModel.StudentId);
            var classViewModel = await classService.GetById(classStudentViewModel.ClassId);
            if (classStudentViewModel == null || !string.IsNullOrWhiteSpace(classStudentViewModel.ASAAS_customer_id)) return null;

            var request = new RestRequest("customers", DataFormat.Json);
            request.AddJsonBody(new { name = studentInfoViewModel.Name, cpfCnpj = studentInfoViewModel._Cpf, email = studentInfoViewModel.Email, externalReference = classViewModel.ClassFullName });

            var customer = await restClient.PostAsync<CustomerModel>(request);

            await SaveCustomerIdToClassStudent(classStudentId, customer.Id);

            return customer.Id;
        }
        public async Task SaveCustomerIdToClassStudent(int classStudentId, string customerId)
        {
            var classStudent = await this.context.ClassStudent.SingleOrDefaultAsync(x => x.ClassStudentId == classStudentId);
            if (classStudent == null) return;

            classStudent.ASAAS_customer_id = customerId;
            await this.context.SaveChangesAsync();
        }
        public async Task<bool> CreateCharge(int classStudentId, string externalReference, double value, int installmentCount, DateTime installmentDate)
        {
            var customerId = await GetCustomerId(classStudentId);

            int _installmenteCount = installmentCount < 1 ? 1 : installmentCount;
            double installmentValue = Math.Round((value / (double)_installmenteCount), 2);

            var request = new RestRequest("payments", DataFormat.Json);

            request.AddJsonBody(new { customer = customerId, billingType = "BOLETO", dueDate = installmentDate, installmentCount = _installmenteCount, installmentValue, value = installmentValue, externalReference });

            var payment = restClient.Post(request);

            return await Task.Run<bool>(() => payment.StatusCode == System.Net.HttpStatusCode.OK);
        }
        public async Task<PaymentListModel> GetCharges(int classStudentId)
        {
            var customerId = await GetCustomerId(classStudentId);

            var request = new RestRequest("payments", DataFormat.Json);
            request.AddParameter("customer", customerId);
            request.AddParameter("limit", 100);

            return await restClient.GetAsync<PaymentListModel>(request);
        }
    }
}
