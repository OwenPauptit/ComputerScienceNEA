#pragma checksum "C:\Users\owenp\Git Hub Repositories\ComputerScienceNEA\NEA\NEA\Pages\Simulations.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7e9089fb3c8479adb6fe026fc043fe953f07b266"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(NEA.Pages.Pages_Simulations), @"mvc.1.0.razor-page", @"/Pages/Simulations.cshtml")]
namespace NEA.Pages
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
#line 1 "C:\Users\owenp\Git Hub Repositories\ComputerScienceNEA\NEA\NEA\Pages\_ViewImports.cshtml"
using NEA;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\owenp\Git Hub Repositories\ComputerScienceNEA\NEA\NEA\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\owenp\Git Hub Repositories\ComputerScienceNEA\NEA\NEA\Pages\_ViewImports.cshtml"
using NEA.Areas.Identity.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\owenp\Git Hub Repositories\ComputerScienceNEA\NEA\NEA\Pages\_ViewImports.cshtml"
using NEA.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\owenp\Git Hub Repositories\ComputerScienceNEA\NEA\NEA\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\owenp\Git Hub Repositories\ComputerScienceNEA\NEA\NEA\Pages\_ViewImports.cshtml"
using NEA.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7e9089fb3c8479adb6fe026fc043fe953f07b266", @"/Pages/Simulations.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7152409a652afccb480b097286c28ffc9b98997b", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Simulations : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/Simulations", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/Questions/Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\owenp\Git Hub Repositories\ComputerScienceNEA\NEA\NEA\Pages\Simulations.cshtml"
  
    ViewData["Title"] = "Simulations";
    Layout = "~/Pages/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<script>

    copyurl = function () {
        var url = window.location.href;
        var temp = document.getElementById(""urlcopyinput"");
        temp.value = url;
        temp.select();
        document.execCommand(""copy"");
        alert(""Copied the text: "" + temp.value);
        temp.value = """";
    };
</script>

<input id=""urlcopyinput""");
            BeginWriteAttribute("value", " value=\"", 492, "\"", 500, 0);
            EndWriteAttribute();
            WriteLiteral(" width=\"2\" height=\"2\" style=\"position: absolute; left: 0; top: 0; z-index: -1\"/>\r\n\r\n<h1>Simulations</h1>\r\n\r\n<div class=\"sidebar\">\r\n    <ul>\r\n");
#nullable restore
#line 27 "C:\Users\owenp\Git Hub Repositories\ComputerScienceNEA\NEA\NEA\Pages\Simulations.cshtml"
         foreach (var item in Model.Simulations)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li>\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7e9089fb3c8479adb6fe026fc043fe953f07b2666079", async() => {
                WriteLiteral("\r\n                    ");
#nullable restore
#line 32 "C:\Users\owenp\Git Hub Repositories\ComputerScienceNEA\NEA\NEA\Pages\Simulations.cshtml"
               Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 31 "C:\Users\owenp\Git Hub Repositories\ComputerScienceNEA\NEA\NEA\Pages\Simulations.cshtml"
                     WriteLiteral(item.SimulationID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </li>\r\n");
#nullable restore
#line 35 "C:\Users\owenp\Git Hub Repositories\ComputerScienceNEA\NEA\NEA\Pages\Simulations.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </ul>\r\n</div>\r\n\r\n");
#nullable restore
#line 39 "C:\Users\owenp\Git Hub Repositories\ComputerScienceNEA\NEA\NEA\Pages\Simulations.cshtml"
 if (Model.SelectedSimulation != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"main\">\r\n\r\n    <br />\r\n\r\n    <h3>");
#nullable restore
#line 45 "C:\Users\owenp\Git Hub Repositories\ComputerScienceNEA\NEA\NEA\Pages\Simulations.cshtml"
   Write(Model.SelectedSimulation.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n\r\n    <br />\r\n\r\n    <img class=\"mx-auto\"");
            BeginWriteAttribute("src", " src=\"", 1119, "\"", 1164, 1);
#nullable restore
#line 49 "C:\Users\owenp\Git Hub Repositories\ComputerScienceNEA\NEA\NEA\Pages\Simulations.cshtml"
WriteAttributeValue("", 1125, Model.SelectedSimulation.PreviewImgSrc, 1125, 39, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n\r\n    <br />\r\n\r\n    <p>");
#nullable restore
#line 53 "C:\Users\owenp\Git Hub Repositories\ComputerScienceNEA\NEA\NEA\Pages\Simulations.cshtml"
  Write(Model.SelectedSimulation.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7e9089fb3c8479adb6fe026fc043fe953f07b26610083", async() => {
                WriteLiteral("Go to Questions");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-simID", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 55 "C:\Users\owenp\Git Hub Repositories\ComputerScienceNEA\NEA\NEA\Pages\Simulations.cshtml"
                                                                 WriteLiteral(Model.SelectedSimulation.SimulationID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["simID"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-simID", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["simID"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n    <a class=\"btn btn-primary\"");
            BeginWriteAttribute("href", " href=", 1408, "", 1553, 1);
#nullable restore
#line 57 "C:\Users\owenp\Git Hub Repositories\ComputerScienceNEA\NEA\NEA\Pages\Simulations.cshtml"
WriteAttributeValue("", 1414, "https://" + $"simulator-physsim.azurewebsites.net/{Model.SelectedSimulation.Name.Replace('.','-').Replace(" ",string.Empty).ToLower()}", 1414, 139, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Go to Simulation</a>\r\n\r\n    <button class=\"btn btn-primary clipboard\" onclick=\"copyurl()\">Copy URL to clipboard</button>\r\n\r\n\r\n\r\n</div>\r\n");
#nullable restore
#line 64 "C:\Users\owenp\Git Hub Repositories\ComputerScienceNEA\NEA\NEA\Pages\Simulations.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<NEAUser> UserManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IAuthorizationService AuthorizationService { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<NEA.Pages.SimulationsModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<NEA.Pages.SimulationsModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<NEA.Pages.SimulationsModel>)PageContext?.ViewData;
        public NEA.Pages.SimulationsModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
