using System;
using RIvarX;

namespace SignalExample_InfusionTherapy
{
   public static class Operators
    {
        /// <summary>
        /// *
        /// </summary>
        public static Expression<IOperand> Mul(this IObservable<Signal<IOperand>> operand1, IObservable<Signal<IOperand>> operand2)
        {
            return  operand1.Compute(operand2, (x, y) => x.Mul(y));
        }
        /// <summary>
        /// /
        /// </summary>
        public static Expression<IOperand> Div(this IObservable<Signal<IOperand>> operand1, IObservable<Signal<IOperand>> operand2)
        {
            return  operand1.Compute(operand2, (x, y) => x.Div(y));
        }

        
    }
}
