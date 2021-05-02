using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Bunzl.Kitten.API.Infrastructure.Cataas
{
    public class CataasApi : ICataasApi
    {
        public async Task<Image> GetAsync()
        {
            Image result = null;

            using (HttpClient client = new())
            {
                Stream catStream = await client.GetStreamAsync("https://cataas.com/cat");
                result = Image.FromStream(catStream);
            }

            return result;
        }
    }
}
