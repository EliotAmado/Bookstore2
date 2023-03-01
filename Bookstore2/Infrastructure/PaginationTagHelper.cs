using Bookstore2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore2.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-blah")] //new attribute called page-blah we will use in the index.cshtml
    public class PaginationTagHelper : TagHelper //inherits from taghelper class
    {
        //Dynamically create the page links for us

        //helps us build this tag helper/these links that sends it to the right place
        private IUrlHelperFactory uhf;
        public PaginationTagHelper (IUrlHelperFactory temp)
        {
            uhf = temp;
        }

        [ViewContext]
        [HtmlAttributeNotBound] 
        public ViewContext vc { get; set; } //we need the view context to build the link we are building

        //Different than the View Context
        public PageInfo PageBlah { get; set; }
        public string PageAction { get; set; }

        public bool PageClassesEnabled { get; set; } = false;
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }

        public override void Process (TagHelperContext thc, TagHelperOutput tho) //uses thiss method instead of parent class method
        {
            IUrlHelper uh = uhf.GetUrlHelper(vc);
            TagBuilder final = new TagBuilder("div");

            for (int i = 1; i < PageBlah.TotalPages; i++)
            {
                TagBuilder tb = new TagBuilder("a");
                tb.Attributes["href"] = uh.Action(PageAction, new { pageNum = i });

                if (PageClassesEnabled)
                {
                    tb.AddCssClass(PageClass);
                    tb.AddCssClass(i == PageBlah.CurrentPage
                        ? PageClassSelected : PageClassNormal);
                }


                tb.InnerHtml.Append(i.ToString());

                final.InnerHtml.AppendHtml(tb);
            }
            tho.Content.AppendHtml(final.InnerHtml);

        }
    }
}
