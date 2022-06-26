using API.SolutionPortal.Common;
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
        ServiceResult Add(Company company);
        ServiceResult GetList();
        ServiceResult Get(Company company);
        ServiceResult Delete(Company company);
        Company Update(Company company);
        List<CompanyDropdownDto> GetcompanyForDropdown();
    }
}
