using API.SolutionPortal.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.SolutionPortal.Models
{
    public class Person
    {
        public int Id { get; set; }
        public CostCenter CostCenter { get; set; }
        public int CostCenterId { get; set; }
        public string PersonCode { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Surname { get; set; }
        public string TcNo { get; set; }
        public PersonRoleType PersonRoleType { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Company Company { get; set; }
        public int CompanyId { get; set; }
        public bool IsDeleted { get; set; }
    }
}