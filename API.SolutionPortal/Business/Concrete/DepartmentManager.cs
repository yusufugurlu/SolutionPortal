using API.SolutionPortal.Common;
using API.SolutionPortal.DataAccess.Datas;
using API.SolutionPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.SolutionPortal.Business.Concrete
{
    public class DepartmentManager
    {
        public ServiceResult Add(Department department)
        {
            ServiceResult result = new ServiceResult();
            if (department.Id == 0)
            {
                var lastCompany = DepartmentData.Departments.LastOrDefault();
                if (lastCompany != null)
                {
                    department.Id = lastCompany.Id + 1;
                }
                else
                {
                    department.Id = 1;
                }
                DepartmentData.Departments.Add(department);
            }
            else
            {
                var com = DepartmentData.Departments.Where(x => x.Id == department.Id).FirstOrDefault();
                if (com != null)
                {
                    com.Code = department.Code;
                    com.Defination = department.Defination;
                    com.PersonelCode = department.PersonelCode;
                }
            }

            result.StatusCode = 200;
            result.Message = "İşlem başarılı";
            return result;
        }

        public ServiceResult Delete(Department department)
        {
            ServiceResult result = new ServiceResult();
            var com = DepartmentData.Departments.Where(x => x.Id == department.Id).FirstOrDefault();
            if (com != null)
            {
                com.IsDeleted = true;
                result.StatusCode = 200;
                result.Message = "İşlem başarılı";
            }
            else
            {
                result.StatusCode = 400;
                result.Message = "Şirket bulunamadı.";
            }

            return result;
        }

        public ServiceResult Get(Department department)
        {
            ServiceResult result = new ServiceResult();
            result.Data = DepartmentData.Departments.Where(x => !x.IsDeleted).Where(x => x.Id == department.Id).FirstOrDefault();
            result.StatusCode = 200;
            result.Message = "İşlem başarılı";
            return result;
        }


        public ServiceResult GetList()
        {
            ServiceResult result = new ServiceResult();
            result.StatusCode = 200;
            result.Data = DepartmentData.Departments.Where(x => !x.IsDeleted).ToList();
            result.Message = "İşlem başarılı";
            return result;
        }
    }
}