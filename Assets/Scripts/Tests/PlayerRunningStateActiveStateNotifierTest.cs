using StateMachine.Player;
using StateMachine.Player.States.Core;
using UniRx;
using UnityEngine;

namespace Tests
{
    public class PlayerRunningStateActiveStateNotifierTest : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private PlayerStateMachine _playerStateMachine;

        #region MonoBehaviour

        private void OnValidate()
        {
            _playerStateMachine ??= FindObjectOfType<PlayerStateMachine>();
        }

        #endregion

        private void Start()
        {
            _playerStateMachine.TryGetState(PlayerState.Running).IsRunning.Subscribe(isRunning =>
            {
                Debug.Log("Running state is " + (isRunning ? "active" : "inactive"));
            }).AddTo(this);
        }
    }
}
