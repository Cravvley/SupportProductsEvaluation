#pragma checksum "C:\Users\HP\Desktop\Compareo\src\Compareo.Web\Areas\User\Views\Home\Comparison.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ce65e148d9620f03bdc4ca9f12ba2b91a457c22b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_User_Views_Home_Comparison), @"mvc.1.0.view", @"/Areas/User/Views/Home/Comparison.cshtml")]
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
#line 1 "C:\Users\HP\Desktop\Compareo\src\Compareo.Web\Areas\User\Views\_ViewImports.cshtml"
using Compareo.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\HP\Desktop\Compareo\src\Compareo.Web\Areas\User\Views\_ViewImports.cshtml"
using Compareo.Infrastructure.VMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\HP\Desktop\Compareo\src\Compareo.Web\Areas\User\Views\_ViewImports.cshtml"
using Compareo.Infrastructure.Common.StaticFiles;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ce65e148d9620f03bdc4ca9f12ba2b91a457c22b", @"/Areas/User/Views/Home/Comparison.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9d220943c406a219c750d2112eed4c3873b313d3", @"/Areas/User/Views/_ViewImports.cshtml")]
    public class Areas_User_Views_Home_Comparison : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "FirstShops", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("FirstShopsId"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "SecondShops", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("SecondShopsId"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-secondary form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/comboTreePlugin.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\HP\Desktop\Compareo\src\Compareo.Web\Areas\User\Views\Home\Comparison.cshtml"
  
    ViewData["Title"] = "Comparison";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1 class=""text-center text-info"">Product Comparison</h1>
<br />
<div class=""row container"">
    <div class=""col-11"">
        <div class=""row"" style=""padding-top:10px"">
            <div class=""col-6"">
                <input id=""productName"" placeholder=""Product name..."" class=""form-control"" />
            </div>
            <div class=""col-6"">
                <input type=""text"" autocomplete=""off"" id=""Category"" placeholder=""Category name..."" />
            </div>
        </div>
    </div>
    <div class=""col-1"">
        <div class=""row"" style=""padding-top:10px;"">
            <button id=""productSearch"" type=""submit"" name=""submit"" value=""Search"" class=""btn btn-info form-control"">
                <i class=""fas fa-search""></i>
            </button>
        </div>
    </div>
</div>
<br />
<br />
<div class=""col-12 row mb-4"">
    <div class=""form-group row col-sm-7 col-md-5 col-11"">
        <div class=""col-1 "">
            <label for=""FirstShopsId"" class=""col-form-label text-info text-upp");
            WriteLiteral("ercase mt-3 ml-2\">Shop:</label>\r\n        </div>\r\n        <div class=\"col-8 offset-2  mt-3\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ce65e148d9620f03bdc4ca9f12ba2b91a457c22b7859", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
#nullable restore
#line 36 "C:\Users\HP\Desktop\Compareo\src\Compareo.Web\Areas\User\Views\Home\Comparison.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = (new SelectList(string.Empty,"Id","Name"));

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
        </div>
    </div>
    <div class=""form-group offset-md-1 row col-sm-7 col-md-5 col-11"">
        <div class=""col-1"">
            <label for=""SecondShopsId"" class=""col-form-label text-info text-uppercase mt-3 ml-2"">Shop:</label>
        </div>
        <div class=""col-8 offset-2 mt-3"">
            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ce65e148d9620f03bdc4ca9f12ba2b91a457c22b9958", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Name = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
#nullable restore
#line 44 "C:\Users\HP\Desktop\Compareo\src\Compareo.Web\Areas\User\Views\Home\Comparison.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = (new SelectList(string.Empty,"Id","Name"));

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
        </div>
    </div>
</div>

<div class=""row col-12"">
    <div id=""firstProduct"" class=""col-md-5 border p-3 pt-5""></div>
    <div id=""secondProduct"" class=""col-md-5 offset-md-1 mt-4 mt-md-0 border p-3 pt-5""></div>
</div>

<div class=""col-5 mt-5"">
    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ce65e148d9620f03bdc4ca9f12ba2b91a457c22b12014", async() => {
                WriteLiteral("Back");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n\r\n\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ce65e148d9620f03bdc4ca9f12ba2b91a457c22b13371", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
    <script type=""text/javascript"">

        let ids = 0;
        let productName = $(""#productName"").val();
        let urlShops = `/User/Home/ProductsLocalization?productName=${productName}&categoryId=${ids}`;
        const url = ""/Admin/Category/GetCategories"";

        $(document).ready(() => {

            $('#FirstShopsId').change(() => {
                getProductFromFirstShop();
            });
            $('#SecondShopsId').change(() => {
                getProductFromSecondShop ();
            });

            $.getJSON(url, data => {
                const instance = $('#Category').comboTree({
                    source: data,
                    selected: ['0'],
                    isMultiple: false
                });


            })

        });


        $('#productName').change(() => {
            productName = $(""#productName"").val();
            urlShops = `/User/Home/ProductsLocalization?productName=${productName}&categoryId=${ids}`;
        });

       ");
                WriteLiteral(@" $('#Category').change(() => {
            ids = instance.getSelectedIds();
            urlShops = `/User/Home/ProductsLocalization?productName=${productName}&categoryId=${ids}`;

        });

        $('#productSearch').click(e => {
            e.preventDefault();
            getProducts();
        })

        const getProducts= () => {
            $.getJSON(urlShops, data => {

                let items = '';

                $('#ShopsId').empty();
                $.each(data, (i, shops)=> {
                    items += ""<option value='"" + shops.value + ""'>"" + shops.text + ""</option>"";
                });

                $('#FirstShopsId').html(items);
                $('#SecondShopsId').html(items);

                getProductFromFirstShop();
                getProductFromSecondShop();
            })
        }

        const createProductForm = data => {
            const productForm = `
                <div class=""form-group row"">
                 <div class=""col-2"">
    ");
                WriteLiteral(@"              <label asp-for=""${data.description}"" class=""col-form-label"">Description:</label>
                 </div>
                 <div class=""offset-1 col-md-8"">
                    <input asp-for=""${data.description}"" value=${data.description} disabled class=""form-control"" />
                 </div>
                </div>
                <div class=""form-group row"">
                 <div class=""col-2"">
                  <label asp-for=""${data.price}"" class=""col-form-label"">Price</label>
                 </div>
                 <div class=""offset-1 col-md-8"">
                    <input asp-for=""${data.price}"" value=${data.price} disabled class=""form-control"" />
                 </div>
                </div>
                <div class=""form-group row"">
                 <div class=""col-2"">
                  <label asp-for=""${data.averageGrade}"" class=""col-form-label"">Average Grade</label>
                 </div>
                 <div class=""offset-1 col-md-8"">
                    <input");
                WriteLiteral(@" asp-for=""${data.averageGrade}"" value=${data.averageGrade} disabled class=""form-control"" />
                 </div>
                </div>
               `;
            return productForm;
        }

        const getProductFromFirstShop = () => {

            const source = '#FirstShopsId';
            const url = '");
#nullable restore
#line 158 "C:\Users\HP\Desktop\Compareo\src\Compareo.Web\Areas\User\Views\Home\Comparison.cshtml"
                    Write(Url.Content("~/"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"' + $(source).val();

            const $list = $('#firstProduct');

            $.getJSON(url, data => {
                $list.html('');
                $list.append(createProductForm(data));
            })

        }

        const getProductFromSecondShop = () => {

            const source = '#SecondShopsId';
            const url = '");
#nullable restore
#line 172 "C:\Users\HP\Desktop\Compareo\src\Compareo.Web\Areas\User\Views\Home\Comparison.cshtml"
                    Write(Url.Content("~/"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\' + $(source).val();\r\n\r\n            const $list = $(\'#secondProduct\');\r\n\r\n            $.getJSON(url, data => {\r\n                $list.html(\'\');\r\n                $list.append(createProductForm(data));\r\n            })\r\n        }\r\n    </script>\r\n\r\n");
#nullable restore
#line 183 "C:\Users\HP\Desktop\Compareo\src\Compareo.Web\Areas\User\Views\Home\Comparison.cshtml"
       await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
            }
            );
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
