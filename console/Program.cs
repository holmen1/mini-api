using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace console
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            await Factorize();
        }

        private static async Task Factorize()
        {
            string jparams = "{\"name\":\"Foo\",\"A\":[[1.0, 0.032], [0.032, 1.0]]}";
            client.BaseAddress = new Uri("http://localhost:8080/items/");
            using var content = new StringContent(jparams, Encoding.UTF8, "application/json");
            var response = await client.PostAsync((Uri)null, content);
            var factors = await response.Content.ReadAsStringAsync();

            Console.Write(factors);
        }
    }
}
