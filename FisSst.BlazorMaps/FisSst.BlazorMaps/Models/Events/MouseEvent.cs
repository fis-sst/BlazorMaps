namespace FisSst.BlazorMaps
{
    /// <summary>
    /// MouseEvent represents events that contains properties related to a cursor's position, such as 'click', 'dblclick'.
    /// </summary>
    public class MouseEvent : Event
    {
        public LatLng LatLng { get; set; }
    }
}
