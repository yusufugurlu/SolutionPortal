using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.SolutionPortal.Dtos
{
    public class LoginDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}