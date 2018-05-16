using System.Net.Http;

namespace CarWebApi
{
    public class GitHubClient
    {

        public GitHubClient(HttpClient httpClient)
        {
            Client = httpClient;
        }

        public HttpClient Client { get; }
    }
}