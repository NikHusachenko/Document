using Document.Desktop.Contracts;
using Document.Desktop.Management;

namespace Document.Desktop.Structures.Components.Common
{
    public sealed class Stamp : ICloneable<Stamp>, IValidable
    {
        private readonly DocumentSystemContext _systemContext;

        public string PathToImage { get; set; } = string.Empty;
        public float Height { get; set; }
        public float Width { get; set; }

        public Stamp(DocumentSystemContext systemContext)
        {
            _systemContext = systemContext;
        }

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

        public Stamp Clone(DocumentSystemContext systemContext) => new(systemContext)
        {
            Height = Height,
            Width = Width,
            PathToImage = PathToImage
        };
    }
}