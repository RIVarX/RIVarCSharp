using System;
using System.Linq;

namespace ReactiveVariablesExtension
{
    public class SignalValue<T> : IComparable<SignalValue<T>>, IEquatable<SignalValue<T>>
    {
        private static int _priorityIterator = 0;
        private readonly int[] _prioritySet;

        public T Value { get; }
        public int[] PrioritySet => _prioritySet??new int[] { 0 };
        public SignalValue(T value)
        {
            _prioritySet = new int[] { ++_priorityIterator };
            Value = value;
        }

        public SignalValue(T value, int[] prioritySet)
        {
            _prioritySet = prioritySet;
            Value = value;
        }

        public override string ToString()
        {
            return $"{Value} ({string.Join(",", PrioritySet)})";
        }

        public int CompareTo(SignalValue<T> other)
        {
            if (IsPrioritized(other, this))
                return -1;
            if (IsPrioritized(this, other))
                return 1;
            return 0;
        }

        private bool IsPrioritized(SignalValue<T> signal, SignalValue<T> thanSignal)
        {
            var signalSet = signal?.PrioritySet ?? new int[] { 0 };
            var otherSignalSet = thanSignal?.PrioritySet ?? new int[] { 0 };

            var SignalOnlySet = signalSet.Except(otherSignalSet).ToArray();
            var otherSignalOnlySet = otherSignalSet.Except(signalSet).ToArray();

            if (otherSignalOnlySet.Any() && SignalOnlySet.Any()
                && (SignalOnlySet.All(newSignal => otherSignalOnlySet.All(oldSignal => newSignal > oldSignal))))
            {
                return true;
            }
            if (otherSignalOnlySet.Any() && !SignalOnlySet.Any())
            {
                return true;
            }
            if (otherSignalSet.Contains(0) && !signalSet.Contains(0))
            {
                return true;
            }
              

            return false;
        }

        public bool Equals(SignalValue<T> other)
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
    }


}
