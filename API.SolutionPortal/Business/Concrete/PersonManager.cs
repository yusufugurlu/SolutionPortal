using API.SolutionPortal.Common;
using API.SolutionPortal.DataAccess.Datas;
using API.SolutionPortal.Dtos;
using API.SolutionPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.SolutionPortal.Business.Concrete
{
    public class PersonManager
    {

        public ServiceResult Login(LoginDto loginDto)
        {
            ServiceResult result = new ServiceResult();
            var person = PersonData.Persons.Where(x => x.Username == loginDto.UserName && x.Password == loginDto.Password).FirstOrDefault();
            if (person != null)
            {
                LoginResponseDto loginResponseDto = new LoginResponseDto()
                {
                    FullName = person.Name + " " + person.Surname,
                    PersonType = (int)person.PersonRoleType,
                    PersonTypeName = person.PersonRoleType.ToString()
                };
                result.Data = loginResponseDto;
                result.Message = "İşlem başarılı";
                result.StatusCode = 200;
            }
            else
            {
                result.Message = "Kullanıcı adı ve şifre hatalı.";
                result.StatusCode = 400;
            }

            return result;
        }

        public ServiceResult GetList()
        {
            ServiceResult result = new ServiceResult();
            var persons = PersonData.Persons.Where(x => !x.IsDeleted && x.PersonRoleType != Common.Enums.PersonRoleType.Admin).ToList();
            result.Message = "İşlem başarılı";
            result.StatusCode = 200;
            result.Data = persons;
            return result;
        }

        public ServiceResult Delete(Person person)
        {
            ServiceResult result = new ServiceResult();
            var com = PersonData.Persons.Where(x => x.Id == person.Id).FirstOrDefault();
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
        
        public ServiceResult Get(Person person)
        {
            ServiceResult result = new ServiceResult();
            var persons = PersonData.Persons.FirstOrDefault(x => !x.IsDeleted && x.PersonRoleType != Common.Enums.PersonRoleType.Admin && x.Id == person.Id);
            result.Message = "İşlem başarılı";
            result.StatusCode = 200;
            result.Data = persons;
            return result;
        }

        public ServiceResult Add(Person person)
        {
            ServiceResult result = new ServiceResult();
            if (person.Id == 0)
            {
                var lastPerson = PersonData.Persons.LastOrDefault();
                if (lastPerson != null)
                {
                    person.Id = lastPerson.Id + 1;
                }
                else
                {
                    person.Id = 1;
                }

                var company = CompanyData.Companies.FirstOrDefault(x => x.Id == person.CompanyId);
                if (company != null)
                {
                    person.Company = company;
                    person.CompanyId = company.Id;
                }

                var costCenter = CostCenterData.CostCenters.FirstOrDefault(x => x.Id == person.CostCenterId);
                if (costCenter != null)
                {
                    person.CostCenter = costCenter;
                    person.CostCenterId = costCenter.Id;
                }

                var department = DepartmentData.Departments.FirstOrDefault(x => x.Id == person.DepartmentId);
                if (costCenter != null)
                {
                    person.Department = department;
                    person.DepartmentId = department.Id;
                }
                person.PersonRoleType = Common.Enums.PersonRoleType.Person;
                person.Password = "123";
                person.Username = person.Name + "." + person.Surname;
                PersonData.Persons.Add(person);
            }
            else
            {
                var tmpPerson = PersonData.Persons.FirstOrDefault(x=>x.Id==person.Id);
                if (tmpPerson != null)
                {
                    tmpPerson.Name = person.Name;
                    tmpPerson.PersonCode = tmpPerson.PersonCode;
                    tmpPerson.PersonRoleType = Common.Enums.PersonRoleType.Person;
                    tmpPerson.TcNo = person.TcNo;
                    tmpPerson.SecondName = person.SecondName;
                    tmpPerson.Surname = person.Surname;
                    tmpPerson.PersonCode = person.PersonCode;
                    var company = CompanyData.Companies.FirstOrDefault(x => x.Id == person.CompanyId);
                    if (company != null)
                    {
                        tmpPerson.Company = company;
                        tmpPerson.CompanyId = company.Id;
                    }

                    var costCenter = CostCenterData.CostCenters.FirstOrDefault(x => x.Id == person.CostCenterId);
                    if (costCenter != null)
                    {
                        tmpPerson.CostCenter = costCenter;
                        tmpPerson.CostCenterId = costCenter.Id;
                    }

                    var department = DepartmentData.Departments.FirstOrDefault(x => x.Id == person.DepartmentId);
                    if (costCenter != null)
                    {
                        tmpPerson.Department = department;
                        tmpPerson.DepartmentId = department.Id;
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