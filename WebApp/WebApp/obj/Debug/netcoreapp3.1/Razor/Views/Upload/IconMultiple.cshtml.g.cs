#pragma checksum "D:\bai_6\WebApp\WebApp\Views\Upload\IconMultiple.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "592b1a0efcc64e0b6d91c956785d5662636d83f0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Upload_IconMultiple), @"mvc.1.0.view", @"/Views/Upload/IconMultiple.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"592b1a0efcc64e0b6d91c956785d5662636d83f0", @"/Views/Upload/IconMultiple.cshtml")]
    public class Views_Upload_IconMultiple : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<i class=\"fa fa-upload\"></i>\r\n<form method=\"post\" name=\"frm\">\r\n    <input type=\"file\" multiple name=\"f\"");
            BeginWriteAttribute("value", " value=\"", 103, "\"", 111, 0);
            EndWriteAttribute();
            WriteLiteral(@" />
</form>
<div id=""rs""></div>
<style>
    input {
        display: none;
    }
</style>
<script>
    $('.fa-upload').click(function () {
        $(frm['f']).click();
    })
    $(frm['f']).change(function () {
        var fd = new FormData()
        for (var i = 0; i < this.files.length; i++) {
            fd.append('af', this.files[i]);
        }
       
        $.ajax({
            url: '/upload/ajaxmultiple',
            type: 'post',
            data: fd,
            processData: false,
            contentType: false,
            success: function (a) {
                //console.log(a)
                for (var i in a) {
                    $(rs).append(`<img width=""100"" src=""/upload/${a[i]}""/>`)
                }
                //$(rs).append(`<img width=""100"" src=""/upload/${o.name}""/>`)
            }
        })
    })
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
