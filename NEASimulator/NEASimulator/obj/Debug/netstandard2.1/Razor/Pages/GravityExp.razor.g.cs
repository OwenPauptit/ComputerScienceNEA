#pragma checksum "C:\Users\owenp\Git Hub Repositories\ComputerScienceNEA\NEASimulator\NEASimulator\Pages\GravityExp.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8cec62d667bf3b1cc7e8084ab05c1a71d55c3081"
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
    [Microsoft.AspNetCore.Components.RouteAttribute("/GravityExp")]
    public partial class GravityExp : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<NEASimulator.Components.SimulationPage>(0);
            __builder.AddAttribute(1, "Preset", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<NEASimulator.Models.SaveState>(
#nullable restore
#line 3 "C:\Users\owenp\Git Hub Repositories\ComputerScienceNEA\NEASimulator\NEASimulator\Pages\GravityExp.razor"
                        preset

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(2, "Available", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Collections.Generic.List<NEASimulator.Models.AvailableApparatus>>(
#nullable restore
#line 3 "C:\Users\owenp\Git Hub Repositories\ComputerScienceNEA\NEASimulator\NEASimulator\Pages\GravityExp.razor"
                                           available

#line default
#line hidden
#nullable disable
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
#nullable restore
#line 6 "C:\Users\owenp\Git Hub Repositories\ComputerScienceNEA\NEASimulator\NEASimulator\Pages\GravityExp.razor"
      

    private Models.SaveState preset = new Models.SaveState();
    private List<Models.AvailableApparatus> available = new List<Models.AvailableApparatus>();

    protected override void OnAfterRender(bool firstRender)
    {
        base.OnAfterRender(firstRender);
        if (firstRender)
        {
            preset.Objects.AddRange(
                new List<Interfaces.IDisplayObject> {
                    new NEASimulator.Models.Apparatus.Ball(new System.Numerics.Vector2 { X = 400, Y = 150 }, false),
                    new NEASimulator.Models.Apparatus.Plank(new System.Numerics.Vector2 { X = 400, Y = 800 }, Models.Apparatus.Plank.Type.Horizontal, false),
                    }
            );

            preset.Sensors.AddRange(
                new List<Interfaces.ISensor>
                {
                    new NEASimulator.Models.Apparatus.LightGate(new System.Numerics.Vector2(400, 300), false),
                    new NEASimulator.Models.Apparatus.LightGate(new System.Numerics.Vector2(400, 600), false)
                    }
            );

            preset.DataLoggers.Add(new Models.Apparatus.DataLogger(new System.Numerics.Vector2(700, 500), false));

            preset.Edges.AddRange(
                new List<Models.Edge>
                {
                    new Models.Edge() { datalogger = preset.DataLoggers[0], sensor = preset.Sensors[0], portnum = 0 },
                    new Models.Edge() { datalogger = preset.DataLoggers[0], sensor = preset.Sensors[1], portnum = 1 }
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
