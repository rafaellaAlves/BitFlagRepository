﻿using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Utils
{
    public class TagHelperCutPaste
    {
        public const string ItemsStorageKey = "a2b459c4-3c62-4a90-977a-5999eb5978c5";

        // CutPasteKey identifies the appartenence of the cuted part to the paste section
        public string CutPasteKey { get; set; }

        // Cut script TagContent
        public TagHelperContent TagHelperContent { get; set; }

        // Attributes belonging to the cut script
        public List<TagHelperAttribute> Attributes { get; set; }
    }
}
