using AutoMapper;
using KnockoutJS.Core;
using KnockoutJS.Core.Categories;
using KnockoutJS.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnockoutJS.Web.Profiles
{
    public class CategoryProfile:Profile,IProfile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryViewModel>();
            //CreateMap<List<Category>, List<CategoryViewModel>>();
            CreateMap<CategoryViewModel, Category>();
            //CreateMap<List<CategoryViewModel>, List<Category>>();
        }
    }
}
