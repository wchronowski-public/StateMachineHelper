namespace Sample.Core.SampleStateMachine {
    public class EndSampleState : ISampleState {
        public ISampleState Start() => this;
        public ISampleState First() => this;
        public ISampleState Middle() => this;
        public ISampleState Last() => this;
        public ISampleState End() => this;
        public ISampleState DeepClone() => new EndSampleState();
    }
}