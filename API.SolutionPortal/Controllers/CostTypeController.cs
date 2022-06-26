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
    public class CostTypeController : ApiController
    {
        private readonly CostTypeManager _costTypeManager;
        public CostTypeController()
        {
            _costTypeManager = new CostTypeManager();
        }

        [HttpPost]
        public ServiceResult Get(CostType costType)
        {
            return _costTypeManager.Get(costType);
        }

        [HttpGet]
        public ServiceResult GetList()
        {
            return _costTypeManager.GetList();
        }


        [HttpPost]
        public ServiceResult Add(CostType costTyp)
        {
            return _costTypeManager.Add(costTyp);
        }

        [HttpPost]
        public ServiceResult Delete(CostType costTyp)
        {
            return _costTypeManager.Delete(costTyp);
        }

    }
}
