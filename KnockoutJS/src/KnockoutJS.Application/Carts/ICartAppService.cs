﻿using KnockoutJS.Core;
using KnockoutJS.Core.Carts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KnockoutJS.Application
{
    /// <summary>
    /// 购物车应用服务接口
    /// </summary>
    public interface ICartAppService : IAppServiceBase
    {
        /// <summary>
        /// 获取购物车第一条记录
        /// </summary>
        /// <returns></returns>
        Task<Cart> GetFirstCart();

        /// <summary>
        /// 根据userId获取购物车信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<Cart> GetByUserId(string userId);
    }
}
