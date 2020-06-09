using System.Collections.Generic;

namespace DataHandlerInterfaces
{
    public interface IForumPostContext
    {
        void CreatePost(IForumPostDto forumPostDto);
        IForumPostDto GetForumPost(int postID);
        void EditForumPost(IForumPostDto forumPostDto);
        List<IForumPostDto> GetForumPosts(int threadID);
    }
}