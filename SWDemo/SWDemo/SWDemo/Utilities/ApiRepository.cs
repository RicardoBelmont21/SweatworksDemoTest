using SWDemo.Models.Response.Books;
using SWDemo.Settings;
using System.Threading.Tasks;

namespace SWDemo.Utilities
{
    public class ApiRepository
    {
        protected RestClient client;

        public ApiRepository()
        {
            client = new RestClient();
        }

        public async Task<GetBooksResponse> GetBooksByKeyword(string keyword, long page, int itemsPPage = 20)
        {
            try
            {
                var response = await client.Get<GetBooksResponse>(string.Format(Methods.GetBooksByName, keyword, page*itemsPPage, itemsPPage));
                if (response != null)
                    return response;
            }
            catch { }
            return new GetBooksResponse() { Success = false };
        }
    }
}
