using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.SolutionPortal.Models
{
    /// <summary>
    /// Vergi Kodu
    /// </summary>
    public class TaxCode
    {
        public int Id { get; set; }
        /// <summary>
        /// Vergi Göstergesi
        /// </summary>
        public string Indicator { get; set; }
        public string Defination { get; set; }
        /// <summary>
        /// Vergi Oranı
        /// </summary>
        public float Rate { get; set; }
        public bool IsDeleted { get; set; }
    }
}