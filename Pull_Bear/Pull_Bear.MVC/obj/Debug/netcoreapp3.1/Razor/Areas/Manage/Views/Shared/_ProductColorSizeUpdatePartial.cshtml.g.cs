#pragma checksum "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\Shared\_ProductColorSizeUpdatePartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3f71b426883ff9311e5eeddbe6efa899b5edc7e0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Manage_Views_Shared__ProductColorSizeUpdatePartial), @"mvc.1.0.view", @"/Areas/Manage/Views/Shared/_ProductColorSizeUpdatePartial.cshtml")]
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
#line 2 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.CategoryVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.BodyFitVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.ColorVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.SizeVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.TagVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.SearchVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.ProductColorSizeVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.ProductToTagVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.ProductVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.ProductImageVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\_ViewImports.cshtml"
using Pull_Bear.Service.Enums;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3f71b426883ff9311e5eeddbe6efa899b5edc7e0", @"/Areas/Manage/Views/Shared/_ProductColorSizeUpdatePartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b91420a1a874c54e88c263f42a78b646fd37c400", @"/Areas/Manage/Views/_ViewImports.cshtml")]
    public class Areas_Manage_Views_Shared__ProductColorSizeUpdatePartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ProductColorSizeGetVM>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "newcolor", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control fortoggle col-lg-8"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("changecolor col-lg-2"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Manage", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Product", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "UpdateProductColorSize", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("position: absolute; top:10px; right:-30px; width: 30px;font-size:20px; text-decoration: none; color: black;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "newsize", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control col-lg-8 fortoggle"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("changesize col-lg-2"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("position: absolute; top: 10px; right: -30px; width: 30px; font-size: 20px; text-decoration: none; color: black;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_12 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("changecount col-lg-2"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_13 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString(" position: absolute; top: 10px; right: -30px; width: 30px; font-size: 20px; text-decoration: none; color: black;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_14 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DeleteColorSize", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_15 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("deletecolorsizedb"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_16 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("position: absolute; top:4px; right:-60px; width: 30px;font-size:20px; text-decoration: none; color: black;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\Shared\_ProductColorSizeUpdatePartial.cshtml"
  
    SelectList colors = new SelectList(ViewBag.Colors, nameof(ColorListVM.Id), nameof(ColorListVM.Name));
    SelectList sizes = new SelectList(ViewBag.Sizes, nameof(SizeListVM.Id), nameof(SizeListVM.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3f71b426883ff9311e5eeddbe6efa899b5edc7e012516", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper);
#nullable restore
#line 8 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\Shared\_ProductColorSizeUpdatePartial.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary = global::Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary.ModelOnly;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-summary", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 9 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\Shared\_ProductColorSizeUpdatePartial.cshtml"
 if (Model != null)
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\Shared\_ProductColorSizeUpdatePartial.cshtml"
     foreach (ProductColorSizeGetVM item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <div class=""col-lg-12 col-12 d-flex flex-wrap justify-content-between align-items-center"" style=""position: relative;"">
            <span class=""col-lg-3 col-3  text-center d-flex justify-content-between align-items-center position-relative"">

                <span class=""col-lg-12 flex-wrap togglespan "" style=""display: none;"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3f71b426883ff9311e5eeddbe6efa899b5edc7e014964", async() => {
                WriteLiteral("\r\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3f71b426883ff9311e5eeddbe6efa899b5edc7e015249", async() => {
                    WriteLiteral("Select Color");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Name = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
#nullable restore
#line 17 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\Shared\_ProductColorSizeUpdatePartial.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = colors;

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
            WriteLiteral("\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3f71b426883ff9311e5eeddbe6efa899b5edc7e017989", async() => {
                WriteLiteral("<ion-icon name=\"refresh-outline\"></ion-icon>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 20 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\Shared\_ProductColorSizeUpdatePartial.cshtml"
                                                                                                                                        Write(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("data-val", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                    <span class=""closetoggleinp"" style=""cursor: pointer; position: absolute; top: -10px; right: -30px; width: 30px; font-size: 20px; text-decoration: none; color: black;""><ion-icon name=""close-outline""></ion-icon></span>
                </span>

                <span");
            BeginWriteAttribute("style", " style=\"", 1533, "\"", 1541, 0);
            EndWriteAttribute();
            WriteLiteral(" class=\"col-lg-12 col-12 text-start p-1 fortogglespan\">\r\n                    Color:<span");
            BeginWriteAttribute("style", " style=\"", 1630, "\"", 1718, 8);
            WriteAttributeValue("", 1638, "text-align:end;", 1638, 15, true);
            WriteAttributeValue(" ", 1653, "font-size:", 1654, 11, true);
            WriteAttributeValue(" ", 1664, "16px;", 1665, 6, true);
            WriteAttributeValue(" ", 1670, "color:", 1671, 7, true);
#nullable restore
#line 25 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\Shared\_ProductColorSizeUpdatePartial.cshtml"
WriteAttributeValue(" ", 1677, item.Color.HexCode, 1678, 19, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1697, ";", 1697, 1, true);
            WriteAttributeValue(" ", 1698, "padding-left:", 1699, 14, true);
            WriteAttributeValue(" ", 1712, "20px;", 1713, 6, true);
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 25 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\Shared\_ProductColorSizeUpdatePartial.cshtml"
                                                                                                                    Write(item.Color.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                </span>
                <span class=""colorclick col-lg-2"" style=""position: absolute; top: 4px; right: -30px; width: 30px; font-size: 20px; text-decoration: none; color: black; cursor: pointer ""><ion-icon name=""create-outline""></ion-icon></span>
            </span>

            <span class=""col-lg-3 col-3  text-center d-flex justify-content-between align-items-center position-relative"">

                <span class=""col-lg-12 flex-wrap togglespan "" style=""display: none;"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3f71b426883ff9311e5eeddbe6efa899b5edc7e022773", async() => {
                WriteLiteral("\r\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3f71b426883ff9311e5eeddbe6efa899b5edc7e023058", async() => {
                    WriteLiteral("Select Size");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Name = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
#nullable restore
#line 33 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\Shared\_ProductColorSizeUpdatePartial.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = sizes;

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
            WriteLiteral("\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3f71b426883ff9311e5eeddbe6efa899b5edc7e025796", async() => {
                WriteLiteral("<ion-icon name=\"refresh-outline\"></ion-icon>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 36 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\Shared\_ProductColorSizeUpdatePartial.cshtml"
                                                                                                                                       Write(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("data-val", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_11);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                    <span class=""closetoggleinp"" style=""cursor: pointer; position: absolute; top: -10px; right: -30px; width: 30px; font-size: 20px; text-decoration: none; color: black;""><ion-icon name=""close-outline""></ion-icon></span>
                </span>

                <span");
            BeginWriteAttribute("style", " style=\"", 3048, "\"", 3056, 0);
            EndWriteAttribute();
            WriteLiteral(" class=\"col-lg-12 col-12 text-start fortogglespan p-1\">\r\n                    Size:<span style=\"text-align:end; font-size: 16px; color: red; padding-left: 20px;\">");
#nullable restore
#line 41 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\Shared\_ProductColorSizeUpdatePartial.cshtml"
                                                                                                   Write(item.Size.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                </span>
                <span class=""sizeclick col-lg-2"" style=""position: absolute; top: 4px; right: -30px; width: 30px; font-size: 20px; text-decoration: none; color: black; cursor: pointer ""><ion-icon name=""create-outline""></ion-icon></span>
            </span>

            <span class=""col-lg-3 col-3 text-center  d-flex justify-content-between align-items-center position-relative"">

                <span class=""col-lg-12 flex-wrap togglespan "" style=""display: none;"">
                    <input name=""newcount"" class=""fortoggle form-control col-lg-8"" placeholder=""Count"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3f71b426883ff9311e5eeddbe6efa899b5edc7e029833", async() => {
                WriteLiteral("<ion-icon name=\"refresh-outline\"></ion-icon>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_12);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 50 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\Shared\_ProductColorSizeUpdatePartial.cshtml"
                                                                                                                                        Write(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("data-val", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_13);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                    <span class=""closetoggleinp"" style=""cursor: pointer; position: absolute; top: -10px; right: -30px; width: 30px; font-size: 20px; text-decoration: none; color: black;""><ion-icon name=""close-outline""></ion-icon></span>
                </span>

                <span");
            BeginWriteAttribute("style", " style=\"", 4453, "\"", 4461, 0);
            EndWriteAttribute();
            WriteLiteral(" class=\"col-lg-12 col-12 text-start fortogglespan p-1\">\r\n                    Count:<span style=\"text-align:end; font-size: 16px; color: red; padding-left: 20px;\">");
#nullable restore
#line 55 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\Shared\_ProductColorSizeUpdatePartial.cshtml"
                                                                                                    Write(item.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                </span>
                <span class=""countclick col-lg-2"" style=""position: absolute; top:4px; right:-30px; width: 30px;font-size:20px; text-decoration: none; color: black; cursor:pointer""><ion-icon name=""create-outline""></ion-icon></span>
            </span>
            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3f71b426883ff9311e5eeddbe6efa899b5edc7e033524", async() => {
                WriteLiteral("<ion-icon name=\"trash-outline\"></ion-icon>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_14.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_14);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 59 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\Shared\_ProductColorSizeUpdatePartial.cshtml"
                                                                                         WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_15);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_16);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n");
#nullable restore
#line 61 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\Shared\_ProductColorSizeUpdatePartial.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 61 "C:\Users\hp\Desktop\Back_End\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\Shared\_ProductColorSizeUpdatePartial.cshtml"
     
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ProductColorSizeGetVM>> Html { get; private set; }
    }
}
#pragma warning restore 1591
