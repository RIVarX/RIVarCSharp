using System;
using RIvarX;

namespace DrugAdministration
{
   public static class Operators
    {
        public static Expression<decimal> Div(this RIvar<decimal> operand1, RIvar<decimal> operand2)
        {
            Func<decimal, decimal, decimal> div = (x, y) => x / y;

            return div.Lift(operand1, operand2);
        }

        public static Expression<decimal> Mul(this RIvar<decimal> operand1, RIvar<decimal> operand2)
        {
            Func<decimal, decimal, decimal> mul = (x, y) => x * y;

            return mul.Lift(operand1, operand2);
        }
    }
}
