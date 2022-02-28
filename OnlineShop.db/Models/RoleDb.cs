using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.db.Models
{
    public class RoleDb
    {        
        public Guid id { get; set; }

        public string Name { get; set; }
    }
}
