#pragma checksum "D:\programming\Final Project\Final_Project_Back\Pull_Bear\Pull_Bear.MVC\Views\Shared\_CheckoutSubmitFormPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "476698732f2763222623f6641259460dbe386029"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__CheckoutSubmitFormPartial), @"mvc.1.0.view", @"/Views/Shared/_CheckoutSubmitFormPartial.cshtml")]
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
#line 2 "D:\programming\Final Project\Final_Project_Back\Pull_Bear\Pull_Bear.MVC\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.AccountVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\programming\Final Project\Final_Project_Back\Pull_Bear\Pull_Bear.MVC\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.HomeVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\programming\Final Project\Final_Project_Back\Pull_Bear\Pull_Bear.MVC\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.ProductColorSizeVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\programming\Final Project\Final_Project_Back\Pull_Bear\Pull_Bear.MVC\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.ProductImageVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\programming\Final Project\Final_Project_Back\Pull_Bear\Pull_Bear.MVC\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.ProductVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\programming\Final Project\Final_Project_Back\Pull_Bear\Pull_Bear.MVC\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.ProductReviewVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\programming\Final Project\Final_Project_Back\Pull_Bear\Pull_Bear.MVC\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.ShopVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\programming\Final Project\Final_Project_Back\Pull_Bear\Pull_Bear.MVC\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.CategoryVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\programming\Final Project\Final_Project_Back\Pull_Bear\Pull_Bear.MVC\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.BodyFitVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\programming\Final Project\Final_Project_Back\Pull_Bear\Pull_Bear.MVC\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "D:\programming\Final Project\Final_Project_Back\Pull_Bear\Pull_Bear.MVC\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.ColorVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "D:\programming\Final Project\Final_Project_Back\Pull_Bear\Pull_Bear.MVC\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.AddressVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "D:\programming\Final Project\Final_Project_Back\Pull_Bear\Pull_Bear.MVC\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.OrderItemVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "D:\programming\Final Project\Final_Project_Back\Pull_Bear\Pull_Bear.MVC\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.SizeVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "D:\programming\Final Project\Final_Project_Back\Pull_Bear\Pull_Bear.MVC\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.HeaderVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "D:\programming\Final Project\Final_Project_Back\Pull_Bear\Pull_Bear.MVC\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.AppUserVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "D:\programming\Final Project\Final_Project_Back\Pull_Bear\Pull_Bear.MVC\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.WishlistVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "D:\programming\Final Project\Final_Project_Back\Pull_Bear\Pull_Bear.MVC\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.BasketVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "D:\programming\Final Project\Final_Project_Back\Pull_Bear\Pull_Bear.MVC\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.OrderVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "D:\programming\Final Project\Final_Project_Back\Pull_Bear\Pull_Bear.MVC\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.ContactVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "D:\programming\Final Project\Final_Project_Back\Pull_Bear\Pull_Bear.MVC\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.CardVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "D:\programming\Final Project\Final_Project_Back\Pull_Bear\Pull_Bear.MVC\Views\_ViewImports.cshtml"
using Pull_Bear.Service.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 24 "D:\programming\Final Project\Final_Project_Back\Pull_Bear\Pull_Bear.MVC\Views\_ViewImports.cshtml"
using Pull_Bear.Core.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 25 "D:\programming\Final Project\Final_Project_Back\Pull_Bear\Pull_Bear.MVC\Views\_ViewImports.cshtml"
using System;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"476698732f2763222623f6641259460dbe386029", @"/Views/Shared/_CheckoutSubmitFormPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7b8f68898f74a05c868dfe5b772d5e36d12c5c44", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__CheckoutSubmitFormPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<double>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Policy", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("col-lg-12 col-12"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Faq", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("policyhref"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"top\">\r\n    <span class=\"col-lg-4 col-4\">Subtotal:</span>\r\n    <span class=\"col-lg-7 col-7\">");
#nullable restore
#line 5 "D:\programming\Final Project\Final_Project_Back\Pull_Bear\Pull_Bear.MVC\Views\Shared\_CheckoutSubmitFormPartial.cshtml"
                            Write(Model);

#line default
#line hidden
#nullable disable
            WriteLiteral(" $</span>\r\n    <span class=\"col-lg-4 col-4\">Delivery:</span>\r\n    <span class=\"col-lg-7 col-7\">FREE</span>\r\n</div>\r\n<div class=\"middle\">\r\n    <span class=\"col-lg-4 col-4\">Total:</span>\r\n    <span class=\"col-lg-7 col-7\">");
#nullable restore
#line 11 "D:\programming\Final Project\Final_Project_Back\Pull_Bear\Pull_Bear.MVC\Views\Shared\_CheckoutSubmitFormPartial.cshtml"
                            Write(Model);

#line default
#line hidden
#nullable disable
            WriteLiteral(" $</span>\r\n</div>\r\n<div class=\"bottom\">\r\n");
#nullable restore
#line 14 "D:\programming\Final Project\Final_Project_Back\Pull_Bear\Pull_Bear.MVC\Views\Shared\_CheckoutSubmitFormPartial.cshtml"
     if (Model != 0)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <button type=\"submit\" form=\"orderform\" class=\"aldiq\">\r\n            PAY FOR ORDER\r\n        </button>\r\n");
#nullable restore
#line 19 "D:\programming\Final Project\Final_Project_Back\Pull_Bear\Pull_Bear.MVC\Views\Shared\_CheckoutSubmitFormPartial.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"paywith\">\r\n        <span class=\"col-lg-12 col-12\">\r\n            By continuing you agree to P&B\'s\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "476698732f2763222623f6641259460dbe38602911495", async() => {
                WriteLiteral("\r\n                General Terms and Conditions.\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </span>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "476698732f2763222623f6641259460dbe38602912943", async() => {
                WriteLiteral("\r\n            Need help? See our customer service pages.\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "476698732f2763222623f6641259460dbe38602914460", async() => {
                WriteLiteral("\r\n            DELIVERY AND RETURN OPTIONS\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<double> Html { get; private set; }
    }
}
#pragma warning restore 1591
