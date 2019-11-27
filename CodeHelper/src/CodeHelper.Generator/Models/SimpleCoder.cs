using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using RazorEngine;
using RazorEngine.Templating;

namespace CodeHelper.Models
{
    /// <summary>
    /// 简单解析器
    /// </summary>
    public class SimpleCoder
    {
        public string TemplatePage { get; set; }

        public string TemplatePageJson { get; set; }

        public SimpleCoder()
        {
            var templatePage = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates", "templatePage.txt");
            TemplatePage = File.ReadAllText(templatePage);

            var templatePageJson = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates", "templatePageJson.json");
            TemplatePageJson = File.ReadAllText(templatePageJson);

            Console.WriteLine(TemplatePageJson);
        }

        /// <summary>
        /// 构建解析器
        /// </summary>
        public void Builder()
        {
            var templatePageJsonList = JsonConvert.DeserializeObject<List<PageDataModel>>(TemplatePageJson);
            Console.WriteLine(templatePageJsonList);

            foreach (var templatePageJson in templatePageJsonList)
            {
                RazorParse(
                    templatePageJson.Index ?? 1,
                    templatePageJson.Date,
                    templatePageJson.Index - 1,
                    templatePageJson.Index + 1,
                    templatePageJson.Content
                );
            }
        }

        /// <summary>
        /// Razor解析
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="date"></param>
        /// <param name="prev"></param>
        /// <param name="next"></param>
        /// <param name="content"></param>
        public void RazorParse(int pageIndex, DateTime? date, int? prev, int? next, string content)
        {
            Console.WriteLine(TemplatePage);

            var entityResult = Engine.Razor.RunCompile(TemplatePage,"templatePageKey", null, new
            {
                PostData = (date ?? DateTime.Now).ToString("yyyy-MM-dd"),
                PrevIndex = prev.Value,
                NextIndex = next.Value,
                ContentHtml = content
            });

            Console.WriteLine(entityResult);

            //Utils.Save(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CodeGenerate\\Code", $"detail_{pageIndex}.html"), entityResult);
        }
    }

    /// <summary>
    /// 页面数据
    /// </summary>
    public class PageDataModel
    {
        public DateTime? Date { get; set; }

        public int? Index { get; set; }

        public string Content { get; set; }
    }
}