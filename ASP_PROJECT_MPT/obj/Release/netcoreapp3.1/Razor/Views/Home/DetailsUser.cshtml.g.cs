#pragma checksum "C:\Users\leox5\МПТ\3 Курс\1 Семестр\mptASP\ASP_PROJECT_MPT\Views\Home\DetailsUser.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "73b6a257b1345a4b5812759626f93c387d204479"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_DetailsUser), @"mvc.1.0.view", @"/Views/Home/DetailsUser.cshtml")]
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
#line 1 "C:\Users\leox5\МПТ\3 Курс\1 Семестр\mptASP\ASP_PROJECT_MPT\Views\_ViewImports.cshtml"
using ASP_PROJECT_MPT;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\leox5\МПТ\3 Курс\1 Семестр\mptASP\ASP_PROJECT_MPT\Views\_ViewImports.cshtml"
using ASP_PROJECT_MPT.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"73b6a257b1345a4b5812759626f93c387d204479", @"/Views/Home/DetailsUser.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cedab70cb52de2e418987a753e82ee61855435dc", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_DetailsUser : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ASP_PROJECT_MPT.Models.User>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width:80px; height:60px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.SingleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Files/ya-logo-2020-02-1-900x506 (1).png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("login100-form validate-form flex-sb flex-w "), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("border: 3px solid #fff; border-radius: 10px; background-color:white"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("background-color:darkturquoise"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\leox5\МПТ\3 Курс\1 Семестр\mptASP\ASP_PROJECT_MPT\Views\Home\DetailsUser.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Мои данные</h1>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "73b6a257b1345a4b5812759626f93c387d2044795858", async() => {
                WriteLiteral(@"
    <title>Login V5</title>
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1"">
    <!--===============================================================================================-->
    <link rel=""icon"" type=""image/png"" href=""images/icons/favicon.ico"" />
    <!--===============================================================================================-->
    <link rel=""stylesheet"" type=""text/css"" href=""vendor/bootstrap/css/bootstrap.min.css"">
    <!--===============================================================================================-->
    <link rel=""stylesheet"" type=""text/css"" href=""fonts/font-awesome-4.7.0/css/font-awesome.min.css"">
    <!--===============================================================================================-->
    <link rel=""stylesheet"" type=""text/css"" href=""fonts/Linearicons-Free-v1.0.0/icon-font.min.css"">
    <!--====================================================================================");
                WriteLiteral(@"===========-->
    <link rel=""stylesheet"" type=""text/css"" href=""vendor/animate/animate.css"">
    <!--===============================================================================================-->
    <link rel=""stylesheet"" type=""text/css"" href=""vendor/css-hamburgers/hamburgers.min.css"">
    <!--===============================================================================================-->
    <link rel=""stylesheet"" type=""text/css"" href=""vendor/animsition/css/animsition.min.css"">
    <!--===============================================================================================-->
    <link rel=""stylesheet"" type=""text/css"" href=""vendor/select2/select2.min.css"">
    <!--===============================================================================================-->
    <link rel=""stylesheet"" type=""text/css"" href=""vendor/daterangepicker/daterangepicker.css"">
    <!--===============================================================================================-->
    <link rel=""stylesheet");
                WriteLiteral("\" type=\"text/css\" href=\"css/util.css\">\r\n    <link rel=\"stylesheet\" type=\"text/css\" href=\"css/main.css\">\r\n    <!--===============================================================================================-->\r\n");
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "73b6a257b1345a4b5812759626f93c387d2044799231", async() => {
                WriteLiteral("\r\n    <div class=\"limiter\">\r\n        <div class=\"container-login100\">\r\n            <div class=\"wrap-login100 p-l-110 p-r-110 p-t-62 p-b-33\">\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "73b6a257b1345a4b5812759626f93c387d2044799657", async() => {
                    WriteLiteral(" ");
                    WriteLiteral(" \r\n                    <div>\r\n                        <h4>Инфо</h4>\r\n                        <hr />\r\n                        <dl class=\"row\">\r\n                            <dt class=\"col-sm-2\">\r\n                                ");
#nullable restore
#line 44 "C:\Users\leox5\МПТ\3 Курс\1 Семестр\mptASP\ASP_PROJECT_MPT\Views\Home\DetailsUser.cshtml"
                           Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n                            </dt>\r\n                            <dd class=\"col-sm-10\">\r\n                                ");
#nullable restore
#line 47 "C:\Users\leox5\МПТ\3 Курс\1 Семестр\mptASP\ASP_PROJECT_MPT\Views\Home\DetailsUser.cshtml"
                           Write(Html.DisplayFor(model => model.Id));

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n                            </dd>\r\n                            <dt class=\"col-sm-2\">\r\n                                ");
#nullable restore
#line 50 "C:\Users\leox5\МПТ\3 Курс\1 Семестр\mptASP\ASP_PROJECT_MPT\Views\Home\DetailsUser.cshtml"
                           Write(Html.DisplayNameFor(model => model.Avatar));

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n                            </dt>\r\n                            <dd class=\"col-sm-10\">\r\n");
#nullable restore
#line 53 "C:\Users\leox5\МПТ\3 Курс\1 Семестр\mptASP\ASP_PROJECT_MPT\Views\Home\DetailsUser.cshtml"
                                 if (Model.Avatar != null)
                                {

#line default
#line hidden
#nullable disable
                    WriteLiteral("                                    <img style=\'width:80px; height:60px\'");
                    BeginWriteAttribute("src", " src=\"", 3620, "\"", 3689, 2);
                    WriteAttributeValue("", 3626, "data:image/jpeg;base64,", 3626, 23, true);
#nullable restore
#line 55 "C:\Users\leox5\МПТ\3 Курс\1 Семестр\mptASP\ASP_PROJECT_MPT\Views\Home\DetailsUser.cshtml"
WriteAttributeValue(" ", 3649, Convert.ToBase64String(Model.Avatar), 3650, 39, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(" />\r\n");
#nullable restore
#line 56 "C:\Users\leox5\МПТ\3 Курс\1 Семестр\mptASP\ASP_PROJECT_MPT\Views\Home\DetailsUser.cshtml"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
                    WriteLiteral("                                    ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "73b6a257b1345a4b5812759626f93c387d20447912660", async() => {
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n");
#nullable restore
#line 60 "C:\Users\leox5\МПТ\3 Курс\1 Семестр\mptASP\ASP_PROJECT_MPT\Views\Home\DetailsUser.cshtml"
                                }

#line default
#line hidden
#nullable disable
                    WriteLiteral("                            </dd>\r\n                            <dt class=\"col-sm-2\">\r\n                                ");
#nullable restore
#line 63 "C:\Users\leox5\МПТ\3 Курс\1 Семестр\mptASP\ASP_PROJECT_MPT\Views\Home\DetailsUser.cshtml"
                           Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n                            </dt>\r\n                            <dd class=\"col-sm-10\">\r\n                                ");
#nullable restore
#line 66 "C:\Users\leox5\МПТ\3 Курс\1 Семестр\mptASP\ASP_PROJECT_MPT\Views\Home\DetailsUser.cshtml"
                           Write(Html.DisplayFor(model => model.Email));

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n                            </dd>\r\n                            <dt class=\"col-sm-2\">\r\n                                ");
#nullable restore
#line 69 "C:\Users\leox5\МПТ\3 Курс\1 Семестр\mptASP\ASP_PROJECT_MPT\Views\Home\DetailsUser.cshtml"
                           Write(Html.DisplayNameFor(model => model.Login));

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n                            </dt>\r\n                            <dd class=\"col-sm-10\">\r\n                                ");
#nullable restore
#line 72 "C:\Users\leox5\МПТ\3 Курс\1 Семестр\mptASP\ASP_PROJECT_MPT\Views\Home\DetailsUser.cshtml"
                           Write(Html.DisplayFor(model => model.Login));

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n                            </dd>\r\n                            <dt class=\"col-sm-2\">\r\n                                ");
#nullable restore
#line 75 "C:\Users\leox5\МПТ\3 Курс\1 Семестр\mptASP\ASP_PROJECT_MPT\Views\Home\DetailsUser.cshtml"
                           Write(Html.DisplayNameFor(model => model.Password));

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n                            </dt>\r\n                            <dd class=\"col-sm-10\">\r\n                                ");
#nullable restore
#line 78 "C:\Users\leox5\МПТ\3 Курс\1 Семестр\mptASP\ASP_PROJECT_MPT\Views\Home\DetailsUser.cshtml"
                           Write(Html.DisplayFor(model => model.Password));

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n                            </dd>\r\n\r\n\r\n                            <dt class=\"col-sm-2\">\r\n                                ");
#nullable restore
#line 83 "C:\Users\leox5\МПТ\3 Курс\1 Семестр\mptASP\ASP_PROJECT_MPT\Views\Home\DetailsUser.cshtml"
                           Write(Html.DisplayNameFor(model => model.First_Name));

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n                            </dt>\r\n                            <dd class=\"col-sm-10\">\r\n                                ");
#nullable restore
#line 86 "C:\Users\leox5\МПТ\3 Курс\1 Семестр\mptASP\ASP_PROJECT_MPT\Views\Home\DetailsUser.cshtml"
                           Write(Html.DisplayFor(model => model.First_Name));

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n                            </dd>\r\n                            <dt class=\"col-sm-2\">\r\n                                ");
#nullable restore
#line 89 "C:\Users\leox5\МПТ\3 Курс\1 Семестр\mptASP\ASP_PROJECT_MPT\Views\Home\DetailsUser.cshtml"
                           Write(Html.DisplayNameFor(model => model.Last_Name));

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n                            </dt>\r\n                            <dd class=\"col-sm-10\">\r\n                                ");
#nullable restore
#line 92 "C:\Users\leox5\МПТ\3 Курс\1 Семестр\mptASP\ASP_PROJECT_MPT\Views\Home\DetailsUser.cshtml"
                           Write(Html.DisplayFor(model => model.Last_Name));

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n                            </dd>\r\n                            <dt class=\"col-sm-2\">\r\n                                ");
#nullable restore
#line 95 "C:\Users\leox5\МПТ\3 Курс\1 Семестр\mptASP\ASP_PROJECT_MPT\Views\Home\DetailsUser.cshtml"
                           Write(Html.DisplayNameFor(model => model.Otchestvo));

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n                            </dt>\r\n                            <dd class=\"col-sm-10\">\r\n                                ");
#nullable restore
#line 98 "C:\Users\leox5\МПТ\3 Курс\1 Семестр\mptASP\ASP_PROJECT_MPT\Views\Home\DetailsUser.cshtml"
                           Write(Html.DisplayFor(model => model.Otchestvo));

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n                            </dd>\r\n");
                    WriteLiteral("                            <dt class=\"col-sm-2\">\r\n                                ");
