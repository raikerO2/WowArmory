#pragma checksum "C:\Users\rares\source\repos\WowArmory\WowArmory\Views\Zones\Zone.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3db54e9171a78700ae0b03e8f4053882b98a67a3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Zones_Zone), @"mvc.1.0.view", @"/Views/Zones/Zone.cshtml")]
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
#line 1 "C:\Users\rares\source\repos\WowArmory\WowArmory\Views\_ViewImports.cshtml"
using WowArmory;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\rares\source\repos\WowArmory\WowArmory\Views\_ViewImports.cshtml"
using WowArmory.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3db54e9171a78700ae0b03e8f4053882b98a67a3", @"/Views/Zones/Zone.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7d3bb9c42c45193cb0439f3f2c1cf60d3c241837", @"/Views/_ViewImports.cshtml")]
    public class Views_Zones_Zone : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ZoneModel>
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\rares\source\repos\WowArmory\WowArmory\Views\Zones\Zone.cshtml"
   
    ViewData["Title"] = Model.Name;
    string imgFormat = ".jpg";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>");
#nullable restore
#line 8 "C:\Users\rares\source\repos\WowArmory\WowArmory\Views\Zones\Zone.cshtml"
Write(ViewBag.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n<h4>");
#nullable restore
#line 9 "C:\Users\rares\source\repos\WowArmory\WowArmory\Views\Zones\Zone.cshtml"
Write(Html.DisplayFor(model => model.Category));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n<h4>");
#nullable restore
#line 10 "C:\Users\rares\source\repos\WowArmory\WowArmory\Views\Zones\Zone.cshtml"
Write(Html.DisplayFor(model => model.Territory));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3db54e9171a78700ae0b03e8f4053882b98a67a34042", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 3, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 239, "~/Maps/", 239, 7, true);
#nullable restore
#line 11 "C:\Users\rares\source\repos\WowArmory\WowArmory\Views\Zones\Zone.cshtml"
AddHtmlAttributeValue("", 246, Model.Name, 246, 11, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\rares\source\repos\WowArmory\WowArmory\Views\Zones\Zone.cshtml"
AddHtmlAttributeValue("", 257, imgFormat, 257, 10, false);

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ZoneModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
