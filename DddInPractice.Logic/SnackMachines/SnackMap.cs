namespace DddInPractice.Logic.SnackMachines
{
    using FluentNHibernate.Mapping;

    public class SnackMap : ClassMap<Snack>
    {
        public SnackMap()
        {
            this.Id(x => x.Id);
            this.Map(x => x.Name);
        }
    }
}