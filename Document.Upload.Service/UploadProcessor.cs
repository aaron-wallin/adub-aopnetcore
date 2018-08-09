using System;
using Document.Core.Processing;
using Document.Upload.Processing;

namespace Document.Upload.Service
{
    public class UploadProcessor : IUploadProcessor
    {
        public void UploadDocument(UploadableDocument documentToUpload)
        {
            // very simple processor, we'll just say we got it and uploaded it
            Console.WriteLine($"Processor uploaded {documentToUpload.GetDocumentName()}");
        }
    }
}
