using DTO.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Residue
{
    public class ResidueFamilyViewModel
    {
        public int? ResidueFamilyId { get; set; }
        [Update]
        public string Name { get; set; }
        [Update]
        public string NameAbbreviation { get; set; }
        [Update]
        public int? ResidueFamilyClassId { get; set; }
        [Update]
        public string Risk { get; set; }
        [Update]
        public string RiskClass { get; set; }
        [Update]
        public string ONUCode { get; set; }
        public string GroupName { get; set; }
        public int? GroupOrder { get; set; }
        /// <summary>
        /// Usado na atribuição de famílias no MTR de Coleta, se o valor for "false" outras familías que não sejam do mesmo agrupamento desta família não podem ser atribuidas.
        /// </summary>
        public bool AcceptDifferentFamilies { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int? DeletedBy { get; set; }
    }
}
