using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace KnockoutJS.Web.Extensions
{
    public static class HtmlHelperExtension
    {
        public static HtmlString HtmlConvertToJson(this IHtmlHelper htmlHelper,object model)
        {
            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Formatting.Indented
            };

            var htmlStringResult = new HtmlString(JsonConvert.SerializeObject(model, settings));
            return htmlStringResult;
        }
    }
}
