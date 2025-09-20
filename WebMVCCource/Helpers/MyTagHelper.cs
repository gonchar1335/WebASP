using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WebMVCCource.Helpers
{
    public class ShowDateTagHelper: TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "h2";
            output.Content.SetContent($"{DateTime.Today.ToShortTimeString()}"); 
        }
    }
}
