#pragma checksum "D:\CNPM\QuanLyNhaHang_CNPM\Source\QuanLyNhaHang\Views\NguoiDung\Profile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8f9ef669476e2ce7d2f9cd763829a50c47e3cd62"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_NguoiDung_Profile), @"mvc.1.0.view", @"/Views/NguoiDung/Profile.cshtml")]
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
#line 1 "D:\CNPM\QuanLyNhaHang_CNPM\Source\QuanLyNhaHang\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\CNPM\QuanLyNhaHang_CNPM\Source\QuanLyNhaHang\Views\_ViewImports.cshtml"
using ApplicationCore.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8f9ef669476e2ce7d2f9cd763829a50c47e3cd62", @"/Views/NguoiDung/Profile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"81bdbf4ec029a514e8fa82b9cbdc4776e3a6a6d8", @"/Views/_ViewImports.cshtml")]
    public class Views_NguoiDung_Profile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<QuanLyNhaHang.ViewModels.UserProfileVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-responsive avatar-view"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width:100%;height:100%"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Images/picture.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Avatar"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Avatar"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "SuaThongTinCaNhan", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "NguoiDung", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onsubmit", new global::Microsoft.AspNetCore.Html.HtmlString("SuaTen()"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\CNPM\QuanLyNhaHang_CNPM\Source\QuanLyNhaHang\Views\NguoiDung\Profile.cshtml"
  
    ViewData["Title"] = "Quản lý hồ sơ cá nhân";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""row"">
    <div class=""col-md-12 col-sm-12 "">
        <div class=""x_panel"">
            <div class=""x_title"">
                <h2>Hồ sơ cá nhân</h2>
                <div class=""clearfix""></div>
            </div>
            <div class=""x_content"">
                <div class=""col-md-3 col-sm-3  profile_left"">
                    <div class=""profile_img"">
                        <div id=""crop-avatar"">
                          <!-- Current avatar -->
                          ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "8f9ef669476e2ce7d2f9cd763829a50c47e3cd627249", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
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
                </div>

                <div class=""col-md-9 col-sm-9 "">
                    <div class=""profile_title"">
                        <div class=""col-md-12"">
                          <h2>Thông tin người dùng</h2>
                        </div>
                    </div>

                    <div class=""col-md-11"" style=""margin-left:10px"">
                            <dl class=""row"">
                                <dt class = ""col-sm-2"">
                                    ");
#nullable restore
#line 34 "D:\CNPM\QuanLyNhaHang_CNPM\Source\QuanLyNhaHang\Views\NguoiDung\Profile.cshtml"
                               Write(Html.DisplayNameFor(model => model.NguoiDungDTO.Ten));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </dt>\r\n                                <dd class = \"col-sm-10\">\r\n                                    ");
#nullable restore
#line 37 "D:\CNPM\QuanLyNhaHang_CNPM\Source\QuanLyNhaHang\Views\NguoiDung\Profile.cshtml"
                               Write(Html.DisplayFor(model => model.NguoiDungDTO.Ten));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </dd>\r\n                                <dt class = \"col-sm-2\">\r\n                                    ");
#nullable restore
#line 40 "D:\CNPM\QuanLyNhaHang_CNPM\Source\QuanLyNhaHang\Views\NguoiDung\Profile.cshtml"
                               Write(Html.DisplayNameFor(model => model.NguoiDungDTO.TenDangNhap));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </dt>\r\n                                <dd class = \"col-sm-10\">\r\n                                    ");
#nullable restore
#line 43 "D:\CNPM\QuanLyNhaHang_CNPM\Source\QuanLyNhaHang\Views\NguoiDung\Profile.cshtml"
                               Write(Html.DisplayFor(model => model.NguoiDungDTO.TenDangNhap));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </dd>\r\n                                <dt class = \"col-sm-2\">\r\n                                    ");
#nullable restore
#line 46 "D:\CNPM\QuanLyNhaHang_CNPM\Source\QuanLyNhaHang\Views\NguoiDung\Profile.cshtml"
                               Write(Html.DisplayNameFor(model => model.NguoiDungDTO.Role));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </dt>\r\n                                <dd class = \"col-sm-10\">\r\n                                    ");
