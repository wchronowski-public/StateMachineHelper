namespace Sample.Core.SampleStateMachine {
    public class StartSampleState : ISampleState {
        public ISampleState Start() => this;
        public ISampleState First() => new FirstSampleState();
        public ISampleState Middle() => this;
        public ISampleState Last() => this;
        public ISampleState End() => this;
        public ISampleState DeepClone() => new StartSampleState();
    }
}