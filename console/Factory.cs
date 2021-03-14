using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace console
{
    public class Factory
    {
        private string _jparams;
        private static readonly HttpClient Client = new HttpClient();
        
        public Factory(string jparams)
        {
            _jparams = jparams;
            Client.BaseAddress = new Uri("http://localhost:8080/items/");
        }

        

        public async Task<string> GetJsonFactors()
        {
            using var content = new StringContent(_jparams, Encoding.UTF8, "application/json");

            var response = await Client.PostAsync((Uri)null, content);
            using var contentStream = await response.Content.ReadAsStreamAsync();
            var jfactors = await JsonSerializer.DeserializeAsync<Factors>(contentStream);

            var json = JsonSerializer.Serialize(jfactors);
            return json;
        }

        public async Task<Factors> GetFactors()
        {
            using var content = new StringContent(_jparams, Encoding.UTF8, "application/json");

            var response = await Client.PostAsync((Uri)null, content);
            using var contentStream = await response.Content.ReadAsStreamAsync();
            var jfactors = await JsonSerializer.DeserializeAsync<Factors>(contentStream);

            return jfactors;
        }

        public class Factors
        {
            public double[][] U { get; set; }
            public double[] S { get; set; }
            public double[][] Vh { get; set; }
        }
    }
}
