using System;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using RIVarX;

namespace DrugAdministration
{
    
    public class Pump
    {
        public RIVar<decimal> Rate = new RIVar<decimal>();
        public RIVar<decimal> Dose = new RIVar<decimal>();
        public RIVar<decimal> Duration = new RIVar<decimal>();

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
