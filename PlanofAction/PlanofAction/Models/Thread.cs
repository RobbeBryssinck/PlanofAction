using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanofAction.Models
{
    public class Thread
    {
        public int ThreadID { get; set; }
        public int AccountID { get; set; }
        public string ThreadTitle { get; set; }
        public string ThreadMessage { get; set; }
        public string ThreadCategory { get; set; }
        public DateTime ThreadDateCreated { get; set; }
    }
}
