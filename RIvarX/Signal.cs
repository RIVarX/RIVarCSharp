using System;
using System.Linq;

namespace RIVarX
{
    public class Globals
    {
        public static int _priorityIterator = 0;
    }

    public class Signal<T> : IComparable<Signal<T>>, IEquatable<Signal<T>>
    {
       
        private readonly int[] _prioritySet;

        public T Value { get; }
        public int[] PrioritySet => _prioritySet;
        public Signal(T value)
        {
            _prioritySet = new int[] { ++Globals._priorityIterator };
            Value = value;
        }

        public Signal(T value, int[] prioritySet)
        {
            _prioritySet = prioritySet;
            Value = value;
        }

        public override string ToString()
        {
            return $"{Value} ({string.Join(",", PrioritySet)})";
        }

        public int CompareTo(Signal<T> other)
        {
            if (IsPrioritized(other, this))
                return -1;
            if (IsPrioritized(this, other))
                return 1;
            return 0;
        }

        private bool IsPrioritized(Signal<T> signal, Signal<T> thanSignal)
        {
            var zero = new int[] { };

            var signalSet = signal?.PrioritySet?.Except(zero) ?? new int[] { 0 };
            var otherSignalSet = thanSignal?.PrioritySet?.Except(zero) ?? new int[] { 0 };

            var SignalOnlySet = signalSet.Except(otherSignalSet).Except(zero).ToArray();
            var otherSignalOnlySet = otherSignalSet.Except(signalSet).Except(zero).ToArray();

            if (otherSignalOnlySet.Any() && SignalOnlySet.Any() && SignalOnlySet.All(newSignal => otherSignalOnlySet.All(oldSignal => newSignal > oldSignal)))//rule A
            {
                return true;
            }
            if (signal != null && signalSet.Any() && !SignalOnlySet.Any() && otherSignalOnlySet.Any()/*extra*/)//rule B (extra, comes from cycle)
            {//super set {1} compare to {1,2,3}, there is no new 
                //{1} > {1,2,3}
                //but null < {1,0}
                return true;
            }

          
            return false;
        }

        public bool Equals(Signal<T> other)
        {
         
            if (this.Value != null && other.Value != null && !this.Value.Equals(other.Value))
                return false;

            if (this.Value != null && other.Value == null)
                return false;

            if (this.Value == null && other.Value != null)
                return false;

            if (this.PrioritySet != null && other.PrioritySet == null)
                return false;

            if (this.PrioritySet == null && other.PrioritySet != null)
                return false;

            if (this.PrioritySet.Except(other.PrioritySet).Any())
                return false;

            if (other.PrioritySet.Except(this.PrioritySet).Any())
                return false;

            return true;
        }

        public static implicit operator Signal<T>(T v) => new Signal<T>(v);

        public static implicit operator T(Signal<T> s) => s.Value;
    }


}
