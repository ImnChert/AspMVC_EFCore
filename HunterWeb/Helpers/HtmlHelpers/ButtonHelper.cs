using HunterWeb.ViewModels;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Web;

namespace HunterWeb.Helpers.HtmlHelpers
{
    public static class ButtonHelper
    {
        public static IHtmlContent Button(this IHtmlHelper htmlHelper, string value, string css)
        {
            var input = new TagBuilder("input");
            input.Attributes.Add("value",value);
            input.AddCssClass(css);

            return input;
        }
    }
}
