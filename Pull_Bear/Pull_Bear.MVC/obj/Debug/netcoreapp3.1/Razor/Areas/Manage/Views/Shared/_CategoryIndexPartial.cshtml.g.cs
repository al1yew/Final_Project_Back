#pragma checksum "D:\programming\Final Project\Back_End_kotoriy_ya_commitil\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\Shared\_CategoryIndexPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3179b49ab8d83e508806e0876b2e1c0a7338126b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Manage_Views_Shared__CategoryIndexPartial), @"mvc.1.0.view", @"/Areas/Manage/Views/Shared/_CategoryIndexPartial.cshtml")]
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
#line 2 "D:\programming\Final Project\Back_End_kotoriy_ya_commitil\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.CategoryVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\programming\Final Project\Back_End_kotoriy_ya_commitil\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.BodyFitVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\programming\Final Project\Back_End_kotoriy_ya_commitil\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.ColorVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\programming\Final Project\Back_End_kotoriy_ya_commitil\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.SizeVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\programming\Final Project\Back_End_kotoriy_ya_commitil\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.TagVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\programming\Final Project\Back_End_kotoriy_ya_commitil\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.SearchVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\programming\Final Project\Back_End_kotoriy_ya_commitil\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.ProductColorSizeVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\programming\Final Project\Back_End_kotoriy_ya_commitil\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.ProductToTagVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\programming\Final Project\Back_End_kotoriy_ya_commitil\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.ProductVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "D:\programming\Final Project\Back_End_kotoriy_ya_commitil\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.ProductImageVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "D:\programming\Final Project\Back_End_kotoriy_ya_commitil\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.AccountVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "D:\programming\Final Project\Back_End_kotoriy_ya_commitil\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.AppUserVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "D:\programming\Final Project\Back_End_kotoriy_ya_commitil\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.OrderItemVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "D:\programming\Final Project\Back_End_kotoriy_ya_commitil\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels.OrderVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "D:\programming\Final Project\Back_End_kotoriy_ya_commitil\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\_ViewImports.cshtml"
using Pull_Bear.Core.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "D:\programming\Final Project\Back_End_kotoriy_ya_commitil\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\_ViewImports.cshtml"
using Pull_Bear.Service.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "D:\programming\Final Project\Back_End_kotoriy_ya_commitil\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\_ViewImports.cshtml"
using Pull_Bear.Service.Enums;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3179b49ab8d83e508806e0876b2e1c0a7338126b", @"/Areas/Manage/Views/Shared/_CategoryIndexPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d062b668211512316e1353cd5adfc7ec7aba299", @"/Areas/Manage/Views/_ViewImports.cshtml")]
    public class Areas_Manage_Views_Shared__CategoryIndexPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PaginationList<CategoryListVM>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-fluid"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-warning"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Manage", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Category", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Update", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary restoreBtn"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Restore", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger deleteBtn"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "D:\programming\Final Project\Back_End_kotoriy_ya_commitil\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\Shared\_CategoryIndexPartial.cshtml"
  
    int no = Model.ItemsCount * (Model.Page - 1);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<table class=""table table-bordered table-striped tblContent"">
    <thead>
        <tr>
            <th class=""col-lg-1 col-1 text-wrap"">№</th>
            <th class=""col-lg-1 col-1 text-wrap"">Name</th>
            <th class=""col-lg-1 col-1 text-wrap"">Image</th>
            <th class=""col-lg-1 col-1 text-wrap"">Category Type</th>
            <th class=""col-lg-1 col-1 text-wrap"">Category's Parent</th>
            <th class=""col-lg-1 col-1 text-wrap"">Category's Children</th>
            <th class=""col-lg-1 col-1 text-wrap"">Gender</th>
            <th class=""col-lg-1 col-1 text-wrap"">Status</th>
            <th class=""col-lg-1 col-1 text-wrap"">Update</th>
            <th class=""col-lg-1 col-1 text-wrap"">Delete/Restore</th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 23 "D:\programming\Final Project\Back_End_kotoriy_ya_commitil\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\Shared\_CategoryIndexPartial.cshtml"
         foreach (CategoryListVM category in Model)
        {
            no++;

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td class=\"col-lg-1 col-1 text-wrap text-center p-1\">");
#nullable restore
#line 27 "D:\programming\Final Project\Back_End_kotoriy_ya_commitil\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\Shared\_CategoryIndexPartial.cshtml"
                                                                Write(no);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td class=\"col-lg-1 col-1 text-wrap text-center p-1\">");
