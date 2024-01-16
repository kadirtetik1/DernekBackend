using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Address: BaseEntity
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string FatherName { get; set; }
        public string address { get; set; }
        public string Phone { get; set; }
        public string WorkInfo { get; set; }
        public string Unvan { get; set; }
        public Guid? UserID { get; set; }
        public User CreatedUser { get; set; }
    }
}
