﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NEA.CustomAttributes
{
    public class FutureDate : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return value == null || (DateTime)value > DateTime.Now;
        }
    }
}
