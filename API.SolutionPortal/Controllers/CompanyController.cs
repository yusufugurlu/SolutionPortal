using API.SolutionPortal.Business.Abstract;
using API.SolutionPortal.Business.Concrete;
using API.SolutionPortal.Common;
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
        public ServiceResult Get(Company company)
        {
            return _companyService.Get(company);
        }

        [HttpGet]
        public ServiceResult GetList()
        {
            return _companyService.GetList();
        }

        [HttpGet]
        public List<CompanyDropdownDto> GetListForDropdown()
        {
            return _companyService.GetcompanyForDropdown();
        }

        [HttpPost]
        public ServiceResult Add(Company company)
        {
            return _companyService.Add(company);
        }

        [HttpPost]
        public ServiceResult Delete(Company company)
        {
            return _companyService.Delete(company);
        }

        [HttpPost]
        public Company Update(Company company)
        {
            return _companyService.Update(company);
        }
    }
}
