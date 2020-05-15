using System.Collections.Generic;

namespace LogicInterfaces
{
    public interface IForumPostCollection
    {
        List<IForumPost> GetForumPosts(int threadID);
        IForumPost GetForumPost(int postID);
        void CreatePost(IForumPost forumPost);
    }
}