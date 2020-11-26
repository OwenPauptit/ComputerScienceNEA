#pragma checksum "C:\Users\owenp\Git Hub Repositories\ComputerScienceNEA\NEASimulator\NEASimulator\Pages\Mobilehome.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9304184558b6b9a4926c5438dd3cf272c613c67b"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace NEASimulator.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\owenp\Git Hub Repositories\ComputerScienceNEA\NEASimulator\NEASimulator\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\owenp\Git Hub Repositories\ComputerScienceNEA\NEASimulator\NEASimulator\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\owenp\Git Hub Repositories\ComputerScienceNEA\NEASimulator\NEASimulator\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\owenp\Git Hub Repositories\ComputerScienceNEA\NEASimulator\NEASimulator\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\owenp\Git Hub Repositories\ComputerScienceNEA\NEASimulator\NEASimulator\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\owenp\Git Hub Repositories\ComputerScienceNEA\NEASimulator\NEASimulator\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\owenp\Git Hub Repositories\ComputerScienceNEA\NEASimulator\NEASimulator\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\owenp\Git Hub Repositories\ComputerScienceNEA\NEASimulator\NEASimulator\_Imports.razor"
using NEASimulator;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\owenp\Git Hub Repositories\ComputerScienceNEA\NEASimulator\NEASimulator\_Imports.razor"
using NEASimulator.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\owenp\Git Hub Repositories\ComputerScienceNEA\NEASimulator\NEASimulator\_Imports.razor"
using NEASimulator.Components;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/mobilehome")]
    public partial class Mobilehome : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 9 "C:\Users\owenp\Git Hub Repositories\ComputerScienceNEA\NEASimulator\NEASimulator\Pages\Mobilehome.razor"
      

    private Models.SaveState preset = new Models.SaveState();
    private List<Models.AvailableApparatus> available = new List<Models.AvailableApparatus>();
    private Simulation sim;
    private bool paused = true;

    private void Play()
    {
        if (paused)
        {
            paused = false;
            sim.PlayPause();
        }
    }

    protected override void OnAfterRender(bool firstRender)
    {
        base.OnAfterRender(firstRender);
        if (firstRender)
        {
            preset.Objects.AddRange(
                new List<Interfaces.IDisplayObject> {
                    new NEASimulator.Models.Apparatus.Ball(new System.Numerics.Vector2 { X = 80, Y = 50 }, false),
                    new NEASimulator.Models.Apparatus.Ball(new System.Numerics.Vector2 { X = 180, Y = 50 }, false),
                    new NEASimulator.Models.Apparatus.Ball(new System.Numerics.Vector2 { X = 280, Y = 50 }, false),
                    new NEASimulator.Models.Apparatus.Ball(new System.Numerics.Vector2 { X = 130, Y = 150 }, false),
                    new NEASimulator.Models.Apparatus.Ball(new System.Numerics.Vector2 { X = 230, Y = 150 }, false),
                    new NEASimulator.Models.Apparatus.Ball(new System.Numerics.Vector2 { X = 180, Y = 250 }, false),
                    new NEASimulator.Models.Apparatus.Plank(new System.Numerics.Vector2 { X = 170, Y = 500 }, Models.Apparatus.Plank.Type.Horizontal, false),
                    new NEASimulator.Models.Apparatus.Plank(new System.Numerics.Vector2 { X = 0, Y = 350 }, Models.Apparatus.Plank.Type.Vertical, false),
                    new NEASimulator.Models.Apparatus.Plank(new System.Numerics.Vector2 { X = 330, Y = 350 }, Models.Apparatus.Plank.Type.Vertical, false),

                    }
            );



        }
    }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
