using DB;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;

namespace GoggleDriveImport
{
    class Program
    {
        const string filePath = "C:\\Users\\lucas\\Downloads\\Clientes-20201109T171539Z-001\\Clientes";
        const string googleDriveFile = "E:\\Desenvolvimento\\BitFlag\\TFS - BitFlag\\TerraNostra\\TerraNostraCRM\\Application\\TerraNostraCRM\\GoggleDriveImport\\MyProject-66223163b12b.json";
        const string DbCredentials = "Server=sistema.tncidadaniaitaliana.com.br;Database=TerraNostra_Dev;User Id=TerraNostra;Password=Trocar123!;MultipleActiveResultSets=true;";

        static void Main(string[] args)
        {
            var context = new DB.TerraNostraContext(new DbContextOptionsBuilder<DB.TerraNostraContext>().UseSqlServer(DbCredentials, opt => { opt.CommandTimeout(3600); })); ;

            var googleDriveAPI = new GoogleDriveAPI.GoogleDriveAPI(googleDriveFile);

            var clients = from c in context.Client join ca in context.ClientArchive on c.ClientId equals ca.ClientId where !ca.IsDeleted group ca by c;

            foreach (var client in clients)
            {
                Console.WriteLine($"Salvando arquivos do cliente: {client.Key.ClientId}");

                var folderId = googleDriveAPI.CreateFolder(client.Key.ClientId.ToString(), "1Tg6SHcAEt0qApouyWlDk_IDvdBajidxE");

                foreach (var clientArchive in client)
                {
                    var document = GetClientDocument(client.Key);
                    var folder = (string.IsNullOrWhiteSpace(client.Key.RazaoSocial) ? client.Key.FirstName + " " + client.Key.LastName : client.Key.RazaoSocial) + (string.IsNullOrWhiteSpace(document) ? "" : $"({document})");
                    folder = folder.TrimEnd().TrimStart();

                    if (!File.Exists(Path.Combine(filePath, folder, clientArchive.FileName)))
                        continue;

                    using var stream = new MemoryStream(File.ReadAllBytes(Path.Combine(filePath, folder, clientArchive.FileName)));
                    clientArchive.FilePath = googleDriveAPI.CreateFile(clientArchive.FileName, folderId, stream, clientArchive.ContentType);

                    context.ClientArchive.Update(clientArchive);
                }
            }

            context.SaveChanges();
        }

        static string GetClientDocument(Client client)
        {
            var document = (string.IsNullOrWhiteSpace(client.Cnpj) ? client.Cpf : client.Cnpj);

            if (string.IsNullOrWhiteSpace(document)) return "";
            else if (document.Length > 11) return Int64.Parse(document).ToString(@"00\.000\.000\/0000\-00");
            else return Int64.Parse(document).ToString(@"000\.000\.000\-00");
        }
    }
}
