using Document.Desktop.Contracts;
using Document.Desktop.Management;

namespace Document.Desktop.Structures.Components.BodyComponents
{
    public abstract class Component : ICloneable<Component>, IValidable, IDisplayable
    {
        public float MarginLeft { get; set; }
        public float MarginRight { get; set; }
        public TextHeader InnerFontHeight { get; set; }

        public abstract bool IsValid { get; }
        
        public abstract Component Clone(DocumentSystemContext systemContext);
        public abstract void Display();
    }

    public enum TextHeader
    {
        H1 = 1,
        H2 = 2,
        H3 = 3,
        H4 = 4,
        H5 = 5,
        H6 = 6,
    }
}