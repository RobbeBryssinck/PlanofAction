using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlanofAction.Models;

namespace PlanofAction.ViewModels
{
    public class CreateForumThreadViewModel
    {
        public int AccountID { get; set; }
        public string ThreadTitle { get; set; }
        public string ThreadMessage { get; set; }
        public DateTime ThreadDateCreated { get; set; }
        public ForumCategory Category { get; set; }
    }
}
