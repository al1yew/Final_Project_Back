#pragma checksum "C:\Users\ASUS\Desktop\Final_Project_Back\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\Order\Update.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "239643c2ba83a619a799f878caf89d23ac732b681a5f8ae29fe0b8df955e2b9e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Manage_Views_Order_Update), @"mvc.1.0.view", @"/Areas/Manage/Views/Order/Update.cshtml")]
namespace AspNetCore
{
    #line hidden
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 2 "C:\Users\ASUS\Desktop\Final_Project_Back\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.CategoryVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\ASUS\Desktop\Final_Project_Back\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.BodyFitVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\ASUS\Desktop\Final_Project_Back\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.ColorVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\ASUS\Desktop\Final_Project_Back\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.SizeVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\ASUS\Desktop\Final_Project_Back\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.TagVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\ASUS\Desktop\Final_Project_Back\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.SearchVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\ASUS\Desktop\Final_Project_Back\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.ProductColorSizeVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\ASUS\Desktop\Final_Project_Back\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.ProductToTagVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\ASUS\Desktop\Final_Project_Back\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.ProductVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\ASUS\Desktop\Final_Project_Back\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.ProductImageVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\ASUS\Desktop\Final_Project_Back\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.AccountVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\ASUS\Desktop\Final_Project_Back\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.AppUserVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\ASUS\Desktop\Final_Project_Back\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.OrderItemVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Users\ASUS\Desktop\Final_Project_Back\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.OrderVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\Users\ASUS\Desktop\Final_Project_Back\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\_ViewImports.cshtml"
using Pull_Bear.Core.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "C:\Users\ASUS\Desktop\Final_Project_Back\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "C:\Users\ASUS\Desktop\Final_Project_Back\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\_ViewImports.cshtml"
using Pull_Bear.Service.Enums;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"239643c2ba83a619a799f878caf89d23ac732b681a5f8ae29fe0b8df955e2b9e", @"/Areas/Manage/Views/Order/Update.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"fbf641e5344a6558ab9efb8899ecf63eda56f9ece787d2598827d6b1cbcf66aa", @"/Areas/Manage/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_Manage_Views_Order_Update : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<OrderListVM>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "orderstatus", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("orderstatus"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "manage", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "order", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "update", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\ASUS\Desktop\Final_Project_Back\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\Order\Update.cshtml"
  
    int no = 0;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"row justify-content-center\">\r\n    <div class=\"col-lg-10 \">\r\n        <div class=\"card\">\r\n            <div class=\"card-body\">\r\n                <h5 class=\"card-title\">FUllName ");
#nullable restore
#line 10 "C:\Users\ASUS\Desktop\Final_Project_Back\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\Order\Update.cshtml"
                                           Write(Model.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                <p class=\"card-text\">");
#nullable restore
#line 11 "C:\Users\ASUS\Desktop\Final_Project_Back\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\Order\Update.cshtml"
                                Write(Model.OrderStatus);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <p class=\"card-text\">");
#nullable restore
#line 12 "C:\Users\ASUS\Desktop\Final_Project_Back\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\Order\Update.cshtml"
                                Write(Model.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <p class=\"card-text\">");
#nullable restore
#line 13 "C:\Users\ASUS\Desktop\Final_Project_Back\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\Order\Update.cshtml"
                                Write(Model.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <p class=\"card-text\">");
#nullable restore
#line 14 "C:\Users\ASUS\Desktop\Final_Project_Back\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\Order\Update.cshtml"
                                Write(Model.CityCountry);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <p class=\"card-text\">");
#nullable restore
#line 15 "C:\Users\ASUS\Desktop\Final_Project_Back\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\Order\Update.cshtml"
                                Write(Model.ZipCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <p class=\"card-text\">");
#nullable restore
#line 16 "C:\Users\ASUS\Desktop\Final_Project_Back\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\Order\Update.cshtml"
                                Write(Model.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <p class=\"card-text\">");
