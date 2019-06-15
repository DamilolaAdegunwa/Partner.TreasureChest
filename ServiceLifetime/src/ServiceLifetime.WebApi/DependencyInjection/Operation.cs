using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceLifetime.WebApi.DependencyInjection
{
    /// <summary>
    /// 常规服务
    /// </summary>
    public class Operation : IOperation
    {
        private readonly Guid _guid;

        public Operation()
        {
            _guid = Guid.NewGuid();
        }

        public Operation(Guid guid)
        {
            _guid = guid == Guid.Empty ? Guid.NewGuid() : guid;
        }

        public Guid GetGuid()
        {
            return _guid;
        }
    }

    /// <summary>
    /// 瞬时服务
    /// </summary>
    public class OperationTransient : IOperationTransient
    {
        private readonly Guid _guid;

        public OperationTransient()
        {
            _guid = Guid.NewGuid();
        }

        public OperationTransient(Guid guid)
        {
            _guid = guid == Guid.Empty ? Guid.NewGuid() : guid;
        }

        public Guid GetGuid()
        {
            return _guid;
        }
    }

    /// <summary>
    /// 单次请求内服务固定
    /// </summary>
    public class OperationScoped : IOperationScoped
    {
        private readonly Guid _guid;

        public OperationScoped()
        {
            _guid = Guid.NewGuid();
        }

        public OperationScoped(Guid guid)
        {
            _guid = guid == Guid.Empty ? Guid.NewGuid() : guid;
        }

        public Guid GetGuid()
        {
            return _guid;
        }
    }


    /// <summary>
    /// 所有请求内固定服务
    /// </summary>
    public class OperationSingleton : IOperationSingleton
    {
        private readonly Guid _guid;

        public OperationSingleton()
        {
            _guid = Guid.NewGuid();
        }

        public OperationSingleton(Guid guid)
        {
            _guid = guid == Guid.Empty ? Guid.NewGuid() : guid;
        }

        public Guid GetGuid()
        {
            return _guid;
        }
    }

    /// <summary>
    /// 应用程序内固定服务
    /// </summary>
    public class OperationInstance : IOperationInstance
    {
        private readonly Guid _guid;

        public OperationInstance(Guid guid)
        {
            _guid = guid;
        }

        public Guid GetGuid()
        {
            return _guid;
        }
    }
}
