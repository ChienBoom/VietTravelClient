#pragma checksum "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Areas\Customer\Views\HomeCustomer\History.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8ad7524ceb505cd8c7538c57a7597bc2b4bd6db8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Customer_Views_HomeCustomer_History), @"mvc.1.0.view", @"/Areas/Customer/Views/HomeCustomer/History.cshtml")]
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
#line 1 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Areas\Customer\Views\_ViewImports.cshtml"
using VietTravelClient;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Areas\Customer\Views\_ViewImports.cshtml"
using VietTravelClient.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8ad7524ceb505cd8c7538c57a7597bc2b4bd6db8", @"/Areas/Customer/Views/HomeCustomer/History.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f0efa66d1bcb428e72df198de36b8c870586a0c5", @"/Areas/Customer/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_Customer_Views_HomeCustomer_History : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Areas\Customer\Views\HomeCustomer\History.cshtml"
  
    ViewData["Title"] = "Lịch sử đặt Tour";
    List<Ticket> tickets = (List<Ticket>)ViewData["Tickets"];
    string status = (string)ViewData["Status"];

#line default
#line hidden
#nullable disable
            WriteLiteral("<style>\r\n    .modal-dialog {\r\n        max-width: 800px;\r\n    }\r\n</style>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8ad7524ceb505cd8c7538c57a7597bc2b4bd6db83773", async() => {
                WriteLiteral("\r\n    <div class=\"row\" style=\"margin-top: 40px; margin-bottom: 10px;\">\r\n        <div class=\"col-10\"></div>\r\n    </div>\r\n    <div class=\"row\">\r\n");
                WriteLiteral("        <div hidden>\r\n            <input type=\"text\" id=\"Status\"");
                BeginWriteAttribute("value", " value=\"", 594, "\"", 609, 1);
#nullable restore
#line 21 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Areas\Customer\Views\HomeCustomer\History.cshtml"
WriteAttributeValue("", 602, status, 602, 7, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n        </div>\r\n\r\n        <div class=\"col-1\"></div>\r\n        <table class=\"col-10 col-sm-10 col-md-10 border\" style=\"border: 1px; border-color: black;\">\r\n            <tr");
                BeginWriteAttribute("class", " class=\"", 784, "\"", 792, 0);
                EndWriteAttribute();
                WriteLiteral(@">
                <th style=""width : 5%"" class=""text-center bg-info text-light border"">STT</th>
                <th style=""width : 20%"" class=""text-center bg-info text-light border"">Tên Tour</th>
                <th style=""width : 20%"" class=""text-center bg-info text-light border"">Ngày đặt Tour</th>
                <th style=""width : 35%"" class=""text-center bg-info text-light border"">Gía Tour</th>
                <th style=""width : 20%"" class=""text-center bg-info text-light border""></th>
            </tr>
");
#nullable restore
#line 33 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Areas\Customer\Views\HomeCustomer\History.cshtml"
              
                for(int i =0; i<tickets.Count; i++)
                {
                    Ticket item = tickets[i];

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <tr>\r\n                        <td class=\"text-center border\">");
#nullable restore
#line 38 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Areas\Customer\Views\HomeCustomer\History.cshtml"
                                                   Write(i + 1);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                        <td class=\"text-center border\">");
#nullable restore
#line 39 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Areas\Customer\Views\HomeCustomer\History.cshtml"
                                                  Write(item.TourPackageId);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                        <td class=\"text-center border\">");
#nullable restore
#line 40 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Areas\Customer\Views\HomeCustomer\History.cshtml"
                                                  Write(item.BookingDate);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                        <td class=\"text-center border\">");
#nullable restore
#line 41 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Areas\Customer\Views\HomeCustomer\History.cshtml"
                                                  Write(item.TourPackageId);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                        <td class=\"text-center border\"><button class=\"btn btn-info\" data-toggle=\"modal\" data-target=\"#readTourGuide");
#nullable restore
#line 42 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Areas\Customer\Views\HomeCustomer\History.cshtml"
                                                                                                                               Write(item.Id);

#line default
#line hidden
#nullable disable
                WriteLiteral("\">Xem</button></td>\r\n\r\n                    </tr>\r\n");
#nullable restore
#line 45 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Areas\Customer\Views\HomeCustomer\History.cshtml"
                }
            

#line default
#line hidden
#nullable disable
                WriteLiteral("        </table>\r\n    </div>\r\n\r\n    <");
                WriteLiteral("\r\n");
                WriteLiteral(@"    <div class=""modal"" id=""Warning"">
        <div class=""modal-dialog"" role=""document"">
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <h4 class=""modal-title text-warning"">THÔNG BÁO</h4>
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>
                </div>
                <div class=""modal-body"">
                    <p id=""WarningMessage""></p>
                </div>
                <div class=""modal-footer"">
                    <button type=""button"" class=""btn btn-warning"" data-dismiss=""modal"">Đồng ý</button>
                </div>
            </div>
        </div>
    </div>

");
                WriteLiteral(@"    <div class=""modal"" id=""StatusModal"">
        <div class=""modal-dialog"" role=""document"">
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <h4 class=""modal-title text-warning"">THÔNG BÁO</h4>
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>
                </div>
                <div class=""modal-body"">
                    <p id=""StatusMessage""></p>
                </div>
                <div class=""modal-footer"">
                    <button type=""button"" class=""btn btn-warning"" data-dismiss=""modal"">Đồng ý</button>
                </div>
            </div>
        </div>
    </div>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
<script>
    $(document).ready(function () {
        var status = $(""#Status"").val();
        if (status == 1) {
            $('#StatusMessage').text(""ĐẶT TOUR THÀNH CÔNG"")
            $('#StatusModal').modal('show');
        } else if (messageValue == 2) {
            $('#StatusMessage').text(""ĐẶT TOUR THẤT BẠI"")
            $('#StatusModal').modal('show');
        }
    });
</script>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
