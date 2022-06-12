using Microsoft.VisualStudio.TestTools.UnitTesting;
using AsteriodeWEB.Controllers;
using AsteriodeWEB.Exceptions;

namespace AsteroideTest
{
    [TestClass]
    public class AsteroideUnitTest
    {
        //Metodo sin argumentos
        [TestMethod]
        public void TestCamposObligatorio()
        {

            var controller = new AsteroidsController();
            Assert.ThrowsException<AsteroideException>(() => controller.GetAsteroids());

        }
        //Metodo con dias mayor que 7
        [TestMethod]
        public void TestDiasMayor7()
        {
            int days = 12;
            var controller = new AsteroidsController();
            Assert.ThrowsException<AsteroideException>(() => controller.GetAsteroids(days));
        }

        //Metodo con dias menos que 1
        [TestMethod]
        public void TestDiasMenor1()
        {
            int days = 0;
            var controller = new AsteroidsController();
            Assert.ThrowsException<AsteroideException>(() => controller.GetAsteroids(days));
        }
        //Metodo con ejecucion ok
        [TestMethod]
        public void TestOKDias4()
        {
            int days = 4;
            var controller = new AsteroidsController();
            var result = controller.GetAsteroids(days);
            Assert.IsNotNull(result);
        }
    }
}
