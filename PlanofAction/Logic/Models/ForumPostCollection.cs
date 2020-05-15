using DataHandler.Context;
using DataHandlerFactory;
using DataHandlerInterfaces;
using LogicInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Models
{
    public class ForumPostCollection : IForumPostCollection
    {
        private IForumPostContext db;
        private List<IForumPost> forumPosts;

        public ForumPostCollection()
        {
            db = Factory.GetForumPostContext();
            forumPosts = new List<IForumPost>();
        }

        public List<IForumPost> GetForumPosts(int threadID)
        {
            List<IForumPostDto> forumPostDtos = db.GetForumPosts(threadID);
            foreach (var forumPostDto in forumPostDtos)
            {
                forumPosts.Add(new ForumPost()
                {
                    PostID = forumPostDto.PostID,
                    ThreadID = forumPostDto.ThreadID,
                    AccountID = forumPostDto.AccountID,
                    PostMessage = forumPostDto.PostMessage,
                    PostDateCreated = forumPostDto.PostDateCreated,
                });
            }
            return forumPosts;
        }

        public IForumPost GetForumPost(int postID)
        {
            IForumPostDto forumPostDto = db.GetForumPost(postID);
            IForumPost forumPost = new ForumPost()
            {
                PostID = forumPostDto.PostID,
                ThreadID = forumPostDto.ThreadID,
                AccountID = forumPostDto.AccountID,
                PostMessage = forumPostDto.PostMessage,
                PostDateCreated = forumPostDto.PostDateCreated,
            };
            return forumPost;
        }

        public void CreatePost(IForumPost forumPost)
        {
            IForumPostDto forumPostDto = Factory.GetForumPostDto();
            forumPostDto.ThreadID = forumPost.ThreadID;
            forumPostDto.AccountID = forumPost.AccountID;
            forumPostDto.PostMessage = forumPost.PostMessage;
            forumPostDto.PostDateCreated = forumPost.PostDateCreated;

            db.CreatePost(forumPostDto);
        }
    }
}
