namespace DddInPractice.Logic.Atms
{
    public class AtmDto
    {
        public AtmDto(long id, decimal cash)
        {
            this.Id = id;
            this.Cash = cash;
        }

        public decimal Cash { get; private set; }

        public long Id { get; private set; }
    }
}