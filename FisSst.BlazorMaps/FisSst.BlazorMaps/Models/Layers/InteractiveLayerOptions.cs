namespace FisSst.BlazorMaps
{
    /// <summary>
    /// Determines InteractiveLayer's properties.
    /// </summary>
    public class InteractiveLayerOptions : LayerOptions
    {
        public bool Interactive { get; init; }
        public bool BubblingMouseEvents { get; init; }
    }
}
