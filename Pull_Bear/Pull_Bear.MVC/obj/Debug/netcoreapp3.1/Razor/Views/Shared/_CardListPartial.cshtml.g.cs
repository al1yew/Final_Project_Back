#pragma checksum "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\Shared\_CardListPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dc3b27ecb5a5eef064cd7256c9e7734f30a85322"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__CardListPartial), @"mvc.1.0.view", @"/Views/Shared/_CardListPartial.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 2 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.AccountVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.HomeVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.ProductColorSizeVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.ProductImageVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.ProductVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.ProductReviewVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.ShopVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.CategoryVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.BodyFitVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.ColorVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.AddressVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.SizeVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.HeaderVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.AppUserVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.BasketVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.OrderItemVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.OrderVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.CardVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\_ViewImports.cshtml"
using Pull_Bear.Service.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\_ViewImports.cshtml"
using Pull_Bear.Core.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\_ViewImports.cshtml"
using System;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dc3b27ecb5a5eef064cd7256c9e7734f30a85322", @"/Views/Shared/_CardListPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"99e8facbfc61f664073e41ab067e55975cdd75cc", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__CardListPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<CardListVM>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-fluid"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/images/settings/mastercard.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Card", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DeleteCard", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("deleteuserscard"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "MakeMain", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("makemaincard"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\Shared\_CardListPartial.cshtml"
 foreach (CardListVM card in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"cardinozu col-lg-4 col-12\">\r\n        <div class=\"cardozu col-lg-12 col-12\">\r\n            <span class=\"col-lg-1-5 col-1-5\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "dc3b27ecb5a5eef064cd7256c9e7734f30a8532210493", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </span>\r\n            <span class=\"cardno\">\r\n");
#nullable restore
#line 11 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\Shared\_CardListPartial.cshtml"
                 for (int i = 0; i <= 6; i++)
                {
                    if (i == 4)
                    {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\Shared\_CardListPartial.cshtml"
                    Write(" ");

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\Shared\_CardListPartial.cshtml"
                              
                    }

                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\Shared\_CardListPartial.cshtml"
               Write(card.CardNo.ToString()[i]);

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\Shared\_CardListPartial.cshtml"
                                              
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\Shared\_CardListPartial.cshtml"
                 for (int i = 7; i < card.CardNo.ToString().Length; i++)
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\Shared\_CardListPartial.cshtml"
                Write("*");

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\Shared\_CardListPartial.cshtml"
                          
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </span>\r\n            <span class=\"cardexpire\">\r\n                ");
#nullable restore
#line 26 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\Shared\_CardListPartial.cshtml"
           Write(card.ExpireDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </span>\r\n            <span class=\"cardholder\">\r\n                ");
#nullable restore
#line 29 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\Shared\_CardListPartial.cshtml"
           Write(card.CardHolder);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </span>\r\n            <span class=\"deletecard\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dc3b27ecb5a5eef064cd7256c9e7734f30a8532214450", async() => {
                WriteLiteral(@"
                    <svg width=""24"" height=""24"" viewBox=""0 0 24 24"" fill=""none""
                         xmlns=""http://www.w3.org/2000/svg"">
                        <path d=""M3.75 4.2998V22.9998H20.25V4.2998H3.75Z"" stroke=""black""
                              stroke-linejoin=""round"" />
                        <path d=""M9.8 9.7998V16.9498M14.2 9.7998V16.9498M1 4.2998H23"" stroke=""black""
                              stroke-linecap=""round"" stroke-linejoin=""round"" />
                        <path d=""M7.60059 4.3L9.40954 1H14.6279L16.4006 4.3H7.60059Z"" stroke=""black""
                              stroke-linejoin=""round"" />
                    </svg>
                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 32 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\Shared\_CardListPartial.cshtml"
                                                                   WriteLiteral(card.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </span>\r\n");
#nullable restore
#line 44 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\Shared\_CardListPartial.cshtml"
             if (card.IsMain)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <span class=\"ismain\">Main Card</span>\r\n");
#nullable restore
#line 47 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\Shared\_CardListPartial.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <span class=\"makemain\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dc3b27ecb5a5eef064cd7256c9e7734f30a8532218277", async() => {
                WriteLiteral("\r\n                        MAKE MAIN\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 51 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\Shared\_CardListPartial.cshtml"
                                                                     WriteLiteral(card.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </span>\r\n");
#nullable restore
#line 55 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\Shared\_CardListPartial.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            <span class=\" headword\">International card</span>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 59 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\Shared\_CardListPartial.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<CardListVM>> Html { get; private set; }
    }
}
#pragma warning restore 1591
