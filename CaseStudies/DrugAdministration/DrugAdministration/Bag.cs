using System.Reactive.Subjects;
using RIVarX;

namespace DrugAdministration
{
    public class Bag: IBag
    {
        public RIVar<decimal> Amount { get; set; } = new RIVar<decimal>();
        public RIVar<decimal> Volume { get; set; } = new RIVar<decimal>();
        public RIVar<decimal> Concentration { get; set; } = new RIVar<decimal>();

        public Bag()
        {
            Concentration.Set(Amount.Div(Volume));
            Amount.Set(Concentration.Mul(Volume));
            Volume.Set(Amount.Div(Concentration));
        }
      
    }
}
