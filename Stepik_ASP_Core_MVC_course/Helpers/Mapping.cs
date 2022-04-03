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
        // ------- users --------

        public static UserViewModel ToUserViewModel(UserDb userDb)
        {
            return new UserViewModel
            {
                Name = userDb.UserName,
                Phone = userDb.PhoneNumber
            };
        }

        // ------ products -------

        public static ProductViewModel ToProductViewModel(Product productDb)
        {
            return new ProductViewModel
            {
                Id = productDb.Id,
                Name = productDb.Name,
                Cost = productDb.Cost,
                Description = productDb.Description,
                ImagesPaths = productDb.Images.Select(x => x.Url).ToArray()
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

        public static EditProductViewModel ToEditProductViewModel(this Product product)
        {
            return new EditProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description,
                ImagesPaths = product.Images.ToPaths()
            };
        }
        
        public static Product ToProductDb(this ProductViewModel productVm)
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

        public static Product ToProductDb(this AddProductViewModel addProductViewModel, List<string> imagesPaths)
        {
            return new Product
            {
                Name = addProductViewModel.Name,
                Cost = addProductViewModel.Cost,
                Description = addProductViewModel.Description,
                Images = ToImages(imagesPaths)
            };
        }

        public static Product ToProductDb(this EditProductViewModel editProductVM)
        {
            return new Product
            {
                Id = editProductVM.Id,
                Name = editProductVM.Name,
                Cost = editProductVM.Cost,
                Description = editProductVM.Description,
                Images = editProductVM.ImagesPaths.ToImages()
            };
        }

        public static List<Image> ToImages(this List<string> paths)
        {
            return paths.Select(x => new Image { Url = x }).ToList();
        }

        public static List<string> ToPaths(this List<Image> paths)
        {
            return paths.Select(x => x.Url).ToList();
        }

        // ------- carts --------

        public static CartViewModel ToCartViewModel(Cart cartDb)
        {
            if (cartDb == null)
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

        // ------- orders --------

        public static OrderViewModel ToOrderViewModel(Order orderDb)
        {
            return new OrderViewModel()
            {
                Id = orderDb.Id,
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

        // ------- userDeliveryInfo -------

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

        // ------- roles -------

        public static RoleDb ToRoleDb(RoleViewModel role)
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
                //Id = roleDb.id,
                Name = roleDb.Name
            };
        }
    }
}

