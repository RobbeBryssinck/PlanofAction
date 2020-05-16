using System.Collections.Generic;

namespace LogicInterfaces
{
    public interface IForumThreadCollection
    {
        List<IForumThread> GetForumThreads(int categoryID);
        IForumThread GetForumThread(int threadID);
        int CreateForumThread(IForumThread forumThread);
    }
}