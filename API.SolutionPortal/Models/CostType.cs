using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.SolutionPortal.Models
{
    /// <summary>
    /// Masraf Türü
    /// </summary>
    public class CostType
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Defination { get; set; }
        /// <summary>
        /// Ana Hesap
        /// </summary>
        public string ParentAccount { get; set; }
        public bool IsDeleted { get; set; }

    }
}