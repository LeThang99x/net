#pragma checksum "D:\bai_6\WebApp\WebApp\Views\Brand\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "85519dee8f8b5fed472b8a068587960c480658db"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Brand_Index), @"mvc.1.0.view", @"/Views/Brand/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"85519dee8f8b5fed472b8a068587960c480658db", @"/Views/Brand/Index.cshtml")]
    public class Views_Brand_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<WebApp.Models.Brand>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"    <button type=""button"" class=""btn btn-primary"" data-toggle=""modal"" data-target=""#exampleModal"">
        update
    </button>

    <!-- Modal -->
<div class=""modal fade"" id=""exampleModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog"" role=""document"">
        <form action=""/brand/create"" method=""post"" name=""frm"">
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <h5 class=""modal-title"" id=""exampleModalLabel"">Modal title</h5>
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>
                </div>
                <div class=""modal-body"">
                    <input type=""hidden"" name=""id"" />
                    <div class=""mb-3"">
                        <label>Name</label>
                        <input type=""text"" class=""form-control");
            WriteLiteral(@""" placeholder=""Brand Name"" name=""name"" />
                    </div>
                    
                </div>
                <div class=""modal-footer"">
                    <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Close</button>
                    <button  class=""btn btn-primary"">Save changes</button>
                </div>
            </div>
        </form>
    </div>
</div>
  
       
    
    <table>
        <thead>
            <tr>
                <th>Id</th>
                <th>Name</th>
                <th> Edit</th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 45 "D:\bai_6\WebApp\WebApp\Views\Brand\Index.cshtml"
             foreach (WebApp.Models.Brand item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 48 "D:\bai_6\WebApp\WebApp\Views\Brand\Index.cshtml"
                   Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 49 "D:\bai_6\WebApp\WebApp\Views\Brand\Index.cshtml"
                   Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td><i");
            BeginWriteAttribute("v", " v=\"", 1895, "\"", 1907, 1);
#nullable restore
#line 50 "D:\bai_6\WebApp\WebApp\Views\Brand\Index.cshtml"
WriteAttributeValue("", 1899, item.Id, 1899, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"fa fa-edit\"></i></td>\r\n                </tr>\r\n");
#nullable restore
#line 52 "D:\bai_6\WebApp\WebApp\Views\Brand\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        </tbody>
    </table>
    <script>
        $('.fa-edit').click(function () {
            var m = new bootstrap.Modal(exampleModal);
            m.show();
            //console.log($(this).attr('v'));
            var v = $(this).attr('v');
            $.get('/brand/detail/' + v, function (o) {
                console.log(o);
                $(frm['id']).val(o['id']);
                $(frm['name']).val(o['name']);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<WebApp.Models.Brand>> Html { get; private set; }
    }
}
#pragma warning restore 1591
