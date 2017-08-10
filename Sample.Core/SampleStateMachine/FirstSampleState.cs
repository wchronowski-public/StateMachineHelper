namespace Sample.Core.SampleStateMachine {
    public class FirstSampleState : ISampleState {
        public ISampleState Start() => this;
        public ISampleState First() => this;
        public ISampleState Middle() => new MiddleSampleState();
        public ISampleState Last() => this;
        public ISampleState End() => this;
        public ISampleState DeepClone() => new FirstSampleState();
    }
}