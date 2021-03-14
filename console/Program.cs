using System;
using System.Threading.Tasks;


namespace console
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await Factorize();
        }

        private static async Task Factorize()
        {
            string jparams = "{\"name\":\"Foo\",\"A\":[[1.0, 0.032], [0.032, 1.0]]}";
            Factory factory = new Factory(jparams);
            Console.WriteLine(jparams);
            Console.WriteLine("Factorize A = U S Vh");

            var v = factory.GetJsonFactors();
            string content = await v;

            Console.WriteLine($"Result: {content}");
        }
    }
}
