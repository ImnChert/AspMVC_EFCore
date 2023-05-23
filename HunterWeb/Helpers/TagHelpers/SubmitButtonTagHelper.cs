using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HunterWeb.Helpers.TagHelpers
{
    public class SubmitButtonTagHelper : TagHelper
    {
        public string Value { get; set; } = string.Empty;
        public string Class { get; set; } = "btn btn-primary";

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "input";
            output.Attributes.SetAttribute("type", "submit");
            output.Attributes.SetAttribute("class", Class);
            output.Attributes.SetAttribute("value", Value);
        }
    }
}
