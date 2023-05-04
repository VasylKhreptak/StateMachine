using Plugins.StateMachine.State.Core;
using StateMachine.Player.States.Core;
using UnityEngine;

namespace StateMachine.Player.States
{
    public class PlayerRunningState : State<PlayerState>
    {
        protected override void OnEnter()
        {
            Debug.Log("On enter running via code");
        }

        protected override void OnExit()
        {
            Debug.Log("On exit running via code");
        }
    }
}
