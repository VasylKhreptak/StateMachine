using UniRx;
using UnityEngine;

namespace Plugins.StateMachine.State.Core
{
    public class ReadonlyState<StateType> : MonoBehaviour
    {
        [Header("Preferences")]
        [SerializeField] private StateType _type;

        protected BoolReactiveProperty _isRunning = new BoolReactiveProperty();

        public StateType Type => _type;

        public IReadOnlyReactiveProperty<bool> IsRunning => _isRunning;
    }
}
