﻿using System;
using System.Collections.Generic;

namespace AMaisImob_DB.Models
{
    public partial class CertificateContractualApolicyFile
    {
        public int CertificateContractualApolicyFileId { get; set; }
        public int CertificateContractualId { get; set; }
        public string FileGuid { get; set; }
        public string FileName { get; set; }
        public string FileMimeType { get; set; }
    }
}
