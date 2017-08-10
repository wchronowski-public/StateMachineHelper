using Sample.Core.SampleStateMachine;

namespace Sample.Core {
    public class SampleObject {
        private ISampleState _currentState;

        public SampleObject(ISampleState initializeState) => _currentState = initializeState;

        public void Start() => _currentState = _currentState.Start();
        public void First() => _currentState = _currentState.First();
        public void Middle() => _currentState = _currentState.Middle();
        public void Last() => _currentState = _currentState.Last();
        public void End() => _currentState = _currentState.End();
    }
}