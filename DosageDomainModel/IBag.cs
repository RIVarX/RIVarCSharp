using System.Reactive.Subjects;
using RIvarX;

namespace DosageDomainModel
{
    public  interface IBag
    {
        ISubject<Signal<IOperand>> Amount { get; }
        ISubject<Signal<IOperand>> Volume { get; }
    }
}
