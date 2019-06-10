using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pagination.Web.Models;
using Pagination.Web.Utils;

namespace Pagination.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #region SamplePaging
        public IActionResult SamplePaging()
        {
            var bookList = new List<Book>();
            return View(bookList);
        }

        [HttpPost]
        public IActionResult SampleGetData(PageRequestViewModel pageEntity)
        {
            var bookList = PageDataSeed.GetPageDataList()
                .Skip((pageEntity.PageIndex - 1) * pageEntity.PageSize)
                .Take(pageEntity.PageSize);

            var pageResultViewModel = new PageResultViewModel<Book>()
            {
                PageIndex = pageEntity.PageIndex,
                PageSize = pageEntity.PageSize,
                TotalCount = PageDataSeed.GetPageDataList().Count(),
                Data = bookList
            };

            return Json(pageResultViewModel);
        }
        #endregion

        #region SingleQueryPaging
        public IActionResult SingleQueryPaging()
        {
            var bookList = new List<Book>();
            return View(bookList);
        }

        [HttpPost]
        public IActionResult SingleQueryGetData(PageRequestViewModel pageEntity, string bookName)
        {
            IEnumerable<Book> bookList = PageDataSeed.GetPageDataList();
            PageResultViewModel<Book> pageResultViewModel = null;

            if (!string.IsNullOrEmpty(bookName))
                bookList = bookList.Where(b => b.BookName.Contains(bookName));

            var books = bookList.Skip((pageEntity.PageIndex - 1) * pageEntity.PageSize)
                    .Take(pageEntity.PageSize);

            pageResultViewModel = new PageResultViewModel<Book>()
            {
                PageIndex = pageEntity.PageIndex,
                PageSize = pageEntity.PageSize,
                TotalCount = bookList.Count(),
                Data = books
            };

            return Json(pageResultViewModel);
        }
        #endregion

        #region MultipleQueryPaging
        public IActionResult MultipleQueryPaging()
        {
            var bookList = new List<Book>();
            return View(bookList);
        }

        [HttpPost]
        public IActionResult MultipleQueryGetData(PageRequestViewModel pageEntity, QueryItemViewModel queryItemEntity)
        {
            var bookList = PageDataSeed.GetPageDataList();

            #region 条件过滤
            if (!string.IsNullOrEmpty(queryItemEntity.BookName))
                bookList = bookList.Where(b => b.BookName.Contains(queryItemEntity.BookName)).ToList();
            if (!string.IsNullOrEmpty(queryItemEntity.Author))
                bookList = bookList.Where(b => b.Author.Contains(queryItemEntity.Author)).ToList();
            if (!string.IsNullOrEmpty(queryItemEntity.Press))
                bookList = bookList.Where(b => b.Press.Contains(queryItemEntity.Press)).ToList();
            #endregion

            var books = bookList.Skip((pageEntity.PageIndex - 1) * pageEntity.PageSize).Take(pageEntity.PageSize);

            var pageResultViewModel = new PageResultViewModel<Book>()
            {
                PageIndex = pageEntity.PageIndex,
                PageSize = pageEntity.PageSize,
                TotalCount = bookList.Count(),
                Data = books
            };

            return Json(pageResultViewModel);
        }
        #endregion
    }
}
