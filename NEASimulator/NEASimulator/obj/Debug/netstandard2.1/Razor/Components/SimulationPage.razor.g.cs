#pragma checksum "C:\Users\owenp\Git Hub Repositories\ComputerScienceNEA\NEASimulator\NEASimulator\Components\SimulationPage.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3828ed6a6da11c8b23fe7c57b11c7dea9727f3b2"
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
    public partial class SimulationPage : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, @"<style>

    body {
        height: 100%;
        overflow: hidden;
    }

    .side-bar-left {
        left: 0;
    }
        .side-bar-left ul li button img {
            padding-right: 15px;
        }

    .side-bar-right {
        right: 0;
        text-align: right;
    }
        .side-bar-right ul li button img {
            padding-left: 15px;
        }


    .side-bar {
        position: fixed;
        top: 0;
        height: 100%;
        padding: 40px 30px 0px 20px;
        background-color: brown;
    }

        .side-bar ul {
            list-style: none;
        }

            .side-bar ul li {
                padding: 10px 0px 10px 0px;
                border-radius: 5px;
            }

                .side-bar ul li:hover {
                    background-color: rosybrown;
                }

                .side-bar ul li button {
                    background: none;
                    color: white;
                    border: none;
                }

</style>

");
            __builder.OpenElement(1, "div");
            __builder.AddAttribute(2, "class", "side-bar side-bar-left");
            __builder.AddMarkupContent(3, "\r\n    ");
            __builder.OpenElement(4, "ul");
            __builder.AddMarkupContent(5, "\r\n");
