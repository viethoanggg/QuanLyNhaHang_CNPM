#pragma checksum "D:\CNPM\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\BanAn\_CTHDPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "99a82eeb3a3dadebfa59c745c801d27051499957"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_BanAn__CTHDPartial), @"mvc.1.0.view", @"/Views/BanAn/_CTHDPartial.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"99a82eeb3a3dadebfa59c745c801d27051499957", @"/Views/BanAn/_CTHDPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e162fa2d12f7268917634a0a4f525942fa6c1109", @"/Views/_ViewImports.cshtml")]
    public class Views_BanAn__CTHDPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<QuanLyNhaHang.ViewModels.ServeVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "number", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\CNPM\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\BanAn\_CTHDPartial.cshtml"
  
    Layout=null;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            <table class=""table table-stripe"">
               <tr>
                    <th>Tên món ăn</th>
                    <th>Số lượng</th>
                    <th>Đơn giá</th>
                     <th>Sửa</th>
                </tr>
                
");
#nullable restore
#line 14 "D:\CNPM\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\BanAn\_CTHDPartial.cshtml"
                 foreach (var item in Model.ChiTietHoaDons)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
#nullable restore
#line 18 "D:\CNPM\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\BanAn\_CTHDPartial.cshtml"
                       Write(Html.DisplayFor(modelItem => item.TenMonAn));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                         <td>\r\n                           ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "99a82eeb3a3dadebfa59c745c801d270514999574442", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 21 "D:\CNPM\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\BanAn\_CTHDPartial.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => item.SoLuong);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 24 "D:\CNPM\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\BanAn\_CTHDPartial.cshtml"
                       Write(Html.DisplayFor(modelItem => item.DonGia));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                           chỉnh sửa ....\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 30 "D:\CNPM\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\BanAn\_CTHDPartial.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("               \r\n            </table>\r\n            <input type=\"hidden\" id=\"laythanhtoan\"");
            BeginWriteAttribute("value", " value=\"", 1083, "\"", 1114, 1);
#nullable restore
#line 33 "D:\CNPM\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\BanAn\_CTHDPartial.cshtml"
WriteAttributeValue("", 1091, Model.HoaDon.ThanhTien, 1091, 23, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("/>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<QuanLyNhaHang.ViewModels.ServeVM> Html { get; private set; }
    }
}
#pragma warning restore 1591