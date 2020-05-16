using System;

namespace LogicInterfaces
{
    public interface IForumPost
    {
        int AccountID { get; set; }
        DateTime PostDateCreated { get; set; }
        int PostID { get; set; }
        string PostMessage { get; set; }
        int ThreadID { get; set; }
        IAccount Account { get; set; }

        void EditPost();
    }
}