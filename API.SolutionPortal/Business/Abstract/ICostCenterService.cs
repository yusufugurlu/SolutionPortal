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
    public interface ICostCenterService
    {
        ServiceResult Add(CostCenter costCenter);
        ServiceResult GetList();
        ServiceResult Get(CostCenter costCenter);
        ServiceResult Delete(CostCenter costCenter);
        ServiceResult GetCostCenterByCompanyId(CostCenter costCenter);
    }
}
