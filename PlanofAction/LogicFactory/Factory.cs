﻿using Logic.Models;
using LogicInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicFactory
{
    public static class Factory
    {
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
    }
}
