#pragma checksum "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Views\Restaurant\RestaurantDetail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5eb46f1f7d7aa3c52c85c5b308e1999a9a5a809d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Restaurant_RestaurantDetail), @"mvc.1.0.view", @"/Views/Restaurant/RestaurantDetail.cshtml")]
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
#line 1 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Views\_ViewImports.cshtml"
using VietTravelClient;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Views\_ViewImports.cshtml"
using VietTravelClient.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5eb46f1f7d7aa3c52c85c5b308e1999a9a5a809d", @"/Views/Restaurant/RestaurantDetail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f0efa66d1bcb428e72df198de36b8c870586a0c5", @"/Views/_ViewImports.cshtml")]
    public class Views_Restaurant_RestaurantDetail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Icon/logo.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width:100px; height:100px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("d-block col-12 col-sm-12 col-md-12"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("height: 500px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("mx-3 rounded order-0"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width: 100px; height: 100px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Views\Restaurant\RestaurantDetail.cshtml"
  
    ViewData["Title"] = "Chi tiết Nhà hàng";
    Restaurant restaurant = (Restaurant)ViewData["Restaurant"];
    List<Evaluate> evaluates = (List<Evaluate>)ViewData["Evaluates"];

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5eb46f1f7d7aa3c52c85c5b308e1999a9a5a809d6213", async() => {
                WriteLiteral(@"
    <div class=""row"" style=""margin-top: 20px;"">
        <div class=""col-6 col-sm-6 col-md-6"">
            <div class=""row"">
                <div class=""col-12 col-sm-12 col-md-12 text-info font-weight-bold"" style=""font-size: 30px; padding-left: 50px;"">
                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "5eb46f1f7d7aa3c52c85c5b308e1999a9a5a809d6759", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                    LALOLI TRAVEL\r\n                </div>\r\n                <div class=\"col-12 col-sm-12 col-md-12 text-info font-italic\" style=\"padding-left: 50px; font-size: 25px;\">\r\n                    ");
#nullable restore
#line 18 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Views\Restaurant\RestaurantDetail.cshtml"
               Write(restaurant.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </div>\r\n                <div class=\"col-12 col-sm-12 col-md-12 text-info font-italic\" style=\"padding-left: 50px;\">\r\n                    ");
#nullable restore
#line 21 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Views\Restaurant\RestaurantDetail.cshtml"
               Write(restaurant.TitleIntroduct);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </div>\r\n                <div class=\"col-12 col-sm-12 col-md-12 font-italic\" style=\"padding-left: 50px; margin-top: 20px;\">\r\n                    ");
#nullable restore
#line 24 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Views\Restaurant\RestaurantDetail.cshtml"
               Write(restaurant.ContentIntroduct);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </div>\r\n                <div class=\"col-12 col-sm-12 col-md-12 font-italic\" style=\"padding-left: 50px; margin-top: 20px;\">\r\n                    Gía theo đầu người: ");
