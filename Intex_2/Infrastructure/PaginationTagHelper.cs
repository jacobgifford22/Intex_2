using Intex_2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intex_2.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PaginationTagHelper : TagHelper
    {
        // Dynamically create the page links for us
        private IUrlHelperFactory _uhf;

        public PaginationTagHelper(IUrlHelperFactory temp)
        {
            _uhf = temp;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext vc { get; set; }
        
        public PageInfo PageModel { get; set; }
        public string PageAction { get; set; }
        public string PageClass { get; set; }
        public bool PageClassesEnabled { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }
        public string PageClassLabel { get; set; }
        public string PageClassLinks { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper uh = _uhf.GetUrlHelper(vc);

            TagBuilder final = new TagBuilder("div");

            int startPage = 1;
            int endPage = PageModel.TotalPages;

            if (PageModel.TotalPages > 1)
            {
                if (PageModel.TotalPages <= PageModel.LinksPerPage)
                {
                    startPage = 1;
                    endPage = PageModel.TotalPages;
                }
                else
                {
                    if (PageModel.CurrentPage + PageModel.LinksPerPage - 1 > PageModel.TotalPages)
                    {
                        startPage = PageModel.CurrentPage - ((PageModel.CurrentPage + PageModel.LinksPerPage - 1)
                            - PageModel.TotalPages);
                        endPage = (PageModel.CurrentPage + PageModel.LinksPerPage - 1)
                            - ((PageModel.CurrentPage + PageModel.LinksPerPage - 1) - PageModel.TotalPages);
                    }
                    else
                    {
                        if (PageModel.LinksPerPage != 2)
                        {
                            startPage = PageModel.CurrentPage - (PageModel.LinksPerPage / 2);
                            if (startPage < 1)
                            {
                                startPage = 1;
                            }
                            endPage = startPage + PageModel.LinksPerPage - 1;
                        }
                        else
                        {
                            startPage = PageModel.CurrentPage;
                            endPage = PageModel.CurrentPage + PageModel.LinksPerPage - 1;
                        }
                    }
                }
            }

            TagBuilder labelDiv = new TagBuilder("div");
            labelDiv.AddCssClass(PageClassLabel);
            labelDiv.InnerHtml.Append($"Showing {PageModel.CurrentPage} of {PageModel.TotalPages}");
            final.InnerHtml.AppendHtml(labelDiv);

            TagBuilder linkDiv = new TagBuilder("div");
            linkDiv.InnerHtml.AppendHtml(GeneratePageLinks("First", 1));
            for (int i = startPage; i <= endPage; i++)
            {
                linkDiv.InnerHtml.AppendHtml(GeneratePageLinks(i.ToString(), i));
            }

            linkDiv.InnerHtml.AppendHtml(GeneratePageLinks("Last", PageModel.TotalPages));
            linkDiv.AddCssClass(PageClassLinks);
            final.InnerHtml.AppendHtml(linkDiv);
            output.Content.AppendHtml(final.InnerHtml);
        }

        private TagBuilder GeneratePageLinks(string iterator, int pageNumber)
        {
            IUrlHelper uh = _uhf.GetUrlHelper(vc);

            string url;
            TagBuilder tag;
            tag = new TagBuilder("a");
            // url = PageModel.UrlParams.Replace("-", pageNumber.ToString());
            tag.Attributes["href"] = uh.Action(PageAction, new { pageNum = pageNumber }); //url;
            tag.AddCssClass(PageClass);
            if (iterator != "First" && iterator != "Last")
            {
                tag.AddCssClass(Convert.ToInt32(iterator) == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
            }
            else
            {
                tag.AddCssClass(pageNumber == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
            }
            tag.InnerHtml.Append(iterator.ToString());
            return tag;

        }
    }
}
