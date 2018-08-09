using System;
using System.Linq;
using Castle.DynamicProxy;
using Document.Upload.Processing;

namespace Document.Aspects.Validator
{
    public class UploadDocumentValiator : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var name = $"{invocation.Method.DeclaringType}_{invocation.Method.Name}";

            // because we know this is an uploadable document, validate it is that type
            // then validate values exist

            var uploadDocument = invocation.Arguments.FirstOrDefault();

            if (uploadDocument != null && uploadDocument.GetType() == typeof(UploadableDocument))
            {
                // execute the intercepted method -- other aspects may be 'stacked' and they
                // will be called before the final method proceeds...
                invocation.Proceed();
            }
            else
            {
                Console.WriteLine($"Uploaded Document is invalid... ");
            }
        }
    }
}
