using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using RazorEngine;
using RazorEngine.Templating;
using CodeHelper.Generator.Utils;

namespace CodeHelper.Generator.SimpleCoders
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
            var templatePage = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SimpleCOders\\Templates", "templatePage.txt");
            TemplatePage = File.ReadAllText(templatePage);

            var templatePageJson = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SimpleCOders\\Templates", "templatePageJson.json");
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
        private void RazorParse(int pageIndex, DateTime? date, int? prev, int? next, string content)
        {
            var entityResult = Engine.Razor.RunCompile(TemplatePage, "templatePageKey", null, new
            {
                PostData = (date ?? DateTime.Now).ToString("yyyy-MM-dd"),
                PrevIndex = prev.Value,
                NextIndex = next.Value,
                ContentHtml = content
            });

            UtilHelper.Save(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CodeGenerate", $"detail_{pageIndex}.html"), entityResult);
        }
    }
}