using System;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using RIvarX;

namespace DrugAdministration
{
    
    public class Pump
    {
        public RIvar<decimal> Rate = new RIvar<decimal>();
        public RIvar<decimal> Dose = new RIvar<decimal>();
        public RIvar<decimal> Duration = new RIvar<decimal>();

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
