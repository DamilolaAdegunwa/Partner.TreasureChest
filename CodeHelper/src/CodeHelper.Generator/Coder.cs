// using CMS.Tool.WebApi.Models;
// using CMS.Tool.WebApi.Models.Base;
// using CodeTool.WebApi.Models;
// using System;
// using System.Collections.Generic;
// using System.IO;
// using System.Linq;
// using System.Net;
// using System.Net.Http;
// using System.Net.Http.Headers;
// using System.Web.Http;

// namespace CMS.Tool.WebApi.Controllers
// {
//     /// <summary>
//     /// 代码生成器
//     /// </summary>
//     public class CoderController
//     {
//         /// <summary>
//         /// 查询列表
//         /// </summary>
//         /// <param name="info"></param>
//         /// <returns></returns>
//         public PostResultList<Tables> GetTables(GetTablePage info)
//         {
//             return new GetData().GetTable(info);
//         }

//         /// <summary>
//         /// 生成代码
//         /// </summary>
//         /// <param name="tablename"></param>
//         /// <returns></returns>
//         public HttpResponseMessage GenerateCode(string tablename)
//         {
//             if (string.IsNullOrEmpty(tablename))
//             {
//                 return new HttpResponseMessage(HttpStatusCode.NoContent);
//             }

//             Coder d = new Coder();
//             var FilePath = string.Empty;
//             var FileName = string.Empty;
//             var result = d.Builder(tablename, out FilePath, out FileName);

//             var stream = new FileStream(FilePath, FileMode.Open);
//             HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
//             response.Content = new StreamContent(stream);
//             response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
//             response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
//             {
//                 FileName = FileName
//             };

//             return response;
//         }
//     }
// }