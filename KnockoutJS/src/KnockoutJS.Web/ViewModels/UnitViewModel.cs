using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnockoutJS.Web.ViewModels
{
    public class UnitViewModel
    {
        public string OrganizationCode { get; set; }
        public string UnitName { get; set; }
        public string BossName { get; set; }
        public string Address { get; set; }
        public int EmployeeCount { get; set; }
        public UnitTypeEnum UnitTypeValue { get; set; }
  
        public string UnitTypeText
        {
            get { return Enum.GetName(typeof(UnitTypeEnum), UnitTypeValue); }
        }
    }

    public enum UnitTypeEnum:byte
    {
        有限公司 = 1,
        有限责任公司 = 2,
        国有独资公司 = 3,
        股份有限公司 = 4
    }
}
