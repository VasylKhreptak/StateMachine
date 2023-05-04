using System;
using System.Collections.Generic;
using Plugins.StateMachine.State.Core;
using UniRx;
using UnityEngine;

namespace Plugins.StateMachine.Core
{
    public class StateMachine<StateType> : MonoBehaviour
    {
        [Header("States Preferences")]
        [SerializeField] private State<StateType>[] _states;

        private Dictionary<StateType, State<StateType>> _statesMap;

        private State<StateType> _currentState;

        private IReactiveProperty<ReadonlyState<StateType>> _currentReadonlyState = new ReactiveProperty<ReadonlyState<StateType>>();

        public IReadOnlyReactiveProperty<ReadonlyState<StateType>> CurrentState => _currentReadonlyState;


        #region MonoBehaviour

        private void OnValidate()
        {
            _states ??= GetComponentsInChildren<State<StateType>>();
        }

        private void Awake()
        {
            _statesMap = CreateStatesMap();
        }

        private void OnDisable()
        {
            StopCurrentState();
        }

        #endregion

        private Dictionary<StateType, State<StateType>> CreateStatesMap()
        {
            Dictionary<StateType, State<StateType>> states = new Dictionary<StateType, State<StateType>>(_states.Length);

            foreach (State<StateType> state in _states)
            {
                states.Add(state.Type, state);
            }

            return states;
        }

        #region Interface

        public void SetState(StateType stateType)
        {
            if (_statesMap.TryGetValue(stateType, out State<StateType> state))
            {
                if (_currentState != null) _currentState.Exit();

                state.Enter();

                _currentState = state;
                _currentReadonlyState.Value = state;

                return;
            }

            throw new ArgumentException($"State {stateType} not found");
        }

        public void StopCurrentState()
        {
            if (_currentState == null) return;

            _currentState.Exit();
            _currentState = null;
            _currentReadonlyState.Value = null;
        }

        public ReadonlyState<StateType> TryGetState(StateType stateType)
        {
            if (_statesMap.TryGetValue(stateType, out State<StateType> state))
            {
                return state;
            }

            throw new ArgumentException($"State {stateType} not found");
        }

        #endregion

    }
}
