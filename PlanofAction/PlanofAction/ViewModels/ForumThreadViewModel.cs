using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LogicInterfaces;
using PlanofAction.Models;

namespace PlanofAction.ViewModels
{
    public class ForumThreadViewModel
    {
        // Thread and post view
        public int ThreadID { get; set; }
        public IAccount ThreadCreator { get; set; }
        public string ThreadTitle { get; set; }
        public string ThreadMessage { get; set; }
        public DateTime ThreadDateCreated { get; set; }
        public List<IPost> Posts { get; set; }
        
        // Post submit
        [Display(Name="Poster Account ID")]
        public int PosterAccountID { get; set; }
        [Display(Name="Poster Message")]
        public string PosterMessage { get; set; }
    }
}
