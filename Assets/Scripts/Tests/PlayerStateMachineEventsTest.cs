using StateMachine.Player;
using UniRx;
using UnityEngine;

namespace Tests
{
    public class PlayerStateMachineEventsTest : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private PlayerStateMachine _playerStateMachine;

        #region MonoBehaviour

        private void OnValidate()
        {
            _playerStateMachine ??= FindObjectOfType<PlayerStateMachine>();
        }

        private void Awake()
        {
            _playerStateMachine.CurrentState.Subscribe(currentState =>
            {
                if (currentState != null)
                    Debug.Log($"Current state: {currentState.Type}");
            }).AddTo(this);
        }

        #endregion
    }
}
