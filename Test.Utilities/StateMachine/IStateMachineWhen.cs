using System;
using System.Linq.Expressions;
using Project.Utilities;

namespace Test.Utilities.StateMachine {
    public interface IStateMachineWhen<T> where T : class, IDeepCloneable<T> {
        IStateMachineTransition<T> When(Expression<Func<T>> predicate);
    }
}