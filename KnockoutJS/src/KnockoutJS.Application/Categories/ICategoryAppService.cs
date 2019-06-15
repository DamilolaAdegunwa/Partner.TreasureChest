using KnockoutJS.Core;
using KnockoutJS.Core.Categories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KnockoutJS.Application
{
    public interface ICategoryAppService: IAppServiceBase
    {
        Task<List<Category>> Get();
    }
}
