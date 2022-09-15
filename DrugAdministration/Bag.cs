using System.Reactive.Subjects;
using RIvarX;

namespace DrugAdministration
{
    public class Bag: IBag
    {
        public RIvar<decimal> Amount { get; set; } = new RIvar<decimal>();
        public RIvar<decimal> Volume { get; set; } = new RIvar<decimal>();
        public RIvar<decimal> Concentration { get; set; } = new RIvar<decimal>();

        public Bag()
        {
            Concentration.Set(Amount.Div(Volume));
            Amount.Set(Concentration.Mul(Volume));
            Volume.Set(Amount.Div(Concentration));
        }
      
    }
}
