using System.Collections.Generic;

namespace BehaviorTree
{
    public abstract class Node
    {
        protected NodeState _state;
    
        public Node Parent;
        protected List<Node> _children = new();
        
        private Dictionary<string, object> _data = new();
        
        public Node()
        {
            Parent = null;
        }
        public Node(List<Node> children)
        {
            foreach (var child in children)
                Attach(child);
        }

        private void Attach(Node node)
        {
            node.Parent = this;
            _children.Add(node);
        }
        public virtual NodeState Evaluate() => NodeState.FAILURE;
        
        public void SetData(string key, object value)
        {
            _data[key] = value;
        }
        public object GetData(string key)
        {
            if (_data.TryGetValue(key, out var val))
                return val;

            var node = Parent;
            if (node != null)
                val = node.GetData(key);
            return val;
        }
        public bool ClearData(string key)
        {
            var cleared = false;
            if (_data.ContainsKey(key))
            {
                _data.Remove(key);
                return true;
            }

            var node = Parent;
            if (node != null)
                cleared = node.ClearData(key);
            return cleared;
        }
    }
}

