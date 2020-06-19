using DataHandler.Context;
using DataHandlerFactory;
using DataHandlerInterfaces;
using LogicInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class ForumPostCollection : IForumPostCollection
    {
        private IForumPostContext db;
        private IAccountContext accountdb;
        private List<IForumPost> forumPosts;

        public ForumPostCollection(IForumPostContext forumPostContext)
        {
            db = forumPostContext;
            accountdb = DataHandlerFactory.DataHandlerFactory.GetAccountContext();
            forumPosts = new List<IForumPost>();
        }

        public List<IForumPost> GetForumPosts(int threadID)
        {
            List<IForumPostDto> forumPostDtos = db.GetForumPosts(threadID);
            foreach (var forumPostDto in forumPostDtos)
            {
                IAccountDto accountDto = accountdb.GetAccount(forumPostDto.AccountID);
                IAccount account = new Account(DataHandlerFactory.DataHandlerFactory.GetAccountContext())
                {
                    AccountID = accountDto.AccountID,
                    Username = accountDto.Username,
                    Email = accountDto.Email,
                    Password = accountDto.Password,
                    Role = accountDto.Role,
                    ProfilePicture = accountDto.ProfilePicture,
                    DateJoined = accountDto.DateJoined,
                };

                forumPosts.Add(new ForumPost(DataHandlerFactory.DataHandlerFactory.GetForumPostContext())
                {
                    PostID = forumPostDto.PostID,
                    ThreadID = forumPostDto.ThreadID,
                    AccountID = forumPostDto.AccountID,
                    PostMessage = forumPostDto.PostMessage,
                    PostDateCreated = forumPostDto.PostDateCreated,
                    Account = account
                }); 
            }
            return forumPosts;
        }

        public IForumPost GetForumPost(int postID)
        {
            IForumPostDto forumPostDto = db.GetForumPost(postID);
            IForumPost forumPost = new ForumPost(DataHandlerFactory.DataHandlerFactory.GetForumPostContext())
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
            IForumPostDto forumPostDto = DataHandlerFactory.DataHandlerFactory.GetForumPostDto();
            forumPostDto.ThreadID = forumPost.ThreadID;
            forumPostDto.AccountID = forumPost.AccountID;
            forumPostDto.PostMessage = forumPost.PostMessage;
            forumPostDto.PostDateCreated = forumPost.PostDateCreated;

            db.CreatePost(forumPostDto);
        }
    }
}
