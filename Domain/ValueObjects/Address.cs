﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public record  Address(string Street, string City, string PostalCode)
    {
     
    }
}
