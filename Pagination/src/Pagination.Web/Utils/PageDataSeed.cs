using Pagination.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pagination.Web.Utils
{
    public class PageDataSeed
    {
        public static List<Book> GetPageDataList()
        {
            var index = 1;

            return new List<Book>()
            {
                #region 种子数据
                new Book()
                {
                    Author = "李白",
                    BookName = "唐诗三百首",
                    Press = "机械工程出版社",
                    Id = index++,
                    BookNumber = $"{new Random().Next(1000,9999).ToString()}-{DateTime.Now.ToString("yyyyMMddHHmmss")}",
                    Price = new Random().Next(0,199),
                    PublishDate = DateTime.Now.AddYears(-new Random().Next(0,99)).AddMonths(-new Random().Next(0,12)).AddDays(-new Random().Next(0,30)),
                     Version = $"第{new Random().Next(1,10)}版",
                },
                new Book()
                {
                    Author = "柴晓伟",
                    BookName = "ASP.NET Core应用开发",
                    Press = "清华大学出版社",
                    Id = index++,
                    BookNumber = $"{new Random().Next(1000,9999)}-{DateTime.Now.ToString("yyyyMMddHHmmss")}",
                    Price = new Random().Next(0,199),
                    PublishDate = DateTime.Now.AddYears(-new Random().Next(0,99)).AddMonths(-new Random().Next(0,12)).AddDays(-new Random().Next(0,30)),
                    Version = $"第{new Random().Next(1,10)}版",
                },
                new Book()
                {
                    Author = "陆嘉恒",
                    BookName = "Hadoop实战",
                    Press = "机械工业出版社",
                    Id = index++,
                    BookNumber = $"{new Random().Next(1000,9999).ToString()}-{DateTime.Now.ToString("yyyyMMddHHmmss")}",
                    Price = new Random().Next(0,199),
                    PublishDate = DateTime.Now.AddYears(-new Random().Next(0,99)).AddMonths(-new Random().Next(0,12)).AddDays(-new Random().Next(0,30)),
                    Version = $"第{new Random().Next(1,10)}版",
                },
                new Book()
                {
                    Author = "邹琼俊",
                    BookName = "ASP.NET MVC企业级实战",
                    Press = "清华大学出版社",
                    Id = index++,
                    BookNumber = $"{new Random().Next(1000,9999).ToString()}-{DateTime.Now.ToString("yyyyMMddHHmmss")}",
                    Price = new Random().Next(0,199),
                    PublishDate = DateTime.Now.AddYears(-new Random().Next(0,99)).AddMonths(-new Random().Next(0,12)).AddDays(-new Random().Next(0,30)),
                     Version = $"第{new Random().Next(1,10)}版",
                },
                new Book()
                {
                    Author = "Michael Negnevitsky",
                    BookName = "人工智能",
                    Press = "机械工业出版社",
                    Id = index++,
                    BookNumber = $"{new Random().Next(1000,9999)}-{DateTime.Now.ToString("yyyyMMddHHmmss")}",
                    Price = new Random().Next(0,199),
                    PublishDate = DateTime.Now.AddYears(-new Random().Next(0,99)).AddMonths(-new Random().Next(0,12)).AddDays(-new Random().Next(0,30)),
                    Version = $"第{new Random().Next(1,10)}版",
                },
                new Book()
                {
                    Author = "Munro",
                    BookName = "基于Bootstrap和Knockout.js的ASP.NET MVC开发实战",
                    Press = "中国电力出版社",
                    Id = index++,
                    BookNumber = $"{new Random().Next(1000,9999).ToString()}-{DateTime.Now.ToString("yyyyMMddHHmmss")}",
                    Price = new Random().Next(0,199),
                    PublishDate = DateTime.Now.AddYears(-new Random().Next(0,99)).AddMonths(-new Random().Next(0,12)).AddDays(-new Random().Next(0,30)),
                    Version = $"第{new Random().Next(1,10)}版",
                },
                new Book()
                {
                    Author = "图尔",
                    BookName = "隐性动机",
                    Press = "厦门大学出版社",
                    Id = index++,
                    BookNumber = $"{new Random().Next(1000,9999).ToString()}-{DateTime.Now.ToString("yyyyMMddHHmmss")}",
                    Price = new Random().Next(0,199),
                    PublishDate = DateTime.Now.AddYears(-new Random().Next(0,99)).AddMonths(-new Random().Next(0,12)).AddDays(-new Random().Next(0,30)),
                     Version = $"第{new Random().Next(1,10)}版",
                },
                new Book()
                {
                    Author = "马斯",
                    BookName = "思考的艺术",
                    Press = "北京大学出版社",
                    Id = index++,
                    BookNumber = $"{new Random().Next(1000,9999)}-{DateTime.Now.ToString("yyyyMMddHHmmss")}",
                    Price = new Random().Next(0,199),
                    PublishDate = DateTime.Now.AddYears(-new Random().Next(0,99)).AddMonths(-new Random().Next(0,12)).AddDays(-new Random().Next(0,30)),
                    Version = $"第{new Random().Next(1,10)}版",
                },
                new Book()
                {
                    Author = "斯图尔特",
                    BookName = "走出思维的误区",
                    Press = "世界图书出版社",
                    Id = index++,
                    BookNumber = $"{new Random().Next(1000,9999).ToString()}-{DateTime.Now.ToString("yyyyMMddHHmmss")}",
                    Price = new Random().Next(0,199),
                    PublishDate = DateTime.Now.AddYears(-new Random().Next(0,99)).AddMonths(-new Random().Next(0,12)).AddDays(-new Random().Next(0,30)),
                    Version = $"第{new Random().Next(1,10)}版",
                },
                new Book()
                {
                    Author = "王伟",
                    BookName = "系统化思维导论",
                    Press = "人民邮电出版社",
                    Id = index++,
                    BookNumber = $"{new Random().Next(1000,9999).ToString()}-{DateTime.Now.ToString("yyyyMMddHHmmss")}",
                    Price = new Random().Next(0,199),
                    PublishDate = DateTime.Now.AddYears(-new Random().Next(0,99)).AddMonths(-new Random().Next(0,12)).AddDays(-new Random().Next(0,30)),
                     Version = $"第{new Random().Next(1,10)}版",
                },
                new Book()
                {
                    Author = "王康",
                    BookName = "决策与判断",
                    Press = "人民邮电出版社",
                    Id = index++,
                    BookNumber = $"{new Random().Next(1000,9999)}-{DateTime.Now.ToString("yyyyMMddHHmmss")}",
                    Price = new Random().Next(0,199),
                    PublishDate = DateTime.Now.AddYears(-new Random().Next(0,99)).AddMonths(-new Random().Next(0,12)).AddDays(-new Random().Next(0,30)),
                    Version = $"第{new Random().Next(1,10)}版",
                },
                new Book()
                {
                    Author = "加西亚·马尔克斯",
                    BookName = "霍乱时期的爱情",
                    Press = "英国工业出版社",
                    Id = index++,
                    BookNumber = $"{new Random().Next(1000,9999).ToString()}-{DateTime.Now.ToString("yyyyMMddHHmmss")}",
                    Price = new Random().Next(0,199),
                    PublishDate = DateTime.Now.AddYears(-new Random().Next(0,99)).AddMonths(-new Random().Next(0,12)).AddDays(-new Random().Next(0,30)),
                    Version = $"第{new Random().Next(1,10)}版",
                },
                new Book()
                {
                    Author = "艾米莉·勃朗特",
                    BookName = "呼啸山庄",
                    Press = "人民邮电出版社",
                    Id = index++,
                    BookNumber = $"{new Random().Next(1000,9999).ToString()}-{DateTime.Now.ToString("yyyyMMddHHmmss")}",
                    Price = new Random().Next(0,199),
                    PublishDate = DateTime.Now.AddYears(-new Random().Next(0,99)).AddMonths(-new Random().Next(0,12)).AddDays(-new Random().Next(0,30)),
                     Version = $"第{new Random().Next(1,10)}版",
                },
                new Book()
                {
                    Author = "达芙妮·杜穆里埃",
                    BookName = "浮生梦",
                    Press = "人民邮电出版社",
                    Id = index++,
                    BookNumber = $"{new Random().Next(1000,9999)}-{DateTime.Now.ToString("yyyyMMddHHmmss")}",
                    Price = new Random().Next(0,199),
                    PublishDate = DateTime.Now.AddYears(-new Random().Next(0,99)).AddMonths(-new Random().Next(0,12)).AddDays(-new Random().Next(0,30)),
                    Version = $"第{new Random().Next(1,10)}版",
                },
                new Book()
                {
                    Author = "马洛伊·山多尔",
                    BookName = "伪装成独白的爱情",
                    Press = "机械工业出版社",
                    Id = index++,
                    BookNumber = $"{new Random().Next(1000,9999).ToString()}-{DateTime.Now.ToString("yyyyMMddHHmmss")}",
                    Price = new Random().Next(0,199),
                    PublishDate = DateTime.Now.AddYears(-new Random().Next(0,99)).AddMonths(-new Random().Next(0,12)).AddDays(-new Random().Next(0,30)),
                    Version = $"第{new Random().Next(1,10)}版",
                },
                new Book()
                {
                    Author = "东野圭吾",
                    BookName = "白夜行",
                    Press = "人民邮电出版社",
                    Id = index++,
                    BookNumber = $"{new Random().Next(1000,9999).ToString()}-{DateTime.Now.ToString("yyyyMMddHHmmss")}",
                    Price = new Random().Next(0,199),
                    PublishDate = DateTime.Now.AddYears(-new Random().Next(0,99)).AddMonths(-new Random().Next(0,12)).AddDays(-new Random().Next(0,30)),
                     Version = $"第{new Random().Next(1,10)}版",
                },
                new Book()
                {
                    Author = "吉莉安·弗琳",
                    BookName = "消失的爱人",
                    Press = "人民邮电出版社",
                    Id = index++,
                    BookNumber = $"{new Random().Next(1000,9999)}-{DateTime.Now.ToString("yyyyMMddHHmmss")}",
                    Price = new Random().Next(0,199),
                    PublishDate = DateTime.Now.AddYears(-new Random().Next(0,99)).AddMonths(-new Random().Next(0,12)).AddDays(-new Random().Next(0,30)),
                    Version = $"第{new Random().Next(1,10)}版",
                },
                new Book()
                {
                    Author = "村上春树",
                    BookName = "挪威的森林",
                    Press = "机械工业出版社",
                    Id = index++,
                    BookNumber = $"{new Random().Next(1000,9999).ToString()}-{DateTime.Now.ToString("yyyyMMddHHmmss")}",
                    Price = new Random().Next(0,199),
                    PublishDate = DateTime.Now.AddYears(-new Random().Next(0,99)).AddMonths(-new Random().Next(0,12)).AddDays(-new Random().Next(0,30)),
                    Version = $"第{new Random().Next(1,10)}版",
                },
                new Book()
                {
                    Author = "马斯洛",
                    BookName = "人性能达到的境界",
                    Press = "人民邮电出版社",
                    Id = index++,
                    BookNumber = $"{new Random().Next(1000,9999).ToString()}-{DateTime.Now.ToString("yyyyMMddHHmmss")}",
                    Price = new Random().Next(0,199),
                    PublishDate = DateTime.Now.AddYears(-new Random().Next(0,99)).AddMonths(-new Random().Next(0,12)).AddDays(-new Random().Next(0,30)),
                     Version = $"第{new Random().Next(1,10)}版",
                },
                new Book()
                {
                    Author = "川端康成",
                    BookName = "雪国",
                    Press = "日本出版社",
                    Id = index++,
                    BookNumber = $"{new Random().Next(1000,9999)}-{DateTime.Now.ToString("yyyyMMddHHmmss")}",
                    Price = new Random().Next(0,199),
                    PublishDate = DateTime.Now.AddYears(-new Random().Next(0,99)).AddMonths(-new Random().Next(0,12)).AddDays(-new Random().Next(0,30)),
                    Version = $"第{new Random().Next(1,10)}版",
                },
                new Book()
                {
                    Author = "菲茨杰拉德",
                    BookName = "了不起的盖茨比",
                    Press = "上海出版社",
                    Id = index++,
                    BookNumber = $"{new Random().Next(1000,9999).ToString()}-{DateTime.Now.ToString("yyyyMMddHHmmss")}",
                    Price = new Random().Next(0,199),
                    PublishDate = DateTime.Now.AddYears(-new Random().Next(0,99)).AddMonths(-new Random().Next(0,12)).AddDays(-new Random().Next(0,30)),
                    Version = $"第{new Random().Next(1,10)}版",
                },
                new Book()
                {
                    Author = "艾伦伯格",
                    BookName = "弗洛伊德与荣格",
                    Press = "美国出版社",
                    Id = index++,
                    BookNumber = $"{new Random().Next(1000,9999).ToString()}-{DateTime.Now.ToString("yyyyMMddHHmmss")}",
                    Price = new Random().Next(0,199),
                    PublishDate = DateTime.Now.AddYears(-new Random().Next(0,99)).AddMonths(-new Random().Next(0,12)).AddDays(-new Random().Next(0,30)),
                     Version = $"第{new Random().Next(1,10)}版",
                },
                new Book()
                {
                    Author = "欧文斯通",
                    BookName = "心灵的激情",
                    Press = "日本出版社",
                    Id = index++,
                    BookNumber = $"{new Random().Next(1000,9999)}-{DateTime.Now.ToString("yyyyMMddHHmmss")}",
                    Price = new Random().Next(0,199),
                    PublishDate = DateTime.Now.AddYears(-new Random().Next(0,99)).AddMonths(-new Random().Next(0,12)).AddDays(-new Random().Next(0,30)),
                    Version = $"第{new Random().Next(1,10)}版",
                },
                new Book()
                {
                    Author = "鲁格嘉",
                    BookName = "父性",
                    Press = "上海出版社",
                    Id = index++,
                    BookNumber = $"{new Random().Next(1000,9999).ToString()}-{DateTime.Now.ToString("yyyyMMddHHmmss")}",
                    Price = new Random().Next(0,199),
                    PublishDate = DateTime.Now.AddYears(-new Random().Next(0,99)).AddMonths(-new Random().Next(0,12)).AddDays(-new Random().Next(0,30)),
                    Version = $"第{new Random().Next(1,10)}版",
                },
                #endregion
            };
        }
    }
}
