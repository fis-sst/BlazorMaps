using FisSst.Maps.Models;
using System.Threading.Tasks;

namespace FisSst.Maps.Factories
{
    public interface IIconFactory
    {
        Task<Icon> Create(IconOptions options);
        Task<Icon> CreateDefault();
    }
}
