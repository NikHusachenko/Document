using Document.Prodocument.Management;

namespace Document.Prodocument.Contracts
{
    public interface ICloneable<T>
    {
        T Clone(DocumentSystemContext systemContext);
    }
}