using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.db.Models
{
    public class UserDeliveryInfo
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }
        
        public string UserPhone { get; set; }
        
        public string UserAdress { get; set; }
    }
}
