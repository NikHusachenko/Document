using Document.Prodocument.Response;

namespace Document.Prodocument.Management.FileManagement.Export
{
    public abstract class ExportStrategy
    {
        public abstract ResponseService<string> Export(Document document, string path);
    }
}