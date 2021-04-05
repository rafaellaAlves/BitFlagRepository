using DTO.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Account
{
    public class SingUpViewModel
    {
        public string CompanyName { get; set; }
        public string FullName
        {
            get => FirstName + " " + LastName;
            set
            {
                var split = value.Split(" ");
                FirstName = split[0];
                LastName = value.Replace(split[0], "");
            }
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string _CPF { get => CPF.NumbersOnly(); set => CPF = value.NumbersOnly(); }
        public string CNPJ { get; set; }
        public string _CNPJ { get => CNPJ.NumbersOnly(); set => CNPJ = value.NumbersOnly(); }
        public string Password { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
