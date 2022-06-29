using API.SolutionPortal.Business.Abstract;
using API.SolutionPortal.Common;
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
        public ServiceResult Add(CostCenter costCenter)
        {
            ServiceResult result = new ServiceResult();
            if (costCenter.Id == 0)
            {
                var lastCompany = CostCenterData.CostCenters.LastOrDefault();
                if (lastCompany != null)
                {
                    costCenter.Id = lastCompany.Id + 1;
                }
                else
                {
                    costCenter.Id = 1;
                }
                var company = CompanyData.Companies.FirstOrDefault(x => x.Id == costCenter.CompanyId);
                costCenter.Company = company;
                costCenter.CompanyName = company != null ? company.CompanyCode:"";
                CostCenterData.CostCenters.Add(costCenter);
            }
            else
            {
                var com = CostCenterData.CostCenters.Where(x => x.Id == costCenter.Id).FirstOrDefault();
                if (com != null)
                {
                    com.CostCenterCode = costCenter.CostCenterCode;
                    com.CostCenterDefination = costCenter.CostCenterDefination;
                    com.CompanyId = costCenter.CompanyId;
                    var company = CompanyData.Companies.FirstOrDefault(x => x.Id == costCenter.CompanyId);
                    com.Company = company;
                    com.CompanyName = company != null ? company.CompanyCode : "";
                }
            }

            result.StatusCode = 200;
            result.Message = "İşlem başarılı";
            return result;
        }



        public ServiceResult Delete(CostCenter costCenter)
        {
            ServiceResult result = new ServiceResult();
            var com = CostCenterData.CostCenters.Where(x => x.Id == costCenter.Id).FirstOrDefault();
            if (com != null)
            {
                com.IsDeleted = true;
                result.StatusCode = 200;
                result.Message = "İşlem başarılı";
            }
            else
            {
                result.StatusCode = 400;
                result.Message = "Şirket bulunamadı.";
            }

            return result;
        }

        public ServiceResult Get(CostCenter costCenter)
        {
            ServiceResult result = new ServiceResult();
            result.Data = CostCenterData.CostCenters.Where(x => !x.IsDeleted).Where(x => x.Id == costCenter.Id).FirstOrDefault();
            result.StatusCode = 200;
            result.Message = "İşlem başarılı";
            return result;
        }

        public ServiceResult GetCostCenterByCompanyId(CostCenter costCenter)
        {
            ServiceResult result = new ServiceResult();
            result.Data = CostCenterData.CostCenters.Where(x => !x.IsDeleted && x.CompanyId==costCenter.CompanyId).ToList();
            result.StatusCode = 200;
            result.Message = "İşlem başarılı";
            return result;
        }

        public ServiceResult GetList()
        {
            ServiceResult result = new ServiceResult();
            result.StatusCode = 200;
            result.Data = CostCenterData.CostCenters.Where(x => !x.IsDeleted).ToList();
            result.Message = "İşlem başarılı";
            return result;
        }
    }
}