﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AMaisImob_DB.Models
{
    public class CertificateContractualPendencyFile
    {
        public int CertificateContractualPendencyFileId { get; set; }
        public int CertificateContractualId { get; set; }
        public string FileGUID { get; set; }
        public string FileName { get; set; }
        public string FileMimeType { get; set; }
    }
}
