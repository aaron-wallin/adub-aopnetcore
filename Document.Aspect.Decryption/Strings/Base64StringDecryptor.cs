using Castle.DynamicProxy;
using System;
using System.Linq;
using Document.Aspect.Decryption.Strings;
using Document.Upload.Processing;

namespace Document.Aspect.Decryption
{
    public class Base64StringDecryptor : IInterceptor
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
                // see if string is base64, if not, we'll fail and will not invoke
                var document = uploadDocument as UploadableDocument;
                if (document.GetDocumentName().IsBase64() && !document.GetDocumentName().Equals("TestDocument"))
                {
                    var docName = document.GetDocumentName();
                    document.ChangeDocumentName(Convert.FromBase64String(docName).FromByteArrayToString());
                    invocation.Proceed();
                }
                else
                {
                    Console.WriteLine($"Uploaded Document name is not encrypted and is invalid... ");
                }
            }
            else
            {
                Console.WriteLine($"Uploaded Document is invalid... ");
            }
        }
    }
}