#nullable restore
#line 27 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Views\Restaurant\RestaurantDetail.cshtml"
                                   Write(restaurant.PriceDefault.ToString("N2"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@" VND/người
                </div>
            </div>
        </div>
        <div class=""col-6 col-sm-6 col-md-6"">
            <div id=""mycarousel"" class=""carousel slide carousel-fade row rounded"" data-ride=""carousel"">
                <ol class=""carousel-indicators"">
                    <li data-target=""#mycarousel"" data-slide-to=""0""");
                BeginWriteAttribute("class", " class=\"", 1819, "\"", 1827, 0);
                EndWriteAttribute();
                WriteLiteral("></li>\r\n                    <li data-target=\"#mycarousel\" data-slide-to=\"1\" class=\"active\"></li>\r\n                    <li data-target=\"#mycarousel\" data-slide-to=\"2\"");
                BeginWriteAttribute("class", " class=\"", 1993, "\"", 2001, 0);
                EndWriteAttribute();
                WriteLiteral("></li>\r\n                </ol>\r\n                <div class=\"carousel-inner col-12\">\r\n                    <div class=\"carousel-item\">\r\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "5eb46f1f7d7aa3c52c85c5b308e1999a9a5a809d10895", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 2264, "~/UploadImage/", 2264, 14, true);
#nullable restore
#line 41 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Views\Restaurant\RestaurantDetail.cshtml"
AddHtmlAttributeValue("", 2278, restaurant.Pictures, 2278, 22, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                        <div class=\"carousel-caption d-none d-md-block\">\r\n                            <h5>");
#nullable restore
#line 43 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Views\Restaurant\RestaurantDetail.cshtml"
                           Write(restaurant.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h5>\r\n                            <p>");
#nullable restore
#line 44 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Views\Restaurant\RestaurantDetail.cshtml"
                          Write(restaurant.TitleIntroduct);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                        </div>\r\n                    </div>\r\n                    <div class=\"carousel-item active\">\r\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "5eb46f1f7d7aa3c52c85c5b308e1999a9a5a809d13524", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 2741, "~/UploadImage/", 2741, 14, true);
#nullable restore
#line 49 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Views\Restaurant\RestaurantDetail.cshtml"
AddHtmlAttributeValue("", 2755, restaurant.Pictures, 2755, 22, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                        <div class=\"carousel-caption d-none d-md-block\">\r\n                            <h5>");
#nullable restore
#line 51 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Views\Restaurant\RestaurantDetail.cshtml"
                           Write(restaurant.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h5>\r\n                            <p>");
#nullable restore
#line 52 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Views\Restaurant\RestaurantDetail.cshtml"
                          Write(restaurant.TitleIntroduct);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                        </div>\r\n                    </div>\r\n                    <div class=\"carousel-item\">\r\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "5eb46f1f7d7aa3c52c85c5b308e1999a9a5a809d16146", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 3211, "~/UploadImage/", 3211, 14, true);
#nullable restore
#line 57 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Views\Restaurant\RestaurantDetail.cshtml"
AddHtmlAttributeValue("", 3225, restaurant.Pictures, 3225, 22, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                        <div class=\"carousel-caption d-none d-md-block\">\r\n                            <h5>");
#nullable restore
#line 59 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Views\Restaurant\RestaurantDetail.cshtml"
                           Write(restaurant.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h5>\r\n                            <p>");
#nullable restore
#line 60 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Views\Restaurant\RestaurantDetail.cshtml"
                          Write(restaurant.TitleIntroduct);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</p>
                        </div>
                    </div>
                    <a class=""carousel-control-prev"" href=""#mycarousel"" role=""button"" data-slide=""prev"">
                        <span class=""carousel-control-prev-icon"" aria-hidden=""true""></span> <span class=""sr-only"">Previous</span>
                    </a>
                    <a class=""carousel-control-next"" href=""#mycarousel"" role=""button"" data-slide=""next"">
                        <span class=""carousel-control-next-icon"" aria-hidden=""true""></span> <span class=""sr-only"">Next</span>
                    </a>
                </div>
            </div>
        </div>
    </div>

    <div class=""row"" style=""margin-top: 50px;"">
        <div class=""text-center col-12 col-sm-12 col-md-12 text-info font-italic font-weight-bold"" style=""font-size: 20px; margin-bottom: 20px;"">CÁC BÌNH LUẬN NỔI BẬT</div>
        <ul class=""list-unstyled col-12 col-sm-12 col-md-12"">
");
#nullable restore
#line 77 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Views\Restaurant\RestaurantDetail.cshtml"
              
                foreach (Evaluate item in evaluates)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <li class=\"media\" style=\"margin-left: 40px; margin-bottom: 20px; width: 90%;\">\r\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "5eb46f1f7d7aa3c52c85c5b308e1999a9a5a809d20049", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 4637, "~/UploadImage/", 4637, 14, true);
#nullable restore
#line 81 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Views\Restaurant\RestaurantDetail.cshtml"
AddHtmlAttributeValue("", 4651, item.User.Picture, 4651, 20, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                        <div class=\"media-body\">\r\n                            <h5 class=\"mt-0 text-info\">");
#nullable restore
#line 84 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Views\Restaurant\RestaurantDetail.cshtml"
                                                  Write(item.User.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h5>\r\n                            <!-- <h6 class=\"mt-0 text-info\">(linhnh@gmail.com)</h6> -->\r\n                            <p>\r\n                                ");
#nullable restore
#line 87 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Views\Restaurant\RestaurantDetail.cshtml"
                           Write(item.Content);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            </p>\r\n                        </div>\r\n                    </li>\r\n");
#nullable restore
#line 91 "D:\MyProject\VietTravelClientDev\VietTravelClient\VietTravelClient\Views\Restaurant\RestaurantDetail.cshtml"
                }
            

#line default
#line hidden
#nullable disable
                WriteLiteral("        </ul>\r\n    </div>\r\n\r\n");
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
