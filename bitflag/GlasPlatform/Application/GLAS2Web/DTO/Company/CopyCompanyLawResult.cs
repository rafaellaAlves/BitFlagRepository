using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Company
{
    public class CopyCompanyLawResult
    {
        public int Total { get; set; }
        public int Removed { get; set; }

        public CopyCompanyLawResult(int total, int removed)
        {
            Total = total;
            Removed = removed;
        }
    }
}
