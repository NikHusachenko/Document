using Document.Desktop.Response;

namespace Document.Desktop.Management.FileManagement.Export
{
    public abstract class ExportStrategy
    {
        public abstract ResponseService<string> Export(Document document, string path);
    }
}