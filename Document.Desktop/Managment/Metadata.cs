using Document.Desktop.Contracts;

namespace Document.Desktop.Structures
{
    public sealed class Metadata : ICloneable<Metadata>
    {
        private const string DEFAULT_EXTENSION = "prodoc";
        private const string DEFAULT_DOCUMENT_NAME = "Document";

        private string DefaultAuthorName => Environment.MachineName;

        public DateTimeOffset CreatedAt { get; private init; }
        public DateTimeOffset LastModifiedAt { get; private init; }
        public string Author { get; private init; }
        
        public string SavedAt { get; private init; }
        public string DocumentName { get; private init; }
        public string Extension { get; private init; } = DEFAULT_EXTENSION;

        public Metadata()
        {
            CreatedAt = DateTimeOffset.Now;
            LastModifiedAt = DateTimeOffset.Now;
            Author = DefaultAuthorName;

            SavedAt = Environment.SystemDirectory;
            DocumentName = DEFAULT_DOCUMENT_NAME;
        }

        public Metadata(string author)
        {
            CreatedAt = DateTimeOffset.Now;
            LastModifiedAt = DateTimeOffset.Now;
            Author = author;

            SavedAt = Environment.SystemDirectory;
            DocumentName = DEFAULT_DOCUMENT_NAME;
        }

        public Metadata(string author, string documentName)
        {
            CreatedAt = DateTimeOffset.Now;
            LastModifiedAt = DateTimeOffset.Now;
            Author = author;
            
            SavedAt = Environment.SystemDirectory;
            DocumentName = documentName;
        }

        public Metadata Clone() => new Metadata()
        {
            Author = Author,
            CreatedAt = DateTimeOffset.Now,
            DocumentName = DocumentName,
            Extension = Extension,
            LastModifiedAt = DateTimeOffset.Now,
            SavedAt = SavedAt
        };
    }
}