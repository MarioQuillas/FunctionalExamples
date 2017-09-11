namespace DddInPractice.Logic.Utils
{
    using DddInPractice.Logic.Common;
    using DddInPractice.Logic.Management;

    public static class Initer
    {
        public static void Init(string connectionString)
        {
            SessionFactory.Init(connectionString);
            HeadOfficeInstance.Init();
            DomainEvents.Init();
        }
    }
}