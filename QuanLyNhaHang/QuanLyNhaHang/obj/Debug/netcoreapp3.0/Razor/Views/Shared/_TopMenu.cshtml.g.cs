#pragma checksum "C:\Users\del\Documents\GitHub\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\Shared\_TopMenu.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "97e8ee99d2c2ab3131743e3986c65c8d6a985f60"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__TopMenu), @"mvc.1.0.view", @"/Views/Shared/_TopMenu.cshtml")]
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
using ApplicationCore.Entitites;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"97e8ee99d2c2ab3131743e3986c65c8d6a985f60", @"/Views/Shared/_TopMenu.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e162fa2d12f7268917634a0a4f525942fa6c1109", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__TopMenu : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("dropdown-item"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Login", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Logout", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 1 "C:\Users\del\Documents\GitHub\QuanLyNhaHang_CNPM\QuanLyNhaHang\QuanLyNhaHang\Views\Shared\_TopMenu.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <div class=""top_nav"">
          <div class=""nav_menu"">
              <div class=""nav toggle"">
                <a id=""menu_toggle""><i class=""fa fa-bars""></i></a>
              </div>
              <nav class=""nav navbar-nav"">
              <ul class="" navbar-right"">
                <li class=""nav-item dropdown open"" style=""padding-left: 15px;"">
                  <a href=""javascript:;"" class=""user-profile dropdown-toggle"" aria-haspopup=""true"" id=""navbarDropdown"" data-toggle=""dropdown"" aria-expanded=""false"">
                    <img src=""images/img.jpg""");
            BeginWriteAttribute("alt", " alt=\"", 600, "\"", 606, 0);
            EndWriteAttribute();
            WriteLiteral(@">Hoang
                  </a>
                  <div class=""dropdown-menu dropdown-usermenu pull-right"" aria-labelledby=""navbarDropdown"">
                    <a class=""dropdown-item""  href=""javascript:;""> Profile</a>
                      <a class=""dropdown-item""  href=""javascript:;"">
                        <span class=""badge bg-red pull-right"">50%</span>
                        <span>Settings</span>
                      </a>
                    <a class=""dropdown-item""  href=""javascript:;"">Help</a>
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "97e8ee99d2c2ab3131743e3986c65c8d6a985f605422", async() => {
                WriteLiteral("<i class=\"fa fa-sign-out pull-right\"></i> Log Out");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                  </div>
                </li>

                <li role=""presentation"" class=""nav-item dropdown open"">
                  <a href=""javascript:;"" class=""dropdown-toggle info-number"" id=""navbarDropdown1"" data-toggle=""dropdown"" aria-expanded=""false"">
                    <i class=""fa fa-envelope-o""></i>
                    <span class=""badge bg-green"">6</span>
                  </a>
                  <ul class=""dropdown-menu list-unstyled msg_list"" role=""menu"" aria-labelledby=""navbarDropdown1"">
                    <li class=""nav-item"">
                      <a class=""dropdown-item"">
                        <span class=""image""><img src=""images/img.jpg"" alt=""Profile Image"" /></span>
                        <span>
                          <span>John Smith</span>
                          <span class=""time"">3 mins ago</span>
                        </span>
                        <span class=""message"">
                          Film festivals used to be do-or-die moments for movie ");
            WriteLiteral(@"makers. They were where...
                        </span>
                      </a>
                    </li>
                    <li class=""nav-item"">
                      <a class=""dropdown-item"">
                        <span class=""image""><img src=""images/img.jpg"" alt=""Profile Image"" /></span>
                        <span>
                          <span>John Smith</span>
                          <span class=""time"">3 mins ago</span>
                        </span>
                        <span class=""message"">
                          Film festivals used to be do-or-die moments for movie makers. They were where...
                        </span>
                      </a>
                    </li>
                    <li class=""nav-item"">
                      <a class=""dropdown-item"">
                        <span class=""image""><img src=""images/img.jpg"" alt=""Profile Image"" /></span>
                        <span>
                          <span>John Smith</span>
               ");
            WriteLiteral(@"           <span class=""time"">3 mins ago</span>
                        </span>
                        <span class=""message"">
                          Film festivals used to be do-or-die moments for movie makers. They were where...
                        </span>
                      </a>
                    </li>
                    <li class=""nav-item"">
                      <a class=""dropdown-item"">
                        <span class=""image""><img src=""images/img.jpg"" alt=""Profile Image"" /></span>
                        <span>
                          <span>John Smith</span>
                          <span class=""time"">3 mins ago</span>
                        </span>
                        <span class=""message"">
                          Film festivals used to be do-or-die moments for movie makers. They were where...
                        </span>
                      </a>
                    </li>
                    <li class=""nav-item"">
                      <div class=""text");
            WriteLiteral(@"-center"">
                        <a class=""dropdown-item"">
                          <strong>See All Alerts</strong>
                          <i class=""fa fa-angle-right""></i>
                        </a>
                      </div>
                    </li>
                  </ul>
                </li>
              </ul>
            </nav>
          </div>
        </div>");
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
