#pragma checksum "E:\MyProjectPtit\VietTravelClientNet\VietTravelClient\VietTravelClient\Areas\Admin\Views\TourAdmin\TourManager.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "be0d88bbd24dfb6ff6e8289cb19bc63b853fadfe"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_TourAdmin_TourManager), @"mvc.1.0.view", @"/Areas/Admin/Views/TourAdmin/TourManager.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"be0d88bbd24dfb6ff6e8289cb19bc63b853fadfe", @"/Areas/Admin/Views/TourAdmin/TourManager.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f0efa66d1bcb428e72df198de36b8c870586a0c5", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_Admin_Views_TourAdmin_TourManager : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Icon/logo.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width:100px; height:100px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "be0d88bbd24dfb6ff6e8289cb19bc63b853fadfe4508", async() => {
                WriteLiteral("\r\n    <div class=\"row\" style=\"padding-top: 20px;\">\r\n        <div class=\"col-4 col-sm-4 col-md-4\">\r\n            <div class=\"col-12 col-sm-12 col-md-12 text-info font-weight-bold\" style=\"font-size: 30px; padding-left: 50px;\">\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "be0d88bbd24dfb6ff6e8289cb19bc63b853fadfe5021", async() => {
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
                WriteLiteral(@"
                LARS TRAVEL
            </div>
            <div class=""col-12 col-sm-12 col-md-12 text-info"" style=""padding-top: 30px; padding-left: 50px;"">Tìm kiếm Tour</div>
            <!-- <div class=""col-8 col-sm-8 col-md-8 text-info"" style=""padding-top: 20px; padding-left: 50px;"">Find your next holiday on 72
                cool packages!</div> -->
            <div class=""col-10 col-sm-10 col-md-10"" style=""padding-left: 50px; padding-top: 20px;"">
                <input type=""text"" class=""col-12 col-sm-12 col-md-12 rounded border-info"" style=""height:60px;"" placeholder=""NHẬP TÊN TOUR"">
                <input type=""text"" class=""col-12 col-sm-12 col-md-12 rounded border-info btn btn-info"" style=""height:60px; margin-top: 20px;"" value=""Tìm kiếm"">
            </div>

            <div class=""col-10 col-sm-10 col-md-10"" style=""padding-left: 50px; padding-top: 20px;"">
                <input type=""text"" class=""col-12 col-sm-12 col-md-12 rounded border-info btn btn-info"" style=""height:60px;"" value=""Thê");
                WriteLiteral(@"m mới Tour"">
            </div>
        </div>
        <div class=""col-8 col-sm-8 col-md-8"">
            <div id=""mycarousel"" class=""carousel slide carousel-fade row rounded"" data-ride=""carousel"">
                <!--Cho hiện thị chỉ số nếu muốn-->
                <ol class=""carousel-indicators"">
                    <li data-target=""#mycarousel"" data-slide-to=""0""");
                BeginWriteAttribute("class", " class=\"", 1841, "\"", 1849, 0);
                EndWriteAttribute();
                WriteLiteral("></li>\r\n                    <li data-target=\"#mycarousel\" data-slide-to=\"1\" class=\"active\"></li>\r\n                    <li data-target=\"#mycarousel\" data-slide-to=\"2\"");
                BeginWriteAttribute("class", " class=\"", 2015, "\"", 2023, 0);
                EndWriteAttribute();
                WriteLiteral(@"></li>
                </ol>
                <!--Hết tạo chỉ số-->
                <!--Các slide bên trong carousel-inner-->
                <div class=""carousel-inner col-12 col-sm-12 col-md-12"">
                    <!--Slide 1 thiết lập hiện thị đầu tiên .active-->
                    <div class=""carousel-item active"">
                        <img class=""d-block col-12 col-sm-12 col-md-12"" style=""height:500px""
                             src=""https://cdn.pixabay.com/photo/2013/07/18/20/25/boat-164977_640.jpg"">
                        <!--Cho thêm hiện thị thông tin-->
                        <div class=""carousel-caption d-none d-md-block"">
                            <h5>Tiêu đề Slide 1</h5>
                            <p>Dòng text chú thích cho Slide 1</p>
                        </div>
                    </div>
                    <!--Slide 2-->
                    <div class=""carousel-item "">
                        <img class=""d-block col-12 col-sm-12 col-md-12"" style=""height:500px""
");
                WriteLiteral(@"                             src=""https://cdn.pixabay.com/photo/2015/10/30/20/13/sea-1014710_640.jpg"">
                    </div>
                    <!--Slide 3-->
                    <div class=""carousel-item"">
                        <img class=""d-block col-12 col-sm-12 col-md-12"" style=""height:500px""
                             src=""https://cdn.pixabay.com/photo/2017/11/28/13/07/sunset-2983614_640.jpg"">
                    </div>
                    <!--Cho thêm khiển chuyển slide trước, sau nếu muốn-->
                    <a class=""carousel-control-prev"" href=""#mycarousel"" role=""button"" data-slide=""prev"">
                        <span class=""carousel-control-prev-icon"" aria-hidden=""true""></span> <span class=""sr-only"">Previous</span>
                    </a>
                    <a class=""carousel-control-next"" href=""#mycarousel"" role=""button"" data-slide=""next"">
                        <span class=""carousel-control-next-icon"" aria-hidden=""true""></span> <span class=""sr-only"">Next</span>
      ");
                WriteLiteral(@"              </a>
                    <!--Hết tạo điều khiển chuyển Slide-->
                </div>
            </div>
        </div>
    </div>
    <div class=""row"">
        <div class=""col-12 col-sm-12 col-md-12"">
            <div class=""row"" style=""margin-top: 20px;"">
                <div class=""col-12 col-sm-12 col-md-12"">
                    <div class=""row"">
                        <div class=""col-3 col-sm-3 col-md-3"" style=""margin-bottom:20px;"">
                            <div class=""card"">
                                <img class=""card-img-top"" style=""width: 80%; height: 60%; margin-left: 10%;""
                                     src=""https://vapa.vn/wp-content/uploads/2022/12/anh-3d-thien-nhien-010.jpg""");
                BeginWriteAttribute("alt", " alt=\"", 4812, "\"", 4818, 0);
                EndWriteAttribute();
                WriteLiteral(@">
                                <div class=""card-body"">
                                    <h5 class=""card-title"">Ảnh 4K - Đây là sử dụng tiêu đề chính</h5>
                                    <p class=""card-text"">Đây là phần nội dung của Card - Bo tròn 2 góc ở top</p>
                                    <a href=""#"" class=""btn btn-primary"">Update Tour</a>
                                </div>
                            </div>
                        </div>
                        <div class=""col-3 col-sm-3 col-md-3"">
                            <div class=""card"">
                                <img class=""card-img-top"" style=""width: 80%; height: 60%; margin-left: 10%;""
                                     src=""https://vapa.vn/wp-content/uploads/2022/12/anh-3d-thien-nhien-010.jpg""");
                BeginWriteAttribute("alt", " alt=\"", 5626, "\"", 5632, 0);
                EndWriteAttribute();
                WriteLiteral(@">
                                <div class=""card-body"">
                                    <h5 class=""card-title"">Ảnh 4K - Đây là sử dụng tiêu đề chính</h5>
                                    <p class=""card-text"">Đây là phần nội dung của Card - Bo tròn 2 góc ở top</p>
                                    <a href=""#"" class=""btn btn-primary"">Update Tour</a>
                                </div>
                            </div>
                        </div>
                        <div class=""col-3 col-sm-3 col-md-3"">
                            <div class=""card"">
                                <img class=""card-img-top"" style=""width: 80%; height: 60%; margin-left: 10%;""
                                     src=""https://vapa.vn/wp-content/uploads/2022/12/anh-3d-thien-nhien-010.jpg""");
                BeginWriteAttribute("alt", " alt=\"", 6440, "\"", 6446, 0);
                EndWriteAttribute();
                WriteLiteral(@">
                                <div class=""card-body"">
                                    <h5 class=""card-title"">Ảnh 4K - Đây là sử dụng tiêu đề chính</h5>
                                    <p class=""card-text"">Đây là phần nội dung của Card - Bo tròn 2 góc ở top</p>
                                    <a href=""#"" class=""btn btn-primary"">Update Tour</a>
                                </div>
                            </div>
                        </div>
                        <div class=""col-3 col-sm-3 col-md-3"">
                            <div class=""card"">
                                <img class=""card-img-top"" style=""width: 80%; height: 60%; margin-left: 10%;""
                                     src=""https://vapa.vn/wp-content/uploads/2022/12/anh-3d-thien-nhien-010.jpg""");
                BeginWriteAttribute("alt", " alt=\"", 7254, "\"", 7260, 0);
                EndWriteAttribute();
                WriteLiteral(@">
                                <div class=""card-body"">
                                    <h5 class=""card-title"">Ảnh 4K - Đây là sử dụng tiêu đề chính</h5>
                                    <p class=""card-text"">Đây là phần nội dung của Card - Bo tròn 2 góc ở top</p>
                                    <a href=""#"" class=""btn btn-primary"">Update Tour</a>
                                </div>
                            </div>
                        </div>
                        <div class=""col-3 col-sm-3 col-md-3"">
                            <div class=""card"">
                                <img class=""card-img-top"" style=""width: 80%; height: 60%; margin-left: 10%;""
                                     src=""https://vapa.vn/wp-content/uploads/2022/12/anh-3d-thien-nhien-010.jpg""");
                BeginWriteAttribute("alt", " alt=\"", 8068, "\"", 8074, 0);
                EndWriteAttribute();
                WriteLiteral(@">
                                <div class=""card-body"">
                                    <h5 class=""card-title"">Ảnh 4K - Đây là sử dụng tiêu đề chính</h5>
                                    <p class=""card-text"">Đây là phần nội dung của Card - Bo tròn 2 góc ở top</p>
                                    <a href=""#"" class=""btn btn-primary"">Update Tour</a>
                                </div>
                            </div>
                        </div>
                    </div>
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
