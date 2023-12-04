#pragma checksum "D:\MyProject\VietTravelClientNewDb\VietTravelClient\VietTravelClient\Areas\Admin\Views\TourAdmin\AddTour.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4fccb9c6e681050aa35ddf91da5fa16f240fa332"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_TourAdmin_AddTour), @"mvc.1.0.view", @"/Areas/Admin/Views/TourAdmin/AddTour.cshtml")]
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
#line 1 "D:\MyProject\VietTravelClientNewDb\VietTravelClient\VietTravelClient\Areas\Admin\Views\_ViewImports.cshtml"
using VietTravelClient;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\MyProject\VietTravelClientNewDb\VietTravelClient\VietTravelClient\Areas\Admin\Views\_ViewImports.cshtml"
using VietTravelClient.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4fccb9c6e681050aa35ddf91da5fa16f240fa332", @"/Areas/Admin/Views/TourAdmin/AddTour.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f0efa66d1bcb428e72df198de36b8c870586a0c5", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_TourAdmin_AddTour : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "TourAdmin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CreateTour", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("col-12 col-sm-12 col-md-12"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onsubmit", new global::Microsoft.AspNetCore.Html.HtmlString("return Validation()"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 4 "D:\MyProject\VietTravelClientNewDb\VietTravelClient\VietTravelClient\Areas\Admin\Views\TourAdmin\AddTour.cshtml"
  
    ViewData["Title"] = "Thêm Tour";
    List<City> cities = (List<City>)ViewData["Cities"];

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4fccb9c6e681050aa35ddf91da5fa16f240fa3325927", async() => {
                WriteLiteral(@"
    <div class=""row"" style=""margin-top: 20px;"">
        <div class=""media col-12 col-sm-12 col-md-12 border"" style=""margin-left: 10px; margin-right: 10px;"">
            <img class=""mr-3 rounded order-0 col-4 col-sm-4 col-md-4""
                 src=""https://vapa.vn/wp-content/uploads/2022/12/anh-3d-thien-nhien-010.jpg"">
            <div class=""media-body col-8 col-sm-8 col-md-8"" style=""margin-top: 40px;"">
                <div class=""row"">
                    <div class=""mt-0 text-info font-italic col-6 col-sm-6 col-md-6 border-bottom"" style=""font-size: 40px;"">THÊM TOUR DU LỊCH</div>
                    <div class=""mt-0 text-info font-italic col-6 col-sm-6 col-md-6 d-flex align-items-center border-bottom"" style=""font-size: 20px; margin-bottom: 100px;"">
                        LALOLI TRAVEL
                    </div>
                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4fccb9c6e681050aa35ddf91da5fa16f240fa3327066", async() => {
                    WriteLiteral("\r\n                        <div class=\"row\">\r\n                            <div class=\"col-6 col-sm-6 col-md-6\">\r\n                                <label");
                    BeginWriteAttribute("for", " for=\"", 1409, "\"", 1415, 0);
                    EndWriteAttribute();
                    WriteLiteral(@" class=""font-italic text-info col-12 col-sm-12 col-md-12"">Tên Tour du lịch<span style=""color: red;"">*</span></label>
                                <input type=""text"" id=""Name"" name=""Name"" class=""rounded border-info text-info col-12 col-sm-12 col-md-12""
                                       style=""height:60px;"">
                            </div>
                            <div class=""col-3 col-sm-3 col-md-3"">
                                <label");
                    BeginWriteAttribute("for", " for=\"", 1876, "\"", 1882, 0);
                    EndWriteAttribute();
                    WriteLiteral(@" class=""font-italic text-info col-12 col-sm-12 col-md-12"">Vĩ độ địa lý<span style=""color: red;"">*</span></label>
                                <input type=""text"" id=""CoordLat"" name=""CoordLat"" class=""rounded border-info text-info col-12 col-sm-12 col-md-12""
                                       style=""height:60px;"">
                            </div>
                            <div class=""col-3 col-sm-3 col-md-3"">
                                <label");
                    BeginWriteAttribute("for", " for=\"", 2347, "\"", 2353, 0);
                    EndWriteAttribute();
                    WriteLiteral(@" class=""font-italic text-info col-12 col-sm-12 col-md-12"">Kinh độ địa lý<span style=""color: red;"">*</span></label>
                                <input type=""text"" id=""CoordLon"" name=""CoordLon"" class=""rounded border-info text-info col-12 col-sm-12 col-md-12""
                                       style=""height:60px;"">
                            </div>
                        </div>
                        <div class=""row"" style=""margin-top: 20px;"">
                            <div class=""col-6 col-sm-6 col-md-6"">
                                <label");
                    BeginWriteAttribute("for", " for=\"", 2921, "\"", 2927, 0);
                    EndWriteAttribute();
                    WriteLiteral(@" class=""font-italic text-info col-12 col-sm-12 col-md-12"">Lựa chọn thành phố trực thuộc<span style=""color: red;"">*</span></label>
                                <select name=""CityId"" id=""CityId"" class=""bg-info col-12 col-sm-12 col-md-12 border-dark rounded text-light text-center"" style=""height:60px;"">
");
#nullable restore
#line 41 "D:\MyProject\VietTravelClientNewDb\VietTravelClient\VietTravelClient\Areas\Admin\Views\TourAdmin\AddTour.cshtml"
                                      
                                        foreach(City city in cities)
                                        {

#line default
#line hidden
#nullable disable
                    WriteLiteral("                                            ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4fccb9c6e681050aa35ddf91da5fa16f240fa33210430", async() => {
#nullable restore
#line 44 "D:\MyProject\VietTravelClientNewDb\VietTravelClient\VietTravelClient\Areas\Admin\Views\TourAdmin\AddTour.cshtml"
                                                                Write(city.Name);

#line default
#line hidden
#nullable disable
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                    BeginWriteTagHelperAttribute();
#nullable restore
#line 44 "D:\MyProject\VietTravelClientNewDb\VietTravelClient\VietTravelClient\Areas\Admin\Views\TourAdmin\AddTour.cshtml"
                                               WriteLiteral(city.Id);

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
#line 45 "D:\MyProject\VietTravelClientNewDb\VietTravelClient\VietTravelClient\Areas\Admin\Views\TourAdmin\AddTour.cshtml"
                                        }
                                    

#line default
#line hidden
#nullable disable
                    WriteLiteral("                                </select>\r\n                            </div>\r\n                            <div class=\"col-6\">\r\n                                <label");
                    BeginWriteAttribute("for", " for=\"", 3725, "\"", 3731, 0);
                    EndWriteAttribute();
                    WriteLiteral(@" class=""font-italic text-info col-12 col-sm-12 col-md-12"">Thêm ảnh<span style=""color: red;"">*</span></label>
                                <input type=""file"" class=""btn btn-info col-12 col-sm-12 col-md-12 border-dark rounded"" id=""Pictures"" name=""file"" style=""height:60px;"">
                            </div>
                        </div>
                        <div class=""row"">
                            <div class=""col-12 col-sm-12 col-md-12"">
                                <label");
                    BeginWriteAttribute("for", " for=\"", 4229, "\"", 4235, 0);
                    EndWriteAttribute();
                    WriteLiteral(@" class=""font-italic text-info col-12 col-sm-12 col-md-12"">Tiêu đề giới thiệu<span style=""color: red;"">*</span></label>
                                <input type=""text"" id=""TitleIntroduct"" name=""TitleIntroduct"" class=""rounded border-info text-info col-12 col-sm-12 col-md-12""
                                       style=""height:60px;"">
                            </div>
                        </div>
                        <div class=""row"">
                            <div class=""col-12 col-sm-12 col-md-12"">
                                <label");
                    BeginWriteAttribute("for", " for=\"", 4796, "\"", 4802, 0);
                    EndWriteAttribute();
                    WriteLiteral(@" class=""font-italic text-info col-12 col-sm-12 col-md-12"">Nội dung giới thiệu</label>
                                <textarea name=""ContentIntroduct"" id=""ContentIntroduct"" style=""width: 100%;"" rows=""6"" class=""border-info rounded""></textarea>
                            </div>
                        </div>
                        <div class=""row"" style=""margin-top: 40px;"">
                            <div class=""col-3 col-sm-3 col-md-3""></div>
                            <button type=""submit"" style=""height:60px;"" class=""btn-outline-info rounded col-6 col-sm-6 col-md-6 justify-content-center align-items-center"">Thêm mới</button>
                        </div>
                    ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Area = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n");
                WriteLiteral(@"    <div class=""modal"" id=""Warning"">
        <div class=""modal-dialog"" role=""document"">
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <h4 class=""modal-title text-info"">THÔNG BÁO</h4>
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>
                </div>
                <div class=""modal-body"">
                    <p id=""WarningMessage""></p>
                </div>
                <div class=""modal-footer"">
                    <button type=""button"" class=""btn btn-primary"" data-dismiss=""modal"">Đồng ý</button>
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
    function Validation() {
        var name = $('#Name').val();
        var address = $('#Address').val();
        var cityId = $('#CityId').val();
        var pictures = $('#Pictures').val();
        var titleIntroduct = $('#TitleIntroduct').val();
        var contentIntroduct = $('#ContentIntroduct').val();
        var coordLat = $('#CoordLat').val();
        var coordLon = $('#CoordLon').val();
        if (!ValidationField(name, ""Vui lòng nhập Tên khách sạn"")) return false;
        if (!ValidationField(address, ""Vui lòng nhập Địa chỉ khách sạn"")) return false;
        if (!ValidationField(cityId, ""Vui lòng chọn Thành phố trực thuộc"")) return false;
        if (!ValidationField(pictures, ""Vui lòng tải ảnh"")) return false;
        if (!ValidationField(titleIntroduct, ""Vui lòng nhập Tiêu đề giới thiệu"")) return false;
        if (!ValidationField(contentIntroduct, ""Vui lòng nhập Nội dung giới thiệu"")) return false;
        if (!ValidationField(coordLat, ""Vui lòng nhập Vĩ độ địa lý""");
            WriteLiteral(@")) return false;
        if (!ValidationField(coordLon, ""Vui lòng nhập Kinh độ địa lý"")) return false;
        return true;
    }
    function ValidationField(value, message) {
        if (value == """") {
            ShowMessage(message);
            return false;
        }
        return true;
    }
    function ShowMessage(value) {
        $('#WarningMessage').text(value)
        $('#Warning').modal('show');
    }
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
