using LogicInterfaces;
using System.Collections.Generic;

namespace LogicInterfaces
{
    public interface IForumThreadCollection
    {
        List<IForumThread> GetForumThreads(int categoryID);
    }
}