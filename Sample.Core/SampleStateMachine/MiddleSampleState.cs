namespace Sample.Core.SampleStateMachine {
    public class MiddleSampleState : ISampleState {
        public ISampleState Start() => this;
        public ISampleState First() => this;
        public ISampleState Middle() => this;
        public ISampleState Last() => new LastSampleState();
        public ISampleState End() => this;
        public ISampleState DeepClone() => new MiddleSampleState();
    }
}