#nullable restore
#line 49 "D:\CNPM\QuanLyNhaHang_CNPM\Source\QuanLyNhaHang\Views\NguoiDung\Profile.cshtml"
                               Write(Html.DisplayFor(model => model.NguoiDungDTO.Role));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                </dd>
                            </dl>
                            <div>
                                <button type=""button"" class=""btn btn-info btn-sm"" data-toggle=""modal"" data-target=""#SuaThongTinCaNhanModal"">Sửa thông tin cá nhân</button>
                                <button type=""button"" class=""btn btn-info btn-sm"" data-toggle=""modal"" data-target=""#DoiMatKhauModal"">Đổi mật khẩu</button>
                                <div>
                                   
                                </div>
                            </div>
                    </div>
                    
                    <div class=""clearfix""></div>
                </div>

                <div class=""col-md-12"">
                    <div class=""col-md-12"" style=""margin-top:10px"">
                        <div class=""profile_title"">
                            <div class=""col-md-12"">
                                <h2>Hoạt động gần đây  <small>  Danh sách bàn ăn đã phục vụ");
            WriteLiteral(@"</small></h2>
                            </div>
                        </div>
                        <div class=""col-md-12"">
                            <table class=""table table-striped jambo_table no-margin"">
                                <thead>
                                    <tr>
                                        <th>Bàn ăn</th>
                                        <th>Thời gian lập</th>
                                        <th>Thời gian thanh toán</th>
                                        <th>Thành tiền</th>
                                    </tr>
                                </thead>
                                <tbody>
");
#nullable restore
#line 82 "D:\CNPM\QuanLyNhaHang_CNPM\Source\QuanLyNhaHang\Views\NguoiDung\Profile.cshtml"
                                     foreach ( var item in Model.ListHD )
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <tr>\r\n                                            <td> ");
#nullable restore
#line 85 "D:\CNPM\QuanLyNhaHang_CNPM\Source\QuanLyNhaHang\Views\NguoiDung\Profile.cshtml"
                                            Write(item.IdBanAn);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td> \r\n                                            <td> ");
#nullable restore
#line 86 "D:\CNPM\QuanLyNhaHang_CNPM\Source\QuanLyNhaHang\Views\NguoiDung\Profile.cshtml"
                                            Write(item.ThoiGianLap);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td> \r\n                                            <td> ");
#nullable restore
#line 87 "D:\CNPM\QuanLyNhaHang_CNPM\Source\QuanLyNhaHang\Views\NguoiDung\Profile.cshtml"
                                            Write(item.ThoiGianThanhToan);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td> \r\n                                            <td> ");
#nullable restore
#line 88 "D:\CNPM\QuanLyNhaHang_CNPM\Source\QuanLyNhaHang\Views\NguoiDung\Profile.cshtml"
                                            Write(item.ThanhTien);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td> \r\n                                        </tr>\r\n");
#nullable restore
#line 90 "D:\CNPM\QuanLyNhaHang_CNPM\Source\QuanLyNhaHang\Views\NguoiDung\Profile.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                        
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>



<!-- The Modal -->
  <div class=""modal fade"" id=""SuaThongTinCaNhanModal"">
    <div class=""modal-dialog modal-dialog-centered"">
      <div class=""modal-content"">
      
        <!-- Modal Header -->
        <div class=""modal-header"">
          <h4 class=""modal-title"">Sửa thông tin cá nhân</h4>
          <button type=""button"" class=""close"" data-dismiss=""modal"">&times;</button>
        </div>
        
        <!-- Modal body -->
        <div class=""modal-body"">
            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8f9ef669476e2ce7d2f9cd763829a50c47e3cd6216069", async() => {
                WriteLiteral("\r\n                <div class=\"form-group\">\r\n                    <input type=\"hidden\"");
                BeginWriteAttribute("value", " value=\"", 5482, "\"", 5512, 1);
#nullable restore
#line 119 "D:\CNPM\QuanLyNhaHang_CNPM\Source\QuanLyNhaHang\Views\NguoiDung\Profile.cshtml"
WriteAttributeValue("", 5490, ViewBag.IdCurrentUser, 5490, 22, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" name=""IdUser"">
                    <label for=""HoTen"">Họ tên</label>
                    <input type=""text"" class=""form-control"" placeholder=""Nhập họ tên"" name=""HoTen"" id=""HoTenUser"">
                </div>
                
                <button type=""submit"" class=""btn btn-primary"" style=""float:right"">Submit</button>
            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
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
    </div>
  </div>

  <!-- The Modal -->
  <div class=""modal fade"" id=""DoiMatKhauModal"">
    <div class=""modal-dialog modal-dialog-centered"">
      <div class=""modal-content"">
      
        <!-- Modal Header -->
        <div class=""modal-header"">
          <h4 class=""modal-title"">Đổi mật khẩu</h4>
          <button type=""button"" class=""close"" data-dismiss=""modal"">&times;</button>
        </div>
        
        <!-- Modal body -->
        <div class=""modal-body"">
           
                <input type=""hidden""");
            BeginWriteAttribute("value", " value=\"", 6436, "\"", 6466, 1);
#nullable restore
#line 145 "D:\CNPM\QuanLyNhaHang_CNPM\Source\QuanLyNhaHang\Views\NguoiDung\Profile.cshtml"
WriteAttributeValue("", 6444, ViewBag.IdCurrentUser, 6444, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" name=""IdUser"" id=""idu"">
                <div class=""form-group"">
                    <label for=""MatKhauCu"">Mật khẩu cũ</label>
                    <input type=""password"" class=""form-control"" placeholder=""Nhập mật khẩu cũ"" name=""MatKhauCu"" id=""MKCu"">
                </div>
                <div class=""form-group"">
                    <label for=""MatKhauMoi"">Mật khẩu mới</label>
                    <input type=""password"" class=""form-control"" placeholder=""Nhập mật khẩu mới"" name=""MatKhauMoi"" id=""MKMoi"">
                </div>
                <div class=""form-group"">
                    <label for=""NhapLaiMatKhauMoi"">Nhập lại mật khẩu</label>
                    <input type=""password"" class=""form-control"" placeholder=""Nhập lại mật khẩu mới"" name=""NhapLaiMatKhauMoi"" id=""NLMKMoi"">
                </div>
                <div class=""form-group"">
                    <i id=""Message"" style=""color:red""></i>
                </div>
                
                <button onclick=""DoiMatKhau()"" class=""btn");
            WriteLiteral(@" btn-primary"" style=""float:right"">Submit</button>
            
        </div>
    
      </div>
    </div>
  </div>

<script>
    function SuaTen()
    {
        alert(""Đổi tên thành công"");
    }

    function DoiMatKhau()
    {
        var MKCu=document.getElementById(""MKCu"").value;
        var MKMoi=document.getElementById(""MKMoi"").value;
        var NLMKMoi=document.getElementById(""NLMKMoi"").value;
        var IdUser=document.getElementById(""idu"").value;
        if(MKCu=="""")
        {
            document.getElementById(""Message"").innerHTML=""Mật khẩu cũ bị trống"";
            return;
        }
        else if(MKMoi=="""")
        {
             document.getElementById(""Message"").innerHTML=""Mật khẩu mới trống"";
            return;
        }
        else if(NLMKMoi=="""")
        {
             document.getElementById(""Message"").innerHTML=""Mật khẩu nhập lại bị trống"";
            return;
        }
        
        else if(MKMoi!=NLMKMoi)
        {
            document.getEl");
            WriteLiteral(@"ementById(""Message"").innerHTML=""Mật khẩu nhập lại không đúng"";
            return;
        }
         var xhttp = new XMLHttpRequest();

        xhttp.onreadystatechange = function () {
            if (this.readyState == 4 && this.status == 200) {
                if(this.responseText==""0"")
                    document.getElementById(""Message"").innerHTML = ""Mật khẩu cũ không đúng"";
                if(this.responseText==""1"")
                    {
                        alert(""Đổi mật khẩu thành công"");
                        location.reload();
                    }
                if(this.responseText==""-1"")
                    document.getElementById(""Message"").innerHTML =""Không tìm thấy người dùng này"";
            }
        };
        xhttp.open(""POST"", ""/NguoiDung/DoiMatKhau?IdUser="" + IdUser + ""&MatKhauMoi=""+MKMoi+""&MatKhauCu=""+MKCu);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<QuanLyNhaHang.ViewModels.UserProfileVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
