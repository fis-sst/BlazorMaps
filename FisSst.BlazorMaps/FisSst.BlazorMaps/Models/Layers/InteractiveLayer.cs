using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps
{
    /// <summary>
    /// Some Layers can be made interactive - when the user interacts with such a layer,
    /// mouse events like click and mouseover can be handled.
    /// </summary>
    public abstract class InteractiveLayer : Layer
    {
        public async Task OnMouseEvent(MouseEventType mouseEventType, Func<MouseEvent, Task> callback)
        {
            await this.AddMouseEventListener(mouseEventType, callback);
        }

        public async Task OffMouseEvent(MouseEventType mouseEventType)
        {
            await this.RemoveMouseEventListener(mouseEventType);
        }
    }
}
