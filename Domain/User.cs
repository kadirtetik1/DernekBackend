using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class User: BaseEntity
    {
        public String Username { get; set; }
        public String Password { get; set; }
        public String Name { get; set; }
        public String Lastname { get; set; }
        public String Email { get; set; }
        public Boolean Admin { get; set; }

    }
}
