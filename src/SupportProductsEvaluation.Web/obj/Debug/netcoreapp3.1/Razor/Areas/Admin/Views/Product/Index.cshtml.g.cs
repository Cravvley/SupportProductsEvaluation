#pragma checksum "C:\Users\HP\Desktop\SupportProductsEvaluation\src\SupportProductsEvaluation.Web\Areas\Admin\Views\Product\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "03b44147a3f7a16cf3c5e54b04ffcbc0bde5e82f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Product_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Product/Index.cshtml")]
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
#line 1 "C:\Users\HP\Desktop\SupportProductsEvaluation\src\SupportProductsEvaluation.Web\Areas\Admin\Views\_ViewImports.cshtml"
using SupportProductsEvaluation.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\HP\Desktop\SupportProductsEvaluation\src\SupportProductsEvaluation.Web\Areas\Admin\Views\_ViewImports.cshtml"
using SupportProductsEvaluation.Infrastructure.VMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\HP\Desktop\SupportProductsEvaluation\src\SupportProductsEvaluation.Web\Areas\Admin\Views\_ViewImports.cshtml"
using SupportProductsEvaluation.Data.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"03b44147a3f7a16cf3c5e54b04ffcbc0bde5e82f", @"/Areas/Admin/Views/Product/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bfffc26c7d73997f5a702c842635f2087fb35d8f", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Product_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProductListVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_CreateButtonPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_TableButtonPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("page-class", "btn border", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("page-class-normal", "btn btn-light", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("page-class-selected", "btn btn-info active", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn-group float-right "), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        private global::SupportProductsEvaluation.Infrastructure.TagHelpers.PageLinkTagHelper __SupportProductsEvaluation_Infrastructure_TagHelpers_PageLinkTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\HP\Desktop\SupportProductsEvaluation\src\SupportProductsEvaluation.Web\Areas\Admin\Views\Product\Index.cshtml"
  
    ViewData["Title"] = "Product's list";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<br />\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "03b44147a3f7a16cf3c5e54b04ffcbc0bde5e82f6554", async() => {
                WriteLiteral("\r\n    <div class=\"border p-3\">\r\n        <div class=\"row p-1\">\r\n            <div class=\"col-6\">\r\n                <h2 class=\"text-info\"> Product\'s List</h2>\r\n            </div>\r\n            <div class=\"col-6 text-right\">\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "03b44147a3f7a16cf3c5e54b04ffcbc0bde5e82f7069", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <br />\r\n        <div class=\"row container\">\r\n            <div class=\"col-11\">\r\n                <div class=\"row\" style=\"padding-top:10px\">\r\n                    <div class=\"col-6\">\r\n                        ");
#nullable restore
#line 24 "C:\Users\HP\Desktop\SupportProductsEvaluation\src\SupportProductsEvaluation.Web\Areas\Admin\Views\Product\Index.cshtml"
                   Write(Html.Editor("searchName", new { htmlAttributes = new { @class = "form-control", @placeholder = "Name..." } }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </div>\r\n                    <div class=\"col-6\">\r\n                        ");
#nullable restore
#line 27 "C:\Users\HP\Desktop\SupportProductsEvaluation\src\SupportProductsEvaluation.Web\Areas\Admin\Views\Product\Index.cshtml"
                   Write(Html.Editor("searchCategoryName", new { htmlAttributes = new { @class = "form-control", @placeholder = "Category..." } }));

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
        <br />
        <div class=""p-1"">
");
#nullable restore
#line 42 "C:\Users\HP\Desktop\SupportProductsEvaluation\src\SupportProductsEvaluation.Web\Areas\Admin\Views\Product\Index.cshtml"
             if (Model.Products.Count>0)
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <table class=\"table table-striped border\">\r\n                    <tr class=\"table-secondary\">\r\n                        <th>\r\n\r\n                        </th>\r\n                        <th>\r\n                            ");
#nullable restore
#line 50 "C:\Users\HP\Desktop\SupportProductsEvaluation\src\SupportProductsEvaluation.Web\Areas\Admin\Views\Product\Index.cshtml"
                       Write(Html.DisplayNameFor(p => p.Products[0].Name));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
#nullable restore
#line 53 "C:\Users\HP\Desktop\SupportProductsEvaluation\src\SupportProductsEvaluation.Web\Areas\Admin\Views\Product\Index.cshtml"
                       Write(Html.DisplayNameFor(p => p.Products[0].ShopId));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
#nullable restore
#line 56 "C:\Users\HP\Desktop\SupportProductsEvaluation\src\SupportProductsEvaluation.Web\Areas\Admin\Views\Product\Index.cshtml"
                       Write(Html.DisplayNameFor(p => p.Products[0].CategoryId));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </th>\r\n                        <th></th>\r\n                        <th></th>\r\n                    </tr>\r\n");
#nullable restore
#line 61 "C:\Users\HP\Desktop\SupportProductsEvaluation\src\SupportProductsEvaluation.Web\Areas\Admin\Views\Product\Index.cshtml"
                     foreach (var item in Model.Products)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <tr>\r\n                    <td>\r\n");
#nullable restore
#line 65 "C:\Users\HP\Desktop\SupportProductsEvaluation\src\SupportProductsEvaluation.Web\Areas\Admin\Views\Product\Index.cshtml"
                          
                            var base64 = Convert.ToBase64String(item.Picture);
                            var imgsrc = string.Format("data:image/jpg;base64,{0}", base64);
                        

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <div class=\"col-3\">\r\n                            <img");
                BeginWriteAttribute("src", " src=\"", 2661, "\"", 2674, 1);
#nullable restore
#line 70 "C:\Users\HP\Desktop\SupportProductsEvaluation\src\SupportProductsEvaluation.Web\Areas\Admin\Views\Product\Index.cshtml"
WriteAttributeValue("", 2667, imgsrc, 2667, 7, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" height=\"100%\" width=\"100%\" />\r\n                        </div>\r\n\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 75 "C:\Users\HP\Desktop\SupportProductsEvaluation\src\SupportProductsEvaluation.Web\Areas\Admin\Views\Product\Index.cshtml"
                   Write(Html.DisplayFor(m => item.Name));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 78 "C:\Users\HP\Desktop\SupportProductsEvaluation\src\SupportProductsEvaluation.Web\Areas\Admin\Views\Product\Index.cshtml"
                   Write(Html.DisplayFor(m => item.Shop.Name));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 81 "C:\Users\HP\Desktop\SupportProductsEvaluation\src\SupportProductsEvaluation.Web\Areas\Admin\Views\Product\Index.cshtml"
                   Write(Html.DisplayFor(m => item.Category.Name));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "03b44147a3f7a16cf3c5e54b04ffcbc0bde5e82f14324", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#nullable restore
#line 84 "C:\Users\HP\Desktop\SupportProductsEvaluation\src\SupportProductsEvaluation.Web\Areas\Admin\Views\Product\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = item.Id;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 87 "C:\Users\HP\Desktop\SupportProductsEvaluation\src\SupportProductsEvaluation.Web\Areas\Admin\Views\Product\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                </table>\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "03b44147a3f7a16cf3c5e54b04ffcbc0bde5e82f16353", async() => {
                }
                );
                __SupportProductsEvaluation_Infrastructure_TagHelpers_PageLinkTagHelper = CreateTagHelper<global::SupportProductsEvaluation.Infrastructure.TagHelpers.PageLinkTagHelper>();
                __tagHelperExecutionContext.Add(__SupportProductsEvaluation_Infrastructure_TagHelpers_PageLinkTagHelper);
#nullable restore
#line 89 "C:\Users\HP\Desktop\SupportProductsEvaluation\src\SupportProductsEvaluation.Web\Areas\Admin\Views\Product\Index.cshtml"
__SupportProductsEvaluation_Infrastructure_TagHelpers_PageLinkTagHelper.PageModel = Model.PagingInfo;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("page-model", __SupportProductsEvaluation_Infrastructure_TagHelpers_PageLinkTagHelper.PageModel, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 89 "C:\Users\HP\Desktop\SupportProductsEvaluation\src\SupportProductsEvaluation.Web\Areas\Admin\Views\Product\Index.cshtml"
__SupportProductsEvaluation_Infrastructure_TagHelpers_PageLinkTagHelper.PageClassesEnabled = true;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("page-classes-enabled", __SupportProductsEvaluation_Infrastructure_TagHelpers_PageLinkTagHelper.PageClassesEnabled, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __SupportProductsEvaluation_Infrastructure_TagHelpers_PageLinkTagHelper.PageClass = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                __SupportProductsEvaluation_Infrastructure_TagHelpers_PageLinkTagHelper.PageClassNormal = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                __SupportProductsEvaluation_Infrastructure_TagHelpers_PageLinkTagHelper.PageClassSelected = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                <br />\r\n");
#nullable restore
#line 93 "C:\Users\HP\Desktop\SupportProductsEvaluation\src\SupportProductsEvaluation.Web\Areas\Admin\Views\Product\Index.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <p>No products exist...</p>\r\n");
#nullable restore
#line 97 "C:\Users\HP\Desktop\SupportProductsEvaluation\src\SupportProductsEvaluation.Web\Areas\Admin\Views\Product\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("        </div>\r\n    </div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProductListVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
