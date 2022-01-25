﻿using System;

namespace OnlineShop.db.Models
{
    public class Product
    {        
        public Guid Id { get; set; } 
        
        public string Name { get; set; }

        public decimal Cost { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }        
    }
}
