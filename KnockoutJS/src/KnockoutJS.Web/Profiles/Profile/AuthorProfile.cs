using AutoMapper;
using KnockoutJS.Core;
using KnockoutJS.Core.Authors;
using KnockoutJS.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnockoutJS.Web.Profiles
{
    public class AuthorProfile:Profile,IProfile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorViewModel>();
            CreateMap<AuthorViewModel, Author>();
        }
    }
}
