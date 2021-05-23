#pragma checksum "D:\Programming\gamesLibrary\Views\Games\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "01e9e21937c15cb267d3d076c4129c95fbda258c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Games_Index), @"mvc.1.0.view", @"/Views/Games/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"01e9e21937c15cb267d3d076c4129c95fbda258c", @"/Views/Games/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7ab000f82fda023fa6a2ab3f68a7e6e7851db62a", @"/Views/_ViewImports.cshtml")]
    public class Views_Games_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "D:\Programming\gamesLibrary\Views\Games\Index.cshtml"
  
    ViewBag.Title = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 6 "D:\Programming\gamesLibrary\Views\Games\Index.cshtml"
 using(Html.BeginForm()){
    

#line default
#line hidden
#nullable disable
            WriteLiteral("    <b>Search Option</b>");
#nullable restore
#line 8 "D:\Programming\gamesLibrary\Views\Games\Index.cshtml"
                   Write(Html.RadioButton("Option", "Title"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" Title: ");
#nullable restore
#line 9 "D:\Programming\gamesLibrary\Views\Games\Index.cshtml"
Write(Html.RadioButton("Option", "Genre"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" Genre: ");
#nullable restore
#line 10 "D:\Programming\gamesLibrary\Views\Games\Index.cshtml"
Write(Html.RadioButton("Option", "ReleaseYear"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" Year Published: ");
#nullable restore
#line 11 "D:\Programming\gamesLibrary\Views\Games\Index.cshtml"
Write(Html.RadioButton("Option", "Price"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" Price: ");
#nullable restore
#line 12 "D:\Programming\gamesLibrary\Views\Games\Index.cshtml"
Write(Html.TextBox("Search"));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <input type=\"submit\" value=\"Search\" />\r\n    <br>\r\n    <br>\r\n");
#nullable restore
#line 16 "D:\Programming\gamesLibrary\Views\Games\Index.cshtml"
   
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<table class=\"table table-bordered table-striped\" >\r\n    <tr>\r\n        <th>\r\n            ");
#nullable restore
#line 23 "D:\Programming\gamesLibrary\Views\Games\Index.cshtml"
       Write(Html.ActionLink("Title", "Index", new{ sortOrder = ViewBag.NameSortParm}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </th>\r\n        <th>Genre</th>\r\n        <th>\r\n            ");
#nullable restore
#line 27 "D:\Programming\gamesLibrary\Views\Games\Index.cshtml"
       Write(Html.ActionLink("Release Year", "Index", new{sortOrder = ViewBag.DateSortParm}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </th>\r\n        <th>Price</th>\r\n        <th>\r\n            ");
#nullable restore
#line 31 "D:\Programming\gamesLibrary\Views\Games\Index.cshtml"
       Write(Html.ActionLink("Review Rating", "Index", new{sortOrder = ViewBag.RankSortParm}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n         </th>\r\n        <th>Reviews</th>\r\n    </tr>\r\n\r\n");
#nullable restore
#line 36 "D:\Programming\gamesLibrary\Views\Games\Index.cshtml"
      
      if (Model!= null){
          foreach (var Data in Model){

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 40 "D:\Programming\gamesLibrary\Views\Games\Index.cshtml"
                   Write(Data.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 41 "D:\Programming\gamesLibrary\Views\Games\Index.cshtml"
                   Write(Data.Genre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 42 "D:\Programming\gamesLibrary\Views\Games\Index.cshtml"
                   Write(Data.ReleaseYear);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 43 "D:\Programming\gamesLibrary\Views\Games\Index.cshtml"
                   Write(Data.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 44 "D:\Programming\gamesLibrary\Views\Games\Index.cshtml"
                   Write(Data.Review);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 45 "D:\Programming\gamesLibrary\Views\Games\Index.cshtml"
                   Write(Data.TextReview);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 1394, "\"", 1460, 1);
#nullable restore
#line 47 "D:\Programming\gamesLibrary\Views\Games\Index.cshtml"
WriteAttributeValue("", 1401, Url.Action("CreateGame", "Games", new {@id=@Data.gameID }), 1401, 59, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Add Game</a>\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 50 "D:\Programming\gamesLibrary\Views\Games\Index.cshtml"
          }
     }
    

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>");
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