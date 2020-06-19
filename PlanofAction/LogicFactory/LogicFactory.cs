using Logic;
using LogicInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicFactory
{
    public static class LogicFactory
    {
        public static IAccount GetAccount()
        {
            return new Account(DataHandlerFactory.DataHandlerFactory.GetAccountContext());
        }

        public static IAccountCollection GetAccountCollection()
        {
            return new AccountCollection(DataHandlerFactory.DataHandlerFactory.GetAccountContext());
        }

        public static IActionPlan GetActionPlan()
        {
            return new ActionPlan(DataHandlerFactory.DataHandlerFactory.GetActionPlanContext());
        }

        public static IActionPlanCollection GetActionPlanCollection()
        {
            return new ActionPlanCollection(DataHandlerFactory.DataHandlerFactory.GetActionPlanContext());
        }

        public static IForumCategory GetForumCategory()
        {
            return new ForumCategory(DataHandlerFactory.DataHandlerFactory.GetForumCategoryContext());
        }

        public static IForumCategoryCollection GetForumCategoryCollection()
        {
            return new ForumCategoryCollection(DataHandlerFactory.DataHandlerFactory.GetForumCategoryContext());
        }

        public static IForumThread GetForumThread()
        {
            return new ForumThread(DataHandlerFactory.DataHandlerFactory.GetForumThreadContext());
        }

        public static IForumThreadCollection GetForumThreadCollection()
        {
            return new ForumThreadCollection(DataHandlerFactory.DataHandlerFactory.GetForumThreadContext());
        }

        public static IForumPost GetForumPost()
        {
            return new ForumPost(DataHandlerFactory.DataHandlerFactory.GetForumPostContext());
        }

        public static IForumPostCollection GetForumPostCollection()
        {
            return new ForumPostCollection(DataHandlerFactory.DataHandlerFactory.GetForumPostContext());
        }
    }
}
