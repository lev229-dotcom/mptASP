#pragma checksum "C:\Users\leox5\МПТ\3 Курс\1 Семестр\mptASP\ASP_PROJECT_MPT\Views\Messenger\Chat.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2391bd2459812a0949712036ad73baaa8a41cf5f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Messenger_Chat), @"mvc.1.0.view", @"/Views/Messenger/Chat.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2391bd2459812a0949712036ad73baaa8a41cf5f", @"/Views/Messenger/Chat.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cedab70cb52de2e418987a753e82ee61855435dc", @"/Views/_ViewImports.cshtml")]
    public class Views_Messenger_Chat : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ChatTableViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/signalr/dist/browser/signalr.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\leox5\МПТ\3 Курс\1 Семестр\mptASP\ASP_PROJECT_MPT\Views\Messenger\Chat.cshtml"
  
    ViewBag.Title = "Переписка";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div id=\"inputForm\">\r\n    <input type=\"text\" id=\"message\" />\r\n    <input type=\"button\" id=\"sendBtn\" value=\"Отправить\" />\r\n</div>\r\n<div id=\"chatroom\"></div>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2391bd2459812a0949712036ad73baaa8a41cf5f3911", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
<script>
        const hubConnection = new signalR.HubConnectionBuilder()
            .withUrl(""/chat"")
            .build();
        let userName = """";
        // получение сообщения от сервера
        hubConnection.on(""ReceiveTGroup"", function (message, userName) {

            // создаем элемент <b> для имени пользователя
            let userNameElem = document.createElement(""b"");
            userNameElem.appendChild(document.createTextNode(userName + "": ""));

            // создает элемент <p> для сообщения пользователя
            let elem = document.createElement(""p"");
            elem.appendChild(userNameElem);
            elem.appendChild(document.createTextNode(message));

            var firstElem = document.getElementById(""chatroom"").firstChild;
            document.getElementById(""chatroom"").insertBefore(elem, firstElem);

        });

        // диагностическое сообщение
        hubConnection.on(""NotifyToGroup"", function (message) {

            let elem = document.crea");
            WriteLiteral(@"teElement(""p"");
            elem.appendChild(document.createTextNode(message));

            var firstElem = document.getElementById(""chatroom"").firstChild;
            document.getElementById(""chatroom"").insertBefore(elem, firstElem);
        });
       
        // отправка сообщения на сервер
        document.getElementById(""sendBtn"").addEventListener(""click"", function (e) {
            let message = document.getElementById(""message"").value;
            hubConnection.invoke(""SendToGroup"", message, userName);
        });

        hubConnection.start();
</script>

");
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n\r\n");
            WriteLiteral(@"<!--<div class=""col-md-8 col-xl-6 chat"">
    <div class=""card"">
        <div class=""card-header msg_head"">
            <div class=""d-flex bd-highlight"">
                <div class=""user_info"">
                    <span>Chat with : <span id=""chat-with-id""></span></span>
                </div>
            </div>
        </div>
        <div class=""card-body msg_card_body"">

            <ul>
                <li id=""messageListId""></li>
            </ul>-->
");
            WriteLiteral(@"<!--</div>
        <div class=""card-footer"">
            <div class=""input-group"">
                <div class=""input-group-append"">
                    <span class=""input-group-text attach_btn""><i class=""fas fa-paperclip""></i></span>
                </div>
                <textarea name="""" class=""form-control type_msg"" id=""messageInput"" placeholder=""Type your message......"">
                         </textarea>
                <div class=""input-group-append"">
                    <span class=""input-group-text send_btn"" id=""sendButton""><i class=""fas fa-location-arrow""></i></span>
                </div>
            </div>
        </div>
    </div>
</div>-->
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ChatTableViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
