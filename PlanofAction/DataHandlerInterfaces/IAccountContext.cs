namespace DataHandlerInterfaces
{
    public interface IAccountContext
    {
        string ConnectionString { get; set; }

        IAccountDto GetAccountByUsername(string username);
        IAccountDto GetThreadCreator(int accountID);
    }
}