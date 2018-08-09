using Document.Upload.Processing;

namespace Document.Core.Processing
{
    public interface IUploadProcessor
    {
        void UploadDocument(UploadableDocument documentToUpload);

    }
}
