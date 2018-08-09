using System;
using System.Threading;
using Autofac;
using Document.Core.Processing;
using Document.Upload.Enumerations;
using Document.Upload.Processing;
using UploadDocumentProcessor.Scanner;

namespace UploadDocumentProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var builder = new ContainerBuilder();

            builder.ScanAssembly();

            var container = builder.Build();

            while (true)
            {

                var uploader = container.Resolve<IUploadProcessor>();

                // call the uploader and init the uploadable document

                var document = new UploadableDocument();
                const string docName = "TestDocument";
                document.ChangeDocumentName(Convert.ToBase64String(docName.ToByteArray()));
                document.ChangeDocumentType(UploadDocumentType.Mortage);
                uploader.UploadDocument(document);

                // test for no encrypted field
                document = new UploadableDocument();
                document.ChangeDocumentName(docName);
                document.ChangeDocumentType(UploadDocumentType.LoadApplication);
                uploader.UploadDocument(document);

                Thread.Sleep(15000);
            }


            //Console.ReadLine();
        }
    }
}
