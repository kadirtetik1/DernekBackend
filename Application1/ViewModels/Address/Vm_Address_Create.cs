﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application1.ViewModels.Address
{
    public class Vm_Address_Create
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string FatherName { get; set; }
        public string address { get; set; }
        public string Phone { get; set; }
        public string WorkInfo { get; set; }
        public string Unvan { get; set; }
        public string Family { get; set; }
        public Guid? UserID { get; set; }
    }
}
