using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
namespace ScriptableObjects
{
    public abstract class StateRunner<T> : MonoBehaviour where T : MonoBehaviour
    {
        
        [Header("Different States")]
        [SerializeField] private List<State<T>> states;


        private State<T> _activeState;
        private readonly Dictionary<Type, State<T>> _stateByType = new();

        protected void Awake()
        {
            states.ForEach(state => _stateByType.Add(state.GetType(), state));
        }

        public void SetState(Type newStateType)
        {
            if (_activeState != null)
            {
                _activeState.ExitState();
                
            }
            _activeState = states.First(state => state.GetType() == newStateType);
            _activeState.Init(GetComponent<T>());
        }

        private void Update()
        {
            _activeState.HandleInput();
            _activeState.Update();
            _activeState.ChangeState();
        }
    }
}