using System;
using RIVarX;

namespace DrugAdministration
{
   public static class Operators
    {
        public static Expression<decimal> Div(this RIVar<decimal> operand1, RIVar<decimal> operand2)
        {
            Func<decimal, decimal, decimal> div = (x, y) => x / y;

            return div.Lift(operand1, operand2);
        }

        public static Expression<decimal> Mul(this RIVar<decimal> operand1, RIVar<decimal> operand2)
        {
            Func<decimal, decimal, decimal> mul = (x, y) => x * y;

            return mul.Lift(operand1, operand2);
        }
    }
}
