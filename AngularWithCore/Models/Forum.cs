using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularWithCore.Models
{
    public class Forum
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public List<Thread> Threads { get; set; }
        public List<ApplicationUser_Forum> ApplicationUser_Forums { get; set; }

    }
}
