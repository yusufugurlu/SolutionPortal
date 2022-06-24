using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.SolutionPortal.Dtos
{
    public class LoginResponseDto
    {
        public int PersonType { get; set; }
        public string FullName { get; set; }
        public string PersonTypeName { get; set; }
    }
}