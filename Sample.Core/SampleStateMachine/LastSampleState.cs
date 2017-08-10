namespace Sample.Core.SampleStateMachine {
    public class LastSampleState : ISampleState {
        public ISampleState Start() => this;
        public ISampleState First() => this;
        public ISampleState Middle() => this;
        public ISampleState Last() => this;
        public ISampleState End() => new EndSampleState();
        public ISampleState DeepClone() => new LastSampleState();
    }
}