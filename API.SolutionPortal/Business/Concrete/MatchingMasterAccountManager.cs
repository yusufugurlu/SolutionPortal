using API.SolutionPortal.Common;
using API.SolutionPortal.DataAccess.Datas;
using API.SolutionPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.SolutionPortal.Business.Concrete
{
    public class MatchingMasterAccountManager
    {
        public ServiceResult GetList()
        {
            ServiceResult result = new ServiceResult();
            var persons = MatchingMasterAccountData.MatchingMasterAccounts.Where(x => !x.IsDeleted).ToList();
            result.Message = "İşlem başarılı";
            result.StatusCode = 200;
            result.Data = persons;
            return result;
        }

        public ServiceResult Delete(MatchingMasterAccount matchingMasterAccount)
        {
            ServiceResult result = new ServiceResult();
            var com = MatchingMasterAccountData.MatchingMasterAccounts.Where(x => x.Id == matchingMasterAccount.Id).FirstOrDefault();
            if (com != null)
            {
                com.IsDeleted = true;
                result.StatusCode = 200;
                result.Message = "İşlem başarılı";
            }
            else
            {
                result.StatusCode = 400;
                result.Message = "Eşleşme bulunamadı.";
            }

            return result;
        }

        public ServiceResult Get(MatchingMasterAccount matchingMasterAccount)
        {
            ServiceResult result = new ServiceResult();
            var persons = MatchingMasterAccountData.MatchingMasterAccounts.FirstOrDefault(x => !x.IsDeleted && x.Id == matchingMasterAccount.Id);
            result.Message = "İşlem başarılı";
            result.StatusCode = 200;
            result.Data = persons;
            return result;
        }

        public ServiceResult Add(MatchingMasterAccount matchingMasterAccount)
        {
            ServiceResult result = new ServiceResult();
            if (matchingMasterAccount.Id == 0)
            {
                var lastPerson = MatchingMasterAccountData.MatchingMasterAccounts.LastOrDefault();
                if (lastPerson != null)
                {
                    matchingMasterAccount.Id = lastPerson.Id + 1;
                }
                else
                {
                    matchingMasterAccount.Id = 1;
                }

                var company = CompanyData.Companies.FirstOrDefault(x => x.Id == matchingMasterAccount.CompanyId);
                if (company != null)
                {
                    matchingMasterAccount.Company = company;
                    matchingMasterAccount.CompanyId = company.Id;
                }

                var firstcostCenter = CostCenterData.CostCenters.FirstOrDefault(x => x.Id == matchingMasterAccount.FirstCostCenterId);
                if (firstcostCenter != null)
                {
                    matchingMasterAccount.FirstCostCenter = firstcostCenter;
                    matchingMasterAccount.FirstCostCenterId = firstcostCenter.Id;
                }

                var lastcostCenter = CostCenterData.CostCenters.FirstOrDefault(x => x.Id == matchingMasterAccount.LastCostCenterId);
                if (lastcostCenter != null)
                {
                    matchingMasterAccount.LastCostCenter = lastcostCenter;
                    matchingMasterAccount.LastCostCenterId = lastcostCenter.Id;
                }
                MatchingMasterAccountData.MatchingMasterAccounts.Add(matchingMasterAccount);
            }
            else
            {
                var tmmpatchingMasterAccount = MatchingMasterAccountData.MatchingMasterAccounts.FirstOrDefault(x => x.Id == matchingMasterAccount.Id);
                if (tmmpatchingMasterAccount != null)
                {
                    tmmpatchingMasterAccount.MasterAccount = matchingMasterAccount.MasterAccount;
                    var company = CompanyData.Companies.FirstOrDefault(x => x.Id == matchingMasterAccount.CompanyId);
                    if (company != null)
                    {
                        tmmpatchingMasterAccount.Company = company;
                        tmmpatchingMasterAccount.CompanyId = company.Id;
                    }

                    var firstcostCenter = CostCenterData.CostCenters.FirstOrDefault(x => x.Id == matchingMasterAccount.FirstCostCenterId);
                    if (firstcostCenter != null)
                    {
                        tmmpatchingMasterAccount.FirstCostCenter = firstcostCenter;
                        tmmpatchingMasterAccount.FirstCostCenterId = firstcostCenter.Id;
                    }

                    var lastcostCenter = CostCenterData.CostCenters.FirstOrDefault(x => x.Id == matchingMasterAccount.LastCostCenterId);
                    if (lastcostCenter != null)
                    {
                        tmmpatchingMasterAccount.LastCostCenter = lastcostCenter;
                        tmmpatchingMasterAccount.LastCostCenterId = lastcostCenter.Id;
                    }

                }
            }

            result.Message = "İşlem başarılı";
            result.StatusCode = 200;
            result.Data = true;
            return result;
        }
    }
}