// using System;
// using System.Collections.Generic;
// using System.Linq;

// namespace CodeHelper.Models
// {
//     public class GetData : DbService
//     {
//         /// <summary>
//         /// 分页查询
//         /// </summary>
//         /// <param name="info"></param>
//         /// <returns></returns>
//         public PostResultList<Tables> GetTable(GetTablePage info)
//         {
//             if (info == null)
//             {
//                 return new PostResultList<Tables> { data = new List<Tables> { }, msg = "参数不为空" };
//             }
//             var total = 0;
//             var endtime = DateTime.Now;
//             if (info.end.HasValue)
//             {
//                 endtime = new DateTime(info.end.Value.Year, info.end.Value.Month, info.end.Value.Day, 23, 59, 59);
//             }
//             var ret = db.Queryable<Tables>().Where(c => c.table_schema == "easycms")
//                     .WhereIF(!string.IsNullOrEmpty(info.tablename), c => c.table_name.Contains(info.tablename))
//                         .WhereIF(info.start.HasValue, c => c.create_time >= info.start)
//                         .WhereIF(info.end.HasValue, c => c.create_time <= endtime)
//                     .ToPageList(info.pageindex, info.pagesize, ref total)
//                     .ToList();
//             return new PostResultList<Tables>
//             {
//                 data = ret,
//                 msg = ret.Any() ? "success" : "no data",
//                 total = total
//             };
//         }
//     }

//     public class GetTablePage : BaseQueryRequest
//     {
//         public string tablename { get; set; }
//         public DateTime? start { get; set; }
//         public DateTime? end { get; set; }
//     }

//     public class Tables
//     {
//         public string table_schema { get; set; }
//         public string table_name { get; set; }
//         public string table_comment { get; set; }
//         public DateTime? create_time { get; set; }
//     }
// }