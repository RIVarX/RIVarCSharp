﻿using System;
using RIvarX;

namespace SignalExample_InfusionTherapy
{
   public static class ExpressionsExtensions
    {
        public static IObservable<Signal<IOperand>> Mul(this IObservable<Signal<IOperand>> operand1, IObservable<Signal<IOperand>> operand2)
        {
            return  operand1.CombineLatestSignal(operand2, (x, y) => x.Mul(y));
        }
        public static IObservable<Signal<IOperand>> Div(this IObservable<Signal<IOperand>> operand1, IObservable<Signal<IOperand>> operand2)
        {
            return  operand1.CombineLatestSignal(operand2, (x, y) => x.Div(y));
        }

        
    }
}