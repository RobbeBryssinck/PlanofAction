using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PlanofAction.Models;

namespace PlanofAction.ViewModels
{
    public class CreateForumThreadViewModel
    {
        [Display(Name="Account ID")]
        public int AccountID { get; set; }
        [Display(Name="Title")]
        public string ThreadTitle { get; set; }
        [Display(Name="Message")]
        public string ThreadMessage { get; set; }
        public DateTime ThreadDateCreated { get; set; }
        public ForumCategory Category { get; set; }
    }
}
