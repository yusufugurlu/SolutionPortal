using API.SolutionPortal.Business.Abstract;
using API.SolutionPortal.DataAccess.Datas;
using API.SolutionPortal.Dtos;
using API.SolutionPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.SolutionPortal.Business.Concrete
{
    public class CostCenterManager : ICostCenterService
    {
        public CostCenter Add(CostCenter costCenter)
        {
            CostCenterData.CostCenters.Add(costCenter);
            return costCenter;
        }

        public bool Delete(int id)
        {
            var costCenter = CostCenterData.CostCenters.Where(x => x.Id == id).FirstOrDefault();
            if (costCenter != null)
            {
                costCenter.IsDeleted = true;
                return true;
            }
            return false;
        }

        public CostCenter Get(CostCenter costCenter)
        {
            var cost = CostCenterData.CostCenters.Where(x => x.Id == costCenter.Id).FirstOrDefault();
            return cost;
        }

        public List<CostCenterDropdownDto> GetCostCenterForDropdown()
        {
            return CostCenterData.CostCenters.Select(x => new CostCenterDropdownDto()
            {
                Id = x.Id,
                CostCenterCode=x.CostCenterCode
            }).ToList();
        }

        public List<CostCenter> GetList()
        {
            return CostCenterData.CostCenters.Where(x => !x.IsDeleted).ToList();
        }

        public CostCenter Update(CostCenter costCenter)
        {
            var com = CostCenterData.CostCenters.Where(x => x.Id == costCenter.Id).FirstOrDefault();
            if (com != null)
            {
                com.CostCenterCode = costCenter.CostCenterCode;
                com.CostCenterDefination = costCenter.CostCenterDefination;
            }
            return com;
        }
    }
}