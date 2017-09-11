namespace DddInPractice.Logic.SnackMachines
{
    using FluentNHibernate;
    using FluentNHibernate.Mapping;

    public class SnackMachineMap : ClassMap<SnackMachine>
    {
        public SnackMachineMap()
        {
            this.Id(x => x.Id);

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

            this.HasMany<Slot>(Reveal.Member<SnackMachine>("Slots")).Cascade.SaveUpdate().Not.LazyLoad().Inverse();
        }
    }
}