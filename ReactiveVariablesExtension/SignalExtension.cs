using System;
using System.Reactive.Linq;
using System.Linq;
using System.Reactive.Subjects;

namespace ReactiveVariablesExtension
{
    public static class SignalExtension
    {
        public static void Set<T>(this ISubject<SignalValue<T>> target, IObservable<SignalValue<T>> source)
        {
            var targetWithInitialValue = target.StartWith(default(SignalValue<T>));

            var streamOfChanges = Observable.CombineLatest(source, targetWithInitialValue, (valueInSource, valueInTarget) => new Tuple<SignalValue<T>, SignalValue<T>>(valueInSource, valueInTarget));

            var streamOfChangesInSource = streamOfChanges.Where(change => change.Item1.CompareTo(change.Item2) > 0).Select(change => change.Item1);

            streamOfChangesInSource.Subscribe(target.OnNext);// update the target for changes in the source
        }

        public static IObservable<SignalValue<T>> SelectLatest<T>(this IObservable<SignalValue<T>> source, params IObservable<SignalValue<T>>[] moreSources)
        {
            var allSources = moreSources.Union(new[] { source }).ToArray();

            return SelectLatest(allSources);
        }

        private static IObservable<SignalValue<T>> SelectLatest<T>(this IObservable<SignalValue<T>>[] sources)
        {
            return Observable.CombineLatest(sources.Select(o => o.StartWith(default(SignalValue<T>))), o => o)
            .Select(valuesFromAllSources => valuesFromAllSources.Where(o => o != default(SignalValue<T>)).Max())
            .DistinctUntilChanged()
            .Publish().RefCount();
        }

        public static IObservable<SignalValue<TResult>> CombineLatestSignal<T, TResult>(this IObservable<SignalValue<T>> observable1, IObservable<SignalValue<T>> observable2, Func<T, T, TResult> resultSelector)
        {
            return Observable.CombineLatest(observable1.Monotonic(), observable2.Monotonic(), (x, y) => ProduceResult(resultSelector, x, y))
                .Publish().RefCount();
        }

        private static SignalValue<TResult> ProduceResult<T, TResult>(Func<T, T, TResult> resultSelector, SignalValue<T> x, SignalValue<T> y)
        {
            if (x != default(SignalValue<T>) && y != default(SignalValue<T>))
            {
                if (x.Value != null && !x.Value.Equals(default(T)) && y.Value != null && !y.Value.Equals(default(T)))
                    return new SignalValue<TResult>(resultSelector(x.Value, y.Value), x.PrioritySet.Union(y.PrioritySet).ToArray());
                return new SignalValue<TResult>(default(TResult), x.PrioritySet.Union(y.PrioritySet).ToArray());
            }

            if (x != default(SignalValue<T>))
            {
                return new SignalValue<TResult>(default(TResult), x.PrioritySet.Union(new int[] { 0 }).ToArray());
            }

            if (y != default(SignalValue<T>))
            {
                return new SignalValue<TResult>(default(TResult), y.PrioritySet.Union(new int[] { 0 }).ToArray());
            }

            return default(SignalValue<TResult>);

        }

        /// <summary>
        /// ignore "glitch" values
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IObservable<SignalValue<T>> Monotonic<T>(this IObservable<SignalValue<T>> source)
        {
            return source.Select(o => o).Scan((x, y) => x.CompareTo(y) > 0 ? x : y).Select(o => o).DistinctUntilChanged().Select(o => o);
        }


    }
}

