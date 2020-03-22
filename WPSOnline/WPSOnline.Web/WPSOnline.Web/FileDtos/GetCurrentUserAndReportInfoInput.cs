using Abp.Runtime.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WuLong.Lims.LIMS.Reports.Dto
{
    /// <summary>
    /// 获取当前用户和报告信息
    /// </summary>
    public class GetCurrentUserAndReportInfoInput : ICustomValidate
    {
        /// <summary>
        /// 签名信息
        /// </summary>
        public string Signature { get; set; }

        /// <summary>
        /// 应用Id
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 用户代理
        /// </summary>
        public string UserAgent { get; set; }

        /// <summary>
        /// 用户token
        /// </summary>
        public string UserToken { get; set; }

        /// <summary>
        /// 报告Id
        /// </summary>
        [Required]
        public string ReportId { get; set; }

        /// <summary>
        /// 自定义校验
        /// </summary>
        /// <param name="context"></param>
        public void AddValidationErrors(CustomValidationContext context)
        {
            if (!UserToken.Contains("-"))
            {
                context.Results.Add(new ValidationResult("用户令牌数据异常!"));
            }
        }
    }
}
