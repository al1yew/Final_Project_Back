#pragma checksum "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\Contact\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "93f4f9e5e259414a9a6b0aa1efad8e35d8ebf557"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Contact_Index), @"mvc.1.0.view", @"/Views/Contact/Index.cshtml")]
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
using Pull_Bear.Service.ViewModels.OrderItemVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.SizeVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.HeaderVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.AppUserVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.BasketVMs;

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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"93f4f9e5e259414a9a6b0aa1efad8e35d8ebf557", @"/Views/Contact/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7e6245f3908514f323ede0ddb08a99aa0217d79c", @"/Views/_ViewImports.cshtml")]
    public class Views_Contact_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("col-lg-6 col-12"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("formcontact"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"

<main>

    <section class=""whereareyou"">
        <div class=""where"">.</div>
    </section>

    <section class=""breadcrumbregsiter"">
        <div class=""container"">
            <div class=""row keeper"">
                <div class=""col-lg-6"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "93f4f9e5e259414a9a6b0aa1efad8e35d8ebf5579694", async() => {
                WriteLiteral("MAIN PAGE");
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
            WriteLiteral(@"&nbsp;/ CONTACT
                </div>
            </div>
        </div>
    </section>

    <section class=""contact"">
        <div class=""container"">
            <div class=""row all"">
                <p class=""firstp col-lg-12 col-12"">CONTACT US</p>

                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "93f4f9e5e259414a9a6b0aa1efad8e35d8ebf55711342", async() => {
                WriteLiteral(@"
                    <input type=""text"" name=""contactname"" id=""contactname"" placeholder=""Name"" required
                           class=""col-lg-12 col-12"">
                    <input type=""text"" name=""contactsurname"" id=""contactsurname"" placeholder=""Surname"" required
                           class=""col-lg-12 col-12"">
                    <input type=""tel"" name=""contactphone"" id=""contactphone"" placeholder=""Phone"" required
                           class=""col-lg-12 col-12"">
                    <input type=""email"" name=""contactemail"" id=""contactemail"" placeholder=""Email"" required
                           class=""col-lg-12 col-12"">
                    <textarea class=""col-12 col-lg-12"" name=""contacttext"" id=""contacttext"" cols=""10"" rows=""10""
                              placeholder=""Your Text""></textarea>
                    <button type=""submit"" form=""formcontact"" class=""col-lg-12 col-12"">SEND</button>
                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </section>\r\n\r\n</main>\r\n\r\n");
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
