﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Domain.ValueObjects
{
    public record Money(decimal Amount, string Currency = "USD");
}
