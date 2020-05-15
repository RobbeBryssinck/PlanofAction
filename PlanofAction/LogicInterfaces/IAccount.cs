namespace LogicInterfaces
{
    public interface IAccount
    {
        int AccountID { get; set; }
        string DateJoined { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        string ProfilePicture { get; set; }
        string Role { get; set; }
        string Username { get; set; }

        bool LoginQuery(string username, string password);
    }
}