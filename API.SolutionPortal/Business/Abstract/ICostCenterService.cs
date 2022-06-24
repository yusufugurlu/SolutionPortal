using API.SolutionPortal.Dtos;
using API.SolutionPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.SolutionPortal.Business.Abstract
{
   public interface ICostCenterService
    {
        CostCenter Add(CostCenter costCenter);
        List<CostCenter> GetList();
        CostCenter Get(CostCenter costCenter);
        bool Delete(int id);
        CostCenter Update(CostCenter costCenter);
        List<CostCenterDropdownDto> GetCostCenterForDropdown();
    }
}
