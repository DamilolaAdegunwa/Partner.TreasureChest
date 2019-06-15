using AutoMapper;
using KnockoutJS.Core;
using KnockoutJS.Core.CartItems;
using KnockoutJS.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnockoutJS.Web.Profiles
{
    public class CartItemProfile:Profile,IProfile
    {
        public CartItemProfile()
        {
            CreateMap<CartItem, CartItemViewModel>();
            CreateMap<CartItemViewModel, CartItem>();
        }
    }
}
