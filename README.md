# RIvar: Reactive Instance Variable

- ***R***eactive ***I***nstance ***var***iables are reactive variables contained and used in objects. 
- Reactive variables are variables that automatically propagate changes to other variables, similar to formulas in Microsoft Excel.
- When we set RIvar with an expression, it associates it in addition to other existing associations.
- In runtime - new input override old ones. This solves the conflicts of having several associations.

# Example

```C#
    public  interface IBag
    {
        RIvar<decimal> Amount { get; }
        RIvar<decimal> Volume { get; }
    }
    
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


```











