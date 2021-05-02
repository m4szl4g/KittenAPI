using System.Drawing;
using System.Threading.Tasks;

namespace Bunzl.Kitten.API.Infrastructure.Cataas
{
    public interface ICataasApi
    {
        Task<Image> GetAsync();
    }
}
