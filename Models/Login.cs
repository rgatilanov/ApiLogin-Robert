using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginAppApi.Models
{
    public class Login:User
    {
        public string Token { get; set; }
    }
}