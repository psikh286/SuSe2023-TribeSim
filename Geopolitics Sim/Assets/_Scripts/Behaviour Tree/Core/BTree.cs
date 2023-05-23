using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public abstract class BTree : MonoBehaviour
    {
        private Node _root;

        private Dictionary<string, object> _data = new();

        protected void Awake()
        {
            _root = SetupTree();
        }

        protected void OnTick()
        {
            _root?.Evaluate();
        }

        protected abstract Node SetupTree();
        
        public void SetData(string key, object value)
        {
            _data[key] = value;
        }
        public object GetData(string key)
        {
            return _data.TryGetValue(key, out var value) ? value : null;
        }
        public void ClearData(string key)
        {
            _data.Remove(key);
        }
    }
}