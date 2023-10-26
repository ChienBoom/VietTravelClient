#pragma checksum "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Areas\Admin\Views\TourPackageAdmin\AddTourPackage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "93ef8601c64fb100d04bab0047d6d01443519a2a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_TourPackageAdmin_AddTourPackage), @"mvc.1.0.view", @"/Areas/Admin/Views/TourPackageAdmin/AddTourPackage.cshtml")]
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
#line 1 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Areas\Admin\Views\_ViewImports.cshtml"
using VietTravelClient;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Areas\Admin\Views\_ViewImports.cshtml"
using VietTravelClient.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"93ef8601c64fb100d04bab0047d6d01443519a2a", @"/Areas/Admin/Views/TourPackageAdmin/AddTourPackage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f0efa66d1bcb428e72df198de36b8c870586a0c5", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_TourPackageAdmin_AddTourPackage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("col-12 col-sm-12 col-md-12"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Areas\Admin\Views\TourPackageAdmin\AddTourPackage.cshtml"
  
    ViewData["Title"] = "Thêm gói Tour";
    List<Tour> tours = (List<Tour>)ViewData["Tours"];
    List<Hotel> hotels = (List<Hotel>)ViewData["Hotels"];
    List<TimePackage> timePackages = (List<TimePackage>)ViewData["TimePackages"];
    long selectedTourId = 1;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "93ef8601c64fb100d04bab0047d6d01443519a2a4884", async() => {
                WriteLiteral(@"
    <div class=""row"" style=""margin-top: 20px;"">
        <div class=""media col-12 col-sm-12 col-md-12 border"" style=""margin-left: 10px; margin-right: 10px;"">
            <div class=""col-4 col-sm-4 col-md-4"">
                <div class=""row"">
                    <div class=""mt-0 text-info font-italic col-6 col-sm-6 col-md-6 d-flex align-items-center border-bottom"" style=""font-size: 20px; margin-left: 50px;"">
                        THÊM GÓI TOUR
                    </div>
                </div>
                <img class=""mr-3 rounded order-0 col-12 col-sm-12 col-md-12""
                     src=""https://vapa.vn/wp-content/uploads/2022/12/anh-3d-thien-nhien-010.jpg"" style=""margin-top: 50px;"">
            </div>
            <div class=""media-body col-8 col-sm-8 col-md-8"" style=""margin-top: 40px;"">
                <div class=""row"">

                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "93ef8601c64fb100d04bab0047d6d01443519a2a6043", async() => {
                    WriteLiteral("\r\n                        <div class=\"row\">\r\n                            <div class=\"col-6 col-sm-6 col-md-6\">\r\n                                <label");
                    BeginWriteAttribute("for", " for=\"", 1482, "\"", 1488, 0);
                    EndWriteAttribute();
                    WriteLiteral(@" class=""font-italic text-info col-12 col-sm-12 col-md-12"">Tên gói Tour</label>
                                <input type=""text"" class=""rounded border-info text-info col-12 col-sm-12 col-md-12""
                                       style=""height:60px;"">
                            </div>
                            <div class=""col-6 col-sm-6 col-md-6"">
                                <label");
                    BeginWriteAttribute("for", " for=\"", 1889, "\"", 1895, 0);
                    EndWriteAttribute();
                    WriteLiteral(@" class=""font-italic text-info col-12 col-sm-12 col-md-12"">Lựa chọn Tour cho gói</label>
                                <select name=""TourId"" id=""TourId"" class=""bg-info col-12 col-sm-12 col-md-12 border-dark rounded text-light text-center"" style=""height:60px;"" onchange=""updateHotelDropdown()"">
");
#nullable restore
#line 36 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Areas\Admin\Views\TourPackageAdmin\AddTourPackage.cshtml"
                                      
                                        foreach (Tour tour in tours)
                                        {

#line default
#line hidden
#nullable disable
                    WriteLiteral("                                            ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "93ef8601c64fb100d04bab0047d6d01443519a2a7951", async() => {
#nullable restore
#line 39 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Areas\Admin\Views\TourPackageAdmin\AddTourPackage.cshtml"
                                                                Write(tour.Name);

#line default
#line hidden
#nullable disable
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                    BeginWriteTagHelperAttribute();
#nullable restore
#line 39 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Areas\Admin\Views\TourPackageAdmin\AddTourPackage.cshtml"
                                               WriteLiteral(tour.Id);

#line default
#line hidden
#nullable disable
                    __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                    __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n");
#nullable restore
#line 40 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Areas\Admin\Views\TourPackageAdmin\AddTourPackage.cshtml"
                                        }
                                    

#line default
#line hidden
#nullable disable
                    WriteLiteral(@"                                </select>
                            </div>
                        </div>
                        <div class=""row"">
                            <div class=""col-6 col-sm-6 col-md-6"">
                                <label");
                    BeginWriteAttribute("for", " for=\"", 2777, "\"", 2783, 0);
                    EndWriteAttribute();
                    WriteLiteral(@" class=""font-italic text-info col-12 col-sm-12 col-md-12"">Số lượng người lớn (lớn hơn 12 tuổi)</label>
                                <input type=""text"" class=""rounded border-info text-info col-12 col-sm-12 col-md-12""
                                       style=""height:60px;"">
                            </div>
                            <div class=""col-6 col-sm-6 col-md-6"">
                                <label");
                    BeginWriteAttribute("for", " for=\"", 3208, "\"", 3214, 0);
                    EndWriteAttribute();
                    WriteLiteral(@" class=""font-italic text-info col-12 col-sm-12 col-md-12"">Số lượng trẻ em (nhỏ hơn 12 tuổi)</label>
                                <input type=""text"" class=""rounded border-info text-info col-12 col-sm-12 col-md-12""
                                       style=""height:60px;"">
                            </div>
                        </div>
                        <div class=""row"">
                            <div class=""col-4 col-sm-4 col-md-4"">
                                <label");
                    BeginWriteAttribute("for", " for=\"", 3711, "\"", 3717, 0);
                    EndWriteAttribute();
                    WriteLiteral(@" class=""font-italic text-info col-12 col-sm-12 col-md-12"">Ngày khởi hành</label>
                                <input type=""text"" class=""rounded border-info text-info col-12 col-sm-12 col-md-12""
                                       style=""height:60px;"">
                            </div>
                            <div class=""col-4 col-sm-4 col-md-4"">
                                <label");
                    BeginWriteAttribute("for", " for=\"", 4120, "\"", 4126, 0);
                    EndWriteAttribute();
                    WriteLiteral(" class=\"font-italic text-info col-12 col-sm-12 col-md-12\">Lựa chọn gói thời gian</label>\r\n                                <select");
                    BeginWriteAttribute("name", " name=\"", 4256, "\"", 4263, 0);
                    EndWriteAttribute();
                    BeginWriteAttribute("id", " id=\"", 4264, "\"", 4269, 0);
                    EndWriteAttribute();
                    WriteLiteral(" class=\"bg-info col-12 col-sm-12 col-md-12 border-dark rounded text-light text-center\" style=\"height:60px;\">\r\n");
#nullable restore
#line 66 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Areas\Admin\Views\TourPackageAdmin\AddTourPackage.cshtml"
                                      
                                        foreach(TimePackage item in timePackages)
                                        {

#line default
#line hidden
#nullable disable
                    WriteLiteral("                                            ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "93ef8601c64fb100d04bab0047d6d01443519a2a13592", async() => {
#nullable restore
#line 69 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Areas\Admin\Views\TourPackageAdmin\AddTourPackage.cshtml"
                                                                Write(item.Name);

#line default
#line hidden
#nullable disable
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                    BeginWriteTagHelperAttribute();
#nullable restore
#line 69 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Areas\Admin\Views\TourPackageAdmin\AddTourPackage.cshtml"
                                               WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
                    __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                    __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n");
#nullable restore
#line 70 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Areas\Admin\Views\TourPackageAdmin\AddTourPackage.cshtml"
                                        }
                                    

#line default
#line hidden
#nullable disable
                    WriteLiteral("                                </select>\r\n                            </div>\r\n                            <div class=\"col-4 col-sm-4 col-md-4\">\r\n                                <label");
                    BeginWriteAttribute("for", " for=\"", 4902, "\"", 4908, 0);
                    EndWriteAttribute();
                    WriteLiteral(@" class=""font-italic text-info col-12 col-sm-12 col-md-12"">Ngày kết thúc</label>
                                <input type=""text"" class=""rounded border-info text-info col-12 col-sm-12 col-md-12""
                                       style=""height:60px;"">
                            </div>
                        </div>
                        <div class=""row"">
                            <div class=""col-4 col-sm-4 col-md-4"">
                                <label");
                    BeginWriteAttribute("for", " for=\"", 5385, "\"", 5391, 0);
                    EndWriteAttribute();
                    WriteLiteral(@" class=""font-italic text-info col-12 col-sm-12 col-md-12"">Gía gốc</label>
                                <input type=""text"" class=""rounded border-info text-info col-12 col-sm-12 col-md-12""
                                       style=""height:60px;"">
                            </div>
                            <div class=""col-4 col-sm-4 col-md-4"">
                                <label");
                    BeginWriteAttribute("for", " for=\"", 5787, "\"", 5793, 0);
                    EndWriteAttribute();
                    WriteLiteral(@" class=""font-italic text-info col-12 col-sm-12 col-md-12"">Giảm giá</label>
                                <input type=""text"" class=""rounded border-info text-info col-12 col-sm-12 col-md-12""
                                       style=""height:60px;"">
                            </div>
                            <div class=""col-4 col-sm-4 col-md-4"">
                                <label");
                    BeginWriteAttribute("for", " for=\"", 6190, "\"", 6196, 0);
                    EndWriteAttribute();
                    WriteLiteral(@" class=""font-italic text-info col-12 col-sm-12 col-md-12"">Gía cuối cùng</label>
                                <input type=""text"" class=""rounded border-info text-info col-12 col-sm-12 col-md-12""
                                       style=""height:60px;"">
                            </div>
                        </div>
                        <div class=""row"">
                            <div class=""col-12 col-sm-12 col-md-12"">
                                <label");
                    BeginWriteAttribute("for", " for=\"", 6676, "\"", 6682, 0);
                    EndWriteAttribute();
                    WriteLiteral(" class=\"font-italic text-info col-12 col-sm-12 col-md-12\">Ghi chú chi tiết</label>\r\n                                <textarea");
                    BeginWriteAttribute("name", " name=\"", 6808, "\"", 6815, 0);
                    EndWriteAttribute();
                    BeginWriteAttribute("id", " id=\"", 6816, "\"", 6821, 0);
                    EndWriteAttribute();
                    WriteLiteral(@" style=""width: 100%;"" rows=""6"" class=""border-info rounded""></textarea>
                            </div>
                        </div>
                        <div class=""row"" style=""margin-top: 40px;"">
                            <div class=""col-3 col-sm-3 col-md-3""></div>
                            <button type=""submit"" style=""height:60px;"" class=""btn-outline-info rounded col-6 col-sm-6 col-md-6 justify-content-center align-items-center"">Thêm gói Tour</button>
                        </div>
                    ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
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
