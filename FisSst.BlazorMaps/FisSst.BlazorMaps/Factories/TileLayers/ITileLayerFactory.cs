using System.Threading.Tasks;

namespace FisSst.BlazorMaps
{
    public interface ITileLayerFactory
    {
        Task<TileLayer> Create(string urlTemplate, TileLayerOptions options);
    }
}
