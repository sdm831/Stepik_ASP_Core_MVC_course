using OnlineShop.db.Models;
using Stepik_ASP_Core_MVC_course.Areas.Admin.Models;
using Stepik_ASP_Core_MVC_course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stepik_ASP_Core_MVC_course.Helpers
{
    public static class Mapping
    {
        public static ProductViewModel ToProductViewModel(Product productDb)
        {
            return new ProductViewModel
            {
                Id = productDb.Id,
                Name = productDb.Name,
                Cost = productDb.Cost,
                Description = productDb.Description,
                ImagePath = productDb.ImagePath
            };
        }

        public static List<ProductViewModel> ToProductViewModels(List<Product> products)
        {
            var productsViewModels = new List<ProductViewModel>();

            foreach (var product in products)
            {
                productsViewModels.Add(Mapping.ToProductViewModel(product));
            }

            return productsViewModels;
        }

        public static Product ToProductDb(ProductViewModel productVm)
        {
            var productDb = new Product
            {
                Id = productVm.Id,
                Name = productVm.Name,
                Cost = productVm.Cost,
                Description = productVm.Description
            };
            
            return productDb;
        }

        public static CartViewModel ToCartViewModel(Cart cartDb)
        {
            if(cartDb == null)
            {
                return null;
            }
            
            return new CartViewModel
            {
                Id = cartDb.Id,
                UserId = cartDb.UserId,
                Items = Mapping.ToCartItemViewModels(cartDb.Items)
            };
        }

        public static List<CartItemViewModel> ToCartItemViewModels(List<CartItem> cartDbItems)
        {
            var cartItems = new List<CartItemViewModel>();

            foreach (var cartDbItem in cartDbItems)
            {
                var cartItem = new CartItemViewModel
                {
                    Id = cartDbItem.Id,
                    Amount = cartDbItem.Amount,
                    Product = Mapping.ToProductViewModel(cartDbItem.Product)
                };
                cartItems.Add(cartItem);
            }
            
            return cartItems;
        }
        
        public static OrderViewModel ToOrderViewModel(Order orderDb)
        {
            return new OrderViewModel()
            {
                Id=orderDb.Id,
                CreateDateTime = orderDb.CreateDateTime,
                Status = (OrderStatusViewModel)(int)orderDb.Status,                
                User = Mapping.ToUserDeliveryInfoViewModel(orderDb.User),
                Items = ToCartItemViewModels(orderDb.Items)
            };
        }

        public static List<OrderViewModel> ToOrdersViewModel(List<Order> ordersDb)
        {
            List<OrderViewModel> ordersVm = new List<OrderViewModel>();

            foreach (var orderDb in ordersDb)
            {
                ordersVm.Add(ToOrderViewModel(orderDb));
            }
            
            return ordersVm;
        }

        public static UserDeliveryInfoViewModel ToUserDeliveryInfoViewModel(UserDeliveryInfo deliveryInfoDb)
        {
            return new UserDeliveryInfoViewModel
            {
                UserName = deliveryInfoDb.UserName,
                UserAdress = deliveryInfoDb.UserAdress,
                UserPhone = deliveryInfoDb.UserPhone
            };
        }
        
        public static UserDeliveryInfo ToUserDeliveryInfoDb(UserDeliveryInfoViewModel deliveryInfoVm)
        {
            return new UserDeliveryInfo
            {
                UserName = deliveryInfoVm.UserName,
                UserAdress = deliveryInfoVm.UserAdress,
                UserPhone = deliveryInfoVm.UserPhone
            };
        }

        public static RoleDb toRoleDb(RoleViewModel role)
        {
            return new RoleDb
            {
                Name = role.Name
            };
        }

        public static List<RoleViewModel> ToRolesViewModel(List<RoleDb> rolesDb)
        {
            var rolesVm = new List<RoleViewModel>();

            foreach (var roleDb in rolesDb)
            {
                rolesVm.Add(Mapping.ToRoleViewModel(roleDb));
            }

            return rolesVm;
        }

        private static RoleViewModel ToRoleViewModel(RoleDb roleDb)
        {
            return new RoleViewModel
            {
                Id = roleDb.id,
                Name = roleDb.Name
            };
        }
    }
}

