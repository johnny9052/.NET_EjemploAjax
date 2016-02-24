using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ejemploAJAX.DTO.Security
{
    public class LoginDTO
    {
        public String User { get; set; }
        public String Password { get; set; }

        public LoginDTO(String user, String password)
        {
            User = user;
            Password = password;
        }
    }
}