#nullable restore
#line 55 "C:\Users\owenp\Git Hub Repositories\ComputerScienceNEA\NEASimulator\NEASimulator\Components\SimulationPage.razor"
         foreach (var item in Available)
        {

#line default
#line hidden
#nullable disable
            __builder.AddContent(6, "            ");
            __builder.OpenElement(7, "li");
            __builder.AddMarkupContent(8, "\r\n                ");
            __builder.OpenElement(9, "button");
            __builder.AddAttribute(10, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 58 "C:\Users\owenp\Git Hub Repositories\ComputerScienceNEA\NEASimulator\NEASimulator\Components\SimulationPage.razor"
                                    (args) => AddObject(args,item.Name)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(11, "\r\n                    ");
            __builder.OpenElement(12, "img");
            __builder.AddAttribute(13, "src", 
#nullable restore
#line 59 "C:\Users\owenp\Git Hub Repositories\ComputerScienceNEA\NEASimulator\NEASimulator\Components\SimulationPage.razor"
                                "/media/Icons/Icon_" + item.Name + ".png"

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(14, "\r\n                    ");
            __builder.AddContent(15, 
#nullable restore
#line 60 "C:\Users\owenp\Git Hub Repositories\ComputerScienceNEA\NEASimulator\NEASimulator\Components\SimulationPage.razor"
                     item.Name

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(16, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(17, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(18, "\r\n");
#nullable restore
#line 63 "C:\Users\owenp\Git Hub Repositories\ComputerScienceNEA\NEASimulator\NEASimulator\Components\SimulationPage.razor"
        }

#line default
#line hidden
#nullable disable
            __builder.AddContent(19, "    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(20, "\r\n");
            __builder.CloseElement();
            __builder.AddMarkupContent(21, "\r\n\r\n");
            __builder.OpenElement(22, "div");
            __builder.AddAttribute(23, "class", "side-bar side-bar-right");
            __builder.AddMarkupContent(24, "\r\n    ");
            __builder.OpenElement(25, "ul");
            __builder.AddMarkupContent(26, "\r\n");
#nullable restore
#line 69 "C:\Users\owenp\Git Hub Repositories\ComputerScienceNEA\NEASimulator\NEASimulator\Components\SimulationPage.razor"
         foreach (var item in controls)
        {

#line default
#line hidden
#nullable disable
            __builder.AddContent(27, "            ");
            __builder.OpenElement(28, "li");
            __builder.AddMarkupContent(29, "\r\n                ");
            __builder.OpenElement(30, "button");
            __builder.AddAttribute(31, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 72 "C:\Users\owenp\Git Hub Repositories\ComputerScienceNEA\NEASimulator\NEASimulator\Components\SimulationPage.razor"
                                    (args) => ControlClick(item)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(32, "\r\n                    ");
            __builder.AddContent(33, 
#nullable restore
#line 73 "C:\Users\owenp\Git Hub Repositories\ComputerScienceNEA\NEASimulator\NEASimulator\Components\SimulationPage.razor"
                     item

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(34, "\r\n                    ");
            __builder.OpenElement(35, "img");
            __builder.AddAttribute(36, "src", 
#nullable restore
#line 74 "C:\Users\owenp\Git Hub Repositories\ComputerScienceNEA\NEASimulator\NEASimulator\Components\SimulationPage.razor"
                                "/media/Icons/Icon_" + item + ".png"

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(37, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(38, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(39, "\r\n");
#nullable restore
#line 77 "C:\Users\owenp\Git Hub Repositories\ComputerScienceNEA\NEASimulator\NEASimulator\Components\SimulationPage.razor"
        }

#line default
#line hidden
#nullable disable
            __builder.AddContent(40, "    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(41, "\r\n");
            __builder.CloseElement();
            __builder.AddMarkupContent(42, "\r\n\r\n");
            __builder.OpenElement(43, "div");
            __builder.AddAttribute(44, "class", "main");
            __builder.AddMarkupContent(45, "\r\n    ");
            __builder.OpenComponent<NEASimulator.Components.Simulation>(46);
            __builder.AddAttribute(47, "Preset", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<NEASimulator.Models.SaveState>(
#nullable restore
#line 82 "C:\Users\owenp\Git Hub Repositories\ComputerScienceNEA\NEASimulator\NEASimulator\Components\SimulationPage.razor"
                                   Preset

#line default
#line hidden
#nullable disable
            ));
            __builder.AddComponentReferenceCapture(48, (__value) => {
#nullable restore
#line 82 "C:\Users\owenp\Git Hub Repositories\ComputerScienceNEA\NEASimulator\NEASimulator\Components\SimulationPage.razor"
                      sim = (NEASimulator.Components.Simulation)__value;

#line default
#line hidden
#nullable disable
            }
            );
            __builder.CloseComponent();
            __builder.AddMarkupContent(49, "\r\n");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 86 "C:\Users\owenp\Git Hub Repositories\ComputerScienceNEA\NEASimulator\NEASimulator\Components\SimulationPage.razor"
      

    private Simulation sim;
    private List<string> controls = new List<string>();

    [Parameter]
    public List<Models.AvailableApparatus> Available { get; set; }

    [Parameter]
    public Models.SaveState Preset { get; set; }

    private void AddObject(MouseEventArgs e, string type)
    {
        sim.AddObject(e, type);
        sim.Rerender();

    }

    private void ControlClick(string type)
    {
        switch(type.ToUpper())
        {
            case "PLAY":
                sim.PlayPause();
                controls[controls.IndexOf(type)] = "Pause";
                break;
            case "PAUSE":
                sim.PlayPause();
                controls[controls.IndexOf(type)] = "Play";
                break;
            case "CLEAR":
                sim.Clear();
                break;
            case "SAVE":
                sim.Save();
                break;
            case "RESET":
                sim.Reset();
                break;
            default:
                break;
        }
    }

    protected override void OnAfterRender(bool firstRender)
    {
        base.OnAfterRender(firstRender);
        if (firstRender)
        {

            if (Available.Count() == 0)
            {
                Available.Add(new Models.AvailableApparatus { ImageSrc = "/RedBallPreview.png", Name = "Ball" });
                Available.Add(new Models.AvailableApparatus { ImageSrc = "/PlankPreview.png", Name = "Plank" });
                Available.Add(new Models.AvailableApparatus { ImageSrc = "/V_PlankPreview.png", Name = "VPlank" });
                Available.Add(new Models.AvailableApparatus { ImageSrc = "/V_PlankPreview.png", Name = "DataLogger" });
                Available.Add(new Models.AvailableApparatus { ImageSrc = "/V_PlankPreview.png", Name = "LightGate" });
                Available.Add(new Models.AvailableApparatus { ImageSrc = "/V_PlankPreview.png", Name = "MetreStick" });
                this.StateHasChanged();
            }

            controls = new List<string>() { "Play", "Clear", "Save", "Reset" };
        }
    }




#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
