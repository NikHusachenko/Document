using Document.Desktop.Response;

namespace Document.Desktop.Management.FileManagement.Export
{
    public sealed class PdfExport : ExportStrategy
    {
        public override ResponseService<string> Export(Document document, string path)
        {
            throw new NotImplementedException();
        }
    }
}