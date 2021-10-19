using System;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using RIvarX;

namespace DosageDomainModel
{
    
    public class InfusedBag
    {
        public ISubject<Signal<IOperand>> Rate = new Subject<Signal<IOperand>>();
        public ISubject<Signal<IOperand>> Dose = new Subject<Signal<IOperand>>();
        public ISubject<Signal<IOperand>> Duration = new Subject<Signal<IOperand>>();

        public InfusedBag(IBag bag)
        {
           

            Dose.Set(bag.Amount.Div(Duration));
            Rate.Set(bag.Volume.Div(Duration));

            Duration.Set(bag.Amount.Div(Dose));
            Duration.Set(bag.Volume.Div(Rate));

            bag.Amount.Set(Duration.Mul(Dose));
            bag.Volume.Set(Duration.Mul(Rate));

        }
 
    }
}
