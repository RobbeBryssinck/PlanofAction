using DataHandler.Models;
using DataHandlerFactory;
using DataHandlerInterfaces;
using LogicInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class ForumCategory : IForumCategory
    {
        private IForumCategoryContext db;
        public int ForumCategoryID { get; set; }
        public string ForumCategoryString { get; set; }

        public ForumCategory(IForumCategoryContext forumCategoryContext)
        {
            db = forumCategoryContext;
        }

        public void DeleteForumCategory()
        {
            db.DeleteForumCategory(ForumCategoryID);
        }

        public void EditForumCategory()
        {
            IForumCategoryDto forumCategoryDto = DataHandlerFactory.DataHandlerFactory.GetForumCategoryDto();
            forumCategoryDto.ForumCategoryID = ForumCategoryID;
            forumCategoryDto.ForumCategoryString = ForumCategoryString;
            db.EditForumCategory(forumCategoryDto);
        }
    }
}
