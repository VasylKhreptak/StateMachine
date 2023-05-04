using NaughtyAttributes;
using StateMachine.Player;
using StateMachine.Player.States.Core;
using UnityEngine;

namespace Tests
{
    public class PlayerStateMachineTest : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private PlayerStateMachine _playerStateMachine;

        [Header("Preferences")]
        [SerializeField] private PlayerState _targetState;

        #region MonoBehaviour

        private void OnValidate()
        {
            _playerStateMachine ??= FindObjectOfType<PlayerStateMachine>();
        }

        #endregion

        [Button("Enter State")]
        public void EnterState()
        {
            _playerStateMachine.SetState(_targetState);
        }

        [Button("Stop Current State")]
        public void StopCurrentState()
        {
            _playerStateMachine.StopCurrentState();
        }
    }
}
