#pragma checksum "E:\MyProjectPtit\VietTravelClientNet\VietTravelClient\VietTravelClient\Areas\Admin\Views\RestaurantAdmin\RestaurantInfo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d82b9861f6f81be35010aff706becdf43d377d4e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_RestaurantAdmin_RestaurantInfo), @"mvc.1.0.view", @"/Areas/Admin/Views/RestaurantAdmin/RestaurantInfo.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d82b9861f6f81be35010aff706becdf43d377d4e", @"/Areas/Admin/Views/RestaurantAdmin/RestaurantInfo.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f0efa66d1bcb428e72df198de36b8c870586a0c5", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_Admin_Views_RestaurantAdmin_RestaurantInfo : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("mr-3 rounded order-0 col-4 col-sm-4 col-md-4"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width: 100%; height: 600px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "RestaurantAdmin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "UpdateRestaurant", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 4 "E:\MyProjectPtit\VietTravelClientNet\VietTravelClient\VietTravelClient\Areas\Admin\Views\RestaurantAdmin\RestaurantInfo.cshtml"
  
    ViewData["Title"] = "Thông tin Nhà hàng";
    Restaurant Restaurant = (Restaurant)ViewData["Restaurant"];
    List<City> cities = (List<City>)ViewData["Cities"];

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d82b9861f6f81be35010aff706becdf43d377d4e7349", async() => {
                WriteLiteral("\r\n    <div class=\"row\" style=\"margin-top: 20px;\">\r\n        <div class=\"media col-12 col-sm-12 col-md-12 border\" style=\"margin-left: 10px; margin-right: 10px;\">\r\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "d82b9861f6f81be35010aff706becdf43d377d4e7790", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 559, "~/UploadImage/", 559, 14, true);
#nullable restore
#line 13 "E:\MyProjectPtit\VietTravelClientNet\VietTravelClient\VietTravelClient\Areas\Admin\Views\RestaurantAdmin\RestaurantInfo.cshtml"
AddHtmlAttributeValue("", 573, Restaurant.Pictures, 573, 22, false);

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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d82b9861f6f81be35010aff706becdf43d377d4e10213", async() => {
                    WriteLiteral("\r\n                        <div class=\"row\">\r\n                            <div class=\"col-6 col-sm-6 col-md-6\">\r\n                                <label");
                    BeginWriteAttribute("for", " for=\"", 1615, "\"", 1621, 0);
                    EndWriteAttribute();
                    WriteLiteral(@" class=""font-italic text-info col-12 col-sm-12 col-md-12"">Tên Khách sạn<span style=""color: red;"">*</span></label>
                                <input type=""text"" id=""Name"" name=""Name"" class=""rounded border-info text-info col-12 col-sm-12 col-md-12""
                                       style=""height:60px;""");
                    BeginWriteAttribute("value", " value=\"", 1935, "\"", 1959, 1);
#nullable restore
#line 29 "E:\MyProjectPtit\VietTravelClientNet\VietTravelClient\VietTravelClient\Areas\Admin\Views\RestaurantAdmin\RestaurantInfo.cshtml"
WriteAttributeValue("", 1943, Restaurant.Name, 1943, 16, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(">\r\n                                <input type=\"text\" id=\"Id\" name=\"Id\" class=\"rounded border-info text-info col-12 col-sm-12 col-md-12\"\r\n                                       style=\"height:60px;\"");
                    BeginWriteAttribute("value", " value=\"", 2157, "\"", 2179, 1);
#nullable restore
#line 31 "E:\MyProjectPtit\VietTravelClientNet\VietTravelClient\VietTravelClient\Areas\Admin\Views\RestaurantAdmin\RestaurantInfo.cshtml"
WriteAttributeValue("", 2165, Restaurant.Id, 2165, 14, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(" hidden>\r\n                            </div>\r\n                            <div class=\"col-6 col-sm-6 col-md-6\">\r\n                                <label");
                    BeginWriteAttribute("for", " for=\"", 2331, "\"", 2337, 0);
                    EndWriteAttribute();
                    WriteLiteral(@" class=""font-italic text-info col-12 col-sm-12 col-md-12"">Vị trí cụ thể<span style=""color: red;"">*</span></label>
                                <input type=""text"" id=""Address"" name=""Address"" class=""rounded border-info text-info col-12 col-sm-12 col-md-12""
                                       style=""height:60px;""");
                    BeginWriteAttribute("value", " value=\"", 2657, "\"", 2684, 1);
#nullable restore
#line 36 "E:\MyProjectPtit\VietTravelClientNet\VietTravelClient\VietTravelClient\Areas\Admin\Views\RestaurantAdmin\RestaurantInfo.cshtml"
WriteAttributeValue("", 2665, Restaurant.Address, 2665, 19, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(">\r\n                            </div>\r\n                        </div>\r\n                        <div class=\"row\" style=\"margin-top: 20px;\">\r\n                            <div class=\"col-6 col-sm-6 col-md-6\">\r\n                                <label");
                    BeginWriteAttribute("for", " for=\"", 2930, "\"", 2936, 0);
                    EndWriteAttribute();
                    WriteLiteral(@" class=""font-italic text-info col-12 col-sm-12 col-md-12"">Lựa chọn Thành phố trực thuộc<span style=""color: red;"">*</span></label>
                                <select name=""CityId"" id=""CityId"" class=""bg-info col-12 col-sm-12 col-md-12 border-dark rounded text-light text-center"" style=""height:60px;"">
");
#nullable restore
#line 43 "E:\MyProjectPtit\VietTravelClientNet\VietTravelClient\VietTravelClient\Areas\Admin\Views\RestaurantAdmin\RestaurantInfo.cshtml"
                                      
                                        foreach (City city in cities)
                                        {
                                            if (city.Id == Restaurant.CityId)
                                            {

#line default
#line hidden
#nullable disable
                    WriteLiteral("                                                ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d82b9861f6f81be35010aff706becdf43d377d4e14630", async() => {
#nullable restore
#line 48 "E:\MyProjectPtit\VietTravelClientNet\VietTravelClient\VietTravelClient\Areas\Admin\Views\RestaurantAdmin\RestaurantInfo.cshtml"
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
#line 48 "E:\MyProjectPtit\VietTravelClientNet\VietTravelClient\VietTravelClient\Areas\Admin\Views\RestaurantAdmin\RestaurantInfo.cshtml"
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
#line 49 "E:\MyProjectPtit\VietTravelClientNet\VietTravelClient\VietTravelClient\Areas\Admin\Views\RestaurantAdmin\RestaurantInfo.cshtml"
                                            }
                                            else
                                            {

#line default
#line hidden
#nullable disable
                    WriteLiteral("                                                ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d82b9861f6f81be35010aff706becdf43d377d4e17487", async() => {
#nullable restore
#line 52 "E:\MyProjectPtit\VietTravelClientNet\VietTravelClient\VietTravelClient\Areas\Admin\Views\RestaurantAdmin\RestaurantInfo.cshtml"
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
#line 52 "E:\MyProjectPtit\VietTravelClientNet\VietTravelClient\VietTravelClient\Areas\Admin\Views\RestaurantAdmin\RestaurantInfo.cshtml"
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
#line 53 "E:\MyProjectPtit\VietTravelClientNet\VietTravelClient\VietTravelClient\Areas\Admin\Views\RestaurantAdmin\RestaurantInfo.cshtml"
                                            }
                                        }
                                    

#line default
#line hidden
#nullable disable
                    WriteLiteral("                                </select>\r\n                            </div>\r\n                            <div class=\"col-6\">\r\n                                <label");
                    BeginWriteAttribute("for", " for=\"", 4159, "\"", 4165, 0);
                    EndWriteAttribute();
                    WriteLiteral(@" class=""font-italic text-info col-12 col-sm-12 col-md-12"">Thêm ảnh</label>
                                <input type=""file"" class=""btn btn-info col-12 col-sm-12 col-md-12 border-dark rounded"" id=""Pictures"" name=""file"" style=""height:60px;"">
                            </div>
                        </div>
                        <div class=""row"">
                            <div class=""col-6 col-sm-6 col-md-6"">
                                <label");
                    BeginWriteAttribute("for", " for=\"", 4626, "\"", 4632, 0);
                    EndWriteAttribute();
                    WriteLiteral(@" class=""font-italic text-info col-12 col-sm-12 col-md-12"">Tiêu đề giới thiệu<span style=""color: red;"">*</span></label>
                                <input type=""text"" id=""TitleIntroduct"" name=""TitleIntroduct"" class=""rounded border-info text-info col-12 col-sm-12 col-md-12""
                                       style=""height:60px;""");
                    BeginWriteAttribute("value", " value=\"", 4971, "\"", 5005, 1);
#nullable restore
#line 67 "E:\MyProjectPtit\VietTravelClientNet\VietTravelClient\VietTravelClient\Areas\Admin\Views\RestaurantAdmin\RestaurantInfo.cshtml"
WriteAttributeValue("", 4979, Restaurant.TitleIntroduct, 4979, 26, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(">\r\n                            </div>\r\n                            <div class=\"col-6 col-sm-6 col-md-6\">\r\n                                <label");
                    BeginWriteAttribute("for", " for=\"", 5150, "\"", 5156, 0);
                    EndWriteAttribute();
                    WriteLiteral(@" class=""font-italic text-info col-12 col-sm-12 col-md-12"">Số điện thoại<span style=""color: red;"">*</span></label>
                                <input type=""text"" id=""PhoneNumber"" name=""PhoneNumber"" class=""rounded border-info text-info col-12 col-sm-12 col-md-12""
                                       style=""height:60px;""");
                    BeginWriteAttribute("value", " value=\"", 5484, "\"", 5515, 1);
#nullable restore
#line 72 "E:\MyProjectPtit\VietTravelClientNet\VietTravelClient\VietTravelClient\Areas\Admin\Views\RestaurantAdmin\RestaurantInfo.cshtml"
WriteAttributeValue("", 5492, Restaurant.PhoneNumber, 5492, 23, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(">\r\n                            </div>\r\n                        </div>\r\n                        <div class=\"row\">\r\n                            <div class=\"col-12 col-sm-12 col-md-12\">\r\n                                <label");
                    BeginWriteAttribute("for", " for=\"", 5738, "\"", 5744, 0);
                    EndWriteAttribute();
                    WriteLiteral(@" class=""font-italic text-info col-12 col-sm-12 col-md-12"">Nội dung giới thiệu<span style=""color: red;"">*</span></label>
                                <textarea name=""ContentIntroduct"" id=""ContentIntroduct"" style=""width: 100%;"" rows=""6"" class=""border-info rounded"">");
#nullable restore
#line 78 "E:\MyProjectPtit\VietTravelClientNet\VietTravelClient\VietTravelClient\Areas\Admin\Views\RestaurantAdmin\RestaurantInfo.cshtml"
                                                                                                                                             Write(Restaurant.ContentIntroduct);

#line default
#line hidden
#nullable disable
                    WriteLiteral(@"</textarea>
                            </div>
                        </div>
                        <div class=""row"" style=""margin-top: 40px;"">
                            <div class=""col-3 col-sm-3 col-md-3""></div>
                            <button type=""submit"" style=""height:60px;"" class=""btn-outline-info rounded col-6 col-sm-6 col-md-6 justify-content-center align-items-center"">Cập nhật Nhà hàng</button>
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
        if (!ValidationField(name, ""Vui lòng nhập Tên khách sạn"")) return false;
        if (!ValidationField(address, ""Vui lòng nhập Địa chỉ khách sạn"")) return false;
        if (!ValidationField(cityId, ""Vui lòng chọn Thành phố trực thuộc"")) return false;
        if (!ValidationField(titleIntroduct, ""Vui lòng nhập Tiêu đề giới thiệu"")) return false;
        if (!ValidationField(phoneNumber, ""Vui lòng nhập Số điện thoại"")) return false;
        if (!ValidationField(contentIntroduct, ""Vui lòng nhập Nội dung giới thiệu"")) return false;
        return true;
    }
    function ValidationField(value, message) {
        if (value == """") {
            ShowMessage(message)");
            WriteLiteral(";\r\n            return false;\r\n        }\r\n        return true;\r\n    }\r\n    function ShowMessage(value) {\r\n        $(\'#WarningMessage\').text(value)\r\n        $(\'#Warning\').modal(\'show\');\r\n    }\r\n</script>");
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
