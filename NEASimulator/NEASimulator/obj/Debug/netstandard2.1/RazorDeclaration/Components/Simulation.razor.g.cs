#pragma checksum "C:\Users\owenp\Git Hub Repositories\ComputerScienceNEA\NEASimulator\NEASimulator\Components\Simulation.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a11174dc5eeec7e7f1e5fba4c2929dc5bafb43c5"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

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
    public partial class Simulation : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 33 "C:\Users\owenp\Git Hub Repositories\ComputerScienceNEA\NEASimulator\NEASimulator\Components\Simulation.razor"
       

    [Parameter]
    public Models.SaveState Preset { get; set; }

    private List<Models.AvailableApparatus> available = new List<Models.AvailableApparatus>();

    private Models.SaveState currentState = new Models.SaveState();
    private Models.SaveState savedState = new Models.SaveState();

    private bool paused = false;
    private bool makingEdge = false;
    private Models.Apparatus.DataLogger dataloggerToConnect;
    private int portToConnect;

    private float accumulator = 0f;
    private System.Diagnostics.Stopwatch stopwatch;

    public void MakeEdge(Models.Apparatus.DataLogger logger, int port)
    {
        makingEdge = true;
        dataloggerToConnect = logger;
        portToConnect = port;
        logger.OnClick();
    }

    public void RemoveEdge(Models.Apparatus.DataLogger logger, int port)
    {
        Models.Edge? edge = currentState.Edges.FirstOrDefault(e => e.datalogger == logger && e.portnum == port);
        if (edge != null)
        {
            currentState.Edges.Remove(edge.Value);
        }
    }

    public void SensorClick(Interfaces.ISensor sensor)
    {
        if (makingEdge)
        {
            currentState.Edges.Add(new Models.Edge() { datalogger = dataloggerToConnect, sensor = sensor, portnum = portToConnect });
            makingEdge = false;
        }
        else
        {
            if (sensor is Models.Draggable)
            {
                (sensor as Models.Draggable).OnClick();
            }
        }
    }

    public void AddObject(MouseEventArgs e, string type)
    {
        NEASimulator.Interfaces.IDisplayObject obj;
        switch (type.ToUpper())
        {
            case "DATALOGGER":
                currentState.DataLoggers.Add(new Models.Apparatus.DataLogger(new System.Numerics.Vector2 { X = (float)e.ClientX, Y = (float)e.ClientY }));
                return;
            case "LIGHTGATE":
                currentState.Sensors.Add(new Models.Apparatus.LightGate(new System.Numerics.Vector2 { X = (float)e.ClientX, Y = (float)e.ClientY }));
                return;
            case "STOPWATCH":
                currentState.Stopwatches.Add(new Models.Apparatus.UserStopwatch(new System.Numerics.Vector2 { X = (float)e.ClientX, Y = (float)e.ClientY }));
                return;
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

    public void Clear()
    {
        currentState = new Models.SaveState();
    }

    public void Reset()
    {
        Clear();
        currentState = new Models.SaveState(savedState);
        this.StateHasChanged();
    }

    public void Save()
    {
        savedState = new Models.SaveState(currentState);
    }

    public void PlayPause()
    {
        paused = !paused;
        if (!paused)
        {
            stopwatch.Restart();
            foreach(var sw in currentState.Stopwatches)
            {
                if (sw.StartWithSimulation)
                {
                    sw.Start();
                    sw.OnClick();
                }
            }
        }else
        {
            foreach (var sw in currentState.Stopwatches)
            {
                if (sw.StartWithSimulation)
                {
                    sw.Stop();
                    sw.OnClick();
                }
            }
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
        }
        this.StateHasChanged();
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

            currentState = Preset;

            Save();

            paused = true;
        }
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime JSRuntime { get; set; }
    }
}
#pragma warning restore 1591
