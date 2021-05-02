using System.Threading.Tasks;

namespace Bunzl.Kitten.API.Services
{
    public interface IKittenService
    {
        Task<byte[]> GetAsync();
    }
}
