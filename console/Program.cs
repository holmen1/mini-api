using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
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
            Console.WriteLine(jparams);
            Console.WriteLine("Factorize A = U S Vh");

            client.BaseAddress = new Uri("http://localhost:8080/items/");
            using var content = new StringContent(jparams, Encoding.UTF8, "application/json");

            var response = await client.PostAsync((Uri)null, content);
            using var contentStream = await response.Content.ReadAsStreamAsync();
            var jfactors = await JsonSerializer.DeserializeAsync<Factors>(contentStream);

            // Control, multiply factors A = S[0] U[:,0] Vh[0,:] + S[1] U[:,1] Vh[1,:] 
            double a11 = jfactors.S[0] * jfactors.U[0][0] * jfactors.Vh[0][0]
             + jfactors.S[1] * jfactors.U[0][1] * jfactors.Vh[1][0];
            double a12 = jfactors.S[0] * jfactors.U[0][0] * jfactors.Vh[0][1]
             + jfactors.S[1] * jfactors.U[0][1] * jfactors.Vh[1][1];
            double a21 = jfactors.S[0] * jfactors.U[1][0] * jfactors.Vh[0][0]
             + jfactors.S[1] * jfactors.U[1][1] * jfactors.Vh[1][0];
            double a22 = jfactors.S[0] * jfactors.U[1][0] * jfactors.Vh[0][1]
             + jfactors.S[1] * jfactors.U[1][1] * jfactors.Vh[1][1];

            Console.WriteLine($"a11: {Math.Round(a11, 3)} \t\t a12: {Math.Round(a12, 3)}");
            Console.WriteLine($"a21: {Math.Round(a21, 3)} \t a22: {Math.Round(a22, 3)}");
        }

        public class Factors
        {
            public double[][] U { get; set; }
            public double[] S { get; set; }
            public double[][] Vh { get; set; }
        }
    }
}
