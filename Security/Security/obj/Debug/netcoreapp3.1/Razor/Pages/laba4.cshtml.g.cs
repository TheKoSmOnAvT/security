#pragma checksum "D:\PTSU\Защиты информации\labs\Security\Security\Pages\laba4.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dd109be84cc7497baa8d4e137383bbe41dac785a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Pages_laba4), @"mvc.1.0.razor-page", @"/Pages/laba4.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dd109be84cc7497baa8d4e137383bbe41dac785a", @"/Pages/laba4.cshtml")]
    public class Pages_laba4 : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\PTSU\Защиты информации\labs\Security\Security\Pages\laba4.cshtml"
  
    ViewData["Title"] = "DSA";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n<h2>Метод шифрования DSA</h2>\r\n\r\n<form method=\"post\">\r\n    <p> Текст для шифрования <input name=\"text\" /> </p>\r\n    <p> Ключ для шифрования <input name=\"keyS\" /> </p>\r\n    <input type=\"submit\" value=\"Зашифровать\" />\r\n\r\n</form>\r\n\r\n");
#nullable restore
#line 18 "D:\PTSU\Защиты информации\labs\Security\Security\Pages\laba4.cshtml"
 if (@Model.code != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>Закодированное: ");
#nullable restore
#line 20 "D:\PTSU\Защиты информации\labs\Security\Security\Pages\laba4.cshtml"
                  Write(Model.code);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    <p>Раскодированное: ");
#nullable restore
#line 21 "D:\PTSU\Защиты информации\labs\Security\Security\Pages\laba4.cshtml"
                   Write(Model.deCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 22 "D:\PTSU\Защиты информации\labs\Security\Security\Pages\laba4.cshtml"

}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Security.Pages.laba4Model> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Security.Pages.laba4Model> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Security.Pages.laba4Model>)PageContext?.ViewData;
        public Security.Pages.laba4Model Model => ViewData.Model;
    }
}
#pragma warning restore 1591
