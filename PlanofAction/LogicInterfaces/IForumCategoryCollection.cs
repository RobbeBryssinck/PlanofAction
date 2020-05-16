using System.Collections.Generic;

namespace LogicInterfaces
{
    public interface IForumCategoryCollection
    {
        List<IForumCategory> GetForumCategories();
        IForumCategory GetForumCategory(int forumCategoryID);
        int CreateForumCategory(IForumCategory forumCategory);
    }
}
