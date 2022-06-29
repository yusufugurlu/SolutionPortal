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
    public class MatchingMasterAccountController : ApiController
    {
        private readonly MatchingMasterAccountManager _matchingMasterAccountManager;
        public MatchingMasterAccountController()
        {
            _matchingMasterAccountManager = new MatchingMasterAccountManager();
        }

        [HttpPost]
        public ServiceResult Get(MatchingMasterAccount costCenter)
        {
            return _matchingMasterAccountManager.Get(costCenter);
        }

        [HttpGet]
        public ServiceResult GetList()
        {
            return _matchingMasterAccountManager.GetList();
        }


        [HttpPost]
        public ServiceResult Add(MatchingMasterAccount costCenter)
        {
            return _matchingMasterAccountManager.Add(costCenter);
        }

        [HttpPost]
        public ServiceResult Delete(MatchingMasterAccount costCenter)
        {
            return _matchingMasterAccountManager.Delete(costCenter);
        }
    }
}
