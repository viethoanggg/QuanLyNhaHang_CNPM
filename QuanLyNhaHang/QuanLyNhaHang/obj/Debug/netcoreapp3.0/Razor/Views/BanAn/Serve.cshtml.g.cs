#pragma checksum "C:\Users\del\Documents\GitHub\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\BanAn\Serve.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "58a5bd0603f27831870837eff2f7d6fbe5dd8a43"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_BanAn_Serve), @"mvc.1.0.view", @"/Views/BanAn/Serve.cshtml")]
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
#line 1 "C:\Users\del\Documents\GitHub\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\del\Documents\GitHub\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\_ViewImports.cshtml"
using ApplicationCore.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"58a5bd0603f27831870837eff2f7d6fbe5dd8a43", @"/Views/BanAn/Serve.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"81bdbf4ec029a514e8fa82b9cbdc4776e3a6a6d8", @"/Views/_ViewImports.cshtml")]
    public class Views_BanAn_Serve : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ApplicationCore.ModelsContainData.ViewModels.ServeVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("control-label"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.TextAreaTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_TextAreaTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\del\Documents\GitHub\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\BanAn\Serve.cshtml"
  
    ViewData["Title"] = "Phục vụ cho bàn ăn";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""row"">
    <!-- thông tin bàn ăn -->
    <div class=""col-md-5"" style = ""margin:10px 20px 10px 30px;box-shadow:2px 2px 5px grey"">
        <h3>Thông tin bàn ăn</h3>
        <hr />
               
                <div class=""form-group"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "58a5bd0603f27831870837eff2f7d6fbe5dd8a435611", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#nullable restore
#line 13 "C:\Users\del\Documents\GitHub\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\BanAn\Serve.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.BanAn.Id);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "58a5bd0603f27831870837eff2f7d6fbe5dd8a437173", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 14 "C:\Users\del\Documents\GitHub\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\BanAn\Serve.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.BanAn.Id);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("readonly", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("span", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "58a5bd0603f27831870837eff2f7d6fbe5dd8a439040", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper);
#nullable restore
#line 15 "C:\Users\del\Documents\GitHub\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\BanAn\Serve.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.BanAn.Id);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-for", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n               \r\n                <div class=\"form-group\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "58a5bd0603f27831870837eff2f7d6fbe5dd8a4310763", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#nullable restore
#line 19 "C:\Users\del\Documents\GitHub\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\BanAn\Serve.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.BanAn.LoaiBanAn);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "58a5bd0603f27831870837eff2f7d6fbe5dd8a4312333", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 20 "C:\Users\del\Documents\GitHub\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\BanAn\Serve.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.BanAn.LoaiBanAn);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("readonly", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("span", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "58a5bd0603f27831870837eff2f7d6fbe5dd8a4314208", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper);
#nullable restore
#line 21 "C:\Users\del\Documents\GitHub\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\BanAn\Serve.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.BanAn.LoaiBanAn);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-for", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n\r\n                <div class=\"form-group\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "58a5bd0603f27831870837eff2f7d6fbe5dd8a4315924", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#nullable restore
#line 25 "C:\Users\del\Documents\GitHub\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\BanAn\Serve.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.BanAn.TrangThai);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "58a5bd0603f27831870837eff2f7d6fbe5dd8a4317494", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 26 "C:\Users\del\Documents\GitHub\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\BanAn\Serve.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.BanAn.TrangThai);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("readonly", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("span", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "58a5bd0603f27831870837eff2f7d6fbe5dd8a4319369", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper);
#nullable restore
#line 27 "C:\Users\del\Documents\GitHub\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\BanAn\Serve.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.BanAn.TrangThai);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-for", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n\r\n                <div class=\"form-group\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "58a5bd0603f27831870837eff2f7d6fbe5dd8a4321085", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#nullable restore
#line 31 "C:\Users\del\Documents\GitHub\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\BanAn\Serve.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.BanAn.GhiChu);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("textarea", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "58a5bd0603f27831870837eff2f7d6fbe5dd8a4322652", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_TextAreaTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.TextAreaTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_TextAreaTagHelper);
#nullable restore
#line 32 "C:\Users\del\Documents\GitHub\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\BanAn\Serve.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_TextAreaTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.BanAn.GhiChu);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_TextAreaTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("span", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "58a5bd0603f27831870837eff2f7d6fbe5dd8a4324237", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper);
#nullable restore
#line 33 "C:\Users\del\Documents\GitHub\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\BanAn\Serve.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.BanAn.GhiChu);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-for", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                </div>
              
    </div>
    <!-- End thông tin bàn ăn -->

     <!-- thông tin hóa đơn của bàn ăn -->
    <div class=""col-md-6"" style = ""margin:10px 10px ;box-shadow:2px 2px 5px grey"">
        <h3>Hóa đơn</h3>
        <hr/>
");
#nullable restore
#line 43 "C:\Users\del\Documents\GitHub\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\BanAn\Serve.cshtml"
         if(Model.HoaDon.TrangThai=="Chưa thanh toán")
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 45 "C:\Users\del\Documents\GitHub\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\BanAn\Serve.cshtml"
       Write(Html.Partial("_BanAnPartialView/_HoaDonCreatedPartial.cshtml"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 45 "C:\Users\del\Documents\GitHub\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\BanAn\Serve.cshtml"
                                                                           
        }
        else
        {
             

#line default
#line hidden
#nullable disable
#nullable restore
#line 49 "C:\Users\del\Documents\GitHub\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\BanAn\Serve.cshtml"
        Write(Html.Partial("_BanAnPartialView/_CreateHoaDonPartial.cshtml"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 49 "C:\Users\del\Documents\GitHub\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\BanAn\Serve.cshtml"
                                                                           
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        \r\n    </div>\r\n     <!--End thông tin hóa đơn của bàn ăn -->\r\n</div>\r\n<!-- End thông tin hóa đơn và bàn ăn-->\r\n\r\n");
#nullable restore
#line 57 "C:\Users\del\Documents\GitHub\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\BanAn\Serve.cshtml"
 if(Model.HoaDon.TrangThai=="Chưa thanh toán")
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""row"">
        <div class=""col-md-12"" style = ""margin:10px 0px ;box-shadow:2px 2px 5px grey"">
            <hr/>
            <h4>Danh sách món ăn</h4>
            <hr/>

            <select id=""ChonLoaiMonAn"" onchange=""ChonLoaiMonAn()""> 
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "58a5bd0603f27831870837eff2f7d6fbe5dd8a4328199", async() => {
                WriteLiteral("All");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 67 "C:\Users\del\Documents\GitHub\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\BanAn\Serve.cshtml"
                 foreach( var item in Model.LoaiMonAns )
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "58a5bd0603f27831870837eff2f7d6fbe5dd8a4329667", async() => {
#nullable restore
#line 69 "C:\Users\del\Documents\GitHub\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\BanAn\Serve.cshtml"
                                        Write(item.Ten);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 69 "C:\Users\del\Documents\GitHub\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\BanAn\Serve.cshtml"
                       WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 70 "C:\Users\del\Documents\GitHub\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\BanAn\Serve.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </select>\r\n            <div id=\"c\">\r\n                ");
#nullable restore
#line 73 "C:\Users\del\Documents\GitHub\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\BanAn\Serve.cshtml"
           Write(Html.Partial("_BanAnPartialView/_ListMonAnPartial.cshtml"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n             <!-- end ajax -->\r\n        </div>\r\n        <hr/>\r\n    </div>\r\n");
            WriteLiteral("    <div class=\"row\">\r\n        <div class=\"col-md-12\" style = \"margin:5px 0px ;box-shadow:2px 2px 5px grey\">\r\n            <h3>Chi tiết bàn ăn</h3>\r\n            <div id=\"show_cthd\">\r\n                 ");
#nullable restore
#line 84 "C:\Users\del\Documents\GitHub\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\BanAn\Serve.cshtml"
            Write(Html.Partial("_BanAnPartialView/_CTHDPartial.cshtml"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n\r\n        </div>\r\n        <hr/>\r\n    </div>\r\n");
#nullable restore
#line 90 "C:\Users\del\Documents\GitHub\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\BanAn\Serve.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<script scr=""~/jquery.unobtrusive-ajax.js""></script>
<script>
     
        function ChonLoaiMonAn() {
            var xhttp = new XMLHttpRequest();
            var IdBanAn = document.getElementById(""idba"").value;
            var IdLoaiMonAn = document.getElementById(""ChonLoaiMonAn"").value;
            xhttp.onreadystatechange = function () {
                if (this.readyState == 4 && this.status == 200) {
                    document.getElementById(""c"").innerHTML = this.response;
                   
                    }
                };
            xhttp.open(""GET"", ""/BanAn/GetLoaiMonAn?IdBanAn="" + IdBanAn + ""&IdLoaiMonAn="" + IdLoaiMonAn, true);
            xhttp.send();
        }

        function ThemCTHD(IdMonAn,IdSoLuong) {
            var xhttp = new XMLHttpRequest();
            var SoLuong = document.getElementById(IdSoLuong).value;
            var IdHoaDon = document.getElementById(""idhd"").value;
            var IdBanAn = document.getElementById(""idba"").value;
            va");
            WriteLiteral(@"r IdLoaiMonAn = document.getElementById(""ChonLoaiMonAn"").value;
            xhttp.onreadystatechange = function () {
                if (this.readyState == 4 && this.status == 200) {
                    document.getElementById(""show_cthd"").innerHTML = this.response;
                    setTimeout( function(){
                         var s =document.getElementById(""laythanhtoan"").value;
                         document.getElementById(""thanhtien"").value=s;
                    }, 200);
                   
                
                }   
            };
            xhttp.open(""GET"", ""/BanAn/ThemCTHD?IdHoaDon="" + IdHoaDon +""&IdBanAn="" + IdBanAn + ""&IdLoaiMonAn="" + IdLoaiMonAn +""&IdMonAn="" + IdMonAn + ""&SoLuong="" + SoLuong, true);
            xhttp.send();

        }

        function TruSLTrongListMonAn(id)
        {
            var s=document.getElementById(id).value;
            var sl=Number(s);
            sl=sl-1;
            if(sl<1)
                sl=1;
            document.g");
            WriteLiteral(@"etElementById(id).value=sl;
        }
        function CongSLTrongListMonAn(id)
        {
            var s=document.getElementById(id).value;
            var sl=Number(s);
            sl=sl+1;
            if(sl>10)
                sl=10;
            document.getElementById(id).value=sl;
        }

        function TruSLTrongCTHD(id,IdHoaDon,IdMonAn)
        {
            var s=document.getElementById(id).value;        
            var sl=Number(s);
            sl=sl-1;
            if(sl<1)
                sl=1;
             var xhttp = new XMLHttpRequest();
            xhttp.onreadystatechange = function () {
                if (this.readyState == 4 && this.status == 200) {
                    document.getElementById(id).value=sl;  
                    document.getElementById(""laythanhtoan"").value=this.responseText;
                    document.getElementById(""thanhtien"").value=this.responseText;    
                }   
            };
            xhttp.open(""GET"", ""/BanAn/CapNhatS");
            WriteLiteral(@"oLuongCTHD?IdHoaDon="" + IdHoaDon  +""&IdMonAn="" + IdMonAn + ""&SoLuong="" + sl, true);
            xhttp.send();
                    
        }

        function CongSLTrongCTHD(id,IdHoaDon,IdMonAn)
        {
            var s=document.getElementById(id).value;
            var sl=Number(s);
            sl=sl+1;
            if(sl>10)
                sl=10;
             var xhttp = new XMLHttpRequest();
             xhttp.onreadystatechange = function () {
                if (this.readyState == 4 && this.status == 200) {
                    document.getElementById(id).value=sl;  
                    document.getElementById(""laythanhtoan"").value=this.responseText;
                    document.getElementById(""thanhtien"").value=this.responseText;    
                }   
            };
            xhttp.open(""GET"", ""/BanAn/CapNhatSoLuongCTHD?IdHoaDon="" + IdHoaDon  +""&IdMonAn="" + IdMonAn + ""&SoLuong="" + sl, true);
            xhttp.send();
        }

        function XoaCTHD(IdHoaDon,IdMonAn)
");
            WriteLiteral(@"        {
            var xhttp = new XMLHttpRequest();
            var IdHoaDon = document.getElementById(""idhd"").value;
            var IdBanAn = document.getElementById(""idba"").value;
            var IdLoaiMonAn = document.getElementById(""ChonLoaiMonAn"").value;
            xhttp.onreadystatechange = function () {
                if (this.readyState == 4 && this.status == 200) {
                    document.getElementById(""show_cthd"").innerHTML = this.response;
                    var s =document.getElementById(""laythanhtoan"").value;
                    document.getElementById(""thanhtien"").value=s;
                   
                }   
            };
            xhttp.open(""GET"", ""/BanAn/XoaCTHD?IdHoaDon="" + IdHoaDon +""&IdBanAn="" + IdBanAn + ""&IdLoaiMonAn="" + IdLoaiMonAn +""&IdMonAn="" + IdMonAn, true);
            xhttp.send();

        }

</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ApplicationCore.ModelsContainData.ViewModels.ServeVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
