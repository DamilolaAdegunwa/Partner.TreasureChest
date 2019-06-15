using AutoMapper;
using KnockoutJS.Core;
using KnockoutJS.Core.Carts;
using KnockoutJS.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnockoutJS.Web.Profiles
{
    public class CartProfile : Profile, IProfile
    {
        public CartProfile()
        {
            CreateMap<Cart, CartViewModel>();
            CreateMap<CartViewModel, Cart>();
        }
    }
}
