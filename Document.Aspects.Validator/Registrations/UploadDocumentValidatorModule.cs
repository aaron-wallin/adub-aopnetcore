using Autofac;

namespace Document.Aspects.Validator.Registrations
{
    public class UploadDocumentValidatorModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UploadDocumentValiator>()
                .InstancePerDependency();
        }
    }
}