#nullable restore
#line 17 "C:\Users\ASUS\Desktop\Final_Project_Back\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\Order\Update.cshtml"
                                Write(Model.CreatedAt.ToString("dd-MM-yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
            </div>
            <div>
                <table class=""table table-bordered table-active table-striped"">
                    <thead>
                        <tr>
                            <th>№</th>
                            <th>Price</th>
                            <th>Count</th>
                            <th>Name</th>
                            <th>Size</th>
                            <th>Color</th>
                            <th>Tr. No</th>
                        </tr>
                    </thead>
                    <tbody>
");
#nullable restore
#line 33 "C:\Users\ASUS\Desktop\Final_Project_Back\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\Order\Update.cshtml"
                         foreach (var item in Model.OrderItems)
                        {
                            no++;

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td");
            BeginWriteAttribute("class", " class=\"", 1455, "\"", 1463, 0);
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 37 "C:\Users\ASUS\Desktop\Final_Project_Back\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\Order\Update.cshtml"
                                        Write(no);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td class=\" text-wrap\">");
#nullable restore
#line 38 "C:\Users\ASUS\Desktop\Final_Project_Back\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\Order\Update.cshtml"
                                                  Write(item.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td class=\" text-wrap\">");
#nullable restore
#line 39 "C:\Users\ASUS\Desktop\Final_Project_Back\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\Order\Update.cshtml"
                                                  Write(item.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td class=\" text-wrap\">");
#nullable restore
#line 40 "C:\Users\ASUS\Desktop\Final_Project_Back\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\Order\Update.cshtml"
                                                  Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td class=\" text-wrap\">");
#nullable restore
#line 41 "C:\Users\ASUS\Desktop\Final_Project_Back\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\Order\Update.cshtml"
                                                  Write(item.Product.ProductColorSizes.Select(x => x.Size).FirstOrDefault(x => x.Id == item.SizeId).Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td class=\" text-wrap\">");
#nullable restore
#line 42 "C:\Users\ASUS\Desktop\Final_Project_Back\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\Order\Update.cshtml"
                                                  Write(item.Product.ProductColorSizes.Select(x => x.Color).FirstOrDefault(x => x.Id == item.ColorId).Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td class=\" text-wrap\">");
#nullable restore
#line 43 "C:\Users\ASUS\Desktop\Final_Project_Back\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\Order\Update.cshtml"
                                                  Write(item.TrackingNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            </tr>\r\n");
#nullable restore
#line 45 "C:\Users\ASUS\Desktop\Final_Project_Back\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\Order\Update.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tbody>\r\n                </table>\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <div class=\"col-lg-10\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "239643c2ba83a619a799f878caf89d23ac732b681a5f8ae29fe0b8df955e2b9e16473", async() => {
                WriteLiteral("\r\n            <div class=\"mb-3\">\r\n                <input name=\"id\" type=\"hidden\"");
                BeginWriteAttribute("value", " value=\"", 2459, "\"", 2476, 1);
#nullable restore
#line 54 "C:\Users\ASUS\Desktop\Final_Project_Back\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\Order\Update.cshtml"
WriteAttributeValue("", 2467, Model.Id, 2467, 9, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"form-control\">\r\n            </div>\r\n            <div class=\"form-group\">\r\n                <label for=\"orderstatus\">Order Status</label>\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "239643c2ba83a619a799f878caf89d23ac732b681a5f8ae29fe0b8df955e2b9e17414", async() => {
                    WriteLiteral("\r\n                ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Name = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
#nullable restore
#line 58 "C:\Users\ASUS\Desktop\Final_Project_Back\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\Order\Update.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = new SelectList(Enum.GetValues(typeof(OrderStatus)), Model.OrderStatus);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n            </div>\r\n            <button type=\"submit\" class=\"btn btn-primary\">Update</button>\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Area = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
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
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<OrderListVM> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
