using System;
using System.Collections.Generic;
using System.Text;

namespace WuLong.Lims.LIMS.Reports.Dto
{
    public class GetCurrentUserInfoInput
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
        /// 用户Ids
        /// </summary>
        public List<string> Ids { get; set; }
    }
}
