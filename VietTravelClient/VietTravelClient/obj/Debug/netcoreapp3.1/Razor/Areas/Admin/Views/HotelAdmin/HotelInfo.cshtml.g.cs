#pragma checksum "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Areas\Admin\Views\HotelAdmin\HotelInfo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c53feef0ded5dc66b1e965b5ffe43d03b7a3a90e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_HotelAdmin_HotelInfo), @"mvc.1.0.view", @"/Areas/Admin/Views/HotelAdmin/HotelInfo.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c53feef0ded5dc66b1e965b5ffe43d03b7a3a90e", @"/Areas/Admin/Views/HotelAdmin/HotelInfo.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f0efa66d1bcb428e72df198de36b8c870586a0c5", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_HotelAdmin_HotelInfo : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("mr-3 rounded order-0 col-4 col-sm-4 col-md-4"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width: 100%; height: 600px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "HotelAdmin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "UpdateHotel", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("col-12 col-sm-12 col-md-12"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onsubmit", new global::Microsoft.AspNetCore.Html.HtmlString("return Validation()"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Areas\Admin\Views\HotelAdmin\HotelInfo.cshtml"
  
    ViewData["Title"] = "Thông tin Khách sạn";
    Hotel hotel = (Hotel)ViewData["Hotel"];
    List<City> cities = (List<City>)ViewData["Cities"];

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c53feef0ded5dc66b1e965b5ffe43d03b7a3a90e7198", async() => {
                WriteLiteral("\r\n    <div class=\"row\" style=\"margin-top: 20px;\">\r\n        <div class=\"media col-12 col-sm-12 col-md-12 border\" style=\"margin-left: 10px; margin-right: 10px;\">\r\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "c53feef0ded5dc66b1e965b5ffe43d03b7a3a90e7639", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 540, "~/UploadImage/", 540, 14, true);
#nullable restore
#line 13 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Areas\Admin\Views\HotelAdmin\HotelInfo.cshtml"
AddHtmlAttributeValue("", 554, hotel.Pictures, 554, 17, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
            <div class=""media-body col-8 col-sm-8 col-md-8 "" style=""margin-top: 40px;"">
                <div class=""row"">
                    <div class=""mt-0 text-info font-italic col-6 col-sm-6 col-md-6 border-bottom"" style=""font-size: 40px;"">
                        THÔNG TIN TOUR
                        DU LỊCH
                    </div>
                    <div class=""mt-0 text-info font-italic col-6 col-sm-6 col-md-6 d-flex align-items-center border-bottom""
                         style=""font-size: 20px; margin-bottom: 100px;"">
                        VIET TRAVEL
                    </div>
                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c53feef0ded5dc66b1e965b5ffe43d03b7a3a90e10043", async() => {
                    WriteLiteral("\r\n                        <div class=\"row\">\r\n                            <div class=\"col-6 col-sm-6 col-md-6\">\r\n                                <label");
                    BeginWriteAttribute("for", " for=\"", 1581, "\"", 1587, 0);
                    EndWriteAttribute();
                    WriteLiteral(@" class=""font-italic text-info col-12 col-sm-12 col-md-12"">Tên Khách sạn<span style=""color: red;"">*</span></label>
                                <input type=""text"" id=""Name"" name=""Name"" class=""rounded border-info text-info col-12 col-sm-12 col-md-12""
                                       style=""height:60px;""");
                    BeginWriteAttribute("value", " value=\"", 1901, "\"", 1920, 1);
#nullable restore
#line 29 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Areas\Admin\Views\HotelAdmin\HotelInfo.cshtml"
WriteAttributeValue("", 1909, hotel.Name, 1909, 11, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(">\r\n                                <input type=\"text\" id=\"Id\" name=\"Id\" class=\"rounded border-info text-info col-12 col-sm-12 col-md-12\"\r\n                                       style=\"height:60px;\"");
                    BeginWriteAttribute("value", " value=\"", 2118, "\"", 2135, 1);
#nullable restore
#line 31 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Areas\Admin\Views\HotelAdmin\HotelInfo.cshtml"
WriteAttributeValue("", 2126, hotel.Id, 2126, 9, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(" hidden>\r\n                            </div>\r\n                            <div class=\"col-6 col-sm-6 col-md-6\">\r\n                                <label");
                    BeginWriteAttribute("for", " for=\"", 2287, "\"", 2293, 0);
                    EndWriteAttribute();
                    WriteLiteral(@" class=""font-italic text-info col-12 col-sm-12 col-md-12"">Vị trí cụ thể<span style=""color: red;"">*</span></label>
                                <input type=""text"" id=""Address"" name=""Address"" class=""rounded border-info text-info col-12 col-sm-12 col-md-12""
                                       style=""height:60px;""");
                    BeginWriteAttribute("value", " value=\"", 2613, "\"", 2635, 1);
#nullable restore
#line 36 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Areas\Admin\Views\HotelAdmin\HotelInfo.cshtml"
WriteAttributeValue("", 2621, hotel.Address, 2621, 14, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(">\r\n                            </div>\r\n                        </div>\r\n                        <div class=\"row\" style=\"margin-top: 20px;\">\r\n                            <div class=\"col-6 col-sm-6 col-md-6\">\r\n                                <label");
                    BeginWriteAttribute("for", " for=\"", 2881, "\"", 2887, 0);
                    EndWriteAttribute();
                    WriteLiteral(@" class=""font-italic text-info col-12 col-sm-12 col-md-12"">Lựa chọn Thành phố trực thuộc<span style=""color: red;"">*</span></label>
                                <select name=""CityId"" id=""CityId"" class=""bg-info col-12 col-sm-12 col-md-12 border-dark rounded text-light text-center"" style=""height:60px;"">
");
#nullable restore
#line 43 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Areas\Admin\Views\HotelAdmin\HotelInfo.cshtml"
                                      
                                        foreach (City city in cities)
                                        {
                                            if (city.Id == hotel.CityId)
                                            {

#line default
#line hidden
#nullable disable
                    WriteLiteral("                                                ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c53feef0ded5dc66b1e965b5ffe43d03b7a3a90e14383", async() => {
#nullable restore
#line 48 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Areas\Admin\Views\HotelAdmin\HotelInfo.cshtml"
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
#line 48 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Areas\Admin\Views\HotelAdmin\HotelInfo.cshtml"
                                                   WriteLiteral(city.Id);

#line default
#line hidden
#nullable disable
                    __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                    __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    BeginWriteTagHelperAttribute();
                    __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                    __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n");
#nullable restore
#line 49 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Areas\Admin\Views\HotelAdmin\HotelInfo.cshtml"
                                            }
                                            else
                                            {

#line default
#line hidden
#nullable disable
                    WriteLiteral("                                                ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c53feef0ded5dc66b1e965b5ffe43d03b7a3a90e17198", async() => {
#nullable restore
#line 52 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Areas\Admin\Views\HotelAdmin\HotelInfo.cshtml"
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
#line 52 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Areas\Admin\Views\HotelAdmin\HotelInfo.cshtml"
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
#line 53 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Areas\Admin\Views\HotelAdmin\HotelInfo.cshtml"
                                            }
                                        }
                                    

#line default
#line hidden
#nullable disable
                    WriteLiteral("                                </select>\r\n                            </div>\r\n                            <div class=\"col-6\">\r\n                                <label");
                    BeginWriteAttribute("for", " for=\"", 4105, "\"", 4111, 0);
                    EndWriteAttribute();
                    WriteLiteral(@" class=""font-italic text-info col-12 col-sm-12 col-md-12"">Thêm ảnh</label>
                                <input type=""file"" class=""btn btn-info col-12 col-sm-12 col-md-12 border-dark rounded"" id=""Pictures"" name=""file"" style=""height:60px;"">
                            </div>
                        </div>
                        <div class=""row"">
                            <div class=""col-6 col-sm-6 col-md-6"">
                                <label for=""PriceHour"" class=""font-italic text-info col-12 col-sm-12 col-md-12"">Tiêu đề giới thiệu<span style=""color: red;"">*</span></label>
                                <input type=""text"" id=""PriceHour"" name=""PriceHour"" class=""rounded border-info text-info col-12 col-sm-12 col-md-12""
                                       style=""height:60px;""");
                    BeginWriteAttribute("value", " value=\"", 4916, "\"", 4940, 1);
#nullable restore
#line 67 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Areas\Admin\Views\HotelAdmin\HotelInfo.cshtml"
WriteAttributeValue("", 4924, hotel.PriceHour, 4924, 16, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(">\r\n                            </div>\r\n                            <div class=\"col-6 col-sm-6 col-md-6\">\r\n                                <label");
                    BeginWriteAttribute("for", " for=\"", 5085, "\"", 5091, 0);
                    EndWriteAttribute();
                    WriteLiteral(@" class=""font-italic text-info col-12 col-sm-12 col-md-12"">Số điện thoại<span style=""color: red;"">*</span></label>
                                <input type=""text"" id=""PhoneNumber"" name=""PhoneNumber"" class=""rounded border-info text-info col-12 col-sm-12 col-md-12""
                                       style=""height:60px;""");
                    BeginWriteAttribute("value", " value=\"", 5419, "\"", 5445, 1);
#nullable restore
#line 72 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Areas\Admin\Views\HotelAdmin\HotelInfo.cshtml"
WriteAttributeValue("", 5427, hotel.PhoneNumber, 5427, 18, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(@">
                            </div>
                        </div>
                        <div class=""row"">
                            <div class=""col-12 col-sm-12 col-md-12"">
                                <label for=""TitleIntroduct"" class=""font-italic text-info col-12 col-sm-12 col-md-12"">Tiêu đề giới thiệu<span style=""color: red;"">*</span></label>
                                <input type=""text"" id=""TitleIntroduct"" name=""TitleIntroduct"" class=""rounded border-info text-info col-12 col-sm-12 col-md-12""
                                       style=""height:60px;""");
                    BeginWriteAttribute("value", " value=\"", 6027, "\"", 6056, 1);
#nullable restore
#line 79 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Areas\Admin\Views\HotelAdmin\HotelInfo.cshtml"
WriteAttributeValue("", 6035, hotel.TitleIntroduct, 6035, 21, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(">\r\n                            </div>\r\n                        </div>\r\n                        <div class=\"row\">\r\n                            <div class=\"col-12 col-sm-12 col-md-12\">\r\n                                <label");
                    BeginWriteAttribute("for", " for=\"", 6279, "\"", 6285, 0);
                    EndWriteAttribute();
                    WriteLiteral(@" class=""font-italic text-info col-12 col-sm-12 col-md-12"">Nội dung giới thiệu<span style=""color: red;"">*</span></label>
                                <textarea name=""ContentIntroduct"" id=""ContentIntroduct"" style=""width: 100%;"" rows=""6"" class=""border-info rounded"">");
#nullable restore
#line 85 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Areas\Admin\Views\HotelAdmin\HotelInfo.cshtml"
                                                                                                                                             Write(hotel.ContentIntroduct);

#line default
#line hidden
#nullable disable
                    WriteLiteral(@"</textarea>
                            </div>
                        </div>
                        <div class=""row"" style=""margin-top: 40px;"">
                            <div class=""col-3 col-sm-3 col-md-3""></div>
                            <button type=""submit"" style=""height:60px;"" class=""btn-outline-info rounded col-6 col-sm-6 col-md-6 justify-content-center align-items-center"">Cập nhật Khách sạn</button>
                        </div>
                    ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Area = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_6.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
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
        var titleIntroduct = $('#TitleIntroduct').val();
        var phoneNumber = $('#PhoneNumber').val();
        var contentIntroduct = $('#ContentIntroduct').val();
        var priceHour = $('#PriceHour').val();
        if (!ValidationField(name, ""Vui lòng nhập Tên khách sạn"")) return false;
        if (!ValidationField(address, ""Vui lòng nhập Địa chỉ khách sạn"")) return false;
        if (!ValidationField(cityId, ""Vui lòng chọn Thành phố trực thuộc"")) return false;
        if (!ValidationField(titleIntroduct, ""Vui lòng nhập Tiêu đề giới thiệu"")) return false;
        if (!ValidationField(phoneNumber, ""Vui lòng nhập Số điện thoại"")) return false;
        if (!ValidationField(contentIntroduct, ""Vui lòng nhập Nội dung giới thiệu"")) return false;
        if (!ValidationField(priceHour, ""Vui lòng nhập Giá cho Khách sạn(VND/h)"")) return f");
            WriteLiteral(@"alse;
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
