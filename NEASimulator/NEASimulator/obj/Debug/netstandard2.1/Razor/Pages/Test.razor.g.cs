#pragma checksum "C:\Users\owenp\source\repos\NEASimulator\NEASimulator\Pages\Test.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "49274adfbf6a9152d00e4a999db39130a0dd8a01"
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
    [Microsoft.AspNetCore.Components.RouteAttribute("/test")]
    public partial class Test : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, @"<style>
    .draggable {
        cursor: pointer
    }

    .datalogger {
        width: max-content;
        background: #fdc689;
        border: 3px solid #f5a44c;
        border-radius: 15px;
        padding: 10px 10px 10px 10px;
    }

        .datalogger.inner {
            background: #3cb878;
            border: 2px solid #464646;
            border-radius: 0px;
            padding: 0px 10px 0px 0px;
        }

            ul  {
                list-style: none;
                padding-left: 10px;
                font-family: Consolas, Arial;
            }
</style>

");
            __builder.OpenElement(1, "div");
            __builder.AddMarkupContent(2, "\r\n\r\n    ");
            __builder.OpenElement(3, "button");
            __builder.AddAttribute(4, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 33 "C:\Users\owenp\source\repos\NEASimulator\NEASimulator\Pages\Test.razor"
                        (args) => AddObject(args,"Ball")

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(5, "Add Ball");
            __builder.CloseElement();
            __builder.AddMarkupContent(6, "\r\n    ");
            __builder.OpenElement(7, "button");
            __builder.AddAttribute(8, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 34 "C:\Users\owenp\source\repos\NEASimulator\NEASimulator\Pages\Test.razor"
                        (args) => AddObject(args,"Plank")

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(9, "Add Plank");
            __builder.CloseElement();
            __builder.AddMarkupContent(10, "\r\n    ");
            __builder.OpenElement(11, "button");
            __builder.AddAttribute(12, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 35 "C:\Users\owenp\source\repos\NEASimulator\NEASimulator\Pages\Test.razor"
                        (args) => AddObject(args,"VPlank")

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(13, "Add VPlank");
            __builder.CloseElement();
            __builder.AddMarkupContent(14, "\r\n    ");
            __builder.OpenElement(15, "button");
            __builder.AddAttribute(16, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 36 "C:\Users\owenp\source\repos\NEASimulator\NEASimulator\Pages\Test.razor"
                        (args) => AddObject(args,"MetreStick")

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(17, "Add MetreStick");
            __builder.CloseElement();
            __builder.AddMarkupContent(18, "\r\n    ");
            __builder.OpenElement(19, "button");
            __builder.AddAttribute(20, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 37 "C:\Users\owenp\source\repos\NEASimulator\NEASimulator\Pages\Test.razor"
                      PlayPause

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(21, 
#nullable restore
#line 37 "C:\Users\owenp\source\repos\NEASimulator\NEASimulator\Pages\Test.razor"
                                   paused?"Play":"Pause"

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(22, "\r\n    ");
            __builder.OpenElement(23, "button");
            __builder.AddAttribute(24, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 38 "C:\Users\owenp\source\repos\NEASimulator\NEASimulator\Pages\Test.razor"
                      Clear

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(25, "Clear");
            __builder.CloseElement();
            __builder.AddMarkupContent(26, "\r\n    ");
            __builder.OpenElement(27, "button");
            __builder.AddAttribute(28, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 39 "C:\Users\owenp\source\repos\NEASimulator\NEASimulator\Pages\Test.razor"
                      Save

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(29, "Save Current State");
            __builder.CloseElement();
            __builder.AddMarkupContent(30, "\r\n    ");
            __builder.OpenElement(31, "button");
            __builder.AddAttribute(32, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 40 "C:\Users\owenp\source\repos\NEASimulator\NEASimulator\Pages\Test.razor"
                      Reset

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(33, "Return To Saved State");
            __builder.CloseElement();
            __builder.AddMarkupContent(34, "\r\n\r\n    <br>\r\n\r\n");
#nullable restore
#line 44 "C:\Users\owenp\source\repos\NEASimulator\NEASimulator\Pages\Test.razor"
     foreach (var obj in currentState.Objects)
    {

        if (obj is NEASimulator.Models.Draggable)
        {

#line default
#line hidden
#nullable disable
            __builder.AddContent(35, "            ");
            __builder.OpenElement(36, "img");
            __builder.AddAttribute(37, "class", "draggable");
            __builder.AddAttribute(38, "src", 
#nullable restore
#line 50 "C:\Users\owenp\source\repos\NEASimulator\NEASimulator\Pages\Test.razor"
                       obj.ImageSrc

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(39, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 51 "C:\Users\owenp\source\repos\NEASimulator\NEASimulator\Pages\Test.razor"
                             (obj as NEASimulator.Models.Draggable).OnClick

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(40, "onmousemove", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 52 "C:\Users\owenp\source\repos\NEASimulator\NEASimulator\Pages\Test.razor"
                                 (obj as NEASimulator.Models.Draggable).SetPositionToMouse

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(41, "style", "position:absolute;" + " " + (
#nullable restore
#line 53 "C:\Users\owenp\source\repos\NEASimulator\NEASimulator\Pages\Test.razor"
                                            obj.Style_Position

#line default
#line hidden
#nullable disable
            ));
            __builder.CloseElement();
            __builder.AddMarkupContent(42, "\r\n");
#nullable restore
#line 54 "C:\Users\owenp\source\repos\NEASimulator\NEASimulator\Pages\Test.razor"
        }
        else
        {

#line default
#line hidden
#nullable disable
            __builder.AddContent(43, "            ");
            __builder.OpenElement(44, "img");
            __builder.AddAttribute(45, "class", "draggable");
            __builder.AddAttribute(46, "src", 
#nullable restore
#line 58 "C:\Users\owenp\source\repos\NEASimulator\NEASimulator\Pages\Test.razor"
                       obj.ImageSrc

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(47, "style", "position:absolute;" + " " + (
#nullable restore
#line 59 "C:\Users\owenp\source\repos\NEASimulator\NEASimulator\Pages\Test.razor"
                                            obj.Style_Position

#line default
#line hidden
#nullable disable
            ));
            __builder.CloseElement();
            __builder.AddMarkupContent(48, "\r\n");
#nullable restore
#line 60 "C:\Users\owenp\source\repos\NEASimulator\NEASimulator\Pages\Test.razor"
        }

    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 63 "C:\Users\owenp\source\repos\NEASimulator\NEASimulator\Pages\Test.razor"
     foreach (var sensor in currentState.Sensors)
    {

#line default
#line hidden
#nullable disable
            __builder.AddContent(49, "        ");
            __builder.OpenElement(50, "img");
            __builder.AddAttribute(51, "class", "draggable");
            __builder.AddAttribute(52, "src", 
#nullable restore
#line 66 "C:\Users\owenp\source\repos\NEASimulator\NEASimulator\Pages\Test.razor"
                   sensor.ImageSrc

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(53, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 67 "C:\Users\owenp\source\repos\NEASimulator\NEASimulator\Pages\Test.razor"
                         (sensor as NEASimulator.Models.Draggable).OnClick

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(54, "onmousemove", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 68 "C:\Users\owenp\source\repos\NEASimulator\NEASimulator\Pages\Test.razor"
                             (sensor as NEASimulator.Models.Draggable).SetPositionToMouse

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(55, "style", "position:absolute;" + " " + (
#nullable restore
#line 69 "C:\Users\owenp\source\repos\NEASimulator\NEASimulator\Pages\Test.razor"
                                        sensor.Style_Position

#line default
#line hidden
#nullable disable
            ));
            __builder.CloseElement();
            __builder.AddMarkupContent(56, "\r\n");
#nullable restore
#line 70 "C:\Users\owenp\source\repos\NEASimulator\NEASimulator\Pages\Test.razor"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 71 "C:\Users\owenp\source\repos\NEASimulator\NEASimulator\Pages\Test.razor"
     foreach (var logger in currentState.DataLoggers)
    {
        var displaydata = logger.GetDisplayData();

        /*<img class="draggable"
             src="@logger.ImageSrc"
             @onclick="@((logger as NEASimulator.Models.Draggable).OnClick)"
             @onmousemove="@((logger as NEASimulator.Models.Draggable).SetPositionToMouse)"
             style="position:absolute; @logger.Style_Position" />*/


#line default
#line hidden
#nullable disable
            __builder.AddContent(57, "        ");
            __builder.OpenElement(58, "div");
            __builder.AddAttribute(59, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 81 "C:\Users\owenp\source\repos\NEASimulator\NEASimulator\Pages\Test.razor"
                         (logger as NEASimulator.Models.Draggable).OnClick

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(60, "onmousemove", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 82 "C:\Users\owenp\source\repos\NEASimulator\NEASimulator\Pages\Test.razor"
                             (logger as NEASimulator.Models.Draggable).SetPositionToMouse

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(61, "style", "position:absolute;" + " " + (
#nullable restore
#line 83 "C:\Users\owenp\source\repos\NEASimulator\NEASimulator\Pages\Test.razor"
                                        logger.Style_Position

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(62, "class", "datalogger");
            __builder.AddMarkupContent(63, "\r\n\r\n            ");
            __builder.OpenElement(64, "div");
            __builder.AddAttribute(65, "class", "datalogger inner");
            __builder.AddMarkupContent(66, "\r\n                ");
            __builder.OpenElement(67, "ul");
            __builder.AddMarkupContent(68, "\r\n                    <li></li>\r\n                    ");
            __builder.OpenElement(69, "li");
            __builder.AddContent(70, "Velocity at A:            ");
            __builder.AddContent(71, 
#nullable restore
#line 89 "C:\Users\owenp\source\repos\NEASimulator\NEASimulator\Pages\Test.razor"
                                                   displaydata.VelocityA

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(72, "\r\n                    ");
            __builder.OpenElement(73, "li");
            __builder.AddContent(74, "Velocity at B:            ");
            __builder.AddContent(75, 
#nullable restore
#line 90 "C:\Users\owenp\source\repos\NEASimulator\NEASimulator\Pages\Test.razor"
                                                   displaydata.VelocityB

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(76, "\r\n                    ");
            __builder.OpenElement(77, "li");
            __builder.AddContent(78, "Time from A to B:         ");
            __builder.AddContent(79, 
#nullable restore
#line 91 "C:\Users\owenp\source\repos\NEASimulator\NEASimulator\Pages\Test.razor"
                                                   displaydata.TimeDifference

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(80, "\r\n                    ");
            __builder.OpenElement(81, "li");
            __builder.AddContent(82, "Acceleration from A to B: ");
            __builder.AddContent(83, 
#nullable restore
#line 92 "C:\Users\owenp\source\repos\NEASimulator\NEASimulator\Pages\Test.razor"
                                                    ((float)displaydata.Acceleration).ToString("0.0000")

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(84, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(85, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(86, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(87, "\r\n");
#nullable restore
#line 96 "C:\Users\owenp\source\repos\NEASimulator\NEASimulator\Pages\Test.razor"
    }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 99 "C:\Users\owenp\source\repos\NEASimulator\NEASimulator\Pages\Test.razor"
       

    private Models.SaveState currentState = new Models.SaveState();
    private Models.SaveState savedState = new Models.SaveState();

    private bool paused = false;

    private float accumulator = 0f;
    private System.Diagnostics.Stopwatch stopwatch;


    private void AddObject(MouseEventArgs e, string type)
    {
        NEASimulator.Interfaces.IDisplayObject obj;
        switch (type.ToUpper())
        {
            case "BALL":
                obj = new NEASimulator.Models.Apparatus.Ball(new System.Numerics.Vector2 { X = (float)e.ClientX, Y = (float)e.ClientY }, paused);
                break;
            case "PLANK":
                obj = new NEASimulator.Models.Apparatus.Plank(new System.Numerics.Vector2 { X = (float)e.ClientX, Y = (float)e.ClientY }, Models.Apparatus.Plank.Type.Horizontal);
                break;
            case "VPLANK":
                obj = new NEASimulator.Models.Apparatus.Plank(new System.Numerics.Vector2 { X = (float)e.ClientX, Y = (float)e.ClientY }, Models.Apparatus.Plank.Type.Vertical);
                break;
            case "METRESTICK":
                obj = new NEASimulator.Models.Apparatus.MetreStick(new System.Numerics.Vector2 { X = (float)e.ClientX, Y = (float)e.ClientY });
                break;
            default:
                obj = null;
                break;
        }
        currentState.Objects.Add(obj);
    }

    private void Clear()
    {
        currentState.Objects.Clear();
    }

    private void Reset()
    {
        Clear();
        currentState = new Models.SaveState(savedState);
        this.StateHasChanged();
    }

    private void Save()
    {
        savedState = new Models.SaveState(currentState);
    }

    private void PlayPause()
    {
        paused = !paused;
        if (!paused)
        {
            stopwatch.Restart();
        }
    }

    [JSInvokable("Rerender")]
    public void Rerender()
    {
        if (stopwatch.IsRunning)
        {
            stopwatch.Stop();
        }
        if (!paused)
        {
            float seconds = stopwatch.ElapsedMilliseconds / 1000;
            stopwatch.Reset();
            stopwatch.Start();
            accumulator += seconds;
            if (accumulator > 5 * Models.Constants.dt)
            {
                accumulator = 5 * Models.Constants.dt;
            }
            while (accumulator > Models.Constants.dt)
            {
                accumulator -= Models.Constants.dt;
                UpdatePhysics();
            }
            UpdatePhysics();
            this.StateHasChanged();
        }
    }

    private void UpdatePhysics()
    {
        for (int i = 0; i < currentState.Objects.Count; i++)
        {
            if (currentState.Objects[i] is NEASimulator.Interfaces.IDynamic)
            {

                for (int k = 0; k < currentState.Objects.Count; k++)
                {
                    if (i != k && currentState.Objects[k] is NEASimulator.Interfaces.IPhysical)
                    {
                        var obj1 = (currentState.Objects[i] as NEASimulator.Interfaces.IPhysical);
                        var obj2 = (currentState.Objects[k] as NEASimulator.Interfaces.IPhysical);
                        NEASimulator.Models.Collisions.CheckCollision(ref obj1, ref obj2);
                        currentState.Objects[i] = obj1;
                        currentState.Objects[k] = obj2;
                    }

                }
                (currentState.Objects[i] as NEASimulator.Interfaces.IDynamic).CalculateAVP();
            }
        }
        UpdateDataLoggers();

    }

    private void UpdateDataLoggers()
    {
        for (int i = 0; i < currentState.Edges.Count(); i++)
        {

            for (int k = 0; k < currentState.Objects.Count; k++)
            {
                if (currentState.Objects[k] is NEASimulator.Interfaces.IDynamic)
                {
                    // Don't need to pass as references as objects wont be modified
                    if (NEASimulator.Models.Collisions.CheckCollision(currentState.Edges[i].sensor, (currentState.Objects[k] as NEASimulator.Interfaces.IDynamic)))
                    {
                        currentState.Edges[i].sensor.CollectData(currentState.Objects[k] as NEASimulator.Interfaces.IDynamic);
                    }
                }
            }

            if (currentState.Edges[i].sensor.HasData())
            {
                currentState.Edges[i].datalogger.ReceiveData(currentState.Edges[i].portnum, currentState.Edges[i].sensor.ReturnData());

                this.StateHasChanged();

            }
        }
    }

    protected override void OnAfterRender(bool firstRender)
    {
        base.OnAfterRender(firstRender);
        if (firstRender)
        {
            var dotNetReference = DotNetObjectReference.Create(this);
            JSRuntime.InvokeVoidAsync("jsTimer", dotNetReference);

            stopwatch = System.Diagnostics.Stopwatch.StartNew();

            currentState.Sensors.Add(new NEASimulator.Models.Apparatus.LightGate(new System.Numerics.Vector2(300, 300), false));
            currentState.Sensors.Add(new NEASimulator.Models.Apparatus.LightGate(new System.Numerics.Vector2(500, 300), false));

            currentState.DataLoggers.Add(new Models.Apparatus.DataLogger(new System.Numerics.Vector2(400, 500), false));

            currentState.Edges.Add(new Models.Edge() { datalogger = currentState.DataLoggers[0], sensor = currentState.Sensors[0], portnum = 0 });
            currentState.Edges.Add(new Models.Edge() { datalogger = currentState.DataLoggers[0], sensor = currentState.Sensors[1], portnum = 1 });
        }
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime JSRuntime { get; set; }
    }
}
#pragma warning restore 1591
