using Document.Desktop.Contracts.Observers;

namespace Document.Desktop.Management
{
    // Open for inheritance and extension
    public class DocumentSystemContext : IChangeTrackable
    {
        private readonly List<IChangeSubscribable> _subscribers;

        public DocumentSystemContext()
        {
            _subscribers = new List<IChangeSubscribable>();
        }

        public void ChangeNotify()
        {
            foreach (var subscriber in _subscribers)
            {
                subscriber.ChangeNotify();
            }
        }

        public void Subscribe(IChangeSubscribable subscriber) => _subscribers.Add(subscriber);

        public void Unsubscribe(IChangeSubscribable subscriber) => _subscribers.Remove(subscriber);
    }
}