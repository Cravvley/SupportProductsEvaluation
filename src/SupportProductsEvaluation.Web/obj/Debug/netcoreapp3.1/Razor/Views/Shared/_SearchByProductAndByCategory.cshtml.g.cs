#pragma checksum "C:\Users\HP\Desktop\SupportProductsEvaluation\src\SupportProductsEvaluation.Web\Views\Shared\_SearchByProductAndByCategory.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "13bdfaecc29c8ae7b2b8cfc9cbbc2873becb24c5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__SearchByProductAndByCategory), @"mvc.1.0.view", @"/Views/Shared/_SearchByProductAndByCategory.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\HP\Desktop\SupportProductsEvaluation\src\SupportProductsEvaluation.Web\Views\_ViewImports.cshtml"
using SupportProductsEvaluation.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\HP\Desktop\SupportProductsEvaluation\src\SupportProductsEvaluation.Web\Views\_ViewImports.cshtml"
using SupportProductsEvaluation.Infrastructure.VMs;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"13bdfaecc29c8ae7b2b8cfc9cbbc2873becb24c5", @"/Views/Shared/_SearchByProductAndByCategory.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a43d153b73bb7ce92d1d8db865766af3b6c079f", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__SearchByProductAndByCategory : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"row container\">\r\n    <div class=\"col-11\">\r\n        <div class=\"row\" style=\"padding-top:10px\">\r\n            <div class=\"col-6\">\r\n                ");
#nullable restore
#line 5 "C:\Users\HP\Desktop\SupportProductsEvaluation\src\SupportProductsEvaluation.Web\Views\Shared\_SearchByProductAndByCategory.cshtml"
           Write(Html.Editor("searchByProduct", new { htmlAttributes = new { @class = "form-control", @placeholder = "Product name..." } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div class=\"col-6\">\r\n                ");
#nullable restore
#line 8 "C:\Users\HP\Desktop\SupportProductsEvaluation\src\SupportProductsEvaluation.Web\Views\Shared\_SearchByProductAndByCategory.cshtml"
           Write(Html.Editor("searchByCategory", new { htmlAttributes = new { @class = "form-control", @placeholder = "Product category..." } }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            </div>
        </div>
    </div>
    <div class=""col-1"">
        <div class=""row"" style=""padding-top:10px;"">
            <button type=""submit"" name=""submit"" value=""Search"" class=""btn btn-info form-control"">
                <i class=""fas fa-search""></i>
            </button>
        </div>
    </div>
</div>
<br />
<br />");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
