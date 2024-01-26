﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.UtcNow;
        //public DateTime CreatedTime { get; set; } = DateTime.UtcNow.ToString("yyyy-mm-dd");

    }
}