#nullable restore
#line 107 "C:\Users\leox5\МПТ\3 Курс\1 Семестр\mptASP\ASP_PROJECT_MPT\Views\Home\DetailsUser.cshtml"
                           Write(Html.DisplayNameFor(model => model.Date_Brith));

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n                            </dt>\r\n                            <dd class=\"col-sm-10\">\r\n                                ");
#nullable restore
#line 110 "C:\Users\leox5\МПТ\3 Курс\1 Семестр\mptASP\ASP_PROJECT_MPT\Views\Home\DetailsUser.cshtml"
                           Write(Html.DisplayFor(model => model.Date_Brith));

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n                            </dd>\r\n");
                    WriteLiteral("                            <dt class=\"col-sm-2\">\r\n                                ");
#nullable restore
#line 119 "C:\Users\leox5\МПТ\3 Курс\1 Семестр\mptASP\ASP_PROJECT_MPT\Views\Home\DetailsUser.cshtml"
                           Write(Html.DisplayNameFor(model => model.RoleId));

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n                            </dt>\r\n                            <dd class=\"col-sm-10\">\r\n                                ");
#nullable restore
#line 122 "C:\Users\leox5\МПТ\3 Курс\1 Семестр\mptASP\ASP_PROJECT_MPT\Views\Home\DetailsUser.cshtml"
                           Write(Html.DisplayFor(model => model.RoleId));

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n                            </dd>\r\n                        </dl>\r\n                    </div>\r\n                    <div>\r\n                        ");
#nullable restore
#line 127 "C:\Users\leox5\МПТ\3 Курс\1 Семестр\mptASP\ASP_PROJECT_MPT\Views\Home\DetailsUser.cshtml"
                   Write(Html.ActionLink("Мои посты", "OtherUserBlog", new { login = Model.Login }));

