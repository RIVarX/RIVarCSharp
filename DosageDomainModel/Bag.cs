using System.Reactive.Subjects;
using RIvarX;

namespace SignalExample_InfusionTherapy
{
    public class Bag: IBag
    {
        public RIvar<IOperand> Amount { get; set; } = new RIvar<IOperand>();
        public RIvar<IOperand> Volume { get; set; } = new RIvar<IOperand>();
        public RIvar<IOperand> Concentration { get; set; } = new RIvar<IOperand>();

        public Bag()
        {
            Concentration.Set(Amount.Div(Volume));
            Amount.Set(Concentration.Mul(Volume));
            Volume.Set(Amount.Div(Concentration));
        }
      
    }
}
