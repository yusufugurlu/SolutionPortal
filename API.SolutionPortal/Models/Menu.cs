using API.SolutionPortal.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.SolutionPortal.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public PersonRoleType PersonRoleType { get; set; }
    }
}