#pragma checksum "E:\MyProjectPtit\VietTravelClientNet\VietTravelClient\VietTravelClient\Areas\Admin\Views\CityAdmin\CityInfo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "55c9d8e5bd64cc11fab70e551c1dd1ee14cc57d5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_CityAdmin_CityInfo), @"mvc.1.0.view", @"/Areas/Admin/Views/CityAdmin/CityInfo.cshtml")]
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
#line 1 "E:\MyProjectPtit\VietTravelClientNet\VietTravelClient\VietTravelClient\Areas\Admin\Views\_ViewImports.cshtml"
using VietTravelClient;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\MyProjectPtit\VietTravelClientNet\VietTravelClient\VietTravelClient\Areas\Admin\Views\_ViewImports.cshtml"
using VietTravelClient.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"55c9d8e5bd64cc11fab70e551c1dd1ee14cc57d5", @"/Areas/Admin/Views/CityAdmin/CityInfo.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f0efa66d1bcb428e72df198de36b8c870586a0c5", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_Admin_Views_CityAdmin_CityInfo : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "CityAdmin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "UpdateCity", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("col-12 col-sm-12 col-md-12"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "E:\MyProjectPtit\VietTravelClientNet\VietTravelClient\VietTravelClient\Areas\Admin\Views\CityAdmin\CityInfo.cshtml"
  
    ViewData["Title"] = "Thông tin thành phố";
    City city = (City) ViewData["City"];

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "55c9d8e5bd64cc11fab70e551c1dd1ee14cc57d55127", async() => {
                WriteLiteral(@"
    <div class=""row"" style=""margin-top: 20px;"">
        <div class=""media col-12 col-sm-12 col-md-12 border"" style=""margin-left: 10px; margin-right: 10px;"">
            <img class=""mr-3 rounded order-0 col-4 col-sm-4 col-md-4""
                 src=""https://vapa.vn/wp-content/uploads/2022/12/anh-3d-thien-nhien-010.jpg"">
            <div class=""media-body col-8 col-sm-8 col-md-8 "" style=""margin-top: 40px;"">
                <div class=""row"">
                    <div class=""mt-0 text-info font-italic col-6 col-sm-6 col-md-6 border-bottom"" style=""font-size: 40px;"">
                        THÔNG TIN THÀNH PHỐ
                        DU LỊCH
                    </div>
                    <div class=""mt-0 text-info font-italic col-6 col-sm-6 col-md-6 d-flex align-items-center border-bottom""
                         style=""font-size: 20px; margin-bottom: 100px;"">
                        VIET TRAVEL
                    </div>
                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "55c9d8e5bd64cc11fab70e551c1dd1ee14cc57d56374", async() => {
                    WriteLiteral("\r\n                        <div class=\"row\">\r\n                            <div class=\"col-6 col-sm-6 col-md-6\">\r\n                                <label");
                    BeginWriteAttribute("for", " for=\"", 1451, "\"", 1457, 0);
                    EndWriteAttribute();
                    WriteLiteral(" class=\"font-italic text-info col-12 col-sm-12 col-md-12\">Tên thành phố du lịch</label>\r\n                                <input type=\"text\" id=\"Name\" name=\"Name\" class=\"rounded border-info text-info col-12 col-sm-12 col-md-12\" style=\"height:60px;\"");
                    BeginWriteAttribute("value", " value=\"", 1705, "\"", 1723, 1);
#nullable restore
#line 27 "E:\MyProjectPtit\VietTravelClientNet\VietTravelClient\VietTravelClient\Areas\Admin\Views\CityAdmin\CityInfo.cshtml"
WriteAttributeValue("", 1713, city.Name, 1713, 10, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(">\r\n                                <input type=\"text\" id=\"Id\" name=\"Id\" class=\"rounded border-info text-info col-12 col-sm-12 col-md-12\" style=\"height:60px;\"");
                    BeginWriteAttribute("value", " value=\"", 1881, "\"", 1897, 1);
#nullable restore
#line 28 "E:\MyProjectPtit\VietTravelClientNet\VietTravelClient\VietTravelClient\Areas\Admin\Views\CityAdmin\CityInfo.cshtml"
WriteAttributeValue("", 1889, city.Id, 1889, 8, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(" hidden>\r\n                            </div>\r\n                            <div class=\"col-6 col-sm-6 col-md-6\">\r\n                                <label");
                    BeginWriteAttribute("for", " for=\"", 2049, "\"", 2055, 0);
                    EndWriteAttribute();
                    WriteLiteral(" class=\"font-italic text-info col-12 col-sm-12 col-md-12\">Tải ảnh</label>\r\n                                <input type=\"file\"");
                    BeginWriteAttribute("name", " name=\"", 2181, "\"", 2188, 0);
                    EndWriteAttribute();
                    WriteLiteral(@" id=""Picture"" class=""btn btn-info col-12 col-sm-12 col-md-12 border-dark rounded"" style=""height:60px;"">
                            </div>
                        </div>
                        <div class=""row"">
                            <div class=""col-6 col-sm-6 col-md-6"">
                                <label");
                    BeginWriteAttribute("for", " for=\"", 2510, "\"", 2516, 0);
                    EndWriteAttribute();
                    WriteLiteral(@" class=""font-italic text-info col-12 col-sm-12 col-md-12"">Tiêu đề giới thiệu</label>
                                <input type=""text"" id=""TitleIntroduct"" name=""TitleIntroduct"" class=""rounded border-info text-info col-12 col-sm-12 col-md-12"" style=""height:60px;""");
                    BeginWriteAttribute("value", " value=\"", 2781, "\"", 2809, 1);
#nullable restore
#line 38 "E:\MyProjectPtit\VietTravelClientNet\VietTravelClient\VietTravelClient\Areas\Admin\Views\CityAdmin\CityInfo.cshtml"
WriteAttributeValue("", 2789, city.TitleIntroduct, 2789, 20, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(">\r\n                            </div>\r\n                            <div class=\"col-6 col-sm-6 col-md-6\">\r\n                                <label");
                    BeginWriteAttribute("for", " for=\"", 2954, "\"", 2960, 0);
                    EndWriteAttribute();
                    WriteLiteral(@" class=""font-italic text-info col-12 col-sm-12 col-md-12"">Nội dung giới thiệu</label>
                                <input type=""text"" id=""ContentIntroduct"" name=""ContentIntroduct"" class=""rounded border-info text-info col-12 col-sm-12 col-md-12"" style=""height:60px;""");
                    BeginWriteAttribute("value", " value=\"", 3230, "\"", 3260, 1);
#nullable restore
#line 42 "E:\MyProjectPtit\VietTravelClientNet\VietTravelClient\VietTravelClient\Areas\Admin\Views\CityAdmin\CityInfo.cshtml"
WriteAttributeValue("", 3238, city.ContentIntroduct, 3238, 22, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(">\r\n                            </div>\r\n                        </div>\r\n                        <div class=\"row\">\r\n                            <div class=\"col-12 col-sm-12 col-md-12\">\r\n                                <label");
                    BeginWriteAttribute("for", " for=\"", 3483, "\"", 3489, 0);
                    EndWriteAttribute();
                    WriteLiteral(@" class=""font-italic text-info col-12 col-sm-12 col-md-12"">Ghi chú chi tiết</label>
                                <textarea name=""Description"" id=""Description"" style=""width: 100%;"" rows=""6""
                                          class=""border-info rounded"">");
#nullable restore
#line 49 "E:\MyProjectPtit\VietTravelClientNet\VietTravelClient\VietTravelClient\Areas\Admin\Views\CityAdmin\CityInfo.cshtml"
                                                                 Write(city.Description);

#line default
#line hidden
#nullable disable
                    WriteLiteral(@"</textarea>
                            </div>
                        </div>
                        <div class=""row"" style=""margin-top: 40px;"">
                            <div class=""col-3 col-sm-3 col-md-3""></div>
                            <button type=""submit"" style=""height:60px;""
                                    class=""btn-outline-info rounded col-6 col-sm-6 col-md-6 justify-content-center align-items-center"">
                                Cập nhật thông tin thành phố
                            </button>
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
