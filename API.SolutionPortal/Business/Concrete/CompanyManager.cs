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
    public class CompanyManager : ICompanyService
    {
        public ServiceResult Add(Company company)
        {
            ServiceResult result = new ServiceResult();
            if (company.Id==0)
            {
                var lastCompany = CompanyData.Companies.LastOrDefault();
                if (lastCompany != null)
                {
                    company.Id = lastCompany.Id + 1;
                }
                else
                {
                    company.Id = 1;
                }
                CompanyData.Companies.Add(company);
            }
            else
            {
                var com = CompanyData.Companies.Where(x => x.Id == company.Id).FirstOrDefault();
                if (com != null)
                {
                    com.CompanyCode = company.CompanyCode;
                    com.CompanyDefination = company.CompanyDefination;
                }
            }

            result.StatusCode = 200;
            result.Message = "İşlem başarılı";
            return result;
        }

        public ServiceResult Delete(Company company)
        {
            ServiceResult result = new ServiceResult();
            var com = CompanyData.Companies.Where(x => x.Id == company.Id).FirstOrDefault();
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

        public ServiceResult Get(Company company)
        {
            ServiceResult result = new ServiceResult();
           result.Data = CompanyData.Companies.Where(x => !x.IsDeleted).Where(x => x.Id == company.Id).FirstOrDefault();
            result.StatusCode = 200;
            result.Message = "İşlem başarılı";
            return result;
        }

        public List<CompanyDropdownDto> GetcompanyForDropdown()
        {
            return CompanyData.Companies.Where(x => !x.IsDeleted).Select(x => new CompanyDropdownDto()
            {
                Id = x.Id,
                CompanyCode = x.CompanyCode
            }).ToList();
        }

        public ServiceResult GetList()
        {
            ServiceResult result = new ServiceResult();
            result.StatusCode = 200;
            result.Data= CompanyData.Companies.Where(x => !x.IsDeleted).ToList();
            result.Message = "İşlem başarılı";
            return result;
        }

        public Company Update(Company company)
        {
            var com = CompanyData.Companies.Where(x => x.Id == company.Id).FirstOrDefault();
            if (com != null)
            {
                com.CompanyCode = company.CompanyCode;
                com.CompanyDefination = company.CompanyDefination;
            }
            return company;
        }
    }
}