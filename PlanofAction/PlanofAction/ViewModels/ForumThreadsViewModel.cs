using LogicInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanofAction.ViewModels
{
    public class ForumThreadsViewModel
    {
        public List<IForumThread> ForumThreads { get; set; }
        public IForumCategory ForumCategory { get; set; }
    }
}
