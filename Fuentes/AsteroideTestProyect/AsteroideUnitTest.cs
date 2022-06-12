using Microsoft.VisualStudio.TestTools.UnitTesting;
using AsteriodeWEB.Controllers;

namespace AsteroideTest
{
    [TestClass]
    public class AsteroideUnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {

            var controller = new AsteroidsController();
            var result = controller.GetAsteroids();
        }

        [TestMethod]
        public void TestMethod2()
        {
            int days = 12;
            var controller = new AsteroidsController();
            var result = controller.GetAsteroids(days);
        }


        [TestMethod]
        public void TestMethod3()
        {
            int days = -5;
            var controller = new AsteroidsController();
            var result = controller.GetAsteroids(days);
        }

        [TestMethod]
        public void TestMethod4()
        {
            int days = 4;
            var controller = new AsteroidsController();
            var result = controller.GetAsteroids(days);
        }
    }
}