#line default
#line hidden
#nullable disable
                    WriteLiteral(" |\r\n                        ");
#nullable restore
#line 128 "C:\Users\leox5\МПТ\3 Курс\1 Семестр\mptASP\ASP_PROJECT_MPT\Views\Home\DetailsUser.cshtml"
                   Write(Html.ActionLink("Изменить мои данные", "Edit", new { id = Model.Id }));

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n                    </div>\r\n                ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
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

    <div id=""dropDownSelect1""></div>

    <!--===============================================================================================-->
    <script src=""vendor/jquery/jquery-3.2.1.min.js""></script>
    <!--===============================================================================================-->
    <script src=""vendor/animsition/js/animsition.min.js""></script>
    <!--===============================================================================================-->
    <script src=""vendor/bootstrap/js/popper.js""></script>
    <script src=""vendor/bootstrap/js/bootstrap.min.js""></script>
    <!--===============================================================================================-->
    <script src=""vendor/select2/select2.min.js""></script>
    <!--===============================================================================================-->
    <script src=""vendor/daterangepicker/moment.min.js""></script>
    <script");
                WriteLiteral(@" src=""vendor/daterangepicker/daterangepicker.js""></script>
    <!--===============================================================================================-->
    <script src=""vendor/countdowntime/countdowntime.js""></script>
    <!--===============================================================================================-->
    <script src=""js/main.js""></script>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ASP_PROJECT_MPT.Models.User> Html { get; private set; }
    }
}
#pragma warning restore 1591
