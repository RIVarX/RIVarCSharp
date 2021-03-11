using System;
using System.Reactive.Linq;
using System.Linq;
using System.Reactive.Subjects;
using ReactiveVariablesExtension;

namespace ReactiveVariablesExtension.FifoInputs
{
    public static class FifoInputs
    {
        public static void Set<T>(this ISubject<SignalValue<T>> target, IObservable<SignalValue<T>> items)
        {
            Observable.CombineLatest(items, target.StartWith(default(SignalValue<T>)), (c, w) => new { c = c, w = w })
                    .Where(pair => pair.c.CompareTo(pair.w) > 0).Subscribe(val => target.OnNext(val.c));
        }
    }
}

