#pragma checksum "C:\Users\skad1\OneDrive\Рабочий стол\WebCoffee\WebCoffee\Views\Users\CreateEmployee.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a15d3923705ba415392478877dce08fe5ca61f5a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Users_CreateEmployee), @"mvc.1.0.view", @"/Views/Users/CreateEmployee.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\skad1\OneDrive\Рабочий стол\WebCoffee\WebCoffee\Views\_ViewImports.cshtml"
using System;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\skad1\OneDrive\Рабочий стол\WebCoffee\WebCoffee\Views\_ViewImports.cshtml"
using WebCoffee;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\skad1\OneDrive\Рабочий стол\WebCoffee\WebCoffee\Views\_ViewImports.cshtml"
using WebCoffee.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\skad1\OneDrive\Рабочий стол\WebCoffee\WebCoffee\Views\_ViewImports.cshtml"
using WebCoffee.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\skad1\OneDrive\Рабочий стол\WebCoffee\WebCoffee\Views\_ViewImports.cshtml"
using WebCoffee.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\skad1\OneDrive\Рабочий стол\WebCoffee\WebCoffee\Views\_ViewImports.cshtml"
using WebCoffee.ViewModels.Menu;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\skad1\OneDrive\Рабочий стол\WebCoffee\WebCoffee\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a15d3923705ba415392478877dce08fe5ca61f5a", @"/Views/Users/CreateEmployee.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a3a0e8ee4339e4042aba4384ba95caa4b5893705", @"/Views/_ViewImports.cshtml")]
    public class Views_Users_CreateEmployee : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebCoffee.ViewModels.Users.CreateEmployeeViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Users", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CreateEmployee", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\skad1\OneDrive\Рабочий стол\WebCoffee\WebCoffee\Views\Users\CreateEmployee.cshtml"
  
    ViewData["Title"] = "Account";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"main-page\">\r\n    <div>\r\n        Добавить сотрудника\r\n    </div>\r\n    <div class=\"create-employee\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a15d3923705ba415392478877dce08fe5ca61f5a5499", async() => {
                WriteLiteral("\r\n            <div>\r\n                <span>Имя</span>\r\n                <input type=\"text\" name=\"Name\"");
                BeginWriteAttribute("value", " value=\"", 446, "\"", 454, 0);
                EndWriteAttribute();
                WriteLiteral(" />\r\n            </div>\r\n            <div>\r\n                <span>Фамилия</span>\r\n                <input type=\"text\" name=\"Surname\"");
                BeginWriteAttribute("value", " value=\"", 586, "\"", 594, 0);
                EndWriteAttribute();
                WriteLiteral(" />\r\n            </div>\r\n            <div>\r\n                <span>Возраст</span>\r\n                <input type=\"number\" name=\"Age\"");
                BeginWriteAttribute("value", " value=\"", 724, "\"", 732, 0);
                EndWriteAttribute();
                WriteLiteral(@" />
            </div>
            <div>
                <span>Пол</span>
                <input type=""radio"" name=""Gender"" value=""Male"" />
                <input type=""radio"" name=""Gender"" value=""Female"" />
            </div>
            <div>
                <span>Адрес</span>
                <input type=""text"" name=""Address""");
                BeginWriteAttribute("value", " value=\"", 1071, "\"", 1079, 0);
                EndWriteAttribute();
                WriteLiteral(" />\r\n            </div>\r\n            <div>\r\n                <span>Телефон</span>\r\n                <input type=\"text\" name=\"Phone\"");
                BeginWriteAttribute("value", " value=\"", 1209, "\"", 1217, 0);
                EndWriteAttribute();
                WriteLiteral(" />\r\n            </div>\r\n            <div>\r\n                <input type=\"submit\" value=\"Добавить\" />\r\n            </div>\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        \r\n    </div>\r\n    \r\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<ApplicationUser> userManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebCoffee.ViewModels.Users.CreateEmployeeViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
