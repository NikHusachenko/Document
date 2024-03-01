using Document.Prodocument.Contracts;
using Document.Prodocument.Contracts.Observers;
using Document.Prodocument.Management.FileManagement.Export;
using Document.Prodocument.Management.FileManagement.Import;
using Document.Prodocument.Response;
using Document.Prodocument.Structures.Body;
using Document.Prodocument.Structures.Footer;
using Document.Prodocument.Structures.Header;

namespace Document.Prodocument.Management
{
    public class Document : ICloneable<Document>, IValidable, IDisplayable
    {
        private const string DEFAULT_DOCUMENT_TITLE = "Document";

        public Metadata Metadata { get; private init; }
        public HeaderStructure Header { get; private init; }
        public BodyStructure Body { get; private init; }
        public FooterStructure Footer { get; private init; }

        public bool IsValid
        {
            get
            {
                return Header.IsValid && 
                        Body.IsValid &&
                        Footer.IsValid;
            }
        }

        private Document() : this(DEFAULT_DOCUMENT_TITLE) { }

        public Document(string title)
        {
            Metadata = new Metadata();

            Header = HeaderStructure.BuildDefault(Metadata.SystemContext);
            Body = BodyStructure.BuildDefault(Metadata.SystemContext);
            Footer = FooterStructure.BuildDefault(Metadata.SystemContext);
        }

        public void Display()
        {
            DisplayMetadata();
            
            Header.Display();
            Body.Display();
            Footer.Display();
        }

        public void DisplayMetadata()
        {
            Console.WriteLine(new string('=', Console.WindowWidth));
            Console.WriteLine(Metadata.UniqueMetaUuid);
            Console.WriteLine(Metadata.Author);
            Console.WriteLine(Metadata.CreatedAt.ToString("dd.MM.yyyy HH:mm:ss"));
            Console.WriteLine(Metadata.LastModifiedAt.ToString("dd.MM.yyyy HH:mm:ss"));
            Console.WriteLine(Metadata.SavedAt);
            Console.WriteLine(Metadata.DocumentName);
            Console.WriteLine(Metadata.Extension);
            Console.WriteLine(new string('=', Console.WindowWidth));
        }

        public Document Clone() => new Document()
        {
            Body = Body.Clone(Metadata.SystemContext),
            Footer = Footer.Clone(Metadata.SystemContext),
            Header = Header.Clone(Metadata.SystemContext),
            Metadata = Metadata.Clone(Metadata.SystemContext),
        };

        public Document Clone(DocumentSystemContext systemContext) => new Document()
        {
            Body = Body.Clone(systemContext),
            Footer = Footer.Clone(systemContext),
            Header = Header.Clone(systemContext),
            Metadata = Metadata.Clone(systemContext),
        };
    }

    public sealed class DocumentFileManager
    {
        private const string EXPORT_PROVIDER_DOESNT_ASSIGN = "Export provider doesn't assign";
        private const string IMPORT_PROVIDER_DOESNT_ASSIGN = "Import provider doesn't assign";
        
        private readonly Document _document;

        public ExportStrategy? ExportProvider { get; set; }
        public ImportStrategy? ImportProvider { get; set; }

        public DocumentFileManager(Document document)
        {
            _document = document;
        }

        public ResponseService<string> Export(string path)
        {   
            if (ExportProvider is null)
            {
                return ResponseService<string>.Error(EXPORT_PROVIDER_DOESNT_ASSIGN);
            }
            return ExportProvider!.Export(_document, path);
        }

        public ResponseService<Document> Import(string path)
        {
            if (ImportProvider is null)
            {
                return ResponseService<Document>.Error(IMPORT_PROVIDER_DOESNT_ASSIGN);
            }
            return ImportProvider!.Import(path);
        }
    }
}