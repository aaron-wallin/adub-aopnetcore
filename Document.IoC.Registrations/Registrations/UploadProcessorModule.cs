using Autofac;
using Autofac.Extras.DynamicProxy;
using Document.Aspect.Decryption;
using Document.Aspects.Logging.Console;
using Document.Aspects.Validator;
using Document.Core.Processing;
using Document.Upload.Service;

namespace Document.IoC.Registrations.Registrations
{
    public class UploadProcessorModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // note the 'order' of interceptedBy, this 
            // dictates 'the order when' the interception happens.
            builder.RegisterType<UploadProcessor>()
                .As<IUploadProcessor>()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(ConsoleLogger))
                .InterceptedBy(typeof(UploadDocumentValiator))
                .InterceptedBy(typeof(Base64StringDecryptor));
        }
    }
}
