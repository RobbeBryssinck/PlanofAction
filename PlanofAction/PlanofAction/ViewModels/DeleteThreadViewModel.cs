using LogicInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanofAction.ViewModels
{
    public class DeleteThreadViewModel
    {
        public IForumThread ForumThread { get; set; }
        public IForumCategory ForumCategory { get; set; }
    }
}
