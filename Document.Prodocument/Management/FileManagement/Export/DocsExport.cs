using Document.Prodocument.Response;

namespace Document.Prodocument.Management.FileManagement.Export
{
    public sealed class DocsExport : ExportStrategy
    {
        public override ResponseService<string> Export(Document document, string path)
        {
            throw new NotImplementedException();
        }
    }
}