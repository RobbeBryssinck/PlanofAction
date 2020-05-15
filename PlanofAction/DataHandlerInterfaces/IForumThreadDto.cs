using System;

namespace DataHandlerInterfaces
{
    public interface IForumThreadDto
    {
        int AccountID { get; set; }
        int ForumCategoryID { get; set; }
        DateTime ThreadDateCreated { get; set; }
        int ThreadID { get; set; }
        string ThreadMessage { get; set; }
        string ThreadTitle { get; set; }
    }
}