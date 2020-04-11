using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanofAction.ViewModels
{
    public class ForumPostsViewModel
    {
        public int ThreadID { get; set; }
        public int AccountID { get; set; }
        public int ForumCategory { get; set; }
        public string ThreadTitle { get; set; }
        public string ThreadMessage { get; set; }
        public DateTime ThreadDateCreated { get; set; }
    }
}
