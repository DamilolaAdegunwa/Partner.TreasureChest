using AutoMapper;
using KnockoutJS.Application;
using KnockoutJS.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KnockoutJS.Web.Views.Shared.Components.Category
{
    public class CategoryViewComponent : ViewComponent
    {
        private readonly ICategoryAppService _categoryAppService;
        private readonly IMapper _mapper;

        public CategoryViewComponent(ICategoryAppService categoryAppService, IMapper mapper)
        {
            _categoryAppService = categoryAppService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync(int selectedCategoryId)
        {
            Console.WriteLine($"CategoryViewComponent InvokeAsync-Start ThreadId:{Thread.CurrentThread.ManagedThreadId}");
            var categories = await _categoryAppService.Get();
            var cartViewModelList = _mapper.Map<List<CategoryViewModel>>(categories);
            ViewBag.SelectedCategoryId = selectedCategoryId;
            Console.WriteLine($"CategoryViewComponent InvokeAsync-End ThreadId:{Thread.CurrentThread.ManagedThreadId}");
            return View(cartViewModelList);
        }
    }
}
