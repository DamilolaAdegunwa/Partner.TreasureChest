using System;
using System.Collections.Generic;
using System.Text;

namespace CodeHelper.Generator.DataBaseCoders
{
    /// <summary>
    /// 模板解析类
    /// </summary>
    public class TemplateParseModel
    {
        /// <summary>
        /// 项目根名称
        /// </summary>
        public string ProjectRootName { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProjectNameSpace { get; set; }

        /// <summary>
        /// 模块名称
        /// </summary>
        public string ProjectModule { get; set; }

        /// <summary>
        /// 实体名称
        /// </summary>
        public string EntityName { get; set; }

        /// <summary>
        /// 实体名称小写
        /// </summary>
        public string EntityNameLower { get; set; }

        /// <summary>
        /// 实体主键类型
        /// </summary>
        public string EntityKeyType { get; set; }

        /// <summary>
        /// 实体描述
        /// </summary>
        public string EntityDescription { get; set; }
    }
}
