using Document.Desktop.Management;
using Document.Desktop.Structures.Components.Common;

namespace Document.Desktop.Structures.Components.BodyComponents
{
    public sealed class Image : Component
    {
        private const string DEFAULT_IMAGE_LABEL = "Image";

        private readonly DocumentSystemContext _systemContext;

        public string PathToImage { get; } = string.Empty;
        public TextContent Label { get; set; }

        public Image(DocumentSystemContext systemContext, string path) : this(systemContext, path, DEFAULT_IMAGE_LABEL) { }

        public Image(DocumentSystemContext systemContext, string pathToImage, string label)
        {
            _systemContext = systemContext;

            PathToImage = pathToImage;
            Label = new TextContent(systemContext, label);
        }

        public override bool IsValid
        {
            get
            {
                if (string.IsNullOrWhiteSpace(PathToImage))
                {
                    return false;
                }

                return Label.IsValid;
            }
        }

        public override Image Clone(DocumentSystemContext systemContext) => new Image(systemContext, PathToImage)
        {
            InnerFontHeight = InnerFontHeight,
            Label = Label.Clone(systemContext),
            MarginLeft = MarginLeft,
            MarginRight = MarginRight
        };

        public override void Display()
        {
            Console.WriteLine(new string('*', Console.WindowWidth));

            Console.WriteLine(nameof(Image));
            Console.WriteLine(PathToImage);
            Label.Display();

            Console.WriteLine(new string('*', Console.WindowWidth));
        }
    }
}