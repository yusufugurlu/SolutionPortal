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

        public ServiceResult Get(Person person)
        {
            ServiceResult result = new ServiceResult();
            var persons = PersonData.Persons.FirstOrDefault(x => !x.IsDeleted && x.PersonRoleType != Common.Enums.PersonRoleType.Admin && x.Id==person.Id);
            result.Message = "İşlem başarılı";
            result.StatusCode = 200;
            result.Data = persons;
            return result;
        }

        public ServiceResult Add(Person person)
        {
            ServiceResult result = new ServiceResult();
            var persons = PersonData.Persons.FirstOrDefault(x => !x.IsDeleted && x.PersonRoleType != Common.Enums.PersonRoleType.Admin && x.Id == person.Id);
            result.Message = "İşlem başarılı";
            result.StatusCode = 200;
            result.Data = persons;
            return result;
        }
    }
}