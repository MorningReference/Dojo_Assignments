#pragma checksum "C:\Users\Aric Jeon\Desktop\Dojo_assignments\CSharp\ORM\WeddingPlanner\Views\Wedding\Dashboard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1400cf6215aa8574ffe6eb01b80fd55871e0fa56"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Wedding_Dashboard), @"mvc.1.0.view", @"/Views/Wedding/Dashboard.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Wedding/Dashboard.cshtml", typeof(AspNetCore.Views_Wedding_Dashboard))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1400cf6215aa8574ffe6eb01b80fd55871e0fa56", @"/Views/Wedding/Dashboard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f74b8ca08b40f37ad1199f2c8f4e56e10e34ca9b", @"/Views/_ViewImports.cshtml")]
    public class Views_Wedding_Dashboard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DashboardViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(27, 409, true);
            WriteLiteral(@"
<div class=""row"">
    <h1 class=""col-9"">
        Welcome to the Wedding Planner
    </h1>
    <a href=""/logout"" class=""col-3"">Log Out</a>
</div>

<table class=""table"">
    <thead>
        <tr>
            <th scope=""col"">Wedding</th>
            <th scope=""col"">Date</th>
            <th scope=""col"">Guest</th>
            <th scope=""col"">Action</th>
        </tr>
    </thead>
    <tbody>
");
            EndContext();
#line 20 "C:\Users\Aric Jeon\Desktop\Dojo_assignments\CSharp\ORM\WeddingPlanner\Views\Wedding\Dashboard.cshtml"
         foreach(Wedding wedding in Model.AllWeddings)
        {

#line default
#line hidden
            BeginContext(503, 40, true);
            WriteLiteral("            <tr>\r\n                <td><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 543, "\"", 577, 2);
            WriteAttributeValue("", 550, "/wedding/", 550, 9, true);
#line 23 "C:\Users\Aric Jeon\Desktop\Dojo_assignments\CSharp\ORM\WeddingPlanner\Views\Wedding\Dashboard.cshtml"
WriteAttributeValue("", 559, wedding.WeddingId, 559, 18, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(578, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(580, 17, false);
#line 23 "C:\Users\Aric Jeon\Desktop\Dojo_assignments\CSharp\ORM\WeddingPlanner\Views\Wedding\Dashboard.cshtml"
                                                     Write(wedding.WedderOne);

#line default
#line hidden
            EndContext();
            BeginContext(597, 3, true);
            WriteLiteral(" & ");
            EndContext();
            BeginContext(601, 17, false);
#line 23 "C:\Users\Aric Jeon\Desktop\Dojo_assignments\CSharp\ORM\WeddingPlanner\Views\Wedding\Dashboard.cshtml"
                                                                          Write(wedding.WedderTwo);

#line default
#line hidden
            EndContext();
            BeginContext(618, 31, true);
            WriteLiteral("</a></td>\r\n                <td>");
            EndContext();
            BeginContext(650, 12, false);
#line 24 "C:\Users\Aric Jeon\Desktop\Dojo_assignments\CSharp\ORM\WeddingPlanner\Views\Wedding\Dashboard.cshtml"
               Write(wedding.Date);

#line default
#line hidden
            EndContext();
            BeginContext(662, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(690, 18, false);
#line 25 "C:\Users\Aric Jeon\Desktop\Dojo_assignments\CSharp\ORM\WeddingPlanner\Views\Wedding\Dashboard.cshtml"
               Write(wedding.RSVP.Count);

#line default
#line hidden
            EndContext();
            BeginContext(708, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 26 "C:\Users\Aric Jeon\Desktop\Dojo_assignments\CSharp\ORM\WeddingPlanner\Views\Wedding\Dashboard.cshtml"
                  
                    bool IsRsvp = false;
                    if(Model.LoggedUser.UserId == wedding.Creator.UserId)
                    {

#line default
#line hidden
            BeginContext(875, 30, true);
            WriteLiteral("                        <td><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 905, "\"", 946, 3);
            WriteAttributeValue("", 912, "/wedding/", 912, 9, true);
#line 30 "C:\Users\Aric Jeon\Desktop\Dojo_assignments\CSharp\ORM\WeddingPlanner\Views\Wedding\Dashboard.cshtml"
WriteAttributeValue("", 921, wedding.WeddingId, 921, 18, false);

#line default
#line hidden
            WriteAttributeValue("", 939, "/delete", 939, 7, true);
            EndWriteAttribute();
            BeginContext(947, 18, true);
            WriteLiteral(">Delete</a></td>\r\n");
            EndContext();
#line 31 "C:\Users\Aric Jeon\Desktop\Dojo_assignments\CSharp\ORM\WeddingPlanner\Views\Wedding\Dashboard.cshtml"
                    }
                    else
                    {
                        foreach (RSVP rsvp in wedding.RSVP)
                        {
                            if(Model.LoggedUser.UserId == rsvp.UserId)
                            {

#line default
#line hidden
            BeginContext(1228, 38, true);
            WriteLiteral("                                <td><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1266, "\"", 1304, 3);
            WriteAttributeValue("", 1273, "/wedding/", 1273, 9, true);
#line 38 "C:\Users\Aric Jeon\Desktop\Dojo_assignments\CSharp\ORM\WeddingPlanner\Views\Wedding\Dashboard.cshtml"
WriteAttributeValue("", 1282, rsvp.WeddingId, 1282, 15, false);

#line default
#line hidden
            WriteAttributeValue("", 1297, "/unrsvp", 1297, 7, true);
            EndWriteAttribute();
            BeginContext(1305, 19, true);
            WriteLiteral(">Un-RSVP</a></td>\r\n");
            EndContext();
#line 39 "C:\Users\Aric Jeon\Desktop\Dojo_assignments\CSharp\ORM\WeddingPlanner\Views\Wedding\Dashboard.cshtml"
                                IsRsvp = true;
                                break;
                            }
                        }
                        if(!IsRsvp)
                        {

#line default
#line hidden
            BeginContext(1534, 34, true);
            WriteLiteral("                            <td><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1568, "\"", 1607, 3);
            WriteAttributeValue("", 1575, "/wedding/", 1575, 9, true);
#line 45 "C:\Users\Aric Jeon\Desktop\Dojo_assignments\CSharp\ORM\WeddingPlanner\Views\Wedding\Dashboard.cshtml"
WriteAttributeValue("", 1584, wedding.WeddingId, 1584, 18, false);

#line default
#line hidden
            WriteAttributeValue("", 1602, "/rsvp", 1602, 5, true);
            EndWriteAttribute();
            BeginContext(1608, 16, true);
            WriteLiteral(">RSVP</a></td>\r\n");
            EndContext();
#line 46 "C:\Users\Aric Jeon\Desktop\Dojo_assignments\CSharp\ORM\WeddingPlanner\Views\Wedding\Dashboard.cshtml"
                        }
                    }
                

#line default
#line hidden
            BeginContext(1691, 22, true);
            WriteLiteral(";\r\n            </tr>\r\n");
            EndContext();
#line 50 "C:\Users\Aric Jeon\Desktop\Dojo_assignments\CSharp\ORM\WeddingPlanner\Views\Wedding\Dashboard.cshtml"
        }

#line default
#line hidden
            BeginContext(1724, 126, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n<div class=\"text-right\">\r\n    <a href=\"/wedding/new\" class=\"btn btn-primary\">New Wedding</a>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DashboardViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
