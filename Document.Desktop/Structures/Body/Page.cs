using Document.Desktop.Contracts;
using Document.Desktop.Management;
using Document.Desktop.Structures.Components.BodyComponents;

namespace Document.Desktop.Structures.Body
{
    public sealed class Page : ICloneable<Page>, IValidable, IDisplayable
    {
        private readonly DocumentSystemContext _systemContext;

        private Component[] _components;

        public Page(DocumentSystemContext systemContext) : this(systemContext, []) { }

        private Page(DocumentSystemContext systemContext, Component[] components)
        {
            _systemContext = systemContext;
            _components = components;
        }

        public bool IsValid
        {
            get
            {
                for (int i = 0; i < _components.Length; i++)
                {
                    if (!_components[i].IsValid)
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        public Component this[int index]
        {
            get { return _components[index]; }
            set { _components[index] = value; }
        }

        /// <summary>
        /// Append new component to page
        /// </summary>
        /// <param name="component">One of child of Component</param>
        /// <returns>Returns a new length of components on the page</returns>
        public int AppendComponent(Component component)
        {
            Array.Resize(ref _components, _components.Length + 1);
            _components[_components.Length - 1] = component;
            return _components.Length;
        }

        /// <summary>
        ///  Remove the last component from page
        /// </summary>
        /// <returns>Returns a new count of components on page</returns>
        public int RemoveLastComponent()
        {
            Array.Resize(ref _components, _components.Length - 1);
            return _components.Length;
        }

        public Page Clone(DocumentSystemContext systemContext)
        {
            Component[] components = new Component[_components.Length];
            for (int i = 0; i < components.Length; i++)
            {
                components[i] = _components[i].Clone(systemContext);
            }

            return new Page(systemContext, components);
        }

        public void Display()
        {
            throw new NotImplementedException();
        }
    }
}