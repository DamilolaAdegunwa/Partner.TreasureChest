using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceLifetime.WebApi.DependencyInjection
{
    public interface IOperationService
    {
        /// <summary>
        /// 获取四种形式的Guid码
        /// </summary>
        /// <returns></returns>
        List<string> GetGuidString();

        /// <summary>
        /// 获取Singleton的Guid码
        /// </summary>
        /// <returns></returns>
        List<string> GetSingletonGuidString();
        
        /// <summary>
        /// 获取Transient、Scoped的Guid码
        /// </summary>
        /// <returns></returns>
        List<string> GetTransientAndScopedGuidString();
    }
}
