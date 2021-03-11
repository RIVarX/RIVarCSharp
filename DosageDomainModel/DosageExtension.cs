using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveVariablesExtension;

namespace DosageDomainModel
{
   public static class DosageExtension
    {
        public static IObservable<SignalValue<IOperand>> Mul(this IObservable<SignalValue<IOperand>> operand1, IObservable<SignalValue<IOperand>> operand2)
        {
            return  operand1.CombineLatestSignal(operand2, (x, y) => x.Mul(y));
        }
        public static IObservable<SignalValue<IOperand>> Div(this IObservable<SignalValue<IOperand>> operand1, IObservable<SignalValue<IOperand>> operand2)
        {
            return  operand1.CombineLatestSignal(operand2, (x, y) => x.Div(y));
        }

        
    }
}
