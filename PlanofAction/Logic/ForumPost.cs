using DataHandlerInterfaces;
using DataHandlerFactory;
using LogicInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class ForumPost : IForumPost
    {
        private IForumPostContext db;
        public int PostID { get; set; }
        public int ThreadID { get; set; }
        public int AccountID { get; set; }
        public string PostMessage { get; set; }
        public DateTime PostDateCreated { get; set; }
        public IAccount Account { get; set; }

        public ForumPost(IForumPostContext forumPostContext)
        {
            db = forumPostContext;
        }

        public void EditPost()
        {
            IForumPostDto forumPostDto = DataHandlerFactory.DataHandlerFactory.GetForumPostDto();
            forumPostDto.PostID = PostID;
            forumPostDto.PostMessage = PostMessage;
            db.EditForumPost(forumPostDto);
        }
    }
}
