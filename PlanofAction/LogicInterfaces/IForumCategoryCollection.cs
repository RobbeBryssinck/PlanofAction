using System.Collections.Generic;

namespace LogicInterfaces
{
    public interface IForumCategoryCollection
    {
        List<IForumCategory> ForumCategories();
        IForumCategory GetForumCategory(int forumCategoryID);
        int CreateForumCategory(IForumCategory forumCategory);
    }
}
