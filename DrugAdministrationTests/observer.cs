using System;
using RIvarX;

namespace DrugAdministrationTests
{
    class observer : IObserver<Signal<decimal>>
    {
        Action<Signal<decimal>> action;
        public observer(Action<Signal<decimal>> action)
        {
            this.action = action;
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(Signal<decimal> value)
        {
            action(value);
        }
    }
}
