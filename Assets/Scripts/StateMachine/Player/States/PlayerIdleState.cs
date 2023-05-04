using Plugins.StateMachine.State.Core;
using StateMachine.Player.States.Core;
using UnityEngine;

namespace StateMachine.Player.States
{
    public class PlayerIdleState : State<PlayerState>
    {
        protected override void OnEnter()
        {
            Debug.Log("On enter idle via code");
        }
        protected override void OnExit()
        {
            Debug.Log("On exit idle via code");
        }
    }
}
