﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MYWEBMVC_Template.App_Classes
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string SecretQuestion { get; set; }
        public string SecretAnswer { get; set; }
    }
}