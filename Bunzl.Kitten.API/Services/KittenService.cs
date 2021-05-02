using System.Drawing;
using System.Threading.Tasks;
using Bunzl.Kitten.API.Infrastructure.Cataas;

namespace Bunzl.Kitten.API.Services
{
    public class KittenService : IKittenService
    {
        private readonly ICataasApi _api;

        public KittenService(ICataasApi api)
        {
            _api = api;
        }

        public async Task<byte[]> GetAsync()
        {
            Image image = await _api.GetAsync();
            Domain.User.KittenImage kittenImage = new(image);

            return kittenImage.GetRotatedBy180();
        }
    }
}