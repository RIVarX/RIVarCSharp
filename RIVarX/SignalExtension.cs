using System;
using System.Reactive.Linq;
using System.Linq;
using System.Reactive.Subjects;

namespace RIVarX
{
    public static class SignalExtension
    {
        public static Expression<TResult> Lift<T1, T2, TResult>(this Func<T1, T2, TResult> func, RIVar<T1> operand1, RIVar<T2> operand2)
        {
            var stream = Observable.CombineLatest(operand1.Monotonic().Select(o => o), operand2.Monotonic().Select(o => o), (x, y) => ProduceResult(func, x, y))
               .Publish().RefCount();

            return new Expression<TResult>(stream);
        }

        private static Signal<TResult> ProduceResult<T1, T2, TResult>(Func<T1, T2, TResult> resultSelector, Signal<T1> x, Signal<T2> y)// where TResult : class
        {
            if (x != default(Signal<T1>) && y != default(Signal<T2>))
            {
                if (x.Value != null && !x.Value.Equals(default(T1)) && y.Value != null && !y.Value.Equals(default(T2)))
                    return new Signal<TResult>(resultSelector(x.Value, y.Value), x.PrioritySet.Union(y.PrioritySet).ToArray());
                return new Signal<TResult>(default(TResult), x.PrioritySet.Union(y.PrioritySet).ToArray());
            }


            if (x != default(Signal<T1>))
            {
                //   if (typeof(T1) == typeof(TResult))
                //  return new Signal<TResult>(x.Value as TResult, x.PrioritySet.Union(new int[] { 0 }).ToArray());
                return new Signal<TResult>(default(TResult), x.PrioritySet.Union(new int[] { }).ToArray());
            }

            if (y != default(Signal<T2>))
            {
                return new Signal<TResult>(default(TResult), y.PrioritySet.Union(new int[] { }).ToArray());
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
            return source.Select(o => o).Scan((x, y) => y.CompareTo(x) > 0 ? y : x).Select(o => o).DistinctUntilChanged().Select(o => o);
        }


        #region MoreThanTwo Merge several streams
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
        #endregion
    }
}

