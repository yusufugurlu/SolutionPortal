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
    public class CompanyManager : ICompanyService
    {
        public Company Add(Company company)
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
            return company;
        }

        public bool Delete(int id)
        {
            var company = CompanyData.Companies.Where(x => x.Id == id).FirstOrDefault();
            if (company != null)
            {
                company.IsDeleted = true;
                return true;
            }
            return false;
        }

        public Company Get(Company company)
        {
            var com = CompanyData.Companies.Where(x => !x.IsDeleted).Where(x => x.Id == company.Id).FirstOrDefault();
            return com;
        }

        public List<CompanyDropdownDto> GetcompanyForDropdown()
        {
            return CompanyData.Companies.Where(x => !x.IsDeleted).Select(x => new CompanyDropdownDto()
            {
                Id = x.Id,
                CompanyCode = x.CompanyCode
            }).ToList();
        }

        public List<Company> GetList()
        {
            return CompanyData.Companies.Where(x => !x.IsDeleted).ToList();
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