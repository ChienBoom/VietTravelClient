#pragma checksum "D:\MyProject\VietTravelClientNewDb\VietTravelClient\VietTravelClient\Views\Register\RegisterInfo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "61a97ba04a3bd41c54f35d5546d27785ee298e3a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Register_RegisterInfo), @"mvc.1.0.view", @"/Views/Register/RegisterInfo.cshtml")]
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
#line 1 "D:\MyProject\VietTravelClientNewDb\VietTravelClient\VietTravelClient\Views\_ViewImports.cshtml"
using VietTravelClient;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\MyProject\VietTravelClientNewDb\VietTravelClient\VietTravelClient\Views\_ViewImports.cshtml"
using VietTravelClient.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"61a97ba04a3bd41c54f35d5546d27785ee298e3a", @"/Views/Register/RegisterInfo.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f0efa66d1bcb428e72df198de36b8c870586a0c5", @"/Views/_ViewImports.cshtml")]
    public class Views_Register_RegisterInfo : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("rounded order-0 col-12 col-sm-12 col-md-12 user-avatar"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/UploadImage/ava.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "Nam", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "Nữ", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "Khác", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Register", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "SaveRegister", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("col-12 col-sm-12 col-md-12"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 1 "D:\MyProject\VietTravelClientNewDb\VietTravelClient\VietTravelClient\Views\Register\RegisterInfo.cshtml"
  
    ViewData["Title"] = "Thông tin đăng ký";

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "61a97ba04a3bd41c54f35d5546d27785ee298e3a6926", async() => {
                WriteLiteral(@"
    <div class=""row"" style=""margin-top: 20px;"">
        <div class=""media col-12 col-sm-12 col-md-12 border"" style=""margin-left: 10px; margin-right: 10px;"">
            <div class="" col-4 col-sm-4 col-md-4"" style=""width: 100%; height: 500px;"">
                <div class=""col-12 col-sm-12 col-md-12 user-avatar row"">
                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "61a97ba04a3bd41c54f35d5546d27785ee298e3a7538", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                </div>
                <div class=""col-12 col-sm-12 col-md-12 row"">
                    <div class=""col-3 col-sm-3 col-md-3""></div>
                    <button class=""col-6 col-sm-6 col-md-6 btn btn-info"" style=""margin-top: 10px;"">Thay đổi ảnh đại diện</button>
                </div>
            </div>
            <div class=""media-body col-8 col-sm-8 col-md-8"" style=""margin-top: 40px;"">
                <div class=""row"">
                    <div class=""mt-0 text-info font-italic col-6 col-sm-6 col-md-6 border-bottom"" style=""font-size: 40px;"">THÔNG TIN ĐĂNG KÝ TÀI KHOẢN</div>
                    <div class=""mt-0 text-info font-italic col-6 col-sm-6 col-md-6 d-flex align-items-center border-bottom""
                         style=""font-size: 20px; margin-bottom: 100px;"">
                        VIET TRAVEL
                    </div>
                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "61a97ba04a3bd41c54f35d5546d27785ee298e3a9624", async() => {
                    WriteLiteral("\r\n                        <div class=\"row\">\r\n                            <div class=\"col-6 col-sm-6 col-md-6\">\r\n                                <label");
                    BeginWriteAttribute("for", " for=\"", 1691, "\"", 1697, 0);
                    EndWriteAttribute();
                    WriteLiteral(@" class=""font-italic text-info col-12"">Họ và tên</label>
                                <input type=""text"" class=""rounded border-info text-info col-12"" name=""Name"" id=""Name"" style=""height:60px;"">
                            </div>
                            <div class=""col-6 col-sm-6 col-md-6"">
                                <label");
                    BeginWriteAttribute("for", " for=\"", 2037, "\"", 2043, 0);
                    EndWriteAttribute();
                    WriteLiteral(@" class=""font-italic text-info col-12"">Ngày sinh</label>
                                <input type=""datetime-local"" class=""rounded border-info text-info col-12"" name=""DateOfBirth"" id=""DateOfBirth"" style=""height:60px;"">
                            </div>
                        </div>
                        <div class=""row"">
                            <div class=""col-6 col-sm-6 col-md-6"">
                                <label");
                    BeginWriteAttribute("for", " for=\"", 2482, "\"", 2488, 0);
                    EndWriteAttribute();
                    WriteLiteral(" class=\"font-italic text-info col-12\">Giới tính</label>\r\n                                <select name=\"Sex\" id=\"Sex\" class=\"rounded border-info text-info col-12\" style=\"height:60px;\">\r\n                                    ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "61a97ba04a3bd41c54f35d5546d27785ee298e3a11576", async() => {
                        WriteLiteral("Nam");
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_2.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n                                    ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "61a97ba04a3bd41c54f35d5546d27785ee298e3a12897", async() => {
                        WriteLiteral("Nữ");
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_3.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n                                    ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "61a97ba04a3bd41c54f35d5546d27785ee298e3a14217", async() => {
                        WriteLiteral("Khác");
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_4.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n                                </select>\r\n                            </div>\r\n                            <div class=\"col-6 col-sm-6 col-md-6\">\r\n                                <label");
                    BeginWriteAttribute("for", " for=\"", 3068, "\"", 3074, 0);
                    EndWriteAttribute();
                    WriteLiteral(" class=\"font-italic text-info col-12\">Email</label>\r\n                                <input type=\"text\" name=\"Email\" id=\"Email\" class=\"rounded border-info text-info col-12\" style=\"height:60px;\"");
                    BeginWriteAttribute("value", " value=\"", 3268, "\"", 3301, 1);
#nullable restore
#line 46 "D:\MyProject\VietTravelClientNewDb\VietTravelClient\VietTravelClient\Views\Register\RegisterInfo.cshtml"
WriteAttributeValue("", 3276, ViewData["AccountEmail"], 3276, 25, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(" readonly>\r\n                            </div>\r\n                        </div>\r\n                        <div class=\"row\">\r\n                            <div class=\"col-6 col-sm-6 col-md-6\">\r\n                                <label");
                    BeginWriteAttribute("for", " for=\"", 3530, "\"", 3536, 0);
                    EndWriteAttribute();
                    WriteLiteral(@" class=""font-italic text-info col-12"">Số điện thoại</label>
                                <input type=""text"" name=""PhoneNumber"" id=""PhoneNumber"" class=""rounded border-info text-info col-12"" style=""height:60px;"">
                            </div>
                            <div class=""col-6 col-sm-6 col-md-6"">
                                <label");
                    BeginWriteAttribute("for", " for=\"", 3894, "\"", 3900, 0);
                    EndWriteAttribute();
                    WriteLiteral(@" class=""font-italic text-info col-12"">Địa chỉ</label>
                                <input type=""text"" name=""Address"" id=""Address"" class=""rounded border-info text-info col-12"" style=""height:60px;"">
                            </div>
                        </div>
                        <div class=""row"" hidden>
                            <div class=""col-6 col-sm-6 col-md-6"">
                                <label");
                    BeginWriteAttribute("for", " for=\"", 4326, "\"", 4332, 0);
                    EndWriteAttribute();
                    WriteLiteral(" class=\"font-italic text-info col-12\">Tài khoản</label>\r\n                                <input type=\"text\" name=\"Username\" id=\"Username\" class=\"rounded border-info text-info col-12\"");
                    BeginWriteAttribute("value", " value=\"", 4515, "\"", 4548, 1);
#nullable restore
#line 62 "D:\MyProject\VietTravelClientNewDb\VietTravelClient\VietTravelClient\Views\Register\RegisterInfo.cshtml"
WriteAttributeValue("", 4523, ViewData["AccountEmail"], 4523, 25, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(" style=\"height:60px;\">\r\n                            </div>\r\n                            <div class=\"col-6 col-sm-6 col-md-6\">\r\n                                <label");
                    BeginWriteAttribute("for", " for=\"", 4714, "\"", 4720, 0);
                    EndWriteAttribute();
                    WriteLiteral(" class=\"font-italic text-info col-12\">Mật khẩu</label>\r\n                                <input type=\"password\" name=\"Password\" id=\"Password\" class=\"rounded border-info text-info col-12\"");
                    BeginWriteAttribute("value", " value=\"", 4906, "\"", 4942, 1);
#nullable restore
#line 66 "D:\MyProject\VietTravelClientNewDb\VietTravelClient\VietTravelClient\Views\Register\RegisterInfo.cshtml"
WriteAttributeValue("", 4914, ViewData["AccountPassword"], 4914, 28, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(@" style=""height:60px;"">
                            </div>
                        </div>
                        <div class=""row"" style=""margin-top: 40px;"">
                            <div class=""col-3 col-sm-3 col-md-3""></div>
                            <button type=""submit"" style=""height:60px;""
                                    class=""btn-outline-info rounded col-6 col-sm-6 col-md-6 justify-content-center align-items-center"">
                                Đăng ký thông tin
                            </button>
                        </div>
                    ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_6.Value;
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
    //debugger
    function Validation(){
        var name = $('#Name').val();
        var dateObBirth = $('#DateOfBirth').val();
        var sex = $('#Sex').val();
        var email = $('#Email').val();
        var phoneNumber = $('#PhoneNumber').val();
        var address = $('#Address').val();
        if(!ValidationField(name, ""Vui lòng nhập Tên"")) return false;
        if (!ValidationField(dateObBirth, ""Vui lòng nhập Ngày sinh"")) return false;
        if (!ValidationField(sex, ""Vui lòng chọn Giới tính"")) return false;
        if (!ValidationField(email, ""Vui lòng nhập Email"")) return false;
        if (!ValidationField(phoneNumber, ""Vui lòng nhập Số điện thoại"")) return false;
        if (!ValidationField(address, ""Vui lòng nhập Địa chỉ"")) return false;
        return true;
    }
    function ValidationField(value, message){
        if(value == """"){
            ShowMessage(message);
            return false;
        }
        return true;
    }
    function ShowMessage(v");
            WriteLiteral(@"alue) {
        $('#WarningMessage').text(value)
        $('#Warning').modal('show');
    }
    //function SaveRegister() {
    //    if (!ValidateRequired($(""#Name"").val())) return false;
    //    if (!ValidateRequired($(""#Sex"").val())) return false;
    //    if (!ValidateRequired($(""#Email"").val())) return false;
    //    if (!ValidateRequired($(""#DateOfBirth"").val())) return false;
    //    if (!ValidateRequired($(""#PhoneNumber"").val())) return false;
    //    if (!ValidateRequired($(""#Address"").val())) return false;
    //    return true;
    //}
    //function ValidateRequired(value) {
    //    if(value == null || valuev===""""){
    //        alert(""Yêu cầu nhập đầy đủ thông tin"");
    //        return false;
    //    }
    //    return true;
    //}
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
