using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlanofAction.Models
{
    public class ForumCategory
    {
        public int ForumCategoryID { get; set; }
        [Display(Name="Category")]
        public string ForumCategoryString { get; set; }
    }
}
