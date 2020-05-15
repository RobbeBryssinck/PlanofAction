using LogicInterfaces;
using System.Collections.Generic;

namespace LogicInterfaces
{
    public interface IAccountCollection
    {
        List<IAccount> GetAccounts();
        IAccount GetAccount(int accountID);
    }
}