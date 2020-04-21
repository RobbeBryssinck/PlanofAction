using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataHandler.Models
{
    class ForumThreadDto
    {
        public int ThreadID { get; set; }
        public int AccountID { get; set; }
        public int ForumCategoryID { get; set; }
        [Display(Name="Thread Title")]
        public string ThreadTitle { get; set; }
        [Display(Name="Thread Message")]
        public string ThreadMessage { get; set; }
        [Display(Name="Thread Date Created")]
        public DateTime ThreadDateCreated { get; set; }
    }
}
