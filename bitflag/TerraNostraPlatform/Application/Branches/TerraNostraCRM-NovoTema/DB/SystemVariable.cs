using System;
using System.Collections.Generic;

namespace DB
{
    public partial class SystemVariable
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public bool Internal { get; set; }
    }
}
