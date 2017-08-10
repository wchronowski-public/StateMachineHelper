using Project.Utilities;

namespace Sample.Core.SampleStateMachine {
    public interface ISampleState : IDeepCloneable<ISampleState>
    {
        ISampleState Start();
        ISampleState First();
        ISampleState Middle();
        ISampleState Last();
        ISampleState End();
    }
}