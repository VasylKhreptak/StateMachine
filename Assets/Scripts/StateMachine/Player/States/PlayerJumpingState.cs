using Plugins.StateMachine.State.Core;
using StateMachine.Player.States.Core;
using UnityEngine;

namespace StateMachine.Player.States
{
    public class PlayerJumpingState : State<PlayerState>
    {
        protected override void OnEnter()
        {
            Debug.Log("On enter jumping via code");
        }

        protected override void OnExit()
        {
            Debug.Log("On exit jumping via code");
        }
    }
}
