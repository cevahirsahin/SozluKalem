﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozluKalem.Entity.DTOs.Users
{
    public class UserLoginDto
    {
        public string Email { get; set; }   
        public string Password { get; set; }        
        public bool RememberMe { get; set; }    
    }
}