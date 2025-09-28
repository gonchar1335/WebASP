using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Encodings.Web;
using WebMVCCource.Models;

namespace WebMVCCource.Helpers
{
    public static class HtmlHelpers
    {
        public static HtmlString DisplaySelect(this IHtmlHelper htmlHelper, IEnumerable<Student> students)
        {
            TagBuilder select = new TagBuilder("select");
            foreach (var student in students)
            {
                TagBuilder option = new TagBuilder("option");
                option.InnerHtml.Append(student.Name!);
                select.InnerHtml.AppendHtml(option);
            }
            using var writer = new StringWriter();
            select.WriteTo(writer, HtmlEncoder.Default);
            return new HtmlString(writer.ToString());
        }
    }
}
