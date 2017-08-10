namespace Sample.Core.SampleStateMachine {
    public class InitializeSampleState : ISampleState {
        public ISampleState Start() => new StartSampleState();
        public ISampleState First() => this;
        public ISampleState Middle() => this;
        public ISampleState Last() => this;
        public ISampleState End() => this;
        public ISampleState DeepClone() => new InitializeSampleState();
    }
}