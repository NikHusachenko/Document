using Document.Desktop.Contracts;
using Document.Desktop.Structures.Components.BodyComponents;

namespace Document.Desktop.Structures.Body
{
    public sealed class Page : ICloneable<Page>, IValidable, IDisplayable
    {
        private Component[] _components;
        
        private Page(Component[] components) => _components = components;

        public Page() => _components = new Component[0];

        public bool IsValid => throw new NotImplementedException();

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

        public Page Clone()
        {
            Component[] components = new Component[_components.Length];
            for (int i = 0; i < components.Length; i++)
            {
                components[i] = _components[i].Clone();
            }

            return new Page(components);
        }

        public void Display()
        {
            throw new NotImplementedException();
        }
    }
}