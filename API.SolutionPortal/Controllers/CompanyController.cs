using API.SolutionPortal.Business.Abstract;
using API.SolutionPortal.Business.Concrete;
using API.SolutionPortal.Dtos;
using API.SolutionPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.SolutionPortal.Controllers
{
   // [Route("api/{controller}/{action}")]
    public class CompanyController : ApiController
    {
        private readonly ICompanyService _companyService;
        public CompanyController()
        {
            _companyService = new CompanyManager();
        }

        [HttpPost]
        public Company Get(Company company)
        {
            return _companyService.Get(company);
        }

        [HttpGet]
        public List<Company> GetList()
        {
            return _companyService.GetList();
        }

        [HttpGet]
        public List<CompanyDropdownDto> GetListForDropdown()
        {
            return _companyService.GetcompanyForDropdown();
        }

        [HttpPost]
        public Company Add(Company company)
        {
            return _companyService.Add(company);
        }

        [HttpPost]
        public bool Delete(int id)
        {
            return _companyService.Delete(id);
        }

        [HttpPost]
        public Company Update(Company company)
        {
            return _companyService.Update(company);
        }
    }
}
