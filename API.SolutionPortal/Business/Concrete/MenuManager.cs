using API.SolutionPortal.Common;
using API.SolutionPortal.Common.Enums;
using API.SolutionPortal.DataAccess.Datas;
using API.SolutionPortal.Dtos;
using API.SolutionPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace API.SolutionPortal.Business.Concrete
{
    public class MenuManager
    {
        public ServiceResult GetMenus(MenuParamaterDto menuParamaterDto)
        {
            ServiceResult result = new ServiceResult();
            var menus = new List<Menu>();
            if (((PersonRoleType)menuParamaterDto.Id) == PersonRoleType.Admin)
            {
                menus = MenuData.Menus.Where(x => x.PersonRoleType == PersonRoleType.Admin).ToList();
                result.Data = menus;
            }
            else
            {
                menus = MenuData.Menus.Where(x => x.PersonRoleType == PersonRoleType.Person).ToList();
                result.Data = menus;
            }

            result.StatusCode = 200;
            return result;
        }
    }
}