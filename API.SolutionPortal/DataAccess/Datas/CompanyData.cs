using API.SolutionPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.SolutionPortal.DataAccess.Datas
{
    public static class CompanyData
    {
        public static List<Company> Companies = new List<Company>() {
            new Company()
            {
                Id=1,
                CompanyCode="1",
                CompanyDefination="Parent Company"
            }
        };
    }
}