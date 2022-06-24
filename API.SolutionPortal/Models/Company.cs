using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.SolutionPortal.Models
{
    public class Company
    {
        public int Id { get; set; }
        /// <summary>
        /// Şirket Kodu
        /// </summary>
        public string CompanyCode { get; set; }
        /// <summary>
        /// Şirket tanımlama
        /// </summary>
        public string CompanyDefination { get; set; }
        public bool IsDeleted { get; set; }
    }
}