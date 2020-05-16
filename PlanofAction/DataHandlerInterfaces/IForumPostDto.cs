using System;

namespace DataHandlerInterfaces
{
    public interface IForumPostDto
    {
        int AccountID { get; set; }
        DateTime PostDateCreated { get; set; }
        int PostID { get; set; }
        string PostMessage { get; set; }
        int ThreadID { get; set; }
    }
}