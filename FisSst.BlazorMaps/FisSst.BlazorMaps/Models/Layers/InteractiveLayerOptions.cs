namespace FisSst.BlazorMaps
{
    /// <summary>
    /// InteractiveLayerOptions determine InteractiveLayer's properties.
    /// </summary>
    public class InteractiveLayerOptions : LayerOptions
    {
        public bool Interactive { get; init; }
        public bool BubblingMouseEvents { get; init; }
    }
}
