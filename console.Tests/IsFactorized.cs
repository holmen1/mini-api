using NUnit.Framework;
using console;
using System;
using System.Threading.Tasks;

namespace console.UnitTests.Services
{
    [TestFixture]
    public class IsFactorized
    {
        private Factory _factory;

        [SetUp]
        public void SetUp()
        {
            string jparams = "{\"name\":\"Foo\",\"A\":[[1.0, 0.032], [0.032, 1.0]]}";
            _factory = new Factory(jparams);
        }

        [Test]
        public async Task IsDiffLessThanTolReturnTrue()
        {
            var a = _factory.GetFactors();
            Factory.Factors factors = await a;

            // Control, multiply factors A = S[0] U[:,0] Vh[0,:] + S[1] U[:,1] Vh[1,:] 
            double a11 = factors.S[0] * factors.U[0][0] * factors.Vh[0][0]
             + factors.S[1] * factors.U[0][1] * factors.Vh[1][0];
            double a12 = factors.S[0] * factors.U[0][0] * factors.Vh[0][1]
             + factors.S[1] * factors.U[0][1] * factors.Vh[1][1];
            double a21 = factors.S[0] * factors.U[1][0] * factors.Vh[0][0]
             + factors.S[1] * factors.U[1][1] * factors.Vh[1][0];
            double a22 = factors.S[0] * factors.U[1][0] * factors.Vh[0][1]
             + factors.S[1] * factors.U[1][1] * factors.Vh[1][1];

            double diff = Math.Abs(a11 - 1.0) + Math.Abs(a12 - 0.032) +
                            Math.Abs(a21 - 0.032) + Math.Abs(a22 - 1.0);
            Assert.Less(diff, 1E-6, "Error above tolerance");
        }
    }
}