﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlanofAction.Models;

namespace PlanofAction.ViewModels
{
    public class ForumPostViewModel
    {
        public Account ThreadCreator { get; set; }
        public string ThreadTitle { get; set; }
        public string ThreadMessage { get; set; }
        public string ThreadCategory { get; set; }
        public DateTime ThreadDateCreated { get; set; }
        public List<Post> Posts { get; set; }
    }
}
