#pragma checksum "D:\bai_6\WebApp\WebApp\Views\Upload\Online.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "86633b3c73ae4ba38c2e66041191ec0bfbf5a251"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Upload_Online), @"mvc.1.0.view", @"/Views/Upload/Online.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"86633b3c73ae4ba38c2e66041191ec0bfbf5a251", @"/Views/Upload/Online.cshtml")]
    public class Views_Upload_Online : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<form method=\"post\">\r\n    <input type=\"url\" name=\"url\" required />\r\n    <button>Upload</button>\r\n</form>\r\n");
#nullable restore
#line 5 "D:\bai_6\WebApp\WebApp\Views\Upload\Online.cshtml"
 if (!string.IsNullOrEmpty(Model))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <img");
            BeginWriteAttribute("src", " src=\"", 153, "\"", 173, 2);
            WriteAttributeValue("", 159, "/upload/", 159, 8, true);
#nullable restore
#line 7 "D:\bai_6\WebApp\WebApp\Views\Upload\Online.cshtml"
WriteAttributeValue("", 167, Model, 167, 6, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n");
#nullable restore
#line 8 "D:\bai_6\WebApp\WebApp\Views\Upload\Online.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591