#pragma checksum "C:\Users\HP\Desktop\SupportProductsEvaluation\SupportProductsEvaluation.Web\Areas\Admin\Views\Shop\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b2123167a74ed15530b828cb3fb264e41aa8a09f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Shop_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Shop/Index.cshtml")]
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
#line 1 "C:\Users\HP\Desktop\SupportProductsEvaluation\SupportProductsEvaluation.Web\Areas\Admin\Views\_ViewImports.cshtml"
using SupportProductsEvaluation.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\HP\Desktop\SupportProductsEvaluation\SupportProductsEvaluation.Web\Areas\Admin\Views\_ViewImports.cshtml"
using SupportProductsEvaluation.Infrastructure.VMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\HP\Desktop\SupportProductsEvaluation\SupportProductsEvaluation.Web\Areas\Admin\Views\_ViewImports.cshtml"
using SupportProductsEvaluation.Core.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b2123167a74ed15530b828cb3fb264e41aa8a09f", @"/Areas/Admin/Views/Shop/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4ecb59160d33a439babf3bdee78452f6ac8de9d8", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Shop_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ShopListVM>
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
#line 3 "C:\Users\HP\Desktop\SupportProductsEvaluation\SupportProductsEvaluation.Web\Areas\Admin\Views\Shop\Index.cshtml"
  
    ViewData["Title"] = "Shop's list";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<br />\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b2123167a74ed15530b828cb3fb264e41aa8a09f6510", async() => {
                WriteLiteral("\r\n    <div class=\"border p-3\">\r\n        <div class=\"row p-1\">\r\n            <div class=\"col-6\">\r\n                <h2 class=\"text-info\"> Shop\'s List</h2>\r\n            </div>\r\n            <div class=\"col-6 text-right\">\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "b2123167a74ed15530b828cb3fb264e41aa8a09f7022", async() => {
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
                WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <br />\r\n");
#nullable restore
#line 20 "C:\Users\HP\Desktop\SupportProductsEvaluation\SupportProductsEvaluation.Web\Areas\Admin\Views\Shop\Index.cshtml"
         if (Model.Shops.Count() > 0)
        {

#line default
#line hidden
#nullable disable
                WriteLiteral("            <div class=\"row container\">\r\n                <div class=\"col-11\">\r\n                    <div class=\"row\" style=\"padding-top:10px\">\r\n                        <div class=\"col-6\">\r\n                            ");
#nullable restore
#line 26 "C:\Users\HP\Desktop\SupportProductsEvaluation\SupportProductsEvaluation.Web\Areas\Admin\Views\Shop\Index.cshtml"
                       Write(Html.Editor("searchName", new { htmlAttributes = new { @class = "form-control", @placeholder = "Name..." } }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </div>\r\n                        <div class=\"col-6\">\r\n                            ");
#nullable restore
#line 29 "C:\Users\HP\Desktop\SupportProductsEvaluation\SupportProductsEvaluation.Web\Areas\Admin\Views\Shop\Index.cshtml"
                       Write(Html.Editor("searchCity", new { htmlAttributes = new { @class = "form-control", @placeholder = "City..." } }));

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
");
#nullable restore
#line 41 "C:\Users\HP\Desktop\SupportProductsEvaluation\SupportProductsEvaluation.Web\Areas\Admin\Views\Shop\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral("        <br />\r\n        <br />\r\n        <div class=\"p-1\">\r\n");
#nullable restore
#line 45 "C:\Users\HP\Desktop\SupportProductsEvaluation\SupportProductsEvaluation.Web\Areas\Admin\Views\Shop\Index.cshtml"
             if (Model.Shops.Count() > 0)
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <table class=\"table table-striped border\">\r\n                    <tr class=\"table-secondary\">\r\n                        <th>\r\n                            ");
#nullable restore
#line 50 "C:\Users\HP\Desktop\SupportProductsEvaluation\SupportProductsEvaluation.Web\Areas\Admin\Views\Shop\Index.cshtml"
                       Write(Html.DisplayNameFor(s => s.Shops[0].Name));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
#nullable restore
#line 53 "C:\Users\HP\Desktop\SupportProductsEvaluation\SupportProductsEvaluation.Web\Areas\Admin\Views\Shop\Index.cshtml"
                       Write(Html.DisplayNameFor(s => s.Shops[0].City));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
#nullable restore
#line 56 "C:\Users\HP\Desktop\SupportProductsEvaluation\SupportProductsEvaluation.Web\Areas\Admin\Views\Shop\Index.cshtml"
                       Write(Html.DisplayNameFor(s => s.Shops[0].PostalCode));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </th>\r\n                        <th></th>\r\n                        <th></th>\r\n                    </tr>\r\n");
#nullable restore
#line 61 "C:\Users\HP\Desktop\SupportProductsEvaluation\SupportProductsEvaluation.Web\Areas\Admin\Views\Shop\Index.cshtml"
                     foreach (var item in Model.Shops)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <tr>\r\n                            <td>\r\n                                ");
#nullable restore
#line 65 "C:\Users\HP\Desktop\SupportProductsEvaluation\SupportProductsEvaluation.Web\Areas\Admin\Views\Shop\Index.cshtml"
                           Write(Html.DisplayFor(m => item.Name));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 68 "C:\Users\HP\Desktop\SupportProductsEvaluation\SupportProductsEvaluation.Web\Areas\Admin\Views\Shop\Index.cshtml"
                           Write(Html.DisplayFor(m => item.City));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 71 "C:\Users\HP\Desktop\SupportProductsEvaluation\SupportProductsEvaluation.Web\Areas\Admin\Views\Shop\Index.cshtml"
                           Write(Html.DisplayFor(m => item.PostalCode));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "b2123167a74ed15530b828cb3fb264e41aa8a09f13749", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#nullable restore
#line 74 "C:\Users\HP\Desktop\SupportProductsEvaluation\SupportProductsEvaluation.Web\Areas\Admin\Views\Shop\Index.cshtml"
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
                WriteLiteral("\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 77 "C:\Users\HP\Desktop\SupportProductsEvaluation\SupportProductsEvaluation.Web\Areas\Admin\Views\Shop\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                </table>\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b2123167a74ed15530b828cb3fb264e41aa8a09f15780", async() => {
                }
                );
                __SupportProductsEvaluation_Infrastructure_TagHelpers_PageLinkTagHelper = CreateTagHelper<global::SupportProductsEvaluation.Infrastructure.TagHelpers.PageLinkTagHelper>();
                __tagHelperExecutionContext.Add(__SupportProductsEvaluation_Infrastructure_TagHelpers_PageLinkTagHelper);
#nullable restore
#line 79 "C:\Users\HP\Desktop\SupportProductsEvaluation\SupportProductsEvaluation.Web\Areas\Admin\Views\Shop\Index.cshtml"
__SupportProductsEvaluation_Infrastructure_TagHelpers_PageLinkTagHelper.PageModel = Model.PagingInfo;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("page-model", __SupportProductsEvaluation_Infrastructure_TagHelpers_PageLinkTagHelper.PageModel, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 79 "C:\Users\HP\Desktop\SupportProductsEvaluation\SupportProductsEvaluation.Web\Areas\Admin\Views\Shop\Index.cshtml"
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
#line 83 "C:\Users\HP\Desktop\SupportProductsEvaluation\SupportProductsEvaluation.Web\Areas\Admin\Views\Shop\Index.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <p>No shops exist...</p>\r\n");
#nullable restore
#line 87 "C:\Users\HP\Desktop\SupportProductsEvaluation\SupportProductsEvaluation.Web\Areas\Admin\Views\Shop\Index.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ShopListVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
