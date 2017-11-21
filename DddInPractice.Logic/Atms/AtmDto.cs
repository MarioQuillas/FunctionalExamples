namespace DddInPractice.Logic.Atms
{
    public class AtmDto
    {
        public AtmDto(long id, decimal cash)
        {
            Id = id;
            Cash = cash;
        }

        public decimal Cash { get; }

        public long Id { get; }
    }
}