using System;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using ReactiveVariablesExtension;

namespace DosageDomainModel
{
    
    public class InfusedBag
    {
        public ISubject<SignalValue<IOperand>> Rate = new Subject<SignalValue<IOperand>>();
        public ISubject<SignalValue<IOperand>> Dose = new Subject<SignalValue<IOperand>>();
        public ISubject<SignalValue<IOperand>> Duration = new Subject<SignalValue<IOperand>>();

        public InfusedBag(IBag bag)
        {
           

            Dose.Set(bag.Amount.Div(Duration));
            Rate.Set(bag.Volume.Div(Duration));

            Duration.Set(bag.Amount.Div(Dose));
            Duration.Set(bag.Volume.Div(Rate));

            bag.Amount.Set(Duration.Mul(Dose));
            bag.Volume.Set(Duration.Mul(Rate));

           // bag.Amount.OnNext(7);


        }
 
    }
}
