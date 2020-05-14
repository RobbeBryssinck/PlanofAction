using System;
using System.Collections.Generic;
using System.Text;
using DataHandlerInterfaces;
using DataHandlerFactory;
using LogicInterfaces;

namespace Logic.Models
{
    class ForumThreadCollection : IForumThreadCollection
    {
        private IForumThreadContext db;
        private List<IForumThread> forumThreads;

        public ForumThreadCollection()
        {
            db = Factory.GetForumThreadContext();
            forumThreads = db.GetForumThreads();
        }

        public List<IForumThread> GetForumThreads()
        {
            return forumThreads;
        }
    }
}
