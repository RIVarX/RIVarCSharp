using System;
using System.Reactive.Linq;
using System.Linq;
using System.Reactive.Subjects;

namespace RIvarX
{
    public static class SignalExtension
    {
        public static void Set<T>(this ISubject<Signal<T>> target, IObservable<Signal<T>> source)
        {
            var targetWithInitialValue = target.StartWith(default(Signal<T>));

            var streamOfChanges = Observable.CombineLatest(source, targetWithInitialValue, (valueInSource, valueInTarget) => new Tuple<Signal<T>, Signal<T>>(valueInSource, valueInTarget));

            var streamOfChangesInSource = streamOfChanges.Where(change => change.Item1.CompareTo(change.Item2) > 0).Select(change => change.Item1);

            streamOfChangesInSource.Subscribe(target.OnNext);// update the target for changes in the source
        }

        public static IObservable<Signal<T>> SelectLatest<T>(this IObservable<Signal<T>> source, params IObservable<Signal<T>>[] moreSources)
        {
            var allSources = moreSources.Union(new[] { source }).ToArray();

            return SelectLatest(allSources);
        }

        private static IObservable<Signal<T>> SelectLatest<T>(this IObservable<Signal<T>>[] sources)
        {
            return Observable.CombineLatest(sources.Select(o => o.StartWith(default(Signal<T>))), o => o)
            .Select(valuesFromAllSources => valuesFromAllSources.Where(o => o != default(Signal<T>)).Max())
            .DistinctUntilChanged()
            .Publish().RefCount();
        }

        public static IObservable<Signal<TResult>> CombineLatestSignal<T1,T2, TResult>(this IObservable<Signal<T1>> observable1, IObservable<Signal<T2>> observable2, Func<T1, T2, TResult> resultSelector)
        {
            return Observable.CombineLatest(observable1.Monotonic(), observable2.Monotonic(), (x, y) => ProduceResult(resultSelector, x, y))
                .Publish().RefCount();
        }
        public static IObservable<Signal<TResult>> SelectLatestSignal<T, TResult>(this IObservable<Signal<T>> observable, Func<T, TResult> resultSelector)
        {
            return observable.Monotonic().Select(o =>
            o == null ? default(Signal<TResult>) : new Signal<TResult>(resultSelector(o.Value),o.PrioritySet)).Publish().RefCount();
        }

        private static Signal<TResult> ProduceResult<T1,T2, TResult>(Func<T1, T2, TResult> resultSelector, Signal<T1> x, Signal<T2> y)
        {
            if (x != default(Signal<T1>) && y != default(Signal<T2>))
            {
                if (x.Value != null && !x.Value.Equals(default(T1)) && y.Value != null && !y.Value.Equals(default(T2)))
                    return new Signal<TResult>(resultSelector(x.Value, y.Value), x.PrioritySet.Union(y.PrioritySet).ToArray());
                return new Signal<TResult>(default(TResult), x.PrioritySet.Union(y.PrioritySet).ToArray());
            }

            if (x != default(Signal<T1>))
            {
                return new Signal<TResult>(default(TResult), x.PrioritySet.Union(new int[] { 0 }).ToArray());
            }

            if (y != default(Signal<T2>))
            {
                return new Signal<TResult>(default(TResult), y.PrioritySet.Union(new int[] { 0 }).ToArray());
            }

            return default(Signal<TResult>);

        }

        /// <summary>
        /// ignore "glitch" values
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IObservable<Signal<T>> Monotonic<T>(this IObservable<Signal<T>> source)
        {
            return source.Select(o => o).Scan((x, y) => x.CompareTo(y) > 0 ? x : y).Select(o => o).DistinctUntilChanged().Select(o => o);
        }


    }
}

