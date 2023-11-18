using UnityEngine;
namespace ScriptableObjects
{
    public abstract class State<T> : ScriptableObject where T : MonoBehaviour
    {
        protected T Parent;

        public virtual void Init(T parent)
        {
            Parent = parent;
        }

        public abstract void ChangeState();
        public abstract void ExitState();
        public abstract void Update();
        public abstract void HandleInput();
    }
}