using System;
using System.Collections.Generic;
using System.Text;
using DTO.Utils;

namespace DTO.Indication
{
    public class IndicationListViewModel
    {
        public int? IndicationId { get; set; }
        public int? UserId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int? ServiceTypeId { get; set; }
        public string ServiceTypeName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string _CreatedDate { get { return CreatedDate.ToDateTimePtBR(); } }
        public DateTime? DeleteDate { get; set; }
        public string _DeletedOnlyDate { get { return DeleteDate.ToDatePtBR(); } }
        public string _DeletedOnlyHour { get { return DeleteDate.ToTimePtBR(); } }
        public int? DeletedBy { get; set; }
        public string DeletedName { get; set; }
        public bool IsDeleted { get; set; }
        public bool Accepted { get; set; }
        public DateTime? AcceptedDate { get; set; }
        public string _AcceptedOnlyDate { get { return AcceptedDate.ToDatePtBR(); } }
        public string _AcceptedOnlyHour { get { return AcceptedDate.ToTimePtBR(); } }
        public int? AcceptedBy { get; set; }
        public string AcceptedName { get; set; }
    }
}
