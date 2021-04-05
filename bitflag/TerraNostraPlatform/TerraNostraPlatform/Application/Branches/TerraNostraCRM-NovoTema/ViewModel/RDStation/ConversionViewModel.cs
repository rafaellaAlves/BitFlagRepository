using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.RDStation
{
    public class Content
    {
        public string identificador { get; set; }
        public string _rd_experiment_content_id { get; set; }
        public string traffic_source { get; set; }
        public string created_at { get; set; }
        public string ip { get; set; }
        public string email_lead { get; set; }
        public string Nome { get; set; }
        public string Celular { get; set; }
        public string UF { get; set; }
        public string mensagem { get; set; }
    }

    public class ConversionOrigin
    {
        public string source { get; set; }
        public string medium { get; set; }
        public string value { get; set; }
        public string campaign { get; set; }
        public string channel { get; set; }
    }

    public class ConversionViewModel
    {
        public Dictionary<string, string> content { get; set; }
        public DateTime CreatedDate { get; set; }
        public int cumulative_sum { get; set; }
        public string source { get; set; }
        public ConversionOrigin conversion_origin { get; set; }
    }
}
