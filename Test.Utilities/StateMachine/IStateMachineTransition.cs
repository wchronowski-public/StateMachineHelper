using System;
using Project.Utilities;

namespace Test.Utilities.StateMachine {
    public interface IStateMachineTransition<T> where T : class, IDeepCloneable<T> {
        IStateMachineAnd<T> TransitionTo<TConcreteType>(Func<TConcreteType> create) where TConcreteType : class, T;
        void Invoke();
    }
}