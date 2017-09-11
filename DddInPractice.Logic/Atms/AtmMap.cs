namespace DddInPractice.Logic.Atms
{
    using FluentNHibernate.Mapping;

    public class AtmMap : ClassMap<Atm>
    {
        public AtmMap()
        {
            this.Id(x => x.Id);

            this.Map(x => x.MoneyCharged);

            this.Component(
                x => x.MoneyInside,
                y =>
                    {
                        y.Map(x => x.OneCentCount);
                        y.Map(x => x.TenCentCount);
                        y.Map(x => x.QuarterCount);
                        y.Map(x => x.OneDollarCount);
                        y.Map(x => x.FiveDollarCount);
                        y.Map(x => x.TwentyDollarCount);
                    });
        }
    }
}