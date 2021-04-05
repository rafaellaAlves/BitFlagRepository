using AMaisImob_WEB.Models;
using AMaisImob_WEB.Models.GuarantorIntegration.Pottencial;
using AMaisImob_WEB.Models.GuarantorIntegration.Pottencial.Authentication;
using AMaisImob_WEB.Models.GuarantorIntegration.Pottencial.Subscription;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace AMaisImob_WEB.BLL.GuarantorIntegration.Pottencial
{
    public class PottencialSeguros : BLL.GuarantorIntegration.IGuarantorIntegration
    {
        private readonly RestClient restClient;
        private readonly SystemVariableFunctions systemVariableFunctions;
        private readonly CertificateContractualFunctions certificateContractualFunctions;
        private readonly string clientId;
        private readonly string clientSecret;
        private readonly string scope;
        private readonly string grantType;
        private readonly string authenticationUrl;
        private readonly string apiUrl;
        private readonly string brokerCpnj;
        private readonly string callbackUrl;

        public PottencialSeguros(SystemVariableFunctions systemVariableFunctions, CertificateContractualFunctions certificateContractualFunctions)
        {
            this.systemVariableFunctions = systemVariableFunctions;
            this.certificateContractualFunctions = certificateContractualFunctions;

            this.clientId = systemVariableFunctions.GetSystemVariableWithException("Pottencial.ClientId");
            this.clientSecret = systemVariableFunctions.GetSystemVariableWithException("Pottencial.ClientSecret");
            this.scope = systemVariableFunctions.GetSystemVariableWithException("Pottencial.Scope");
            this.grantType = systemVariableFunctions.GetSystemVariableWithException("Pottencial.GrantType");
            this.authenticationUrl = systemVariableFunctions.GetSystemVariableWithException("Pottencial.AuthenticationUrl");
            this.apiUrl = systemVariableFunctions.GetSystemVariableWithException("Pottencial.ApiUrl");
            this.brokerCpnj = systemVariableFunctions.GetSystemVariableWithException("Pottencial.Broker.Cnpj");
            this.callbackUrl = systemVariableFunctions.GetSystemVariableWithException("Pottencial.CallbackUrl");

            this.restClient = new RestClient(this.apiUrl);
        }

        public string Send(CertificateContractualViewModel certificateContractualViewModel, List<CertificateContractualMemberViewModel> certificateContractualMemberViewModels)
        {
            var subscriptionRequest = new SubscriptionRequest();

            subscriptionRequest.PolicyOwner.Cnpj = "12939904000166";
            subscriptionRequest.Broker.Cnpj = brokerCpnj;

            var principalTenant = new Tenant();
            principalTenant.Type = "Principal";
            principalTenant.Name = certificateContractualViewModel.ClientFullName;
            principalTenant.Email = "yuri.santana@bitflag.systems";
            principalTenant.CpfCnpj = certificateContractualViewModel.CPFCNPJ;
            principalTenant.SourceIncome = ConvertSourceIncome(certificateContractualViewModel.CertificateContractualIncomeTypeId.Value);
            principalTenant.Income = certificateContractualViewModel.RendaMensal.Value;
            principalTenant.Resident = true;

            subscriptionRequest.Tenants.Add(principalTenant);

            foreach (var certificateContractualMemberViewModel in certificateContractualMemberViewModels)
            {
                var tenant = new Tenant();
                tenant.Type = "Solidary";
                tenant.Name = certificateContractualMemberViewModel.Name;
                tenant.CpfCnpj = certificateContractualMemberViewModel.CPF;
                tenant.Email = "yuri.santana@bitflag.systems";
                tenant.SourceIncome = ConvertSourceIncome(certificateContractualMemberViewModel.CertificateContractualIncomeTypeId.Value);
                tenant.Income = certificateContractualMemberViewModel.Income.Value;
            }

            subscriptionRequest.Address.ZipCode = certificateContractualViewModel.CEP;
            subscriptionRequest.Address.Street = certificateContractualViewModel.Endereco;
            subscriptionRequest.Address.Number = certificateContractualViewModel.Numero;
            subscriptionRequest.Address.Complement = certificateContractualViewModel.Complemento;
            subscriptionRequest.Address.District = certificateContractualViewModel.Bairro;

            subscriptionRequest.Expenses.RentAmount = certificateContractualViewModel.Aluguel;
            subscriptionRequest.Expenses.Condominium = certificateContractualViewModel.CondominiumPrice ?? 0;
            subscriptionRequest.Expenses.IptuAmount = certificateContractualViewModel.IPTU ?? 0;
            subscriptionRequest.Expenses.WaterBill = certificateContractualViewModel.WaterPrice ?? 0;
            subscriptionRequest.Expenses.ElectricalBill = certificateContractualViewModel.LightPrice ?? 0;
            subscriptionRequest.Expenses.GasBill = 0;
            subscriptionRequest.Expenses.AirConditionerBill = 0;
            subscriptionRequest.Expenses.PromotionFund = 0;

            subscriptionRequest.PlanType = ConvertPlanType(certificateContractualViewModel.GuarantorProductId);
            subscriptionRequest.RentalType = ConvertRentalType(certificateContractualViewModel.ResidenceTypeId);
            subscriptionRequest.CallbackUrl = callbackUrl;

            return JsonSerializer.Serialize(subscriptionRequest);
        }
        public string ProcessStatus<T>(T data)
        {
            throw new NotImplementedException();
        }
        public async Task<string> GetJWTToken()
        {
            var client = new RestClient(authenticationUrl);
            client.Timeout = -1;

            var request = new RestRequest(Method.POST);

            request.AlwaysMultipartFormData = true;
            request.AddParameter("client_id", clientId);
            request.AddParameter("client_secret", clientSecret);
            request.AddParameter("scope", scope);
            request.AddParameter("grant_type", grantType);

            var authenticationResponse = await client.PostAsync<AuthenticationResponse>(request);

            return authenticationResponse.AccessToken;
        }
        public GuarantorProvider GetGuarantorProvider()
        {
            return GuarantorProvider.Pottencial;
        }
        private string ConvertSourceIncome(int incomeTypeId)
        {
            switch (incomeTypeId)
            {
                case 1: // ALUGUEIS
                    return "RentalIncome";
                case 2: // APOSENTADO
                    return "Retired";
                case 3: // EMPRESARIO
                    return "Businessman";
                case 4: // FUNCIONARIOCLT
                    return "CLT";
                case 5: // FUNCIONARIOPUBLICO
                    return "PublicServantCLT";
                case 6: // OUTRASRENDAS
                default:
                    return "Other";
                case 7: // PROFISSIONALLIBERAL
                    return "LiberalProfessional";
            }
        }
        private string ConvertPlanType(int guarantorProductId)
        {
            switch(guarantorProductId)
            {
                case 1:
                    return "Basic";
                case 2:
                    return "Complete";
                default:
                    return string.Empty;
            }
        }
        private string ConvertRentalType(int residenceTypeId)
        {
            switch (residenceTypeId)
            {
                case 1:
                    return "Rensidential";
                case 2:
                    return "Commercial";
                default:
                    return string.Empty;
            }
        }
    }
}
