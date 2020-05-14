using LogicInterfaces;
using System.Collections.Generic;

namespace LogicInterfaces
{
    interface IForumThreadCollection
    {
        List<IForumThread> GetForumThreads();
    }
}