using System;
using System.Collections.Generic;
using System.Text;
using DataHandler.Context;
using DataHandler.Models;
using DataHandlerInterfaces;

namespace DataHandlerFactory
{
    public static class Factory
    {
        public static IActionPlanContext GetActionPlanContext()
        {
            return new ActionPlanContext();
        }

        public static IActionPlanDto GetActionPlanDto()
        {
            return new ActionPlanDto();
        }

        public static IForumCategoryContext GetForumCategoryContext()
        {
            return new ForumCategoryContext();
        }

        public static IForumCategoryDto GetForumCategoryDto()
        {
            return new ForumCategoryDto();
        }
    }
}

