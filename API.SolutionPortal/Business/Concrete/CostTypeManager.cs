using API.SolutionPortal.Common;
using API.SolutionPortal.DataAccess.Datas;
using API.SolutionPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.SolutionPortal.Business.Concrete
{
    public class CostTypeManager
    {
        public ServiceResult Add(CostType costType)
        {
            ServiceResult result = new ServiceResult();
            if (costType.Id == 0)
            {
                var lastCompany = CostTypeData.CostTypes.LastOrDefault();
                if (lastCompany != null)
                {
                    costType.Id = lastCompany.Id + 1;
                }
                else
                {
                    costType.Id = 1;
                }
                CostTypeData.CostTypes.Add(costType);
            }
            else
            {
                var cost = CostTypeData.CostTypes.Where(x => x.Id == costType.Id).FirstOrDefault();
                if (cost != null)
                {
                    cost.Code = costType.Code;
                    cost.Defination = costType.Defination;
                    cost.ParentAccount = costType.ParentAccount;
                }
            }

            result.StatusCode = 200;
            result.Message = "İşlem başarılı";
            return result;
        }

        public ServiceResult Delete(CostType costType)
        {
            ServiceResult result = new ServiceResult();
            var com = CostTypeData.CostTypes.Where(x => x.Id == costType.Id).FirstOrDefault();
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

        public ServiceResult Get(CostType costType)
        {
            ServiceResult result = new ServiceResult();
            result.Data = CostTypeData.CostTypes.Where(x => !x.IsDeleted).Where(x => x.Id == costType.Id).FirstOrDefault();
            result.StatusCode = 200;
            result.Message = "İşlem başarılı";
            return result;
        }


        public ServiceResult GetList()
        {
            ServiceResult result = new ServiceResult();
            result.StatusCode = 200;
            result.Data = CostTypeData.CostTypes.Where(x => !x.IsDeleted).ToList();
            result.Message = "İşlem başarılı";
            return result;
        }
    }
}