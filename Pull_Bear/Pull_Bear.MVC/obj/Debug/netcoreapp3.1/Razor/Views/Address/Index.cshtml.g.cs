#pragma checksum "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\Address\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "817f93307dfe091dd2f0e0ecd90400258fa11fe3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Address_Index), @"mvc.1.0.view", @"/Views/Address/Index.cshtml")]
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
using Pull_Bear.Service.Enums;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"817f93307dfe091dd2f0e0ecd90400258fa11fe3", @"/Views/Address/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2d01ff808dfe2d9aad29a81f4d3de141de7e831c", @"/Views/_ViewImports.cshtml")]
    public class Views_Address_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Address", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DeleteAddress", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "MakeMain", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("addnewaddressform"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("addressozu col-lg-12 col-12 addnewaddressform"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "817f93307dfe091dd2f0e0ecd90400258fa11fe38239", async() => {
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
            WriteLiteral(@"&nbsp;/ ADDRESSES
                </div>
            </div>
        </div>
    </section>

    <section class=""myaddresses"">
        <div class=""container"">
            <div class=""row all"">
                <p class=""firstp col-lg-12 col-12"">MY ADDRESSES</p>
                <div class=""addressdiv col-lg-12 col-12"">

                    <div class=""addressinozu col-lg-4 col-12"">
                        <div class=""addressozu col-lg-12 col-12"">

                            <div class=""top"">
                                <span class=""cityname col-lg-12 col-12"">
                                    City: BAKU
                                </span>
                                <span class=""countryname col-lg-12 col-12"">
                                    Country: AZERBAIJAN
                                </span>
                            </div>
                            <div class=""bottom"">
                                <span class=""address1name col-lg-12 col-12"">
            ");
            WriteLiteral(@"                        <span class=""col-lg-12 col-12"">
                                        Address1:
                                    </span>
                                    <span class=""col-lg-12"">
                                        Tabriz str. 999, ap. 61
                                    </span>
                                </span>
                                <span class=""address2name col-lg-12 col-12"">
                                    <span class=""col-lg-12 col-12"">
                                        Address2:
                                    </span>
                                    <span class=""col-lg-12 col-12"">
                                        Narimanov dis.
                                    </span>
                                </span>
                                <span class=""zipcodename col-lg-12 col-12"">
                                    <span class=""col-lg-12 col-12"">
                                        ZIP code:
       ");
            WriteLiteral(@"                             </span>
                                    <span class=""col-lg-12 col-12"">
                                        AZ1000
                                    </span>
                                </span>
                            </div>
                            <span class=""deleteaddress"">
                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "817f93307dfe091dd2f0e0ecd90400258fa11fe312121", async() => {
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
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                            </span>
                            <span class="" ismain"">Main Address</span>
                        </div>
                    </div>

                    <div class=""addressinozu col-lg-4 col-12"">
                        <div class=""addressozu col-lg-12 col-12"">

                            <div class=""top"">
                                <span class=""cityname col-lg-12 col-12"">
                                    City: BAKU
                                </span>
                                <span class=""countryname col-lg-12 col-12"">
                                    Country: AZERBAIJAN
                                </span>
                            </div>
                            <div class=""bottom"">
                                <span class=""address1name col-lg-12 col-12"">
                                    <span class=""col-lg-12 col-12"">
                                        Address1:
                                    </span>
     ");
            WriteLiteral(@"                               <span class=""col-lg-12"">
                                        Tabriz str. 999, ap. 61
                                    </span>
                                </span>
                                <span class=""address2name col-lg-12 col-12"">
                                    <span class=""col-lg-12 col-12"">
                                        Address2:
                                    </span>
                                    <span class=""col-lg-12 col-12"">
                                        Narimanov dis.
                                    </span>
                                </span>
                                <span class=""zipcodename col-lg-12 col-12"">
                                    <span class=""col-lg-12 col-12"">
                                        ZIP code:
                                    </span>
                                    <span class=""col-lg-12 col-12"">
                                        AZ1000
   ");
            WriteLiteral("                                 </span>\r\n                                </span>\r\n                            </div>\r\n                            <span class=\"deleteaddress\">\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "817f93307dfe091dd2f0e0ecd90400258fa11fe316707", async() => {
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
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </span>\r\n                            <span class=\"makemain\">\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "817f93307dfe091dd2f0e0ecd90400258fa11fe319062", async() => {
                WriteLiteral("\r\n                                    MAKE MAIN\r\n                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                            </span>
                        </div>
                    </div>

                    <div class=""addressform col-lg-4 col-12"">

                        <p class=""clicktoaddnewaddress"">
                            ADD NEW
                        </p>

                        <div class=""again_allcontent"">
                            <div class=""allcontent col-lg-12 col-12"">

                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "817f93307dfe091dd2f0e0ecd90400258fa11fe320962", async() => {
                WriteLiteral(@"

                                    <input name=""address1"" class=""col-12 col-lg-12 addressaddress1""
                                           id=""addressaddress1"" type=""text"" required placeholder=""ADDRESS 1"">

                                    <input name=""address2"" class=""col-12 col-lg-12 addressaddress2""
                                           id=""addressaddress2"" type=""text"" placeholder=""ADDRESS 2"">

                                    <input name=""country"" id=""addresscountry""
                                           class=""col-12 col-lg-12 addresscountry"" type=""text"" required
                                           placeholder=""COUNTRY"">

                                    <input name=""city"" id=""addresscity"" class=""col-12 col-lg-12 addresscity""
                                           type=""text"" required placeholder=""CITY"">

                                    <input name=""zipcode"" id=""addresszipcode""
                                           class=""col-12 col-lg-12 addre");
                WriteLiteral(@"sszipcode"" type=""text"" required max=""10""
                                           maxlength=""10"" title=""ZIP code must be at most 10 characters!""
                                           placeholder=""ZIP code"">

                                    <button form=""addnewaddressform"" type=""submit""
                                            class=""addresschangebtn col-lg-2-5 col-2-5"" value=""save"">
                                        SAVE
                                    </button>

                                    <button type=""button"" class=""cancelnewaddress col-lg-2-5 col-2-5""
                                            value=""save"">
                                        CANCEL
                                    </button>

                                    <button form=""addnewaddressform"" type=""submit""
                                            class=""addresschangebtn col-lg-6-5 col-6-5"" value=""add"">
                                        SAVE AND MAKE MAIN
                  ");
                WriteLiteral("                  </button>\r\n                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </section>\r\n\r\n</main>\r\n\r\n");
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
