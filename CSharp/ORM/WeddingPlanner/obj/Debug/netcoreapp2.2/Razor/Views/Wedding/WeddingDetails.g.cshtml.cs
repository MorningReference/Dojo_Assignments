#pragma checksum "C:\Users\Aric Jeon\Desktop\Dojo_assignments\CSharp\ORM\WeddingPlanner\Views\Wedding\WeddingDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1cdd3a4ac1b01180283d9daa234c970c6d4bbb1e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Wedding_WeddingDetails), @"mvc.1.0.view", @"/Views/Wedding/WeddingDetails.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Wedding/WeddingDetails.cshtml", typeof(AspNetCore.Views_Wedding_WeddingDetails))]
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
#line 1 "C:\Users\Aric Jeon\Desktop\Dojo_assignments\CSharp\ORM\WeddingPlanner\Views\_ViewImports.cshtml"
using WeddingPlanner;

#line default
#line hidden
#line 2 "C:\Users\Aric Jeon\Desktop\Dojo_assignments\CSharp\ORM\WeddingPlanner\Views\_ViewImports.cshtml"
using WeddingPlanner.Models;

#line default
#line hidden
#line 3 "C:\Users\Aric Jeon\Desktop\Dojo_assignments\CSharp\ORM\WeddingPlanner\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1cdd3a4ac1b01180283d9daa234c970c6d4bbb1e", @"/Views/Wedding/WeddingDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f74b8ca08b40f37ad1199f2c8f4e56e10e34ca9b", @"/Views/_ViewImports.cshtml")]
    public class Views_Wedding_WeddingDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Wedding>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(16, 43, true);
            WriteLiteral("\r\n<div class=\"row\">\r\n    <h1 class=\"col-8\">");
            EndContext();
            BeginContext(60, 15, false);
#line 4 "C:\Users\Aric Jeon\Desktop\Dojo_assignments\CSharp\ORM\WeddingPlanner\Views\Wedding\WeddingDetails.cshtml"
                 Write(Model.WedderOne);

#line default
#line hidden
            EndContext();
            BeginContext(75, 5, true);
            WriteLiteral(" and ");
            EndContext();
            BeginContext(81, 15, false);
#line 4 "C:\Users\Aric Jeon\Desktop\Dojo_assignments\CSharp\ORM\WeddingPlanner\Views\Wedding\WeddingDetails.cshtml"
                                      Write(Model.WedderTwo);

#line default
#line hidden
            EndContext();
            BeginContext(96, 251, true);
            WriteLiteral("\'s Wedding</h1>\r\n    <div class=\"col-4 row\">\r\n        <a href=\"/dashboard\" class=\"col-6\">Dashboard</a>\r\n        <a href=\"/logout\" class=\"col-6\">Log Out</a>\r\n    </div>\r\n</div>\r\n<div class=\"content row\">\r\n    <div class=\"left col-6\">\r\n        <p>Date: ");
            EndContext();
            BeginContext(348, 10, false);
#line 12 "C:\Users\Aric Jeon\Desktop\Dojo_assignments\CSharp\ORM\WeddingPlanner\Views\Wedding\WeddingDetails.cshtml"
            Write(Model.Date);

#line default
#line hidden
            EndContext();
            BeginContext(358, 44, true);
            WriteLiteral("</p>\r\n        <p>Guests:</p>\r\n        <ul>\r\n");
            EndContext();
#line 15 "C:\Users\Aric Jeon\Desktop\Dojo_assignments\CSharp\ORM\WeddingPlanner\Views\Wedding\WeddingDetails.cshtml"
             foreach (RSVP rsvp in Model.RSVP)
            {

#line default
#line hidden
            BeginContext(465, 49, true);
            WriteLiteral("                <li class=\"text-decoration-none\">");
            EndContext();
            BeginContext(515, 19, false);
#line 17 "C:\Users\Aric Jeon\Desktop\Dojo_assignments\CSharp\ORM\WeddingPlanner\Views\Wedding\WeddingDetails.cshtml"
                                            Write(rsvp.User.FirstName);

#line default
#line hidden
            EndContext();
            BeginContext(534, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(536, 18, false);
#line 17 "C:\Users\Aric Jeon\Desktop\Dojo_assignments\CSharp\ORM\WeddingPlanner\Views\Wedding\WeddingDetails.cshtml"
                                                                 Write(rsvp.User.LastName);

#line default
#line hidden
            EndContext();
            BeginContext(554, 7, true);
            WriteLiteral("</li>\r\n");
            EndContext();
#line 18 "C:\Users\Aric Jeon\Desktop\Dojo_assignments\CSharp\ORM\WeddingPlanner\Views\Wedding\WeddingDetails.cshtml"
            }

#line default
#line hidden
            BeginContext(576, 69, true);
            WriteLiteral("        </ul>\r\n    </div>\r\n    <div class=\"right col-6\">\r\n        <p>");
            EndContext();
            BeginContext(646, 13, false);
#line 22 "C:\Users\Aric Jeon\Desktop\Dojo_assignments\CSharp\ORM\WeddingPlanner\Views\Wedding\WeddingDetails.cshtml"
      Write(Model.Address);

#line default
#line hidden
            EndContext();
            BeginContext(659, 24, true);
            WriteLiteral("</p>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Wedding> Html { get; private set; }
    }
}
#pragma warning restore 1591
