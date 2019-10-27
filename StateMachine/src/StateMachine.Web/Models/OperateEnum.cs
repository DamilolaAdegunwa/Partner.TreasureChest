using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace StateMachine.Web.Models
{
    public enum OperateEnum
    {
        [Description("同意")]
        Agree = 0,

        [Description("不同意")]
        Disagree = 3
    }
}
