using DTO.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.Shared
{
    public class FileViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string viewComponentId, int id, string guidName, string fileName, string getUrl, string setUrl, string downloadUrl, string removeUrl, bool loadFromController = false, bool isModal = false) => await Task.Run(() => View(new EntityViewMode<FileViewModel>(ViewMode.Editable, new FileViewModel(viewComponentId, id, guidName, fileName, getUrl, setUrl, downloadUrl, removeUrl, isModal), loadFromController)));
    }
}
