#pragma checksum "C:\Users\owenp\source\repos\NEASimulator\NEASimulator\Shared\MainLayout.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5cd351c3531ca9e5fc41c1bed6eca41edf246460"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace NEASimulator.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\owenp\source\repos\NEASimulator\NEASimulator\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\owenp\source\repos\NEASimulator\NEASimulator\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\owenp\source\repos\NEASimulator\NEASimulator\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\owenp\source\repos\NEASimulator\NEASimulator\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\owenp\source\repos\NEASimulator\NEASimulator\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\owenp\source\repos\NEASimulator\NEASimulator\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\owenp\source\repos\NEASimulator\NEASimulator\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\owenp\source\repos\NEASimulator\NEASimulator\_Imports.razor"
using NEASimulator;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\owenp\source\repos\NEASimulator\NEASimulator\_Imports.razor"
using NEASimulator.Shared;

#line default
#line hidden
#nullable disable
    public partial class MainLayout : LayoutComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 16 "C:\Users\owenp\source\repos\NEASimulator\NEASimulator\Shared\MainLayout.razor"
      

    private List<Models.AvailableApparatus> available = new List<Models.AvailableApparatus>();

    protected override void OnAfterRender(bool firstRender)
    {
        base.OnAfterRender(firstRender);
        if (firstRender)
        {
            available.Add(new Models.AvailableApparatus { ImageSrc = "/RedBallPreview.png", Name = "Ball" });
            available.Add(new Models.AvailableApparatus { ImageSrc = "/PlankPreview.png", Name = "Horizontal Plank" });
            available.Add(new Models.AvailableApparatus { ImageSrc = "/V_PlankPreview.png", Name = "Vertical Plank" });
        }
    }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
