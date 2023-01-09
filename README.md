# RIVar: Reactive Instance Variable

- **R**eactive **I**nstance **var**iables (**RIVars**) are reactive variables contained in objects (i.e., in classes, abstract classes and interfaces). 
- _Reactive_ variables are variables that automatically propagate changes to other variables, similar to formulas in Microsoft Excel.
- Setting (assigning) a **RIVar** associates the set (assigned) expression, in addition to other existing associations.
- In runtime - new input overrides old ones. This solves the conflicts of having several associations.

# Example

```C#
    public  interface IBag
    {
        RIvar<decimal> Amount { get; }
        RIvar<decimal> Volume { get; }
    }
    
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


```

## Runtime (by a basic user interface)

- Set _Medication_ (named _Amount_), then _Volume_ then _Duration_.

![image](https://user-images.githubusercontent.com/32875275/211289723-70d58b8a-2fde-407d-9887-bc72ab25251b.png)

- Set _Dose_

![image](https://user-images.githubusercontent.com/32875275/191584478-09a2f250-3fd2-4564-a503-b0d61d624b79.png)

## Learn, Usage or Contribution

**RIVar** is first developed and published as [RIVarX](https://www.nuget.org/packages/RIvar.RIvarX/1.0.0/) nuget package and is compatible with .net framework 4.5 or higher.

Feel free to contact me, if you are curious about **RIVar**, want to learn about it, or if you want an implemention for other programming languages (or upgrades).

Any feedback will be helpful!

Thanks,

Rivka Altshuler

brandrivka@gmail.com











