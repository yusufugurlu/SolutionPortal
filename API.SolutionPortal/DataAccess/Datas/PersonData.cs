using API.SolutionPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.SolutionPortal.DataAccess.Datas
{
    public static class PersonData
    {
        public static List<Person> Persons = new List<Person>() {
            new Person()
            {
                Id=1,
                Name="admin",
                Surname="admin",
                Username="admin",
                Password="123",
                PersonCode="000",
                PersonRoleType=Common.Enums.PersonRoleType.Admin,
                SecondName="admin",
                CompanyId=1
            }
        };
    }
}