using API.SolutionPortal.Business.Concrete;
using API.SolutionPortal.Common;
using API.SolutionPortal.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.SolutionPortal.Controllers
{
    public class MenuController : ApiController
    {
        private readonly MenuManager menuManager;
        public MenuController()
        {
            menuManager = new MenuManager();
        }

        [HttpPost]
        public ServiceResult GetMenus(MenuParamaterDto menuParamaterDto)
        {
            var response = menuManager.GetMenus(menuParamaterDto);
            return response;
        }
    }
}
