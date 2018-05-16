using System;
using System.Net.Http;

namespace ConloseAppHttpClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            SendRequest();
            Console.ReadLine();
        }

        private static async void SendRequest()
        {
            for (int i = 0; i < 10; i++)
            {
                using (var client = new HttpClient())
                {

                    var result = await client.GetAsync("http://web.de");
                    Console.WriteLine("SendRequest:" + result.StatusCode);
                }

            }
            Console.WriteLine("SendRequest done") ;

        }

    }
}
