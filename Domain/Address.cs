using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Address: BaseEntity
    {
        public String Name { get; set; }
        public String Lastname { get; set; }
        public String FatherName { get; set; }
        public String address { get; set; }
        public String Phone { get; set; }
        public String WorkInfo { get; set; }
        public String Unvan { get; set; }
    }
}
