namespace DddInPractice.Logic.Management
{
    using FluentNHibernate.Mapping;

    public class HeadOfficeMap : ClassMap<HeadOffice>
    {
        public HeadOfficeMap()
        {
            this.Id(x => x.Id);

            this.Map(x => x.Balance);

            this.Component(
                x => x.Cash,
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