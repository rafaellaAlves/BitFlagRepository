using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GoogleDriveAPI
{
    public class GoogleDriveAPI
    {
        private ServiceAccountCredential _serviceAccountCredential;
        private DriveService _driveService;

        public GoogleDriveAPI(string json)
        {
            dynamic _json = JsonConvert.DeserializeObject<object>(File.ReadAllText(json));
            var x = _json.client_id;

            this._serviceAccountCredential = new ServiceAccountCredential(new ServiceAccountCredential.Initializer((string)_json.client_id) { Scopes = new string[] { DriveService.Scope.Drive } }.FromPrivateKey((string)_json.private_key));
            this._driveService = new DriveService(new BaseClientService.Initializer() { HttpClientInitializer = this._serviceAccountCredential, ApplicationName = "TerraNostraCRM" });
        }

        #region [FOLDER]
        public string GetFolderIdByName(string name, string parent)
        {
            var listRequest = this._driveService.Files.List();
            listRequest.Q = string.IsNullOrWhiteSpace(parent) ? "name='" + name + "' and mimeType = 'application/vnd.google-apps.folder'" : "name='" + name + "' and mimeType = 'application/vnd.google-apps.folder' and '" + parent + "' in parents";

            var files = listRequest.Execute().Files;
            foreach (var file in files)
                return file.Id;

            return null;
        }
        public string CreateFolder(string name, string parent)
        {
            var fileMetadata = new Google.Apis.Drive.v3.Data.File() { Name = name, MimeType = "application/vnd.google-apps.folder" };
            if (!string.IsNullOrWhiteSpace(parent)) fileMetadata.Parents = new List<string>() { parent };

            var request = this._driveService.Files.Create(fileMetadata);
            request.Fields = "id";

            var file = request.Execute();

            return file.Id;
        }
        public void RemoveFolder(string id)
        {
            var request = this._driveService.Files.Delete(id);
            request.Execute();
        }
        #endregion

        #region [FILE]
        public string GetFileIdByName(string name, string parent)
        {
            var listRequest = this._driveService.Files.List();
            listRequest.Q = string.IsNullOrWhiteSpace(parent) ? "name='" + name + "' and mimeType != 'application/vnd.google-apps.folder'" : "name='" + name + "' and mimeType != 'application/vnd.google-apps.folder' and '" + parent + "' in parents";

            var files = listRequest.Execute().Files;
            foreach (var file in files)
                return file.Id;

            return null;
        }
        public string CreateFile(string name, string parent, Stream stream, string mimeType)
        {
            var fileMetadata = new Google.Apis.Drive.v3.Data.File() { Name = name };
            if (!string.IsNullOrWhiteSpace(parent)) fileMetadata.Parents = new List<string>() { parent };

            var request = this._driveService.Files.Create(fileMetadata, stream, mimeType);
            request.Fields = "id";
            request.Upload();

            var file = request.ResponseBody;
            return file.Id;
        }
        public Stream GetFile(string id)
        {
            var request = this._driveService.Files.Get(id);
            var stream = new System.IO.MemoryStream();
            request.Download(stream);

            stream.Seek(0, SeekOrigin.Begin);

            return stream;
        }
        public void RemoveFile(string id)
        {
            var request = this._driveService.Files.Delete(id);
            request.Execute();
        }
        #endregion
    }
}