using API.SolutionPortal.Business.Abstract;
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
    public class CostCenterController : ApiController
    {

        private readonly ICostCenterService _costCenterService;
        public CostCenterController()
        {
            _costCenterService = new CostCenterManager();
        }

        [HttpPost]
        public ServiceResult Get(CostCenter costCenter)
        {
            return _costCenterService.Get(costCenter);
        }

        [HttpGet]
        public ServiceResult GetList()
        {
            return _costCenterService.GetList();
        }


        [HttpPost]
        public ServiceResult Add(CostCenter costCenter)
        {
            return _costCenterService.Add(costCenter);
        }

        [HttpPost]
        public ServiceResult Delete(CostCenter costCenter)
        {
            return _costCenterService.Delete(costCenter);
        }

        [HttpPost]
        public ServiceResult GetCostCenterByCompanyId(CostCenter costCenter)
        {
            return _costCenterService.GetCostCenterByCompanyId(costCenter);
        }
    }
}
