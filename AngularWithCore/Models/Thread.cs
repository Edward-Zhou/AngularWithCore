using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularWithCore.Models
{
    public class Thread
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime AnsweredTime { get; set; }
        public bool IsAnswered { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser Owner { get; set; }
        public int ForumId { get; set; }
        public Forum Forum { get; set; }
    }
}
