using System;
using System.Collections.Generic;
using System.Text;
using DataHandlerFactory;
using DataHandlerInterfaces;
using LogicInterfaces;

namespace Logic.Models
{
    public class ForumThread : IForumThread
    {
        private IForumThreadContext db;
        public int ThreadID { get; set; }
        public int AccountID { get; set; }
        public int ForumCategoryID { get; set; }
        public string ThreadTitle { get; set; }
        public string ThreadMessage { get; set; }
        public DateTime ThreadDateCreated { get; set; }

        public ForumThread()
        {
            db = Factory.GetForumThreadContext();
        }

        public void EditForumThread()
        {
            throw new NotImplementedException();
        }

        public void DeleteForumThread()
        {
            db.DeleteThread(ThreadID);
        }
    }
}
