using API.SolutionPortal.Common;
using API.SolutionPortal.DataAccess.Datas;
using API.SolutionPortal.Dtos;
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
    }
}