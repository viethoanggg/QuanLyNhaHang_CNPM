#pragma checksum "C:\Users\del\Documents\GitHub\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\BanAn\_BanAnPartialView\_TDPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f05e28e76158fb5f8740c501b002eb8b3aa62cff"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_BanAn__BanAnPartialView__TDPartial), @"mvc.1.0.view", @"/Views/BanAn/_BanAnPartialView/_TDPartial.cshtml")]
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
#line 2 "C:\Users\del\Documents\GitHub\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\_ViewImports.cshtml"
using ApplicationCore.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f05e28e76158fb5f8740c501b002eb8b3aa62cff", @"/Views/BanAn/_BanAnPartialView/_TDPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"19407a6133d8e7e9a734ab30dc1ee5aa4e76712e", @"/Views/_ViewImports.cshtml")]
    public class Views_BanAn__BanAnPartialView__TDPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ApplicationCore.ModelsContainData.ViewModels.ServeVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Serve", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("page-link"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-route-IdLoaiMonAn", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 2 "C:\Users\del\Documents\GitHub\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\BanAn\_BanAnPartialView\_TDPartial.cshtml"
  
    Layout=null;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            <table class=""table table-stripe"">
                <tr>
                    <th>
                        Tên thức ăn
                    </th>
                    <th>
                       Giá
                    </th>
                    <th>
                        Số lượng
                    </th>
                    <th></th>
                </tr>
                
");
#nullable restore
#line 20 "C:\Users\del\Documents\GitHub\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\BanAn\_BanAnPartialView\_TDPartial.cshtml"
                 foreach (var item in Model.ThucDons)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr");
            BeginWriteAttribute("id", " id=\"", 586, "\"", 603, 2);
            WriteAttributeValue("", 591, "row_", 591, 4, true);
