using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using RazorEngine;

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
            var templatePage = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Template", "templatePage.txt");
            TemplatePage = File.ReadAllText(templatePage);

            var templatePageJson = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Template", "templatePageJson.json");
            TemplatePageJson = File.ReadAllText(templatePageJson);
        }

        /// <summary>
        /// 构建解析器
        /// </summary>
        public void Builder()
        {
            var templatePageJsonList = JsonConvert.DeserializeObject<List<PageDataModel>>(TemplatePageJson);

            foreach (var templatePageJson in templatePageJsonList)
            {
                var prev = templatePageJson.Index - 1;
                var next = templatePageJson.Index + 1;
                RazorParse(templatePageJson.Index ?? 1, templatePageJson.Date, prev, next, templatePageJson.Content);
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
            var entity_result = Razor.Parse(TemplatePage, new
            {
                PostData = (date ?? DateTime.Now).ToString("yyyy-MM-dd"),
                PrevIndex = prev,
                NextIndex = next,
                ContentHtml = content
            });

            Utils.Save(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CodeGenerate\\Code\\Yangji", $"detail_{pageIndex}.html"), entity_result);
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