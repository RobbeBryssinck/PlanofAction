using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataHandler.Models
{
    class ForumCategoryDto
    {
        public int ForumCategoryID { get; set; }
        [Display(Name="Category")]
        public string ForumCategoryString { get; set; }
    }
}
