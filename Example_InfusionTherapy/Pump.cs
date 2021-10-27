using System;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using RIvarX;

namespace SignalExample_InfusionTherapy
{
    
    public class Pump
    {
        public RIvar<IOperand> Rate = new RIvar<IOperand>();
        public RIvar<IOperand> Dose = new RIvar<IOperand>();
        public RIvar<IOperand> Duration = new RIvar<IOperand>();

        public Pump(IBag bag)
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
