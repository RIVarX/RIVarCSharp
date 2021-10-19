using SignalExample_InfusionTherapy;

namespace WindowsFormsApp1
{
    public class QuantableValue : IOperand
    {
        private double value;

        public double Value { get => value; set => this.value = value; }
        public QuantableValue(double value)
        {
            this.value = value;
        }
        public  IOperand Div(IOperand operand)
        {
            var a = (operand as QuantableValue);
            return new QuantableValue(Value / a.Value);
        }

        public  IOperand Mul(IOperand operand)
        {
            var a = (operand as QuantableValue);
            return new QuantableValue(Value * a.Value);
        }

        public override string ToString()
        {
            return value.ToString();
        }

        public static implicit operator QuantableValue(double value)
        {
            return new QuantableValue(value);
        }

        public override bool Equals(object obj)
        {
            return (obj as QuantableValue)?.value == value || base.Equals(obj);
        }
    }



}
