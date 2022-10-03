using System;

namespace RIVarX
{
    public class Expression<T> : IObservable<Signal<T>>
    {
        IObservable<Signal<T>> _stream;
        public Expression(IObservable<Signal<T>> stream)
        {
            _stream = stream;
        }

        public IDisposable Subscribe(IObserver<Signal<T>> observer)
        {
            return _stream.Subscribe(observer);
        }
     
    }


}
