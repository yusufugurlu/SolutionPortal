using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.SolutionPortal.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Defination { get; set; }
        public string PersonelCode { get; set; }
        public bool IsDeleted { get; set; }
    }
}