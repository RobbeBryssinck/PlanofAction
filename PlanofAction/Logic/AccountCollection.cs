using DataHandlerFactory;
using DataHandlerInterfaces;
using LogicInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class AccountCollection : IAccountCollection
    {
        private IAccountContext db;
        private List<IAccount> accounts;

        public AccountCollection(IAccountContext accountContext)
        {
            accounts = new List<IAccount>();
            db = accountContext;
            List<IAccountDto> accountDtos = db.GetAccounts();
            foreach (var account in accountDtos)
            {
                accounts.Add(new Account(DataHandlerFactory.DataHandlerFactory.GetAccountContext())
                {
                    AccountID = account.AccountID,
                    Username = account.Username,
                    Email = account.Email,
                    Password = account.Password,
                    Role = account.Role,
                    ProfilePicture = account.ProfilePicture,
                    DateJoined = account.DateJoined,
                });
            }
        }

        public List<IAccount> GetAccounts()
        {
            return accounts;
        }

        public IAccount GetAccount(int accountID)
        {
            IAccountDto accountDto = db.GetAccount(accountID);
            IAccount account = new Account(DataHandlerFactory.DataHandlerFactory.GetAccountContext())
            {
                AccountID = accountDto.AccountID,
                DateJoined = accountDto.DateJoined,
                Email = accountDto.Email,
                Password = accountDto.Password,
                ProfilePicture = accountDto.ProfilePicture,
                Role = accountDto.Role,
                Username = accountDto.Username,
            };
            return account;
        }
    }
}
