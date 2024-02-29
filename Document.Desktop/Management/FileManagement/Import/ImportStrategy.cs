using Document.Desktop.Response;

namespace Document.Desktop.Management.FileManagement.Import
{
    public abstract class ImportStrategy
    {
        public abstract ResponseService<Document> Import(string path);
    }
}