using DataHandlerFactory;
using DataHandlerInterfaces;
using LogicInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Models
{
    public class ForumCategoryCollection : IForumCategoryCollection
    {
        private IForumCategoryContext db { get; set; }
        private List<IForumCategory> ForumCategories { get; set; }

        public ForumCategoryCollection()
        {
            db = Factory.GetForumCategoryContext();
            List<IForumCategoryDto> forumCategoryDtos = db.GetForumCategories();
            foreach (IForumCategoryDto forumCategoryDto in forumCategoryDtos)
            {
                ForumCategories.Add(new ForumCategory()
                {
                    ForumCategoryID = forumCategoryDto.ForumCategoryID,
                    ForumCategoryString = forumCategoryDto.ForumCategoryString
                });
            }
        }

        List<IForumCategory> IForumCategoryCollection.ForumCategories()
        {
            throw new NotImplementedException();
        }

        public IForumCategory GetForumCategory(int forumCategoryID)
        {
            throw new NotImplementedException();
        }

        public int CreateForumCategory(IForumCategory forumCategory)
        {
            throw new NotImplementedException();
        }
    }
}
