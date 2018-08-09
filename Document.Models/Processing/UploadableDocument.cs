using Document.Upload.Enumerations;

namespace Document.Upload.Processing
{
    public class UploadableDocument
    {
        private string DocumentName { get; set; }

        private UploadDocumentType DocumentType { get; set; }

        // change behavior
        public void ChangeDocumentName(string documentName)
        {
            DocumentName = documentName;
        }

        public void ChangeDocumentType(UploadDocumentType documentType)
        {
            DocumentType = documentType;
        }

        // get behavior

        public string GetDocumentName()
        {
            return DocumentName;
        }

        public UploadDocumentType GetDocumentType()
        {
            return DocumentType;
        }
    }
}
