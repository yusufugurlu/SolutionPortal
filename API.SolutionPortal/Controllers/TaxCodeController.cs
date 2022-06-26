using API.SolutionPortal.Business.Concrete;
using API.SolutionPortal.Common;
using API.SolutionPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.SolutionPortal.Controllers
{
    public class TaxCodeController : ApiController
    {
        private readonly TaxCodeManager _taxCodeManager;
        public TaxCodeController()
        {
            _taxCodeManager = new TaxCodeManager();
        }

        [HttpPost]
        public ServiceResult Get(TaxCode taxCode)
        {
            return _taxCodeManager.Get(taxCode);
        }

        [HttpGet]
        public ServiceResult GetList()
        {
            return _taxCodeManager.GetList();
        }


        [HttpPost]
        public ServiceResult Add(TaxCode taxCode)
        {
            return _taxCodeManager.Add(taxCode);
        }

        [HttpPost]
        public ServiceResult Delete(TaxCode taxCode)
        {
            return _taxCodeManager.Delete(taxCode);
        }
    }
}
