﻿using System.ComponentModel.DataAnnotations;

namespace OnlineShop.db.Models
{
    public enum OrderStatus
    {        
        Created,        
        Processed,        
        Delivering,        
        Delivered,        
        Canceled
    }
}