#pragma checksum "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\Order\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cb23a86c24031853d6ab48e353fc7e9988cbd911"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_Index), @"mvc.1.0.view", @"/Views/Order/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cb23a86c24031853d6ab48e353fc7e9988cbd911", @"/Views/Order/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"99e8facbfc61f664073e41ab067e55975cdd75cc", @"/Views/_ViewImports.cshtml")]
    public class Views_Order_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<OrderListVM>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-fluid"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Shop", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ProductDetail", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("col-lg-12 col-12 orderitem"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cb23a86c24031853d6ab48e353fc7e9988cbd9119895", async() => {
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
            WriteLiteral(@"&nbsp;/ PURCHASES
                </div>
            </div>
        </div>
    </section>

    <section class=""ordersection"">
        <div class=""container"">
            <div class=""row all"">
                <p class=""firstp"">PURCHASES</p>

                <div class=""col-lg-4 col-10 ordersearchkeeper"">
                    <input class=""search_input_order"" id=""order_search"" placeholder=""SEARCH"" type=""text"">
                    <a href=""search uchun controller"">
                        <ion-icon name=""search-outline"" class=""search_icon_order""></ion-icon>
                    </a>
                </div>

                <ul class=""head_categories col-12 col-lg-7"">

                    <li class=""headcategoryli"">
                        <a");
            BeginWriteAttribute("href", " href=\"", 1125, "\"", 1132, 0);
            EndWriteAttribute();
            WriteLiteral(" class=\"categoryhref\">ALL</a>\r\n                    </li>\r\n\r\n");
#nullable restore
#line 38 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\Order\Index.cshtml"
                     foreach (var item in Enum.GetNames(typeof(OrderStatus)))
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li class=\"headcategoryli\">\r\n                            <a");
            BeginWriteAttribute("href", " href=\"", 1378, "\"", 1385, 0);
            EndWriteAttribute();
            WriteLiteral(" class=\"categoryhref\">");
#nullable restore
#line 41 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\Order\Index.cshtml"
                                                       Write(item.ToUpperInvariant());

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                        </li>\r\n");
#nullable restore
#line 43 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\Order\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </ul>\r\n                <div class=\"orders col-lg-12 col-12\">\r\n");
#nullable restore
#line 46 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\Order\Index.cshtml"
                     if (Model != null && Model.Count > 0)
                    {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 48 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\Order\Index.cshtml"
                         foreach (OrderListVM order in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            <div class=""order col-lg-12 col-12"">
                                <div class=""top col-lg-12 col-12"">
                                    <div class=""col-lg-2-2 col-7"">
                                        <span class=""col-lg-12 col-12"">ORDER DATE</span>
                                        <span class=""col-lg-12 col-12"">
                                            ");
#nullable restore
#line 55 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\Order\Index.cshtml"
                                       Write(order.CreatedAt.ToLongDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 55 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\Order\Index.cshtml"
                                                                             Write(order.CreatedAt.ToShortTimeString());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                        </span>
                                    </div>
                                    <div class=""col-lg-2-2 col-5"">
                                        <span class=""col-lg-12 col-12"">SUMMARY</span>
                                        <span class=""col-lg-12 col-12"">
                                            ");
#nullable restore
#line 61 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\Order\Index.cshtml"
                                       Write(order.OrderItems.Count());

#line default
#line hidden
#nullable disable
            WriteLiteral(@" products
                                        </span>
                                    </div>
                                    <div class=""col-lg-2-2 col-7"">
                                        <span class=""col-lg-12 col-12"">BUYER</span>
                                        <span class=""col-lg-12 col-12"">
                                            ");
#nullable restore
#line 67 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\Order\Index.cshtml"
                                       Write(order.Name.ToUpperInvariant());

#line default
#line hidden
#nullable disable
            WriteLiteral(" + ");
#nullable restore
#line 67 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\Order\Index.cshtml"
                                                                         Write(" ");

#line default
#line hidden
#nullable disable
            WriteLiteral(" +  ");
#nullable restore
#line 67 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\Order\Index.cshtml"
                                                                                  Write(order.SurName.ToUpperInvariant());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                        </span>
                                    </div>
                                    <div class=""col-lg-2-2 col-5"">
                                        <span class=""col-lg-12 col-12"">TOTAL</span>
                                        <span class=""col-lg-12 col-12"">
                                            ");
#nullable restore
#line 73 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\Order\Index.cshtml"
                                       Write(order.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" $
                                        </span>
                                    </div>
                                    <div class=""col-lg-2-2 col-12"">
                                        <span class=""status col-lg-12 col-6"">
                                            STATUS: ");
#nullable restore
#line 78 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\Order\Index.cshtml"
                                               Write(order.OrderStatus);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                        </span>
                                        <span class=""orderdet col-lg-12 col-6"">
                                            ORDER DETAILS
                                        </span>
                                    </div>
                                </div>
                                <div class=""bottom col-lg-12 col-12"">
");
#nullable restore
#line 86 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\Order\Index.cshtml"
                                     foreach (OrderItemListVM orderItem in order.OrderItems)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cb23a86c24031853d6ab48e353fc7e9988cbd91118807", async() => {
                WriteLiteral("\r\n                                            <div class=\"col-lg-6 col-12\">\r\n                                                <div class=\"col-lg-12 first\">\r\n                                                    ");
#nullable restore
#line 91 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\Order\Index.cshtml"
                                               Write(order.OrderStatus);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                                    <svg width=""18"" height=""14"" viewBox=""0 0 18 14"" fill=""none""
                                                         xmlns=""http://www.w3.org/2000/svg"">
                                                        <path d=""M5.6 10.6L1.4 6.4L0 7.8L5.6 13.4L17.6 1.4L16.2 0L5.6 10.6Z""
                                                              fill=""black"" />
                                                    </svg>
                                                </div>
                                                <div class=""col-lg-12 second"">
                                                    This product was delivered at ");
#nullable restore
#line 99 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\Order\Index.cshtml"
                                                                             Write(order.DeliveredAt);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                                </div>
                                                <div class=""col-lg-12 third"">
                                                    <span class=""col-lg-6 col-6"">
                                                        Tracking number:
                                                    </span>
                                                    <span class=""col-lg-6 col-6"">
                                                        ");
#nullable restore
#line 106 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\Order\Index.cshtml"
                                                   Write(orderItem.TrackingNumber);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                                    </span>
                                                </div>
                                            </div>
                                            <div class=""col-lg-5 orderinfo col-10"">

                                                <div class=""toptop col-lg-12 col-12"">
                                                    <p class=""col-lg-8 col-8"">
                                                        ");
#nullable restore
#line 114 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\Order\Index.cshtml"
                                                   Write(orderItem.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                                    </p>\r\n                                                    <span class=\"price col-lg-4 col-4\">\r\n                                                        ");
#nullable restore
#line 117 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\Order\Index.cshtml"
                                                   Write(orderItem.Price);

#line default
#line hidden
#nullable disable
                WriteLiteral(" $\r\n                                                    </span>\r\n                                                    <p class=\"col-lg-12 col-12\">\r\n                                                        Quantity: <span>");
#nullable restore
#line 120 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\Order\Index.cshtml"
                                                                   Write(orderItem.Count);

#line default
#line hidden
#nullable disable
                WriteLiteral(@" pcs.</span>
                                                    </p>
                                                </div>

                                                <div class=""bottombottom col-lg-12 col-12"">
                                                    <div class=""col-lg-6 col-6"">
                                                        <span class=""col-lg-4 col-4"">
                                                            Seria:
                                                        </span>
                                                        <span class=""col-lg-8 col-8"">");
#nullable restore
#line 129 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\Order\Index.cshtml"
                                                                                Write(orderItem.Product.Seria);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</span>
                                                    </div>
                                                    <div class=""col-lg-6 col-6"">
                                                        <span class=""col-lg-4 col-4"">
                                                            Size:
                                                        </span>
                                                        <span class=""col-lg-8 col-8"">M</span>
                                                    </div>
                                                    <div class=""col-lg-6 col-6"">
                                                        <span class=""col-lg-4 col-4"">
                                                            Color:
                                                        </span>
                                                        <span class=""col-lg-8 col-8"">Beige</span>
                                                    </div>
                                      ");
                WriteLiteral(@"              <div class=""col-lg-6 col-6"">
                                                        <span class=""col-lg-4 col-4"">
                                                            Total:
                                                        </span>
                                                        <span class=""col-lg-8 col-8"">29 €</span>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class=""col-lg-1 col-2"">
                                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "cb23a86c24031853d6ab48e353fc7e9988cbd91125749", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 4, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 9196, "~/assets/images/products/", 9196, 25, true);
#nullable restore
#line 152 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\Order\Index.cshtml"
AddHtmlAttributeValue("", 9221, orderItem.Product.Id, 9221, 21, false);

#line default
#line hidden
#nullable disable
                AddHtmlAttributeValue("", 9242, "/", 9242, 1, true);
#nullable restore
#line 152 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\Order\Index.cshtml"
AddHtmlAttributeValue("", 9243, orderItem.Product.ShopImage, 9243, 28, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                            </div>\r\n                                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 88 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\Order\Index.cshtml"
                                                                                              WriteLiteral(orderItem.ProductId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 155 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\Order\Index.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </div>\r\n                            </div>\r\n");
#nullable restore
#line 159 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\Order\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 159 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\Order\Index.cshtml"
                         
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        <div class=""noordersyet col-lg-12 col-12"">
                            <p class=""col-lg-10 col-10"">
                                You haven't got any order. Try to make one ;)
                            </p>
                        </div>
");
#nullable restore
#line 168 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Views\Order\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n            </div>\r\n        </div>\r\n    </section>\r\n</main>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<OrderListVM>> Html { get; private set; }
    }
}
#pragma warning restore 1591
