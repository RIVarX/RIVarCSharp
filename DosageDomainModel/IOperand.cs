namespace DosageDomainModel
{
    public interface IOperand
    {
        IOperand Mul(IOperand operand);
        IOperand Div(IOperand operand);
    }

  


}
