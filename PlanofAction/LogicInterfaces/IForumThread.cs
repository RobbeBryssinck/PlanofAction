using System;

namespace LogicInterfaces
{
    public interface IForumThread
    {
        int AccountID { get; set; }
        int ForumCategoryID { get; set; }
        DateTime ThreadDateCreated { get; set; }
        int ThreadID { get; set; }
        string ThreadMessage { get; set; }
        string ThreadTitle { get; set; }

        void EditForumThread();
        void DeleteForumThread();
    }
}