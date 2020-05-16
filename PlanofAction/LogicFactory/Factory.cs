using Logic;
using LogicInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicFactory
{
    public static class Factory
    {
        public static IAccount GetAccount()
        {
            return new Account();
        }

        public static IAccountCollection GetAccountCollection()
        {
            return new AccountCollection();
        }

        public static IActionPlan GetActionPlan()
        {
            return new ActionPlan();
        }

        public static IActionPlanCollection GetActionPlanCollection()
        {
            return new ActionPlanCollection();
        }

        public static IForumCategory GetForumCategory()
        {
            return new ForumCategory();
        }

        public static IForumCategoryCollection GetForumCategoryCollection()
        {
            return new ForumCategoryCollection();
        }

        public static IForumThread GetForumThread()
        {
            return new ForumThread();
        }

        public static IForumThreadCollection GetForumThreadCollection()
        {
            return new ForumThreadCollection();
        }

        public static IForumPost GetForumPost()
        {
            return new ForumPost();
        }

        public static IForumPostCollection GetForumPostCollection()
        {
            return new ForumPostCollection();
        }
    }
}
