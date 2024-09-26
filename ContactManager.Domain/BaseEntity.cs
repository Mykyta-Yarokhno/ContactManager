﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Domain
{
    public abstract class BaseEntity<T>
    {
        public T Id { get; protected set; }
    }
}