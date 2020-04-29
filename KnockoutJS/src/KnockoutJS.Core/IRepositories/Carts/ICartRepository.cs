using KnockoutJS.Core.Carts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KnockoutJS.Core.IRepositories
{
    public interface ICartRepository: IRepositoryBase<Cart>
    {
        /// <summary>
        /// 获得第一个购物车
        /// </summary>
        /// <returns></returns>
        Task<Cart> GetFirstCart();

        /// <summary>
        /// 根据userId获取唯一的购物车信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<Cart> GetByUserId(string userId);
    }
}
