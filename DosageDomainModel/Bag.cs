using System.Reactive.Subjects;
using RIvarX;

namespace SignalExample_InfusionTherapy
{
    public class Bag: IBag
    {
        public ISubject<Signal<IOperand>> Amount { get; set; } = new Subject<Signal<IOperand>>();
        public ISubject<Signal<IOperand>> Volume { get; set; } = new Subject<Signal<IOperand>>();
        public ISubject<Signal<IOperand>> Concentration { get; set; } = new Subject<Signal<IOperand>>();

        public Bag()
        {
            Concentration.Set(Amount.Div(Volume));
            Amount.Set(Concentration.Mul(Volume));
            Volume.Set(Amount.Div(Concentration));
        }
      
    }
}
