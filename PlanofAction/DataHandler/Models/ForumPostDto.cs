using System;
using System.Collections.Generic;
using System.Text;

namespace DataHandler.Models
{
    class ForumPostDto
    {
        public int PostID { get; set; }
        public int ThreadID { get; set; }
        public int AccountID { get; set; }
        public string PostMessage { get; set; }
        public DateTime PostDateCreated { get; set; }
    }
}
