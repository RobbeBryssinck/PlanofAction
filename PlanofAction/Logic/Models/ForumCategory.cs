﻿using LogicInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Models
{
    public class ForumCategory : IForumCategory
    {
        public int ForumCategoryID { get; set; }
        public string ForumCategoryString { get; set; }
    }
}
