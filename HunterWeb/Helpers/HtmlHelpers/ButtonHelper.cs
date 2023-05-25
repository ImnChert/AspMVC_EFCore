using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HunterWeb.Helpers.HtmlHelpers
{
    public static class ButtonHelper
    {
        public static IHtmlContent Button(this IHtmlHelper htmlHelper, string value, string css)
        {
            var input = new TagBuilder("input");
            input.Attributes.Add("value",value);
            input.Attributes.Add("type","submit");
            input.AddCssClass(css);

            return input;
        }
    }
}
