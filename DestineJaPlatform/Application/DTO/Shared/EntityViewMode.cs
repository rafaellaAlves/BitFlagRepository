using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Shared
{
    public class EntityViewMode<TViewModel>
    {
        public ViewMode ViewMode { get; set; }
        public TViewModel Model { get; set; }
        public bool LoadFromController { get; set; }

        public EntityViewMode() { }
        public EntityViewMode(TViewModel model, bool loadFromController = false)
        {
            ViewMode = ViewMode.Editable;
            Model = model;
            LoadFromController = loadFromController;
        }
        public EntityViewMode(ViewMode viewMode, TViewModel model, bool loadFromController = false)
        {
            ViewMode = viewMode;
            Model = model;
            LoadFromController = loadFromController;
        }
    }
}
