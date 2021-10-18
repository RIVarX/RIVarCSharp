using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using ReactiveVariablesExtension;

namespace DosageDomainModel
{

    public class Bag: IBag
    {
        public ISubject<SignalValue<IOperand>> Amount { get; set; } = new Subject<SignalValue<IOperand>>();
        public ISubject<SignalValue<IOperand>> Volume { get; set; } = new Subject<SignalValue<IOperand>>();
        public ISubject<SignalValue<IOperand>> Concentration { get; set; } = new Subject<SignalValue<IOperand>>();

        public Bag()
        {
            Concentration.Set(Amount.Div(Volume));
            Amount.Set(Concentration.Mul(Volume));
            Volume.Set(Amount.Div(Concentration));
        }
      
    }
}
