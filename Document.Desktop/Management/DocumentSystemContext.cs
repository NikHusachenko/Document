using Document.Desktop.Contracts.Observers;

namespace Document.Desktop.Management
{
    // Open for inheritance and extension
    public class DocumentSystemContext : IChangeTrackable
    {
        private readonly Document _target;

        public DocumentSystemContext(Document target)
        {
            _target = target;
        }

        public void ChangeNotify()
        {
            throw new NotImplementedException();
        }

        public void Subscribe(IChangeSubscribable subscriber)
        {
            throw new NotImplementedException();
        }

        public void Unsubscribe(IChangeSubscribable subscriber)
        {
            throw new NotImplementedException();
        }
    }
}