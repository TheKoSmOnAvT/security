#pragma checksum "D:\PTSU\Защиты информации\labs\Security\Security\Pages\laba3.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "58d0d2c9ce03e8c61471b710b922590966a98491"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Pages_laba3), @"mvc.1.0.razor-page", @"/Pages/laba3.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"58d0d2c9ce03e8c61471b710b922590966a98491", @"/Pages/laba3.cshtml")]
    public class Pages_laba3 : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\PTSU\Защиты информации\labs\Security\Security\Pages\laba3.cshtml"
  
    ViewData["Title"] = "Диффи-Хеллман";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<h2>Алгоритм Диффи-Хеллмана</h2>\r\n\r\n\r\n\r\n");
#nullable restore
#line 12 "D:\PTSU\Защиты информации\labs\Security\Security\Pages\laba3.cshtml"
 if (@Model.Kx != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p> 1 партнер сгенерировал простое случайное число Х : ");
#nullable restore
#line 14 "D:\PTSU\Защиты информации\labs\Security\Security\Pages\laba3.cshtml"
                                                      Write(Model.X);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    <p> 1 партнер подсчитал число А и отправил его партнеру 2 : ");
#nullable restore
#line 15 "D:\PTSU\Защиты информации\labs\Security\Security\Pages\laba3.cshtml"
                                                           Write(Model.A);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
            WriteLiteral("    <p> 2 партнер сгенерировал простое случайное число Y : ");
#nullable restore
#line 18 "D:\PTSU\Защиты информации\labs\Security\Security\Pages\laba3.cshtml"
                                                      Write(Model.Y);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    <p> 2 партнер подсчитал число В и отправил его партнеру 1 : ");
#nullable restore
#line 19 "D:\PTSU\Защиты информации\labs\Security\Security\Pages\laba3.cshtml"
                                                           Write(Model.B);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
            WriteLiteral("    <p> 1 партнер подсчитал Kx : ");
#nullable restore
#line 22 "D:\PTSU\Защиты информации\labs\Security\Security\Pages\laba3.cshtml"
                            Write(Model.Kx);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    <p> 2 партнер подсчитал Ky: ");
#nullable restore
#line 23 "D:\PTSU\Защиты информации\labs\Security\Security\Pages\laba3.cshtml"
                           Write(Model.Ky);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 24 "D:\PTSU\Защиты информации\labs\Security\Security\Pages\laba3.cshtml"

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Security.Pages.laba3Model> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Security.Pages.laba3Model> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Security.Pages.laba3Model>)PageContext?.ViewData;
        public Security.Pages.laba3Model Model => ViewData.Model;
    }
}
#pragma warning restore 1591
