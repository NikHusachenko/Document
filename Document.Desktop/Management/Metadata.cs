using Document.Desktop.Contracts;

namespace Document.Desktop.Management
{
    public sealed class Metadata : ICloneable<Metadata>
    {
        private const string DEFAULT_EXTENSION = "prodoc";
        private const string DEFAULT_DOCUMENT_NAME = "Document";

        private readonly DocumentSystemContext _systemContext;

        private string DefaultAuthorName => Environment.MachineName;
        
        public Guid UniqueMetaUuid { get; private init; }
        public DateTimeOffset CreatedAt { get; private init; }
        public DateTimeOffset LastModifiedAt { get; private init; }
        public string Author { get; private init; }
        
        public string SavedAt { get; private init; }
        public string DocumentName { get; private init; }
        public string Extension { get; private init; } = DEFAULT_EXTENSION;

        public Metadata(DocumentSystemContext systemContext) 
            : this(systemContext, string.Empty, DEFAULT_DOCUMENT_NAME) { Author = DefaultAuthorName; }

        public Metadata(DocumentSystemContext systemContext, string author) 
            : this(systemContext, author, DEFAULT_DOCUMENT_NAME) { }

        public Metadata(DocumentSystemContext systemContext, string author, string documentName)
        {
            _systemContext = systemContext;
            
            UniqueMetaUuid = Guid.NewGuid();
            CreatedAt = DateTimeOffset.Now;
            LastModifiedAt = DateTimeOffset.Now;
            Author = author;
            
            SavedAt = Environment.CurrentDirectory;
            DocumentName = documentName;
        }

        public Metadata Clone(DocumentSystemContext systemContext) => new Metadata(systemContext)
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