using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Shared
{
    public class FileViewModel
    {
        public string ViewComponentId { get; set; }
        public int Id { get; set; }
        public string FileName { get; set; }
        //public string GuidName { get; set; }
        public string GetUrl { get; set; }
        public string SetUrl { get; set; }
        public string DownloadUrl { get; set; }
        public string RemoveUrl { get; set; }
        public bool IsModal { get; set; }

        public FileViewModel(string viewComponentId, int id, string guidName, string fileName, string getUrl, string setUrl, string downloadUrl, string removeUrl, bool isModal = false)
        {
            ViewComponentId = viewComponentId;
            Id = id;
            //GuidName = guidName;
            FileName = fileName;
            GetUrl = getUrl;
            SetUrl = setUrl;
            DownloadUrl = downloadUrl;
            RemoveUrl = removeUrl;
            IsModal = isModal;
        }
        public FileViewModel(string viewComponentId, int id, string fileName, string getUrl, string setUrl, string downloadUrl, string removeUrl, bool isModal = false)
        {
            ViewComponentId = viewComponentId;
            Id = id;
            //GuidName = guidName;
            FileName = fileName;
            GetUrl = getUrl;
            SetUrl = setUrl;
            DownloadUrl = downloadUrl;
            RemoveUrl = removeUrl;
            IsModal = isModal;
        }
    }
}
