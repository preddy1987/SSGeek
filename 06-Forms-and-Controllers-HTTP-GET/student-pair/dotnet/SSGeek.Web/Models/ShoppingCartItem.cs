﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSGeek.Web.Models
{
    public class ShoppingCartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}

