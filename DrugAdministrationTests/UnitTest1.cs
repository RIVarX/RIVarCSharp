using DrugAdministration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DrugAdministrationTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            decimal result=0;
            var bag = new Bag();
            bag.Concentration.Subscribe(new observer(o => result = o));

            bag.Amount.OnNext(100);
            bag.Volume.OnNext(200);

            Assert.AreEqual(0.5, result);
        }

        [TestMethod]
        public void TestMethod2()
        {
            decimal result = 0;
            var bag = new Bag();
            bag.Concentration.Subscribe(new observer(o => result = o));

            var pump = new Pump(bag);
            bag.Amount.OnNext(100);
            bag.Volume.OnNext(200);

            Assert.AreEqual(0.5, result);
        }

     


    }
}
