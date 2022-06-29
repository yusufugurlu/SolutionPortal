using API.SolutionPortal.Business.Concrete;
using API.SolutionPortal.Common;
using API.SolutionPortal.Dtos;
using API.SolutionPortal.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.SolutionPortal.Controllers
{
    public class PersonController : ApiController
    {
        private readonly PersonManager personManager;
        public PersonController()
        {
            personManager = new PersonManager();
        }

        [HttpPost]
        public ServiceResult Login(LoginDto loginDto)
        {
            var response = personManager.Login(loginDto);
            var str = JsonConvert.SerializeObject(response);
            return response;
        }

        [HttpGet]
        public ServiceResult GetList()
        {
            var response = personManager.GetList();
            return response;
        }

        [HttpPost]
        public ServiceResult Get(Person person)
        {
            var response = personManager.Get(person);
            return response;
        }


        [HttpPost]
        public ServiceResult Add(Person person)
        {
            var response = personManager.Add(person);
            return response;
        }

        [HttpPost]
        public ServiceResult Delete(Person person)
        {
            var response = personManager.Delete(person);
            return response;
        }
    }
}
