# RIvar: Reactive Instance Variable

- ***R***eactive ***I***nstance ***var***iables are reactive variables contained in objects (i.e., in classes, abstract classes and interfaces). 
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

## Runtime (by a basic user interface)

- Set _Medication_ (named _Amount_), then _Volume_ then _Duration_.

![image](https://user-images.githubusercontent.com/32875275/191584414-3997bda3-35e1-43b7-90e0-ab4ef6a74768.png)

- Set _Dose_

![image](https://user-images.githubusercontent.com/32875275/191584478-09a2f250-3fd2-4564-a503-b0d61d624b79.png)











