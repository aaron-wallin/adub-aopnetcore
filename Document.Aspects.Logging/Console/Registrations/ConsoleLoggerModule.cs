using Autofac;

namespace Document.Aspects.Logging.Console.Registrations
{
    public class ConsoleLoggerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ConsoleLogger>()
                .InstancePerDependency();
        }
    }
}
