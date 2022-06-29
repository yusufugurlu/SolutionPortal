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
    public class DepartmentController : ApiController
    {
        private readonly DepartmentManager _departmentManager;
        public DepartmentController()
        {
            _departmentManager = new DepartmentManager();
        }

        [HttpPost]
        public ServiceResult Get(Department costCenter)
        {
            return _departmentManager.Get(costCenter);
        }

        [HttpGet]
        public ServiceResult GetList()
        {
            return _departmentManager.GetList();
        }


        [HttpPost]
        public ServiceResult Add(Department costCenter)
        {
            return _departmentManager.Add(costCenter);
        }

        [HttpPost]
        public ServiceResult Delete(Department costCenter)
        {
            return _departmentManager.Delete(costCenter);
        }
    }
}
