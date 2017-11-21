namespace DddInPractice.Logic.SnackMachines
{
    public class SnackMachineDto
    {
        public SnackMachineDto(long id, decimal moneyInside)
        {
            Id = id;
            MoneyInside = moneyInside;
        }

        public long Id { get; }

        public decimal MoneyInside { get; }
    }
}