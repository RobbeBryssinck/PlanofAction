using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlanofAction.Models;

namespace PlanofAction.ViewModels
{
    public class ForumPostViewModel
    {
        public string ThreadTitle { get; set; }
        public string ThreadMessage { get; set; }
        public string ThreadCategory { get; set; }
        public string ThreadDateCreated { get; set; }
        public List<Post> posts { get; set; }
    }
}
