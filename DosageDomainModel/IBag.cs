using System.Reactive.Subjects;
using RIvarX;

namespace SignalExample_InfusionTherapy
{
    public  interface IBag
    {
        ISubject<Signal<IOperand>> Amount { get; }
        ISubject<Signal<IOperand>> Volume { get; }
    }
}
