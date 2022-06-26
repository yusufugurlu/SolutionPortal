using API.SolutionPortal.Common;
using API.SolutionPortal.DataAccess.Datas;
using API.SolutionPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.SolutionPortal.Business.Concrete
{
    public class TaxCodeManager
    {
        public ServiceResult Add(TaxCode taxCode)
        {
            ServiceResult result = new ServiceResult();
            if (taxCode.Id == 0)
            {
                var lastCompany = TaxCodeData.CostTypes.LastOrDefault();
                if (lastCompany != null)
                {
                    taxCode.Id = lastCompany.Id + 1;
                }
                else
                {
                    taxCode.Id = 1;
                }
                TaxCodeData.CostTypes.Add(taxCode);
            }
            else
            {
                var cost = TaxCodeData.CostTypes.Where(x => x.Id == taxCode.Id).FirstOrDefault();
                if (cost != null)
                {
                    cost.Indicator = taxCode.Indicator;
                    cost.Defination = taxCode.Defination;
                    cost.Rate = taxCode.Rate;
                }
            }

            result.StatusCode = 200;
            result.Message = "İşlem başarılı";
            return result;
        }

        public ServiceResult Delete(TaxCode taxCode)
        {
            ServiceResult result = new ServiceResult();
            var com = TaxCodeData.CostTypes.Where(x => x.Id == taxCode.Id).FirstOrDefault();
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

        public ServiceResult Get(TaxCode taxCode)
        {
            ServiceResult result = new ServiceResult();
            result.Data = TaxCodeData.CostTypes.Where(x => !x.IsDeleted).Where(x => x.Id == taxCode.Id).FirstOrDefault();
            result.StatusCode = 200;
            result.Message = "İşlem başarılı";
            return result;
        }


        public ServiceResult GetList()
        {
            ServiceResult result = new ServiceResult();
            result.StatusCode = 200;
            result.Data = TaxCodeData.CostTypes.Where(x => !x.IsDeleted).ToList();
            result.Message = "İşlem başarılı";
            return result;
        }
    }
}