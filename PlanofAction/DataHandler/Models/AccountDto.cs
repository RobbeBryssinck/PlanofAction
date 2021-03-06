﻿using DataHandlerInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataHandler.Models
{
    public class AccountDto : IAccountDto
    {
        public int AccountID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string ProfilePicture { get; set; }
        public string DateJoined { get; set; }
    }
}
