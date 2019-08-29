using KnockoutJS.Core;
using KnockoutJS.Core.Carts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KnockoutJS.Application
{
    public interface ICartAppService : IAppServiceBase
    {
        /// <summary>
        /// 获取购物车第一条记录
        /// </summary>
        /// <returns></returns>
        Task<Cart> GetFirstCart();

        /// <summary>
        /// 根据sessionId获取唯一的购物车信息
        /// </summary>
        /// <param name="sessionId"></param>
        /// <returns></returns>
        Task<Cart> GetBySessionId(string sessionId);
    }
}
