using System.Reactive.Subjects;
using RIVarX;

namespace DrugAdministration
{
    public  interface IBag
    {
        RIVar<decimal> Amount { get; }
        RIVar<decimal> Volume { get; }
    }
}
