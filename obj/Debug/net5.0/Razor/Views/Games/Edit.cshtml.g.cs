#pragma checksum "D:\Programming\gamesLibrary\Views\Games\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4462e7a692961bf17765ae1fe74a322569d57a34"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Games_Edit), @"mvc.1.0.view", @"/Views/Games/Edit.cshtml")]
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
#line 1 "D:\Programming\gamesLibrary\Views\_ViewImports.cshtml"
using gamesLibrary;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Programming\gamesLibrary\Views\_ViewImports.cshtml"
using gamesLibrary.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4462e7a692961bf17765ae1fe74a322569d57a34", @"/Views/Games/Edit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7ab000f82fda023fa6a2ab3f68a7e6e7851db62a", @"/Views/_ViewImports.cshtml")]
    public class Views_Games_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<gamesLibrary.Models.Games>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Programming\gamesLibrary\Views\Games\Edit.cshtml"
  
    ViewBag.Title = "Edit";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Edit</h2>\r\n\r\n");
#nullable restore
#line 9 "D:\Programming\gamesLibrary\Views\Games\Edit.cshtml"
 using (Html.BeginForm())
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\Programming\gamesLibrary\Views\Games\Edit.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"form-horizontal\">\r\n        <h4>");
#nullable restore
#line 14 "D:\Programming\gamesLibrary\Views\Games\Edit.cshtml"
       Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n        <hr />\r\n        ");
#nullable restore
#line 16 "D:\Programming\gamesLibrary\Views\Games\Edit.cshtml"
   Write(Html.ValidationSummary(true));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 17 "D:\Programming\gamesLibrary\Views\Games\Edit.cshtml"
   Write(Html.HiddenFor(model => model.gameID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n        <div class=\"form-group\">\r\n            ");
#nullable restore
#line 20 "D:\Programming\gamesLibrary\Views\Games\Edit.cshtml"
       Write(Html.LabelFor(model => model.Review, new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <div class=\"col-md-10\">\r\n                ");
#nullable restore
#line 22 "D:\Programming\gamesLibrary\Views\Games\Edit.cshtml"
           Write(Html.EditorFor(model => model.Review));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 23 "D:\Programming\gamesLibrary\Views\Games\Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.Review, "", new{@class = "text-danger"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"form-group\">\r\n            ");
#nullable restore
#line 28 "D:\Programming\gamesLibrary\Views\Games\Edit.cshtml"
       Write(Html.LabelFor(model => model.TextReview, new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <div class=\"col-md-10\">\r\n                ");
#nullable restore
#line 30 "D:\Programming\gamesLibrary\Views\Games\Edit.cshtml"
           Write(Html.EditorFor(model => model.TextReview));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 31 "D:\Programming\gamesLibrary\Views\Games\Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.TextReview));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n\r\n        <div class=\"form-group\">\r\n            <div class=\"col-md-offset-2 col-md-10\">\r\n                <input type=\"submit\" value=\"Save\" class=\"btn btn-default\" />\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 42 "D:\Programming\gamesLibrary\Views\Games\Edit.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div>\r\n    ");
#nullable restore
#line 45 "D:\Programming\gamesLibrary\Views\Games\Edit.cshtml"
Write(Html.ActionLink("Back to List", "GetGames"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<gamesLibrary.Models.Games> Html { get; private set; }
    }
}
#pragma warning restore 1591