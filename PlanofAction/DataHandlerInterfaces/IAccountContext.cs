﻿using System.Collections.Generic;

namespace DataHandlerInterfaces
{
    public interface IAccountContext
    {
        string ConnectionString { get; set; }

        List<IAccountDto> GetAccounts();
        IAccountDto GetAccount(string username);
        IAccountDto GetAccount(int accountID);
    }
}