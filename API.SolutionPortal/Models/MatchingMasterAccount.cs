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
        
    }
}