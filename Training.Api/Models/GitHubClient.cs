using System.Net.Http;

namespace Training.Api
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