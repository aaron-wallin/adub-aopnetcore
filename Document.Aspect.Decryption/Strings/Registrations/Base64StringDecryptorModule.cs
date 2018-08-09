using Autofac;

namespace Document.Aspect.Decryption.Strings.Registrations
{
    public class Base64StringDecryptorModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Base64StringDecryptor>()
                .InstancePerDependency();
        }
    }
}
