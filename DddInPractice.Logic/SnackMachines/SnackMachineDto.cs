namespace DddInPractice.Logic.SnackMachines
{
    public class SnackMachineDto
    {
        public SnackMachineDto(long id, decimal moneyInside)
        {
            this.Id = id;
            this.MoneyInside = moneyInside;
        }

        public long Id { get; private set; }

        public decimal MoneyInside { get; private set; }
    }
}