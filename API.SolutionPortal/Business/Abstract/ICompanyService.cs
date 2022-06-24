using API.SolutionPortal.Dtos;
using API.SolutionPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.SolutionPortal.Business.Abstract
{
    public interface ICompanyService
    {
        Company Add(Company company);
        List<Company> GetList();
        Company Get(Company company);
        bool Delete(int id);
        Company Update(Company company);
        List<CompanyDropdownDto> GetcompanyForDropdown();
    }
}
