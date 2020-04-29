using KnockoutJS.Core;
using KnockoutJS.Core.Authors;
using KnockoutJS.Core.Books;
using KnockoutJS.Core.Categories;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace KnockoutJS.EFCore
{
    public class DataInitialization
    {
        public static void Initialize(ShoppingCartContext context)
        {
            context.Database.EnsureCreated();

            if (context.Categories.Any())
            {
                return;
            }

            var categories = new List<Category>()
            {
                new Category(){Name="科学与技术"},
                new Category(){Name="人文哲理"},
                new Category(){Name="经济学"},
                new Category(){Name="走进社会"},
            };
            context.AddRange(categories);

            var author = new Author()
            {
                Biography = "...",
                Name = "莫言"
            };
            context.AddRange(author);

            var books = new List<Book>()
            {
                new Book()
                {
                    Author = author,
                    Category =categories[0],
                    Description = "",
                    Featured = true,
                    ImageUrl = "#",
                    Isbn = "14914914365",
                    ListPrice = 19.99m,
                    SalePrice = 17.99m,
                    Synopsis = "...",
                    Title = "knockout.JS:Building Dynamic Client-Side Web Applications"
                },
                new Book()
                {
                    Author = author,
                    Category =categories[1],
                    Description = "",
                    Featured = false,
                    ImageUrl = "#",
                    Isbn = "149105265",
                    ListPrice = 19.99m,
                    SalePrice = 16.99m,
                    Synopsis = "...",
                    Title = "平凡的世界"
                },
                new Book()
                {
                    Author = author,
                    Category =categories[2],
                    Description = "",
                    Featured = true,
                    ImageUrl = "#",
                    Isbn = "14911254365",
                    ListPrice = 19.99m,
                    SalePrice = 15.99m,
                    Synopsis = "...",
                    Title = "社保金额上涨"
                },
            };
            context.AddRange(books);

            context.SaveChanges();
        }
    }
}
