#pragma checksum "C:\Users\skad1\OneDrive\Рабочий стол\WebCoffee\WebCoffee\Views\Novetlies\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "792479984fd8260c1ac910b49eebe76a47281075"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Novetlies_Index), @"mvc.1.0.view", @"/Views/Novetlies/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"792479984fd8260c1ac910b49eebe76a47281075", @"/Views/Novetlies/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a3a0e8ee4339e4042aba4384ba95caa4b5893705", @"/Views/_ViewImports.cshtml")]
    public class Views_Novetlies_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Novetly>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div>\r\n    <div>\r\n");
#nullable restore
#line 8 "C:\Users\skad1\OneDrive\Рабочий стол\WebCoffee\WebCoffee\Views\Novetlies\Index.cshtml"
         foreach (var news in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"news-item\">\r\n                <div>\r\n                    ");
#nullable restore
#line 12 "C:\Users\skad1\OneDrive\Рабочий стол\WebCoffee\WebCoffee\Views\Novetlies\Index.cshtml"
               Write(news.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n                <div>\r\n                    ");
#nullable restore
#line 15 "C:\Users\skad1\OneDrive\Рабочий стол\WebCoffee\WebCoffee\Views\Novetlies\Index.cshtml"
               Write(news.Body);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n                <div>\r\n                    ");
#nullable restore
#line 18 "C:\Users\skad1\OneDrive\Рабочий стол\WebCoffee\WebCoffee\Views\Novetlies\Index.cshtml"
               Write(news.Date);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n                <div>\r\n                    ");
#nullable restore
#line 21 "C:\Users\skad1\OneDrive\Рабочий стол\WebCoffee\WebCoffee\Views\Novetlies\Index.cshtml"
               Write(news.Time);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 24 "C:\Users\skad1\OneDrive\Рабочий стол\WebCoffee\WebCoffee\Views\Novetlies\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Novetly>> Html { get; private set; }
    }
}
#pragma warning restore 1591