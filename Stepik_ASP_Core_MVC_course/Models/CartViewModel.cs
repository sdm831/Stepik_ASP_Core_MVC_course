﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Stepik_ASP_Core_MVC_course.Models
{
    public class CartViewModel
    {
        public Guid Id { get; set; }

        public string UserId { get; set; }

        public List<CartItemViewModel> Items { get; set; }

        public decimal Cost
        {
            get
            {
                return Items?.Sum(x => x.Cost) ?? 0;
            }
        }

        public decimal Amount
        {
            get
            {
                //return Items?.Sum(x => x.Amount) ?? 0;
                return Items?.Sum(x => x.Cost) ?? 0;
            }
        }
    }
}
