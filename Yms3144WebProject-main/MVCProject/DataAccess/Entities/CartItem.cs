﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class CartItem
    {
        public CartItem()
        {
            Quantity = 1;
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public short Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }

        public decimal? SubTotal
        {
            get
            {
                return Quantity * UnitPrice;
            }
        }
    }
}
