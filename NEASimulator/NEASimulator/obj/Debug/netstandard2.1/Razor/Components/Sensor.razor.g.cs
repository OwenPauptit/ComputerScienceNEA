#pragma checksum "C:\Users\owenp\Git Hub Repositories\ComputerScienceNEA\NEASimulator\NEASimulator\Components\Sensor.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "addd9129959acc412c1dbfd67e1b548d5823054c"
// <auto-generated/>
#pragma warning disable 1591
namespace NEASimulator.Components
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
    public partial class Sensor : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "img");
            __builder.AddAttribute(1, "class", "draggable");
            __builder.AddAttribute(2, "draggable", "true");
            __builder.AddAttribute(3, "src", 
#nullable restore
#line 4 "C:\Users\owenp\Git Hub Repositories\ComputerScienceNEA\NEASimulator\NEASimulator\Components\Sensor.razor"
              sensor.ImageSrc

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(4, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 5 "C:\Users\owenp\Git Hub Repositories\ComputerScienceNEA\NEASimulator\NEASimulator\Components\Sensor.razor"
                    (args) => Parent.SensorClick(sensor)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(5, "ondragend", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.DragEventArgs>(this, 
#nullable restore
#line 6 "C:\Users\owenp\Git Hub Repositories\ComputerScienceNEA\NEASimulator\NEASimulator\Components\Sensor.razor"
                       (sensor as NEASimulator.Models.Draggable).SetPositionToMouse

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(6, "style", "position:absolute;" + " " + (
#nullable restore
#line 7 "C:\Users\owenp\Git Hub Repositories\ComputerScienceNEA\NEASimulator\NEASimulator\Components\Sensor.razor"
                                   sensor.Style_Position

#line default
#line hidden
#nullable disable
            ));
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 9 "C:\Users\owenp\Git Hub Repositories\ComputerScienceNEA\NEASimulator\NEASimulator\Components\Sensor.razor"
       
    [Parameter]
    public Interfaces.ISensor sensor { get; set; }

    [Parameter]
    public Simulation Parent { get; set; }



#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
