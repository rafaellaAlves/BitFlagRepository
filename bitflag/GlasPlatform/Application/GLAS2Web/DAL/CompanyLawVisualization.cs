using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class CompanyLawVisualization
    {
        public int CompanyLawVisualizationId { get; set; }
        public int UserId { get; set; }
        public int CompanyLawId { get; set; }
        public DateTime VisualizationDate { get; set; }

        public CompanyLawVisualization(){ }
        public CompanyLawVisualization(int companyLawId, int userId) 
        {
            CompanyLawId = companyLawId;
            UserId = userId;
            VisualizationDate = DateTime.Now;
        }
    }
}
