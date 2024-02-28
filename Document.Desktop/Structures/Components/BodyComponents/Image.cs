namespace Document.Desktop.Structures.Components.BodyComponents
{
    public sealed class Image : Component
    {
        public string PathToImage { get; }
        public TextContent Label { get; set; }
        
        public Image(string path)
        {
            PathToImage = path;
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

        public override Image Clone() => new Image(PathToImage)
        {
            InnerFontHeight = InnerFontHeight,
            Label = Label.Clone(),
            MarginLeft = MarginLeft,
            MarginRight = MarginRight
        };

        public override void Display()
        {
            throw new NotImplementedException();
        }
    }
}