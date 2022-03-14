﻿using Microsoft.AspNetCore.Identity;
using OnlineShop.db.Models;


namespace OnlineShop.db
{
    public class IdentityInitializer
    {
        public static void Initialize(UserManager<UserDb> userManager, RoleManager<IdentityRole> roleManager)
        {
            var adminEmail = "adm1@adm.com";
            var password = "Adm1@adm.com";

            if(roleManager.FindByNameAsync(Constants.AdminRoleName).Result == null)
            {
                roleManager.CreateAsync(new IdentityRole(Constants.AdminRoleName)).Wait();
            }

            if (roleManager.FindByNameAsync(Constants.UserRoleName).Result == null)
            {
                roleManager.CreateAsync(new IdentityRole(Constants.UserRoleName)).Wait();
            }

            if(userManager.FindByNameAsync(adminEmail).Result == null)
            {   
                var admin = new UserDb { Email = adminEmail, UserName = adminEmail };
                var result = userManager.CreateAsync(admin, password).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(admin, Constants.AdminRoleName).Wait();
                }
            }
        }

    }
}
