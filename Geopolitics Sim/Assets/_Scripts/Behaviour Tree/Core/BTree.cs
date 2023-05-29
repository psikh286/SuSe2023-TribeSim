using UnityEngine;

namespace BehaviorTree
{
    public abstract class BTree : MonoBehaviour
    {
        private Node _root;

        protected void Awake() => _root = SetupTree();

        protected virtual void OnTick()
        {
            _root?.Evaluate();
        }

        protected abstract Node SetupTree();
    }
}