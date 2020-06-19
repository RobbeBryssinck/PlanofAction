using DataHandlerFactory;
using DataHandlerInterfaces;
using LogicInterfaces;
using System;

namespace Logic
{
    public class Account : IAccount
    {
        private IAccountContext db;
        public int AccountID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string ProfilePicture { get; set; }
        public string DateJoined { get; set; }

        public Account(IAccountContext accountContext)
        {
            db = accountContext;
        }

        public bool LoginQuery(string username, string password)
        {
            IAccountDto accountDto = db.GetAccount(username);
            if (username == accountDto.Username && password == accountDto.Password)
                return true;
            else
                return false;
        }
    }
}
