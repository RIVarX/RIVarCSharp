namespace SignalExample_InfusionTherapy
{
    public interface IOperand
    {
        IOperand Mul(IOperand operand);
        IOperand Div(IOperand operand);
    }

}
