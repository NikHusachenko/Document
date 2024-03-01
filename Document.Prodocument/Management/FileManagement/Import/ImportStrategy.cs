using Document.Prodocument.Response;

namespace Document.Prodocument.Management.FileManagement.Import
{
    public abstract class ImportStrategy
    {
        public abstract ResponseService<Document> Import(string path);
    }
}