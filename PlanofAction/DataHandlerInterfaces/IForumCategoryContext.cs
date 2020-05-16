using System.Collections.Generic;

namespace DataHandlerInterfaces
{
    public interface IForumCategoryContext
    {
        string ConnectionString { get; set; }

        int CreateForumCategory(IForumCategoryDto forumCategory);
        void DeleteForumCategory(int forumCategoryID);
        void EditForumCategory(IForumCategoryDto forumCategory);
        List<IForumCategoryDto> GetForumCategories();
        IForumCategoryDto GetForumCategory(int forumCategoryID);
    }
}