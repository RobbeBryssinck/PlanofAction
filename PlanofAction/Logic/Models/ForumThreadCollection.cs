using System;
using System.Collections.Generic;
using System.Text;
using DataHandlerInterfaces;
using DataHandlerFactory;
using LogicInterfaces;
using DataHandler.Models;

namespace Logic.Models
{
    public class ForumThreadCollection : IForumThreadCollection
    {
        private IForumThreadContext db;
        private List<IForumThread> forumThreads;

        public ForumThreadCollection()
        {
            db = Factory.GetForumThreadContext();
        }

        public List<IForumThread> GetForumThreads(int categoryID)
        {
            List<ForumThreadDto> forumThreadDtos = db.GetForumThreads(categoryID);
            return forumThreads;
        }
    }
}
