# RIV
Reactive Instance Variables

We lift the variables as "storage type" to *reactive* variables, 
Changes to variables are automatically propagated to other variables similar to the behavior in Microsoft Excel.

You can connect variables on the same object, or across different objects.

Cases when objects define *conflicts*, that are several assigments to a single variable, 
the variables will contain the values that reflect the recent inputs.


# Example

```C#
    public  interface IBag
    {
        ISubject<SignalValue<IOperand>> Amount { get; }
        ISubject<SignalValue<IOperand>> Volume { get; }
    }
    
    public class InfusedBag
    {
       //Declaring Reactive Instance Variables
        public ISubject<SignalValue<IOperand>> Rate = new Subject<SignalValue<IOperand>>();
        public ISubject<SignalValue<IOperand>> Dose = new Subject<SignalValue<IOperand>>();
        public ISubject<SignalValue<IOperand>> Duration = new Subject<SignalValue<IOperand>>();

        public InfusedBag(IBag bag)
        {
            //Declaring the Functional Relations, 
            //e.g. Dose is set by Amount/Duration, 
            //so that when Amount or Duration Dose will be updated
                        
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
        public ISubject<SignalValue<IOperand>> Amount { get; set; } = new Subject<SignalValue<IOperand>>();
        public ISubject<SignalValue<IOperand>> Volume { get; set; } = new Subject<SignalValue<IOperand>>();
        public ISubject<SignalValue<IOperand>> Concentration { get; set; } = new Subject<SignalValue<IOperand>>();

        public Bag()
        {
            Concentration.Set(Amount.Div(Volume));
            Amount.Set(Concentration.Mul(Volume));
            Volume.Set(Amount.Div(Concentration));
        }
      
    }


```











