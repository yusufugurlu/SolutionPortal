using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.SolutionPortal.Models
{
    /// <summary>
    /// Masraf Yeri & Ana Hesap Eşleştirme
    /// </summary>
    public class MatchingMasterAccount
    {
        public int Id { get; set; }
        public Company Company { get; set; }
        public int CompanyId { get; set; }
        public CostCenter FirstCostCenter { get; set; }
        public int FirstCostCenterId { get; set; }
        public CostCenter LastCostCenter { get; set; }
        public int LastCostCenterId { get; set; }
        public string MasterAccount { get; set; }
        public bool IsDeleted { get; set; }
    }
}