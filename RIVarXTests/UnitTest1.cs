using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RIVarX;

namespace RIVarXTests
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void SimpleUsage()
        {
            //Construction
            int result = 0;
            var X = new RIVar<int>();
            var Y = new RIVar<int>();
            var Z = new RIVar<int>();
            Func<int, int, int> plus = (x, y) => x + y;
            Z.Set(plus.Lift(X, Y));      
            Z.Subscribe(new observer<int>(i => { result = i; }));

            //Action
            X.OnNext(2);
            Y.OnNext(3);

            //Test
            Assert.AreEqual(5, result);         
        }

        [TestMethod]
        public void DiamondGlitchFreedom()
        {
            //Construction
            int result = 0;
            int numberOfUpdates = 0;
            var X = new RIVar<int>();
            var Y1 = new RIVar<int>();
            var Y2 = new RIVar<int>();
            var Z = new RIVar<int>();
            Y1.Set(X);
            Y2.Set(X);
            Func<int, int, int> plus = (x, y) => x + y;
            Z.Set(plus.Lift(Y1, Y2));
            Z.Subscribe(new observer<int>(i=>{ result = i; numberOfUpdates++; }));

            //Action
            X.OnNext(2);
            X.OnNext(3);

            //Test
            Assert.AreEqual(6, result);
            Assert.AreEqual(2, numberOfUpdates);
        }


    }

    class observer<T> : IObserver<Signal<T>>
    {
        Action<Signal<T>> _action;
        public observer(Action<Signal<T>> action)
        {
            this._action = action;
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(Signal<T> value)
        {
            _action(value);
        }

        public static implicit operator observer<T>(Action<Signal<T>> action) => new observer<T>(action);
    }
}
