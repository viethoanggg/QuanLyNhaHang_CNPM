#pragma checksum "D:\CNPM\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\ThucDon\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c2b392d8221d8160f58e5811f3de230af13e3b96"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ThucDon_Delete), @"mvc.1.0.view", @"/Views/ThucDon/Delete.cshtml")]
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
#line 2 "D:\CNPM\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\_ViewImports.cshtml"
using ApplicationCore.Entitites;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c2b392d8221d8160f58e5811f3de230af13e3b96", @"/Views/ThucDon/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e162fa2d12f7268917634a0a4f525942fa6c1109", @"/Views/_ViewImports.cshtml")]
    public class Views_ThucDon_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ApplicationCore.Entitites.ThucDon>
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\CNPM\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\ThucDon\Delete.cshtml"
  
    ViewBag.Title = "Delete";

#line default
#line hidden
#nullable disable
            WriteLiteral("<!DOCTYPE html>\r\n\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c2b392d8221d8160f58e5811f3de230af13e3b963348", async() => {
                WriteLiteral("\r\n    <meta name=\"viewport\" content=\"width=device-width\" />\r\n    <title>Index</title>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c2b392d8221d8160f58e5811f3de230af13e3b964407", async() => {
                WriteLiteral(@"
    <div class=""row"">
        <div class=""col-lg-12"">
            <h1 class=""page-header"">Delete thực đơn </h1>
        </div>
        <!-- /.col-lg-12 -->
    </div>

    <h3>Are you sure you want to delete this?</h3>
    <div>
       
        <dl class=""dl-horizontal"">
            <dt>
                ");
#nullable restore
#line 26 "D:\CNPM\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\ThucDon\Delete.cshtml"
           Write(Html.DisplayNameFor(model => model.IdLoaiMonAn));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </dt>\r\n\r\n            <dd>\r\n                ");
#nullable restore
#line 30 "D:\CNPM\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\ThucDon\Delete.cshtml"
           Write(Html.DisplayFor(model => model.IdLoaiMonAn));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </dd>\r\n\r\n            <dt>\r\n                ");
#nullable restore
#line 34 "D:\CNPM\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\ThucDon\Delete.cshtml"
           Write(Html.DisplayNameFor(model => model.Ten));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </dt>\r\n\r\n            <dd>\r\n                ");
#nullable restore
#line 38 "D:\CNPM\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\ThucDon\Delete.cshtml"
           Write(Html.DisplayFor(model => model.Ten));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </dd>\r\n\r\n            <dt>\r\n                ");
#nullable restore
#line 42 "D:\CNPM\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\ThucDon\Delete.cshtml"
           Write(Html.DisplayNameFor(model => model.Gia));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </dt>\r\n\r\n            <dd>\r\n                ");
#nullable restore
#line 46 "D:\CNPM\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\ThucDon\Delete.cshtml"
           Write(Html.DisplayFor(model => model.Gia));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </dd>\r\n\r\n        </dl>\r\n\r\n");
#nullable restore
#line 51 "D:\CNPM\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\ThucDon\Delete.cshtml"
         using (Html.BeginForm())
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 53 "D:\CNPM\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\ThucDon\Delete.cshtml"
       Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
                WriteLiteral("            <div class=\"form-actions no-color\">\r\n                <input type=\"submit\" value=\"Delete\" class=\"btn btn-default\" /> |\r\n                ");
#nullable restore
#line 57 "D:\CNPM\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\ThucDon\Delete.cshtml"
           Write(Html.ActionLink("Back to List", "Index"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </div>\r\n");
#nullable restore
#line 59 "D:\CNPM\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\ThucDon\Delete.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral("    </div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ApplicationCore.Entitites.ThucDon> Html { get; private set; }
    }
}
#pragma warning restore 1591
