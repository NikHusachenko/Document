using Document.Desktop.Contracts;

namespace Document.Desktop.Management
{
    public sealed class Metadata : ICloneable<Metadata>
    {
        private const string DEFAULT_EXTENSION = "prodoc";
        private const string DEFAULT_DOCUMENT_NAME = "Document";

        private string DefaultAuthorName => Environment.MachineName;

        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset LastModifiedAt { get; set; }
        public string Author { get; set; }
        
        public string SavedAt { get; set; }
        public string DocumentName { get; set; }
        public string Extension { get; set; } = DEFAULT_EXTENSION;

        public Metadata() : this(string.Empty, DEFAULT_DOCUMENT_NAME) { Author = DefaultAuthorName; }

        public Metadata(string author) : this(author, DEFAULT_DOCUMENT_NAME) { }

        public Metadata(string author, string documentName)
        {
            CreatedAt = DateTimeOffset.Now;
            LastModifiedAt = DateTimeOffset.Now;
            Author = author;
            
            SavedAt = Environment.CurrentDirectory;
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