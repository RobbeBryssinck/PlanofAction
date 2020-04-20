using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlanofAction.ViewModels
{
    public class CreateActionPlanViewModel
    {
        public int AccountID { get; set; }
        [Required]
        [StringLength(300)]
        public string PlanTitle { get; set; }
        [Required]
        [StringLength(10000)]
        public string PlanMessage { get; set; }
        [Required]
        [StringLength(100)]
        public string PlanCategory { get; set; }
    }
}
