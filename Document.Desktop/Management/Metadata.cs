using Document.Desktop.Contracts;
using Document.Desktop.Contracts.Observers;

namespace Document.Desktop.Management
{
    public sealed class Metadata : ICloneable<Metadata>, IChangeSubscribable
    {
        private const string DEFAULT_EXTENSION = "prodoc";
        private const string DEFAULT_DOCUMENT_NAME = "Document";

        private string DefaultAuthorName => Environment.MachineName;
        
        public Guid UniqueMetaUuid { get; private init; }
        public DocumentSystemContext SystemContext { get; private set; }

        public DateTimeOffset CreatedAt { get; private init; }
        public DateTimeOffset LastModifiedAt { get; private set; }
        public string Author { get; private init; }
        
        public string SavedAt { get; private set; }
        public string DocumentName { get; private set; }
        public string Extension { get; private set; } = DEFAULT_EXTENSION;

        public Metadata() : this(string.Empty, DEFAULT_DOCUMENT_NAME) { Author = DefaultAuthorName; }

        public Metadata(string author) : this(author, DEFAULT_DOCUMENT_NAME) { }

        public Metadata(string author, string documentName)
        {
            SystemContext = new DocumentSystemContext();
            SystemContext.Subscribe(this);
            
            UniqueMetaUuid = Guid.NewGuid();
            CreatedAt = DateTimeOffset.Now;
            LastModifiedAt = DateTimeOffset.Now;
            Author = author;
            
            SavedAt = Environment.CurrentDirectory;
            DocumentName = documentName;
        }

        public Metadata Clone(DocumentSystemContext systemContext) => new Metadata()
        {
            Author = Author,
            CreatedAt = DateTimeOffset.Now,
            DocumentName = DocumentName,
            Extension = Extension,
            LastModifiedAt = DateTimeOffset.Now,
            SavedAt = SavedAt,
            SystemContext = systemContext
        };

        public void ChangeNotify() => LastModifiedAt = DateTimeOffset.Now;
    }
}