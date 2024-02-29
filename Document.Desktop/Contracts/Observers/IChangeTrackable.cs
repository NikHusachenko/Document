namespace Document.Desktop.Contracts.Observers
{
    public interface IChangeTrackable
    {
        void Subscribe(IChangeSubscribable subscriber);
        void Unsubscribe(IChangeSubscribable subscriber);
        void ChangeNotify();
    }
}