﻿using System;
using System.Collections.Generic;

namespace OnlineShop.db.Models
{
    public class Cart
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public List<CartItem> Items { get; set; }
        
        public DateTime CreatedDateTime { get; set; }

        public Cart()
        {
            CreatedDateTime = DateTime.Now;
            Items = new List<CartItem>();
        }
    }
}
