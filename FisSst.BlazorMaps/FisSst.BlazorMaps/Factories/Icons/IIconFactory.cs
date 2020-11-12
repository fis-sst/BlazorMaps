using System.Threading.Tasks;

namespace FisSst.BlazorMaps
{
    public interface IIconFactory
    {
        Task<Icon> Create(IconOptions options);
        Task<Icon> CreateDefault();
    }
}
