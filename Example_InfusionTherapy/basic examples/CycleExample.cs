using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive;
using System.Reactive.Subjects;
using System.Reactive.Linq;
using ReactiveVariablesExtension;

namespace DosageDomainModel
{
    public class CycleExample
    {
        public Subject<SignalValue<double>> width = new Subject<SignalValue<double>>();
        public Subject<SignalValue<double>> right = new Subject<SignalValue<double>>();
        public Subject<SignalValue<double>> left = new Subject<SignalValue<double>>();

        public CycleExample()
        {
            f(right, left, (r, l) => r - l, width);

            f(width, left, (x, y) => x + y, right);

            f(right, width, (x, y) => x - y, left);
        }

        void f<T>(ISubject<SignalValue<T>> subject1, ISubject<SignalValue<T>> subject2,Func<T,T,T> resultSelector, ISubject<SignalValue<T>> target)
        {
            subject1.CombineLatestSignal(subject2, resultSelector).StartWith(default(SignalValue<T>))
             .CombineLatest(target.StartWith(default(SignalValue<T>)) ,(c, w) => new { c = c, w = w })
             .Where(p => p.c != null)
           .Where(pair => pair.c.CompareTo(pair.w) > 0).Subscribe(val => target.OnNext(val.c));
        }

    }
}
