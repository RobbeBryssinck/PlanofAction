using DataHandlerInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataHandler.Models
{
    public class ForumCategoryDto : IForumCategoryDto
    {
        public int ForumCategoryID { get; set; }
        public string ForumCategoryString { get; set; }
    }
}
