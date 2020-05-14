using System;
using System.Collections.Generic;
using System.Text;
using LogicInterfaces;

namespace Logic.Models
{
    public class ForumThread : IForumThread
    {
        public int ThreadID { get; set; }
        public int AccountID { get; set; }
        public int ForumCategoryID { get; set; }
        public string ThreadTitle { get; set; }
        public string ThreadMessage { get; set; }
        public DateTime ThreadDateCreated { get; set; }
    }
}
