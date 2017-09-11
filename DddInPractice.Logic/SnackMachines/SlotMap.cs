namespace DddInPractice.Logic.SnackMachines
{
    using FluentNHibernate.Mapping;

    public class SlotMap : ClassMap<Slot>
    {
        public SlotMap()
        {
            this.Id(x => x.Id);
            this.Map(x => x.Position);

            this.Component(
                x => x.SnackPile,
                y =>
                    {
                        y.Map(x => x.Quantity);
                        y.Map(x => x.Price);
                        y.References(x => x.Snack).Not.LazyLoad();
                    });

            this.References(x => x.SnackMachine);
        }
    }
}