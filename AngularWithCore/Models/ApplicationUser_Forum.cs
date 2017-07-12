using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularWithCore.Models
{
    public class ApplicationUser_Forum
    {
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int ForumId { get; set; }
        public Forum Forum { get; set; }
    }
}
