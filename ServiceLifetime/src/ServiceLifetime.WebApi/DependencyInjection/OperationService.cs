using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceLifetime.WebApi.DependencyInjection
{
    /// <summary>
    /// 服务调用
    /// </summary>
    public class OperationService : IOperationService
    {
        private IOperationTransient _transientOperation;
        private IOperationScoped _scopedOperation;
        private IOperationSingleton _singletonOperation;
        private IOperationInstance _instanceOperation;
        private IHttpContextAccessor _httpContextAccessor;

        public OperationService(IOperationTransient transientOperation,
            IOperationScoped scopedOperation,
            IOperationSingleton singletonOperation,
            IOperationInstance instanceOperation, IHttpContextAccessor httpContextAccessor)
        {
            _transientOperation = transientOperation;
            _scopedOperation = scopedOperation;
            _singletonOperation = singletonOperation;
            _instanceOperation = instanceOperation;
            _httpContextAccessor = httpContextAccessor;
        }

        public List<string> GetGuidString()
        {
            return new List<string>()
            {
                $"Transient:"+_transientOperation.GetGuid(),
                $"Scoped:"+_scopedOperation.GetGuid(),
                $"Singleton:" +_singletonOperation.GetGuid(),
                $"Instance:"+_instanceOperation.GetGuid(),
            };
        }

        public List<string> GetSingletonGuidString()
        {
            var tempSingletonService = (IOperationSingleton)_httpContextAccessor.HttpContext.RequestServices.GetService(typeof(IOperationSingleton));
            
            return new List<string>()
            {
                $"原生Singleton:"+tempSingletonService.GetGuid(),
                $"二次获取Singleton:"+_singletonOperation.GetGuid()
            };
        }

        public List<string> GetTransientAndScopedGuidString()
        {
            //var tempTransientService = (IOperationTransient)ServiceLocator.Instance.GetService(typeof(IOperationTransient));

            var tempTransientService = (IOperationTransient)_httpContextAccessor.HttpContext.RequestServices.GetService(typeof(IOperationTransient));
            var tempScopedService = (IOperationScoped)_httpContextAccessor.HttpContext.RequestServices.GetService(typeof(IOperationScoped));

            return new List<string>()
            {
                $"原生Transient请求服务:"+_transientOperation.GetGuid(),
                $"手动Transient请求服务:"+ tempTransientService.GetGuid(),
                $"原生Scoped请求服务:"+_scopedOperation.GetGuid(),
                $"手动Scoped请求服务:"+tempScopedService.GetGuid(),
            };
        }
    }
}
