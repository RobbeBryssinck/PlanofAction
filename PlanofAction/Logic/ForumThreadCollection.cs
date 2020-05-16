using System;
using System.Collections.Generic;
using System.Text;
using DataHandlerInterfaces;
using DataHandlerFactory;
using LogicInterfaces;
using DataHandler.Models;

namespace Logic
{
    public class ForumThreadCollection : IForumThreadCollection
    {
        private IForumThreadContext db;
        private List<IForumThread> forumThreads;

        public ForumThreadCollection()
        {
            db = Factory.GetForumThreadContext();
            forumThreads = new List<IForumThread>();
        }

        public List<IForumThread> GetForumThreads(int categoryID)
        {
            List<IForumThreadDto> forumThreadDtos = db.GetForumThreads(categoryID);
            foreach (var thread in forumThreadDtos)
            {
                forumThreads.Add(new ForumThread()
                {
                    ThreadID = thread.ThreadID,
                    AccountID = thread.AccountID,
                    ForumCategoryID = thread.ForumCategoryID,
                    ThreadTitle = thread.ThreadTitle,
                    ThreadMessage = thread.ThreadMessage,
                    ThreadDateCreated = thread.ThreadDateCreated
                });
            }
            return forumThreads;
        }

        public IForumThread GetForumThread(int threadID)
        {
            IForumThreadDto forumThreadDto = db.GetForumThread(threadID);
            IForumThread forumThread = new ForumThread()
            {
                AccountID = forumThreadDto.AccountID,
                ForumCategoryID = forumThreadDto.ForumCategoryID,
                ThreadDateCreated = forumThreadDto.ThreadDateCreated,
                ThreadID = forumThreadDto.ThreadID,
                ThreadMessage = forumThreadDto.ThreadMessage,
                ThreadTitle = forumThreadDto.ThreadTitle,
            };

            return forumThread;
        }

        public int CreateForumThread(IForumThread forumThread)
        {
            IForumThreadDto forumThreadDto = new ForumThreadDto()
            {
                AccountID = forumThread.AccountID,
                ForumCategoryID = forumThread.ForumCategoryID,
                ThreadTitle = forumThread.ThreadTitle,
                ThreadMessage = forumThread.ThreadMessage,
                ThreadDateCreated = forumThread.ThreadDateCreated,
            };

            int rowcount = db.CreateThread(forumThreadDto);

            return rowcount;
        }
    }
}
