using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Linq;
using ReactiveVariablesExtension;

namespace DosageDomainModel.another
{
  public  class GlitchExample
    {
        public Subject<SignalValue<int>> seconds = new Subject<SignalValue<int>>();
        public IObservable<SignalValue<int>> t;
        public IObservable<SignalValue<bool>> g;
        public GlitchExample()
        {
            t = seconds.Select(_ => new SignalValue<int>(_.Value + 1, _.PrioritySet));
            g = seconds.CombineLatestSignal(t, (sec, y) => y > sec);//.Monotonic(); //monotonic prevent glitch
        }
    }
}
