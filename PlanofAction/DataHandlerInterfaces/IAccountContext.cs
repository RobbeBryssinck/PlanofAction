using System.Collections.Generic;

namespace DataHandlerInterfaces
{
    public interface IAccountContext
    {
        List<IAccountDto> GetAccounts();
        IAccountDto GetAccount(string username);
        IAccountDto GetAccount(int accountID);
    }
}