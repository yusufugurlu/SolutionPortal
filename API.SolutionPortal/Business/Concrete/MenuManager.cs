﻿using API.SolutionPortal.Common;
using API.SolutionPortal.Common.Enums;
using API.SolutionPortal.DataAccess.Datas;
using API.SolutionPortal.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.SolutionPortal.Business.Concrete
{
    public class MenuManager
    {
        public ServiceResult GetMenus(MenuParamaterDto menuParamaterDto)
        {
            ServiceResult result = new ServiceResult();
            var menus= MenuData.Menus.Where(x=>x.PersonRoleType==(PersonRoleType)menuParamaterDto.Id).Select(x=>new MenuDto() {
                Name=x.Name,
                Url=x.Url
            }).ToList();
            result.Data = menus;
            result.StatusCode = 200;
            return result;
        }
    }
}