using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using AMaisImob_DB.Models;
using System.IO;
using System.IO.Compression;
using OfficeOpenXml;
using BackgroundServices.Models;
using BackgroundServices.Utils;
using System.Net;
using System.Net.Mime;

namespace BackgroundServices
{
    public class SendAssistanceReportService : AMaisImob_BackgroundServices.Bases.ServicoProcessamentoFila<byte[]>
    {
        public static void Main() { }

        #region [Propriedades]
        private class Retorno
        {
            public string Version { get; set; }
            public int StatusCode { get; set; }
            public bool Success { get; set; }
            public object Content { get; set; }
        }

        private ApplicationDbContext context;
        #endregion

        public SendAssistanceReportService(string connectionString) : base()
        {
            Init(connectionString);
        }

        public SendAssistanceReportService(string connectionString, Dictionary<string, object> parametros) : base(parametros)
        {
            Init(connectionString);
        }

        public void Init(string connectionString)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>();
            options.UseSqlServer(connectionString);
            this.context = new ApplicationDbContext(options.Options);
        }

        public override byte[] ObterItem()
        {
            byte[] fileBytes;

            var data = GetListAssistanceExportViewModel();

            var byteArray = System.IO.File.ReadAllBytes(System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot", "template", "Blank.xlsx"));
            using (var memoryStream = new MemoryStream())
            {
                memoryStream.Write(byteArray, 0, (int)byteArray.Length);
                memoryStream.Position = 0;

                using (var excelPackage = new ExcelPackage(memoryStream))
                {

                    //foreach (var item in certificates.GroupBy(x => x.Apolice))
                    ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[0];
                    worksheet.Column(4).Style.Numberformat.Format = "0000000000";

                    int l = 0;
                    worksheet.Cells[1, ++l].Value = "H";
                    worksheet.Cells[1, ++l].Value = $"00{DateTime.Now:yyyyMMdd}";
                    worksheet.Cells[1, ++l].Value = "AMA";
                    worksheet.Cells[1, ++l].Value = "L1";
                    worksheet.Cells[1, ++l].Value = DateTime.Now.ToString("yyyyMMdd");
                    worksheet.Cells[1, ++l].Value = data.Count.ToString("0000000000");
                    worksheet.Cells[1, ++l].Value = "";
                    worksheet.Cells[1, ++l].Value = "";
                    worksheet.Cells[1, ++l].Value = "";
                    worksheet.Cells[1, ++l].Value = "";
                    worksheet.Cells[1, ++l].Value = "";
                    worksheet.Cells[1, ++l].Value = "";
                    worksheet.Cells[1, ++l].Value = "";
                    worksheet.Cells[1, ++l].Value = "";
                    worksheet.Cells[1, ++l].Value = "";
                    worksheet.Cells[1, ++l].Value = "";

                    int i = 2;
                    foreach (var certificate in data.OrderBy(x => x.DataDeInclusao))
                    {
                        l = 0;
                        worksheet.Cells[i, ++l].Value = certificate.Referencia;
                        worksheet.Cells[i, ++l].Value = certificate.NomeInquilino;
                        worksheet.Cells[i, ++l].Value = certificate.CPFInquilino.NumbersOnly();
                        worksheet.Cells[i, ++l].Value = certificate.DataDeInclusao.ToString("yyyyMMdd");
                        worksheet.Cells[i, ++l].Value = certificate.VigencyDate.ToString("yyyyMMdd");
                        worksheet.Cells[i, ++l].Value = certificate.VigencyDate.AddYears(1).ToString("yyyyMMdd");
                        worksheet.Cells[i, ++l].Value = certificate.AssistanceReportCode;
                        worksheet.Cells[i, ++l].Value = "I";
                        worksheet.Cells[i, ++l].Value = certificate.LocalDeRisco.Length > 150 ? certificate.LocalDeRisco.Substring(0, 150) : certificate.LocalDeRisco; //Endereço
                        worksheet.Cells[i, ++l].Value = certificate.Numero.Length > 5 ? certificate.Numero.Substring(0, 5) : certificate.Numero;
                        worksheet.Cells[i, ++l].Value = certificate.Complemento.Length > 10 ? certificate.Complemento.Substring(0, 10) : certificate.Complemento;
                        worksheet.Cells[i, ++l].Value = certificate.Bairro.Length > 50 ? certificate.Bairro.Substring(0, 50) : certificate.Bairro;
                        worksheet.Cells[i, ++l].Value = certificate.Cidade.Length > 50 ? certificate.Cidade.Substring(0, 50) : certificate.Cidade;
                        worksheet.Cells[i, ++l].Value = certificate.CEP.NumbersOnly();
                        worksheet.Cells[i, ++l].Value = certificate.UF;
                        worksheet.Cells[i, ++l].Value = (i - 1).ToString("000000000");

                        i++;
                    }
                    fileBytes = excelPackage.ConvertToCsv();
                }

                return fileBytes;
            }
        }

        public List<AssistanceExportViewModel> GetListAssistanceExportViewModel()
        {
            var connection = context.Database.GetDbConnection();
            connection.Open();

            var command = connection.CreateCommand();

            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "[dbo].[pr_GetAssistanceExport]";

            var _realEstateId = command.CreateParameter();
            _realEstateId.ParameterName = "@RealEstateId";
            _realEstateId.Value = DBNull.Value;
            command.Parameters.Add(_realEstateId);

            var _refMonth = command.CreateParameter();
            _refMonth.ParameterName = "@RefMonth";
            _refMonth.Value = DateTime.Now;
            command.Parameters.Add(_refMonth);

            var reader = command.ExecuteReader();
            var certificates = new List<AssistanceExportViewModel>();
            while (reader.Read())
            {
                var certificate = new AssistanceExportViewModel
                {
                    Apolice = reader["Apolice"].GetString(),
                    ValorAssistencia = reader["ValorAssistencia"].GetDouble(),
                    Bairro = reader["Bairro"].GetString(),
                    CEP = reader["CEP"].GetString(),
                    Cidade = reader["Cidade"].GetString(),
                    Complemento = reader["Complemento"].GetString(),
                    Corretora = reader["Corretora"].GetString(),
                    CPFInquilino = reader["CPFInquilino"].GetString(),
                    CPFProprietario = reader["CPFProprietario"].GetString(),
                    DataDeInclusao = reader["DataDeInclusao"].GetDateTime().Value,
                    VigencyDate = reader["VigencyDate"].GetDateTime().Value,
                    Imobiliaria = reader["Imobiliaria"].GetString(),
                    LocalDeRisco = reader["LocalDeRisco"].GetString(),
                    NomeInquilino = reader["NomeInquilino"].GetString(),
                    NomeProprietario = reader["NomeProprietario"].GetString(),
                    Numero = reader["Numero"].GetString(),
                    Plano = reader["Plano"].GetString(),
                    Produto = reader["Produto"].GetString(),
                    Referencia = reader["Referencia"].GetString(),
                    TipoDeImovel = reader["TipoDeImovel"].GetString(),
                    UF = reader["UF"].GetString(),
                    ProductId = (int)reader["ProductId"],
                    AssistanceId = (int)reader["ProductId"],
                    NomeAssistancia = reader["NomeAssistancia"].GetString(),
                    AssistanceReportCode = reader["AssistanceReportCode"].GetString()
                };
                certificates.Add(certificate);
            }
            connection.Close();

            return certificates;
        }

        public override void ProcessarItem(byte[] item)
        {
            //Enviar arquivo por FTP 

            //var request = (System.Net.FtpWebRequest)System.Net.WebRequest.Create("ftp://ftp.lucasfrancisco.com.br/Teste/" + $"Assistencias_AMAISIMOB_{DateTime.Now:yyyy_MM}.txt");
            //request.Method = System.Net.WebRequestMethods.Ftp.UploadFile;
            //request.Credentials = new NetworkCredential("usuario", "senha");

            //request.ContentLength = item.Length;

            //var requestStream = request.GetRequestStream();
            //requestStream.Write(item, 0, item.Length);
            //requestStream.Close();


            //Envio de e-mail

            //System.Net.Mail.Attachment att = new System.Net.Mail.Attachment(new MemoryStream(item), $"Assistencias_AMAISIMOB_{DateTime.Now:yyyy_MM}.txt", MediaTypeNames.Text.Plain);
            //Services.MailFunctions.Send("AMAISIMOB - Relatório de Assistencias", $"Em anexo o relatório de assistências do dia {DateTime.Now:dd/MM/yyyy}.", new List<string> { "lucas.araujo@bitflag.systems" }, new List<System.Net.Mail.Attachment> { att }, false);
        }

        public override void Progresso(byte[] item)
        {
        }

        public override void Finalizar(byte[] item)
        {
        }
    }
}
