using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Linq;



namespace RIVarX
{
    public class RIVar<T> : ISubject<Signal<T>>
    {
        ISubject<Signal<T>> _subject;

        /// <summary>
        /// relate source to target, so that for any (new) change in the source, the target is updated
        /// </summary>
        public void Set(Expression<T> source)
        {
            var targetWithInitialValue = _subject.StartWith(new Signal<T>(default(T),new int[] { 0 }));

            var streamOfChanges = Observable.CombineLatest(source, targetWithInitialValue, (valueInSource, valueInTarget) => new Tuple<Signal<T>, Signal<T>>(valueInSource, valueInTarget));

            var streamOfChangesInSource = streamOfChanges.Where(change => change.Item1?.CompareTo(change.Item2) > 0).Select(change => change.Item1);

            //streamOfChangesInSource.Subscribe(o=> {
            //    System.IO.File.AppendAllText($"sets.txt", $"\r\ntrigger {o.Value} <{string.Join(",", o.PrioritySet)}>");
            //    _subject.OnNext(o);
            //    System.IO.File.AppendAllText($"sets.txt", $"\r\nafter trigger {o.Value} <{string.Join(",", o.PrioritySet)}>");
            //});// update the target for changes in the source

            streamOfChangesInSource.Subscribe(_subject.OnNext);// update the target for changes in the source
        }

    

        public RIVar()
        {
            _subject = new Subject<Signal<T>>();
        }
        public void OnCompleted()
        {
            _subject.OnCompleted();
        }

        public void OnError(Exception error)
        {
            _subject.OnError(error);
        }

        public void OnNext(Signal<T> value)
        {
            _subject.OnNext(value);
        }

        public IDisposable Subscribe(IObserver<Signal<T>> observer)
        {
            return _subject.Subscribe(observer);
        }
    }
}

