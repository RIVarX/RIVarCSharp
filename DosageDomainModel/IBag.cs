using System.Reactive.Subjects;
using ReactiveVariablesExtension;

namespace DosageDomainModel
{
    public  interface IBag
    {
        ISubject<SignalValue<IOperand>> Amount { get; }
        ISubject<SignalValue<IOperand>> Volume { get; }
    }
}
