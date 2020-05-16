using DataHandlerFactory;
using DataHandlerInterfaces;
using LogicInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic.Models
{
    public class ForumCategoryCollection : IForumCategoryCollection
    {
        private IForumCategoryContext db { get; set; }
        private List<IForumCategory> ForumCategories { get; set; }

        public ForumCategoryCollection()
        {
            ForumCategories = new List<IForumCategory>();
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

        public List<IForumCategory> GetForumCategories()
        {
            return ForumCategories;
        }

        public IForumCategory GetForumCategory(int forumCategoryID)
        {
            return ForumCategories.Where(x => x.ForumCategoryID == forumCategoryID).FirstOrDefault();
        }

        public int CreateForumCategory(IForumCategory forumCategory)
        {
            IForumCategoryDto forumCategoryDto = Factory.GetForumCategoryDto();
            forumCategoryDto.ForumCategoryString = forumCategory.ForumCategoryString;
            int rowcount = db.CreateForumCategory(forumCategoryDto);
            return rowcount;
        }
    }
}
