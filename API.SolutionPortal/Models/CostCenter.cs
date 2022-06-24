using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.SolutionPortal.Models
{
    /// <summary>
    /// Masraf Merkezi
    /// </summary>
    public class CostCenter
    {
        public int Id { get; set; }
        public Company Company { get; set; }
        public int CompanyId { get; set; }
        /// <summary>
        /// Masraf merkezi kodu
        /// </summary>
        public string CostCenterCode { get; set; }
        /// <summary>
        /// Masraf merkezi Tanımlama
        /// </summary>
        public string CostCenterDefination { get; set; }
        public bool IsDeleted { get; set; }
    }
}