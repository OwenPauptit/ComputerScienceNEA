#pragma checksum "C:\Users\owenp\Git Hub Repositories\ComputerScienceNEA\NEASimulator\NEASimulator\Pages\Home.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5b3b19c875d1f302538c5ec627b7202617d559f8"
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
    [Microsoft.AspNetCore.Components.RouteAttribute("/home")]
    public partial class Home : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 9 "C:\Users\owenp\Git Hub Repositories\ComputerScienceNEA\NEASimulator\NEASimulator\Pages\Home.razor"
      

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
                    new NEASimulator.Models.Apparatus.Ball(new System.Numerics.Vector2 { X = 110, Y = 50 }, false),
                    new NEASimulator.Models.Apparatus.Ball(new System.Numerics.Vector2 { X = 210, Y = 50 }, false),
                    new NEASimulator.Models.Apparatus.Ball(new System.Numerics.Vector2 { X = 310, Y = 50 }, false),
                    new NEASimulator.Models.Apparatus.Ball(new System.Numerics.Vector2 { X = 410, Y = 50 }, false),
                    new NEASimulator.Models.Apparatus.Ball(new System.Numerics.Vector2 { X = 510, Y = 50 }, false),
                    new NEASimulator.Models.Apparatus.Ball(new System.Numerics.Vector2 { X = 160, Y = 150 }, false),
                    new NEASimulator.Models.Apparatus.Ball(new System.Numerics.Vector2 { X = 260, Y = 150 }, false),
                    new NEASimulator.Models.Apparatus.Ball(new System.Numerics.Vector2 { X = 360, Y = 150 }, false),
                    new NEASimulator.Models.Apparatus.Ball(new System.Numerics.Vector2 { X = 460, Y = 150 }, false),
                    new NEASimulator.Models.Apparatus.Ball(new System.Numerics.Vector2 { X = 210, Y = 250 }, false),
                    new NEASimulator.Models.Apparatus.Ball(new System.Numerics.Vector2 { X = 310, Y = 250 }, false),
                    new NEASimulator.Models.Apparatus.Ball(new System.Numerics.Vector2 { X = 410, Y = 250 }, false),
                    new NEASimulator.Models.Apparatus.Ball(new System.Numerics.Vector2 { X = 260, Y = 350 }, false),
                    new NEASimulator.Models.Apparatus.Ball(new System.Numerics.Vector2 { X = 360, Y = 350 }, false),
                    new NEASimulator.Models.Apparatus.Ball(new System.Numerics.Vector2 { X = 310, Y = 450 }, false),
                    new NEASimulator.Models.Apparatus.Plank(new System.Numerics.Vector2 { X = 200, Y = 700 }, Models.Apparatus.Plank.Type.Horizontal, false),
                    new NEASimulator.Models.Apparatus.Plank(new System.Numerics.Vector2 { X = 300, Y = 700 }, Models.Apparatus.Plank.Type.Horizontal, false),
                    new NEASimulator.Models.Apparatus.Plank(new System.Numerics.Vector2 { X = 500, Y = 700 }, Models.Apparatus.Plank.Type.Horizontal, false),
                    new NEASimulator.Models.Apparatus.Plank(new System.Numerics.Vector2 { X = 40, Y = 560 }, Models.Apparatus.Plank.Type.Vertical, false),
                    new NEASimulator.Models.Apparatus.Plank(new System.Numerics.Vector2 { X = 40, Y = 350 }, Models.Apparatus.Plank.Type.Vertical, false),
                    new NEASimulator.Models.Apparatus.Plank(new System.Numerics.Vector2 { X = 650, Y = 560 }, Models.Apparatus.Plank.Type.Vertical, false),
                    new NEASimulator.Models.Apparatus.Plank(new System.Numerics.Vector2 { X = 650, Y = 350 }, Models.Apparatus.Plank.Type.Vertical, false),

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
