#pragma checksum "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Areas\Admin\Views\TimePackageAdmin\TimePackageManager.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "00a861be701b36c53d272e3efcfb4bc4fe5b034a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_TimePackageAdmin_TimePackageManager), @"mvc.1.0.view", @"/Areas/Admin/Views/TimePackageAdmin/TimePackageManager.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"00a861be701b36c53d272e3efcfb4bc4fe5b034a", @"/Areas/Admin/Views/TimePackageAdmin/TimePackageManager.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f0efa66d1bcb428e72df198de36b8c870586a0c5", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_Admin_Views_TimePackageAdmin_TimePackageManager : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "TimePackageAdmin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CreateTimePackage", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onsubmit", new global::Microsoft.AspNetCore.Html.HtmlString("return ValidationCre()"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "UpdateTimePackage", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onsubmit", new global::Microsoft.AspNetCore.Html.HtmlString("return ValidationUpd()"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DeleteTimePackage", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 4 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Areas\Admin\Views\TimePackageAdmin\TimePackageManager.cshtml"
  
    ViewData["Title"] = "Thêm gói thời gian";
    List<TimePackage> timePackages = (List<TimePackage>)ViewData["TimePackages"];

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "00a861be701b36c53d272e3efcfb4bc4fe5b034a6550", async() => {
                WriteLiteral(@"
    <div class=""row"" style=""margin-top: 40px; margin-bottom: 10px;"">
        <div class=""col-10""></div>
        <div class=""col-2"">
            <button class=""btn btn-info"" data-toggle=""modal"" data-target=""#createTimePackage"">Thêm mới </button>
            <div id=""createTimePackage"" class=""modal fade"" tabindex=""-1"" role=""dialog"">
                <div class=""modal-dialog"" role=""document"">
                    <div class=""modal-content"">
                        <div class=""modal-header"">
                            <h4 class=""modal-title text-info"">THÊM MỚI GÓI THỜI GIAN</h4>
                            <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                                <span aria-hidden=""true"">&times;</span>
                            </button>
                        </div>
                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "00a861be701b36c53d272e3efcfb4bc4fe5b034a7713", async() => {
                    WriteLiteral(@"
                            <div class=""modal-body"">
                                <label for=""NameCre"" class=""text-info font-italic"">Nhập tên<span style=""color: red;"">*</span></label>
                                <input type=""text"" class=""col-12 rounded border-info text-info"" style=""height: 40px; margin-bottom: 20px;"" id=""NameCre"" name=""Name"">
                                <label for=""DescriptionCre"" class=""text-info font-italic"">Nhập ghi chú chi tiết<span style=""color: red;"">*</span></label>
                                <textarea name=""Description"" id=""DescriptionCre"" cols=""30"" rows=""6"" class=""col-12 rounded border-info text-info""></textarea>
                            </div>
                            <div class=""modal-footer"">
                                <button type=""button"" class=""btn btn-default"" data-dismiss=""modal"">Hủy bỏ</button>
                                <button type=""submit"" class=""btn btn-primary"">Thêm mới</button>
                            </div>
             ");
                    WriteLiteral("           ");
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
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class=""row"">
        <div class=""col-1""></div>
        <table class=""col-10 col-sm-10 col-md-10 border"" style=""border: 1px; border-color: black;"">
            <tr");
                BeginWriteAttribute("class", " class=\"", 2586, "\"", 2594, 0);
                EndWriteAttribute();
                WriteLiteral(@">
                <th style=""width : 5%"" class=""text-center bg-info text-light border"">STT</th>
                <th style=""width : 20%"" class=""text-center bg-info text-light border"">Tên gói</th>
                <th style=""width : 50%"" class=""text-center bg-info text-light border"">Ghi chú chi tiết</th>
                <th style=""width : 25%"" class=""text-center bg-info text-light border""></th>
            </tr>
");
#nullable restore
#line 48 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Areas\Admin\Views\TimePackageAdmin\TimePackageManager.cshtml"
              
                for (int i = 0; i < timePackages.Count; i++)
                {
                    var item = timePackages[i];

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <tr>\r\n                        <td class=\"text-center border\">");
#nullable restore
#line 53 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Areas\Admin\Views\TimePackageAdmin\TimePackageManager.cshtml"
                                                   Write(i + 1);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                        <td class=\"text-center border\">");
#nullable restore
#line 54 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Areas\Admin\Views\TimePackageAdmin\TimePackageManager.cshtml"
                                                  Write(item.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                        <td class=\"text-center border\">");
#nullable restore
#line 55 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Areas\Admin\Views\TimePackageAdmin\TimePackageManager.cshtml"
                                                  Write(item.Description);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                        <td class=\"text-center border\"><button class=\"btn btn-info\" data-toggle=\"modal\" data-target=\"#updateTimePackage");
#nullable restore
#line 56 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Areas\Admin\Views\TimePackageAdmin\TimePackageManager.cshtml"
                                                                                                                                   Write(item.Id);

#line default
#line hidden
#nullable disable
                WriteLiteral("\">Sửa</button> <button class=\"btn btn-info\" data-toggle=\"modal\" data-target=\"#deleteTimePackage");
#nullable restore
#line 56 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Areas\Admin\Views\TimePackageAdmin\TimePackageManager.cshtml"
                                                                                                                                                                                                                                            Write(item.Id);

#line default
#line hidden
#nullable disable
                WriteLiteral("\">Xóa</button> </td>\r\n\r\n                        <div");
                BeginWriteAttribute("id", " id=\"", 3709, "\"", 3741, 2);
                WriteAttributeValue("", 3714, "updateTimePackage", 3714, 17, true);
#nullable restore
#line 58 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Areas\Admin\Views\TimePackageAdmin\TimePackageManager.cshtml"
WriteAttributeValue("", 3731, item.Id, 3731, 10, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" class=""modal fade"" tabindex=""-1"" role=""dialog"">
                            <div class=""modal-dialog"" role=""document"">
                                <div class=""modal-content"">
                                    <div class=""modal-header"">
                                        <h4 class=""modal-title text-info"">CẬP NHẬT GÓI THỜI GIAN</h4>
                                        <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                                            <span aria-hidden=""true"">&times;</span>
                                        </button>
                                    </div>
                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "00a861be701b36c53d272e3efcfb4bc4fe5b034a15876", async() => {
                    WriteLiteral(@"
                                        <div class=""modal-body"">
                                            <label for=""NameUpd"" class=""text-info font-italic"">Nhập tên<span style=""color: red;"">*</span></label>
                                            <input type=""text"" class=""col-12 rounded border-info text-info"" style=""height: 40px; margin-bottom: 20px;"" id=""NameUpd"" name=""Name""");
                    BeginWriteAttribute("value", " value=\"", 4952, "\"", 4970, 1);
#nullable restore
#line 70 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Areas\Admin\Views\TimePackageAdmin\TimePackageManager.cshtml"
WriteAttributeValue("", 4960, item.Name, 4960, 10, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(">\r\n                                            <input type=\"text\" class=\"col-12 rounded border-info text-info\" style=\"height: 40px; margin-bottom: 20px;\" id=\"IdUpd\" name=\"Id\"");
                    BeginWriteAttribute("value", " value=\"", 5145, "\"", 5161, 1);
#nullable restore
#line 71 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Areas\Admin\Views\TimePackageAdmin\TimePackageManager.cshtml"
WriteAttributeValue("", 5153, item.Id, 5153, 8, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(@" hidden>
                                            <label for=""DescriptionUpd"" class=""text-info font-italic"">Nhập ghi chú chi tiết<span style=""color: red;"">*</span></label>
                                            <textarea name=""Description"" id=""DescriptionUpd"" cols=""30"" rows=""6"" class=""col-12 rounded border-info text-info"">");
#nullable restore
#line 73 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Areas\Admin\Views\TimePackageAdmin\TimePackageManager.cshtml"
                                                                                                                                                        Write(item.Description);

#line default
#line hidden
#nullable disable
                    WriteLiteral(@"</textarea>
                                        </div>
                                        <div class=""modal-footer"">
                                            <button type=""button"" class=""btn btn-default"" data-dismiss=""modal"">Hủy bỏ</button>
                                            <button type=""submit"" class=""btn btn-primary"">Cập nhật</button>
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
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n\r\n                        <div");
                BeginWriteAttribute("id", " id=\"", 6110, "\"", 6142, 2);
                WriteAttributeValue("", 6115, "deleteTimePackage", 6115, 17, true);
#nullable restore
#line 84 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Areas\Admin\Views\TimePackageAdmin\TimePackageManager.cshtml"
WriteAttributeValue("", 6132, item.Id, 6132, 10, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" class=""modal fade"" tabindex=""-1"" role=""dialog"">
                            <div class=""modal-dialog"" role=""document"">
                                <div class=""modal-content"">
                                    <div class=""modal-header"">
                                        <h4 class=""modal-title text-info"">BẠN CHẮC CHẮN MUỐN XÓA GÓI THỜI GIAN NÀY?</h4>
                                        <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                                            <span aria-hidden=""true"">&times;</span>
                                        </button>
                                    </div>
                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "00a861be701b36c53d272e3efcfb4bc4fe5b034a22167", async() => {
                    WriteLiteral(@"
                                        <div class=""modal-body"">
                                            <label for=""Name"" class=""text-info font-italic"">Tên gói<span style=""color: red;"">*</span></label>
                                            <input type=""text"" class=""col-12 rounded border-info text-info"" style=""height: 40px; margin-bottom: 20px;""");
                    BeginWriteAttribute("id", " id=\"", 7309, "\"", 7314, 0);
                    EndWriteAttribute();
                    BeginWriteAttribute("name", " name=\"", 7315, "\"", 7322, 0);
                    EndWriteAttribute();
                    BeginWriteAttribute("value", " value=\"", 7323, "\"", 7341, 1);
#nullable restore
#line 96 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Areas\Admin\Views\TimePackageAdmin\TimePackageManager.cshtml"
WriteAttributeValue("", 7331, item.Name, 7331, 10, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(">\r\n                                            <input type=\"text\" class=\"col-12 rounded border-info text-info\" style=\"height: 40px; margin-bottom: 20px;\" id=\"TimePackageId\" name=\"TimePackageId\"");
                    BeginWriteAttribute("value", " value=\"", 7535, "\"", 7551, 1);
#nullable restore
#line 97 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Areas\Admin\Views\TimePackageAdmin\TimePackageManager.cshtml"
WriteAttributeValue("", 7543, item.Id, 7543, 8, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(">\r\n                                            <label for=\"Description\" class=\"text-info font-italic\">Ghi chú chi tiết<span style=\"color: red;\">*</span></label>\r\n                                            <textarea");
                    BeginWriteAttribute("name", " name=\"", 7767, "\"", 7774, 0);
                    EndWriteAttribute();
                    BeginWriteAttribute("id", " id=\"", 7775, "\"", 7780, 0);
                    EndWriteAttribute();
                    WriteLiteral(" cols=\"30\" rows=\"6\" class=\"col-12 rounded border-info text-info\">");
#nullable restore
#line 99 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Areas\Admin\Views\TimePackageAdmin\TimePackageManager.cshtml"
                                                                                                                               Write(item.Description);

#line default
#line hidden
#nullable disable
                    WriteLiteral(@"</textarea>
                                        </div>
                                        <div class=""modal-footer"">
                                            <button type=""button"" class=""btn btn-default"" data-dismiss=""modal"">Hủy bỏ</button>
                                            <button type=""submit"" class=""btn btn-primary"">Xác nhận</button>
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
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_7.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n                    </tr>\r\n");
#nullable restore
#line 110 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Areas\Admin\Views\TimePackageAdmin\TimePackageManager.cshtml"
                } 
                

#line default
#line hidden
#nullable disable
                WriteLiteral("        </table>\r\n    </div>\r\n\r\n");
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
    function ValidationCre() {
        var name = $('#NameCre').val();
        var description = $('#DescriptionCre').val();
        if (!ValidationField(name, ""Vui lòng nhập Tên gói"")) return false;
        if (!ValidationField(description, ""Vui lòng nhập Nội dung gói"")) return false;
        return true;
    }
    function ValidationUpd() {
        var name = $('#NameUpd').val();
        var description = $('#DescriptionUpd').val();
        if (!ValidationField(name, ""Vui lòng nhập Tên gói"")) return false;
        if (!ValidationField(description, ""Vui lòng nhập Nội dung gói"")) return false;
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
