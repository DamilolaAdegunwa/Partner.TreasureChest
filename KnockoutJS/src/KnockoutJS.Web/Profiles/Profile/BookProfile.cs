using AutoMapper;
using KnockoutJS.Core;
using KnockoutJS.Core.Books;
using KnockoutJS.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnockoutJS.Web.Profiles
{
    public class BookProfile:Profile,IProfile
    {
        public BookProfile()
        {
            CreateMap<Book, BookViewModel>();
            CreateMap<BookViewModel, Book>();
            //CreateMap<Author, AuthorViewModel>();
            //CreateMap<Category, CategoryViewModel>();
        }
    }
}
