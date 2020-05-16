using System.Collections.Generic;

namespace DataHandlerInterfaces
{
    public interface IForumPostContext
    {
        string ConnectionString { get; set; }

        void CreatePost(IForumPostDto forumPostDto);
        IForumPostDto GetForumPost(int postID);
        void EditForumPost(IForumPostDto forumPostDto);
        List<IForumPostDto> GetForumPosts(int threadID);
    }
}