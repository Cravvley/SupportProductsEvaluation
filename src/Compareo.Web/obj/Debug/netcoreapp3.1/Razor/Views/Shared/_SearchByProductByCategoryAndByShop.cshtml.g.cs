#pragma checksum "C:\Users\HP\Desktop\Compareo\src\Compareo.Web\Views\Shared\_SearchByProductByCategoryAndByShop.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ace541d50981f62250cd3bb25b6aedee71b98a2a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__SearchByProductByCategoryAndByShop), @"mvc.1.0.view", @"/Views/Shared/_SearchByProductByCategoryAndByShop.cshtml")]
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
#line 1 "C:\Users\HP\Desktop\Compareo\src\Compareo.Web\Views\_ViewImports.cshtml"
using Compareo.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\HP\Desktop\Compareo\src\Compareo.Web\Views\_ViewImports.cshtml"
using Compareo.Infrastructure.VMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\HP\Desktop\Compareo\src\Compareo.Web\Views\_ViewImports.cshtml"
using Compareo.Infrastructure.Common.StaticFiles;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ace541d50981f62250cd3bb25b6aedee71b98a2a", @"/Views/Shared/_SearchByProductByCategoryAndByShop.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"62e13e5110a8d60cc934e7b815dba461c7126df5", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__SearchByProductByCategoryAndByShop : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"row container\">\r\n    <div class=\"col-11\">\r\n        <div class=\"row\" style=\"padding-top:10px\">\r\n            <div class=\"col-4\">\r\n                ");
#nullable restore
#line 5 "C:\Users\HP\Desktop\Compareo\src\Compareo.Web\Views\Shared\_SearchByProductByCategoryAndByShop.cshtml"
           Write(Html.Editor("searchByProduct", new { htmlAttributes = new { @class = "form-control", @placeholder = "Product name..." } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div class=\"col-4\">\r\n                ");
#nullable restore
#line 8 "C:\Users\HP\Desktop\Compareo\src\Compareo.Web\Views\Shared\_SearchByProductByCategoryAndByShop.cshtml"
           Write(Html.Editor("searchByCategory", new { htmlAttributes = new { @class = "form-control", @placeholder = "Product category..." } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div class=\"col-4\">\r\n                ");
#nullable restore
#line 11 "C:\Users\HP\Desktop\Compareo\src\Compareo.Web\Views\Shared\_SearchByProductByCategoryAndByShop.cshtml"
           Write(Html.Editor("searchByShop", new { htmlAttributes = new { @class = "form-control", @placeholder = "Product shop..." } }));

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
