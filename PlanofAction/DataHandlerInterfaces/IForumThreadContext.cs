using System.Collections.Generic;

namespace DataHandlerInterfaces
{
    public interface IForumThreadContext
    {
        int CreateThread(IForumThreadDto forumThreadDto);
        void DeleteThread(int threadID);
        void EditThread(IForumThreadDto forumThreadDto);
        IForumThreadDto GetForumThread(int threadID);
        List<IForumThreadDto> GetForumThreads(int categoryID);
    }
}