#nullable restore
#line 28 "D:\programming\Final Project\Back_End_kotoriy_ya_commitil\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\Shared\_CategoryIndexPartial.cshtml"
                                                                Write(category.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td class=\"col-lg-2 col-2 text-center p-2\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3179b49ab8d83e508806e0876b2e1c0a7338126b12569", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1241, "~/assets/images/categories/", 1241, 27, true);
#nullable restore
#line 29 "D:\programming\Final Project\Back_End_kotoriy_ya_commitil\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\Shared\_CategoryIndexPartial.cshtml"
AddHtmlAttributeValue("", 1268, category.Image, 1268, 15, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</td>\r\n                <td class=\"col-lg-1 col-1 text-wrap\">");
#nullable restore
#line 30 "D:\programming\Final Project\Back_End_kotoriy_ya_commitil\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\Shared\_CategoryIndexPartial.cshtml"
                                                 Write(category.IsMain ? "Main Category"  :"Sub Category");

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td class=\"col-lg-1 col-1 text-wrap text-success\">\r\n");
#nullable restore
#line 32 "D:\programming\Final Project\Back_End_kotoriy_ya_commitil\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\Shared\_CategoryIndexPartial.cshtml"
                     if (category.ParentId != null && category.IsMain == false)
                    {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 34 "D:\programming\Final Project\Back_End_kotoriy_ya_commitil\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\Shared\_CategoryIndexPartial.cshtml"
                   Write(category.Parent.Name);

#line default
#line hidden
#nullable disable
#nullable restore
#line 34 "D:\programming\Final Project\Back_End_kotoriy_ya_commitil\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\Shared\_CategoryIndexPartial.cshtml"
                                             
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span class=\"text-danger\">Parent category</span>\r\n");
#nullable restore
#line 39 "D:\programming\Final Project\Back_End_kotoriy_ya_commitil\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\Shared\_CategoryIndexPartial.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\r\n                <td class=\"col-lg-1 col-1 text-wrap text-success\">\r\n");
#nullable restore
#line 42 "D:\programming\Final Project\Back_End_kotoriy_ya_commitil\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\Shared\_CategoryIndexPartial.cshtml"
                     if (category.IsMain && category.ParentId == null)
                    {
                        if (category.Children.Count > 0 && category.Children != null)
                        {
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 46 "D:\programming\Final Project\Back_End_kotoriy_ya_commitil\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\Shared\_CategoryIndexPartial.cshtml"
                             foreach (CategoryListVM categoryListVM in category.Children)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <span>\r\n                                    ");
#nullable restore
#line 49 "D:\programming\Final Project\Back_End_kotoriy_ya_commitil\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\Shared\_CategoryIndexPartial.cshtml"
                               Write(categoryListVM.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(",&nbsp;\r\n                                </span>\r\n");
#nullable restore
#line 51 "D:\programming\Final Project\Back_End_kotoriy_ya_commitil\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\Shared\_CategoryIndexPartial.cshtml"
                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 51 "D:\programming\Final Project\Back_End_kotoriy_ya_commitil\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\Shared\_CategoryIndexPartial.cshtml"
                             
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <span class=\"text-danger\">No Children</span>\r\n");
#nullable restore
#line 56 "D:\programming\Final Project\Back_End_kotoriy_ya_commitil\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\Shared\_CategoryIndexPartial.cshtml"
                        }
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\r\n                <td class=\"col-lg-1 col-1 text-wrap\">");
#nullable restore
#line 59 "D:\programming\Final Project\Back_End_kotoriy_ya_commitil\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\Shared\_CategoryIndexPartial.cshtml"
                                                Write(category.GenderName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td class=\"col-lg-1 col-1 text-wrap\"");
            BeginWriteAttribute("style", " style=\"", 2757, "\"", 2810, 2);
            WriteAttributeValue("", 2765, "color:", 2765, 6, true);
