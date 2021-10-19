using System.Reactive.Subjects;
using RIvarX;

namespace SignalExample_InfusionTherapy
{
    public  interface IBag
    {
        RIvar<IOperand> Amount { get; }
        RIvar<IOperand> Volume { get; }
    }
}
