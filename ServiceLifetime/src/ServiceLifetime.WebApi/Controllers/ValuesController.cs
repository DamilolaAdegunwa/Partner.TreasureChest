using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceLifetime.WebApi.DependencyInjection;
using Microsoft.AspNetCore.Mvc;

namespace ServiceLifetime.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IOperationService _operationService;

        public ValuesController(IOperationService operationService)
        {
            _operationService = operationService;
        }

        [HttpGet]
        [Route(nameof(GetGuidString))]
        public ActionResult<string> GetGuidString()
        {
            return string.Join("\n", _operationService.GetGuidString());
        }

        [HttpGet]
        [Route(nameof(GetTransientAndScopedGuidString))]
        public ActionResult<string> GetTransientAndScopedGuidString()
        {
            return string.Join("\n", _operationService.GetTransientAndScopedGuidString());
        }

        [HttpGet]
        [Route(nameof(GetSingletonGuidString))]
        public ActionResult<string> GetSingletonGuidString()
        {
            return string.Join("\n", _operationService.GetSingletonGuidString());
        }
    }
}
