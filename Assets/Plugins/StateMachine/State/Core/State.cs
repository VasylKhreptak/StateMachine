namespace Plugins.StateMachine.State.Core
{
    public abstract class State<StateType> : ReadonlyState<StateType>
    {
        protected abstract void OnEnter();

        protected abstract void OnExit();

        public void Enter()
        {
            OnEnter();
            _isRunning.Value = true;
        }

        public void Exit()
        {
            OnExit();
            _isRunning.Value = false;
        }
    }
}
