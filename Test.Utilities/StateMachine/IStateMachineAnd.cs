using Project.Utilities;

namespace Test.Utilities.StateMachine {
    public interface IStateMachineAnd<T> where T : class, IDeepCloneable<T> {
        IStateMachineWhen<T> And();
        void Assert();
    }
}