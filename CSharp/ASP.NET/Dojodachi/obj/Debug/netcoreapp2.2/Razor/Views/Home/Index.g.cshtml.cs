#pragma checksum "C:\Users\Aric Jeon\Desktop\Dojo_assignments\CSharp\ASP.NET\Dojodachi\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0b2a2efc62819673cf067d104020d0bb5463ba89"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
#line 1 "C:\Users\Aric Jeon\Desktop\Dojo_assignments\CSharp\ASP.NET\Dojodachi\Views\_ViewImports.cshtml"
using Dojodachi;

#line default
#line hidden
#line 1 "C:\Users\Aric Jeon\Desktop\Dojo_assignments\CSharp\ASP.NET\Dojodachi\Views\Home\Index.cshtml"
using Dojodachi.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0b2a2efc62819673cf067d104020d0bb5463ba89", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9f823666e3659d58cebeb316cce4284db07d26c9", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Dojodachi>
    {
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(43, 37, true);
            WriteLiteral("\r\n<!DOCTYPE html>\r\n<html lang=\"en\">\r\n");
            EndContext();
            BeginContext(80, 367, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0b2a2efc62819673cf067d104020d0bb5463ba893400", async() => {
                BeginContext(86, 354, true);
                WriteLiteral(@"
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>Dojodachi!</title>
    <link rel=""stylesheet"" href=""https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css"" integrity=""sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk"" crossorigin=""anonymous"">
");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(447, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(449, 870, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0b2a2efc62819673cf067d104020d0bb5463ba894947", async() => {
                BeginContext(455, 99, true);
                WriteLiteral("\r\n    <div class=\"container\">\r\n        <div class=\"row\">\r\n            <div class=\"col-3\">Fullness: ");
                EndContext();
                BeginContext(555, 14, false);
#line 15 "C:\Users\Aric Jeon\Desktop\Dojo_assignments\CSharp\ASP.NET\Dojodachi\Views\Home\Index.cshtml"
                                    Write(Model.Fullness);

#line default
#line hidden
                EndContext();
                BeginContext(569, 50, true);
                WriteLiteral("</div>\r\n            <div class=\"col-3\">Happiness: ");
                EndContext();
                BeginContext(620, 15, false);
#line 16 "C:\Users\Aric Jeon\Desktop\Dojo_assignments\CSharp\ASP.NET\Dojodachi\Views\Home\Index.cshtml"
                                     Write(Model.Happiness);

#line default
#line hidden
                EndContext();
                BeginContext(635, 46, true);
                WriteLiteral("</div>\r\n            <div class=\"col-3\">Meals: ");
                EndContext();
                BeginContext(682, 10, false);
#line 17 "C:\Users\Aric Jeon\Desktop\Dojo_assignments\CSharp\ASP.NET\Dojodachi\Views\Home\Index.cshtml"
                                 Write(Model.Meal);

#line default
#line hidden
                EndContext();
                BeginContext(692, 47, true);
                WriteLiteral("</div>\r\n            <div class=\"col-3\">Energy: ");
                EndContext();
                BeginContext(740, 12, false);
#line 18 "C:\Users\Aric Jeon\Desktop\Dojo_assignments\CSharp\ASP.NET\Dojodachi\Views\Home\Index.cshtml"
                                  Write(Model.Energy);

#line default
#line hidden
                EndContext();
                BeginContext(752, 83, true);
                WriteLiteral("</div>\r\n        </div>\r\n        <div class=\"content text-center\">\r\n            <img");
                EndContext();
                BeginWriteAttribute("src", " src=\"", 835, "\"", 853, 1);
#line 21 "C:\Users\Aric Jeon\Desktop\Dojo_assignments\CSharp\ASP.NET\Dojodachi\Views\Home\Index.cshtml"
WriteAttributeValue("", 841, Model.Image, 841, 12, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(854, 25, true);
                WriteLiteral(" alt=\"\">\r\n            <p>");
                EndContext();
                BeginContext(880, 13, false);
#line 22 "C:\Users\Aric Jeon\Desktop\Dojo_assignments\CSharp\ASP.NET\Dojodachi\Views\Home\Index.cshtml"
          Write(Model.Message);

#line default
#line hidden
                EndContext();
                BeginContext(893, 419, true);
                WriteLiteral(@"</p>
        </div>
        <div class=""row"">
            <div class=""col-3""><a href=""/feed"" class=""btn btn-light"">Feed</a></div>
            <div class=""col-3""><a href=""/play"" class=""btn btn-light"">Play</a></div>
            <div class=""col-3""><a href=""/work"" class=""btn btn-light"">Work</a></div>
            <div class=""col-3""><a href=""/sleep"" class=""btn btn-light"">Sleep</a></div>
        </div>
    </div>
");
                EndContext();
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
            EndContext();
            BeginContext(1319, 9, true);
            WriteLiteral("\r\n</html>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Dojodachi> Html { get; private set; }
    }
}
#pragma warning restore 1591
