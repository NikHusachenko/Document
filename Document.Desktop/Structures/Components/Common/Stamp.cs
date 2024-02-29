using Document.Desktop.Contracts;

namespace Document.Desktop.Structures.Components.Common
{
    public sealed class Stamp : ICloneable<Stamp>, IValidable
    {
        public string PathToImage { get; set; } = string.Empty;
        public float Height { get; set; }
        public float Width { get; set; }

        public bool IsValid
        {
            get
            {
                if (string.IsNullOrWhiteSpace(PathToImage))
                {
                    return false;
                }

                if (Height <= 0f || Width <= 0f)
                {
                    return false;
                }

                return true;
            }
        }

        public Stamp Clone() => new()
        {
            Height = Height,
            Width = Width,
            PathToImage = PathToImage
        };
    }
}