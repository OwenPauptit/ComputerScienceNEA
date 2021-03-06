#pragma checksum "C:\Users\owenp\Git Hub Repositories\ComputerScienceNEA\NEASimulator\NEASimulator\Pages\Mobilehome.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2f64bf220649f000abd28df9a2fdc3c7aad96e1e"
// <auto-generated/>
#pragma warning disable 1591
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
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "main");
            __builder.AddAttribute(2, "onmousemove", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 4 "C:\Users\owenp\Git Hub Repositories\ComputerScienceNEA\NEASimulator\NEASimulator\Pages\Mobilehome.razor"
                                Play

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(3, "\r\n    ");
            __builder.OpenComponent<NEASimulator.Components.Simulation>(4);
            __builder.AddAttribute(5, "Preset", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<NEASimulator.Models.SaveState>(
#nullable restore
#line 5 "C:\Users\owenp\Git Hub Repositories\ComputerScienceNEA\NEASimulator\NEASimulator\Pages\Mobilehome.razor"
                                   preset

#line default
#line hidden
#nullable disable
            ));
            __builder.AddComponentReferenceCapture(6, (__value) => {
#nullable restore
#line 5 "C:\Users\owenp\Git Hub Repositories\ComputerScienceNEA\NEASimulator\NEASimulator\Pages\Mobilehome.razor"
                      sim = (NEASimulator.Components.Simulation)__value;

#line default
#line hidden
#nullable disable
            }
            );
            __builder.CloseComponent();
            __builder.AddMarkupContent(7, "\r\n");
            __builder.CloseElement();
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
                    new NEASimulator.Models.Apparatus.Ball(new System.Numerics.Vector2 { X = 90, Y = 50 }, false),
                    new NEASimulator.Models.Apparatus.Ball(new System.Numerics.Vector2 { X = 190, Y = 50 }, false),
                    new NEASimulator.Models.Apparatus.Ball(new System.Numerics.Vector2 { X = 290, Y = 50 }, false),
                    new NEASimulator.Models.Apparatus.Ball(new System.Numerics.Vector2 { X = 140, Y = 150 }, false),
                    new NEASimulator.Models.Apparatus.Ball(new System.Numerics.Vector2 { X = 240, Y = 150 }, false),
                    new NEASimulator.Models.Apparatus.Ball(new System.Numerics.Vector2 { X = 190, Y = 250 }, false),
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