#nullable restore
#line 22 "C:\Users\del\Documents\GitHub\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\BanAn\_BanAnPartialView\_TDPartial.cshtml"
WriteAttributeValue("", 595, item.Id, 595, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                        <td>\r\n                            ");
#nullable restore
#line 24 "C:\Users\del\Documents\GitHub\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\BanAn\_BanAnPartialView\_TDPartial.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Ten));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 27 "C:\Users\del\Documents\GitHub\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\BanAn\_BanAnPartialView\_TDPartial.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Gia));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                         <td>\r\n                           <input name=\"SoLuong\" value=\"1\" type=\"number\"");
            BeginWriteAttribute("id", " id=\"", 970, "\"", 986, 2);
            WriteAttributeValue("", 975, "TD_", 975, 3, true);
#nullable restore
#line 30 "C:\Users\del\Documents\GitHub\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\BanAn\_BanAnPartialView\_TDPartial.cshtml"
WriteAttributeValue("", 978, item.Id, 978, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("/>\r\n                        </td>\r\n                        <td>\r\n                           <input type=\"button\" value=\"Thêm\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1112, "\"", 1175, 7);
            WriteAttributeValue("", 1122, "ThemCTHD(\'", 1122, 10, true);
#nullable restore
#line 33 "C:\Users\del\Documents\GitHub\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\BanAn\_BanAnPartialView\_TDPartial.cshtml"
WriteAttributeValue("", 1132, Model.HoaDon.Id, 1132, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1148, "\',\'", 1148, 3, true);
#nullable restore
#line 33 "C:\Users\del\Documents\GitHub\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\BanAn\_BanAnPartialView\_TDPartial.cshtml"
WriteAttributeValue("", 1151, item.Id, 1151, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1159, "\',\'TD_", 1159, 6, true);
#nullable restore
#line 33 "C:\Users\del\Documents\GitHub\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\BanAn\_BanAnPartialView\_TDPartial.cshtml"
WriteAttributeValue("", 1165, item.Id, 1165, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1173, "\')", 1173, 2, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 36 "C:\Users\del\Documents\GitHub\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\BanAn\_BanAnPartialView\_TDPartial.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("               \r\n            </table>\r\n");
#nullable restore
#line 39 "C:\Users\del\Documents\GitHub\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\BanAn\_BanAnPartialView\_TDPartial.cshtml"
               
                    var disNext= !Model.ThucDons.HasNext ? " visibility: hidden" : "";   
                    var disPre= !Model.ThucDons.HasPrevious ? " visibility: hidden" : "";   
                

#line default
#line hidden
#nullable disable
            WriteLiteral("             <span style=\"float:right\"> \r\n                <ul class=\"pagination\">\r\n                    <li class=\"page-item\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f05e28e76158fb5f8740c501b002eb8b3aa62cff9207", async() => {
                WriteLiteral(" Previous ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "style", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 46 "C:\Users\del\Documents\GitHub\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\BanAn\_BanAnPartialView\_TDPartial.cshtml"
AddHtmlAttributeValue("", 1715, disPre, 1715, 7, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-pageIndex", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 47 "C:\Users\del\Documents\GitHub\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\BanAn\_BanAnPartialView\_TDPartial.cshtml"
                                  WriteLiteral( Model.ThucDons.PageIndex - 1 );

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["pageIndex"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-pageIndex", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["pageIndex"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-IdLoaiMonAn", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["IdLoaiMonAn"] = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 49 "C:\Users\del\Documents\GitHub\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\BanAn\_BanAnPartialView\_TDPartial.cshtml"
                               WriteLiteral(Model.BanAn.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["IdBanAn"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-IdBanAn", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["IdBanAn"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </li>\r\n                    \r\n");
#nullable restore
#line 52 "C:\Users\del\Documents\GitHub\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\BanAn\_BanAnPartialView\_TDPartial.cshtml"
                  
                
                    for(int i=1; i <= Model.ThucDons.TotalPages; i++)
                    {
                        //Nếu số tổng số trang >=8 thì sẽ hiện ... và sẽ hiện trang : i-2 , i-1 , i , i+1 ,i+2
                        if(Model.ThucDons.TotalPages>=8 && @i>=Model.ThucDons.PageIndex-2 && @i<=Model.ThucDons.PageIndex+2)
                        {
                            if(@i==Model.ThucDons.PageIndex-2 && @i>1)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <li class=\"page-item\"><a class=\"page-link\">...</a></li>\r\n");
#nullable restore
#line 62 "C:\Users\del\Documents\GitHub\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\BanAn\_BanAnPartialView\_TDPartial.cshtml"
                            }
                            if(@i==Model.ThucDons.PageIndex)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <li class=\"page-item\">\r\n                                    <a class=\"page-link\" style=\"background-color:lightblue\"> ");
#nullable restore
#line 66 "C:\Users\del\Documents\GitHub\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\BanAn\_BanAnPartialView\_TDPartial.cshtml"
                                                                                        Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </a>\r\n                                </li>   \r\n");
#nullable restore
#line 68 "C:\Users\del\Documents\GitHub\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\BanAn\_BanAnPartialView\_TDPartial.cshtml"
                            }
                            else 
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <li class=\"page-item\">\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f05e28e76158fb5f8740c501b002eb8b3aa62cff15540", async() => {
                WriteLiteral(" ");
#nullable restore
#line 76 "C:\Users\del\Documents\GitHub\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\BanAn\_BanAnPartialView\_TDPartial.cshtml"
                                                                    Write(i);

#line default
#line hidden
#nullable disable
                WriteLiteral(" ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-pageIndex", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 74 "C:\Users\del\Documents\GitHub\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\BanAn\_BanAnPartialView\_TDPartial.cshtml"
                                             WriteLiteral(i);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["pageIndex"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-pageIndex", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["pageIndex"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-IdLoaiMonAn", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["IdLoaiMonAn"] = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 76 "C:\Users\del\Documents\GitHub\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\BanAn\_BanAnPartialView\_TDPartial.cshtml"
                                           WriteLiteral(Model.BanAn.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["IdBanAn"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-IdBanAn", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["IdBanAn"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                </li>\r\n");
#nullable restore
#line 78 "C:\Users\del\Documents\GitHub\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\BanAn\_BanAnPartialView\_TDPartial.cshtml"
                            }
                            if(@i==Model.ThucDons.PageIndex+2 && @i<Model.ThucDons.TotalPages)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <li class=\"page-item\"><a class=\"page-link\">...</a></li>\r\n");
#nullable restore
#line 82 "C:\Users\del\Documents\GitHub\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\BanAn\_BanAnPartialView\_TDPartial.cshtml"
                            }
                        }
                        else if( Model.ThucDons.TotalPages < 8 ) //Nếu số tổng số trang <8 thì sẽ hiện hết các trang
                        {
                            if(@i==Model.ThucDons.PageIndex)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <li class=\"page-item\">\r\n                                    <a class=\"page-link\" style=\"background-color:lightblue\"> ");
#nullable restore
#line 89 "C:\Users\del\Documents\GitHub\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\BanAn\_BanAnPartialView\_TDPartial.cshtml"
                                                                                        Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </a>\r\n                                </li>   \r\n");
#nullable restore
#line 91 "C:\Users\del\Documents\GitHub\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\BanAn\_BanAnPartialView\_TDPartial.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <li class=\"page-item\">\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f05e28e76158fb5f8740c501b002eb8b3aa62cff21497", async() => {
                WriteLiteral(" ");
#nullable restore
#line 99 "C:\Users\del\Documents\GitHub\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\BanAn\_BanAnPartialView\_TDPartial.cshtml"
                                                                    Write(i);

#line default
#line hidden
#nullable disable
                WriteLiteral(" ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-pageIndex", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 97 "C:\Users\del\Documents\GitHub\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\BanAn\_BanAnPartialView\_TDPartial.cshtml"
                                             WriteLiteral(i);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["pageIndex"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-pageIndex", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["pageIndex"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-IdLoaiMonAn", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["IdLoaiMonAn"] = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 99 "C:\Users\del\Documents\GitHub\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\BanAn\_BanAnPartialView\_TDPartial.cshtml"
                                           WriteLiteral(Model.BanAn.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["IdBanAn"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-IdBanAn", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["IdBanAn"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                </li>\r\n");
#nullable restore
#line 101 "C:\Users\del\Documents\GitHub\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\BanAn\_BanAnPartialView\_TDPartial.cshtml"
                            }
                        }
                    
                    
                    }
                
                

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <li class=\"page-item\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f05e28e76158fb5f8740c501b002eb8b3aa62cff25931", async() => {
                WriteLiteral(" Next ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "style", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 110 "C:\Users\del\Documents\GitHub\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\BanAn\_BanAnPartialView\_TDPartial.cshtml"
AddHtmlAttributeValue("", 4940, disNext, 4940, 8, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-pageIndex", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 111 "C:\Users\del\Documents\GitHub\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\BanAn\_BanAnPartialView\_TDPartial.cshtml"
                                  WriteLiteral( Model.ThucDons.PageIndex + 1 );

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["pageIndex"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-pageIndex", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["pageIndex"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-IdLoaiMonAn", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["IdLoaiMonAn"] = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 113 "C:\Users\del\Documents\GitHub\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\BanAn\_BanAnPartialView\_TDPartial.cshtml"
                               WriteLiteral(Model.BanAn.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["IdBanAn"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-IdBanAn", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["IdBanAn"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </li>\r\n                </ul>\r\n            </span>\r\n\r\n");
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
