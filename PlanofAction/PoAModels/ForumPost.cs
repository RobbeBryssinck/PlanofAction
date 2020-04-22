using System;
using System.Collections.Generic;
using System.Text;

namespace PoAModels
{
    class ForumPost
    {
        public int PostID { get; set; }
        public int ThreadID { get; set; }
        public int AccountID { get; set; }
        public string PostMessage { get; set; }
        public DateTime PostDateCreated { get; set; }
    }
}
