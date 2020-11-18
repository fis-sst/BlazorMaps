using System.Threading.Tasks;

namespace FisSst.BlazorMaps
{
    /// <summary>
    /// IIconFactory is responsible for creating icons.
    /// </summary>
    public interface IIconFactory
    {
        Task<Icon> Create(IconOptions options);
        Task<Icon> CreateDefault();
    }
}
