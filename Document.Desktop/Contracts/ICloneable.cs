using Document.Desktop.Management;

namespace Document.Desktop.Contracts
{
    public interface ICloneable<T>
    {
        T Clone(DocumentSystemContext systemContext);
    }
}