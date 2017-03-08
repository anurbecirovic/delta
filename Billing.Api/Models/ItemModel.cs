﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Billing.Api.Models
{
    public class ItemModel
    {
     
        public int Id { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double SubTotal { get; set; }
    }
}

