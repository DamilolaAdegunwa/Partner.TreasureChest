using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceLifetime.WebApi.DependencyInjection
{
    public interface IOperation
    {
        Guid GetGuid();
    }

    public interface IOperationTransient: IOperation
    {

    }

    public interface IOperationScoped : IOperation
    {

    }

    public interface IOperationSingleton : IOperation
    {
      
    }

    public interface IOperationInstance : IOperation
    {
   
    }
}