#nullable restore
#line 60 "D:\programming\Final Project\Back_End_kotoriy_ya_commitil\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\Shared\_CategoryIndexPartial.cshtml"
WriteAttributeValue("", 2771, category.IsDeleted ? "red" : "green", 2771, 39, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 60 "D:\programming\Final Project\Back_End_kotoriy_ya_commitil\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\Shared\_CategoryIndexPartial.cshtml"
                                                                                                       Write(category.IsDeleted ? "Deleted" : "Active");

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td class=\"col-lg-1 col-1 text-wrap\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3179b49ab8d83e508806e0876b2e1c0a7338126b19877", async() => {
                WriteLiteral("Update");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
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
#line 62 "D:\programming\Final Project\Back_End_kotoriy_ya_commitil\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\Shared\_CategoryIndexPartial.cshtml"
                                                                                                                 WriteLiteral(category.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </td>\r\n                <td class=\"col-lg-1 col-1 text-wrap\">\r\n");
#nullable restore
#line 65 "D:\programming\Final Project\Back_End_kotoriy_ya_commitil\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\Shared\_CategoryIndexPartial.cshtml"
                     if (category.IsDeleted)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3179b49ab8d83e508806e0876b2e1c0a7338126b23077", async() => {
                WriteLiteral("Restore");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
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
#line 68 "D:\programming\Final Project\Back_End_kotoriy_ya_commitil\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\Shared\_CategoryIndexPartial.cshtml"
                                                  WriteLiteral(category.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 68 "D:\programming\Final Project\Back_End_kotoriy_ya_commitil\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\Shared\_CategoryIndexPartial.cshtml"
                                                                                WriteLiteral(ViewBag.Type);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["type"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-type", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["type"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 68 "D:\programming\Final Project\Back_End_kotoriy_ya_commitil\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\Shared\_CategoryIndexPartial.cshtml"
                                                                                                                 WriteLiteral(ViewBag.Select);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["select"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-select", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["select"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 68 "D:\programming\Final Project\Back_End_kotoriy_ya_commitil\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\Shared\_CategoryIndexPartial.cshtml"
                                                                                                                                                    WriteLiteral(ViewBag.Status);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["status"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-status", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["status"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 68 "D:\programming\Final Project\Back_End_kotoriy_ya_commitil\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\Shared\_CategoryIndexPartial.cshtml"
                                                                                                                                                                                     WriteLiteral(ViewBag.Page);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-page", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 69 "D:\programming\Final Project\Back_End_kotoriy_ya_commitil\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\Shared\_CategoryIndexPartial.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3179b49ab8d83e508806e0876b2e1c0a7338126b29576", async() => {
                WriteLiteral("Delete");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 73 "D:\programming\Final Project\Back_End_kotoriy_ya_commitil\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\Shared\_CategoryIndexPartial.cshtml"
                                                 WriteLiteral(category.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 73 "D:\programming\Final Project\Back_End_kotoriy_ya_commitil\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\Shared\_CategoryIndexPartial.cshtml"
                                                                               WriteLiteral(ViewBag.Type);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["type"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-type", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["type"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 73 "D:\programming\Final Project\Back_End_kotoriy_ya_commitil\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\Shared\_CategoryIndexPartial.cshtml"
                                                                                                                WriteLiteral(ViewBag.Select);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["select"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-select", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["select"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 73 "D:\programming\Final Project\Back_End_kotoriy_ya_commitil\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\Shared\_CategoryIndexPartial.cshtml"
                                                                                                                                                   WriteLiteral(ViewBag.Status);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["status"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-status", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["status"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 73 "D:\programming\Final Project\Back_End_kotoriy_ya_commitil\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\Shared\_CategoryIndexPartial.cshtml"
                                                                                                                                                                                    WriteLiteral(ViewBag.Page);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-page", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 74 "D:\programming\Final Project\Back_End_kotoriy_ya_commitil\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\Shared\_CategoryIndexPartial.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\r\n            </tr>\r\n");
#nullable restore
#line 77 "D:\programming\Final Project\Back_End_kotoriy_ya_commitil\Pull_Bear\Pull_Bear.MVC\Areas\Manage\Views\Shared\_CategoryIndexPartial.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PaginationList<CategoryListVM>> Html { get; private set; }
    }
}
#pragma warning restore 1591
