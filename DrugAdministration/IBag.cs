using System.Reactive.Subjects;
using RIvarX;

namespace DrugAdministration
{
    public  interface IBag
    {
        RIvar<decimal> Amount { get; }
        RIvar<decimal> Volume { get; }
    }
}
