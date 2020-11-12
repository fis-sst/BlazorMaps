using FisSst.BlazorMaps.Models;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps.Factories
{
    public interface IIconFactory
    {
        Task<Icon> Create(IconOptions options);
        Task<Icon> CreateDefault();
    }
}
