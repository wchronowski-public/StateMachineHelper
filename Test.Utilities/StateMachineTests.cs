using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Project.Utilities;
using Test.Utilities.StateMachine;

namespace Test.Utilities {
    public class StateMachineTests<T> : IStateMachineWhen<T>, IStateMachineTransition<T>, IStateMachineAnd<T> where T : class, IDeepCloneable<T> {
        internal struct TestCase {
            public TestCase(Expression<Func<T>> predicate, T expectedState, T actualState, Func<bool> typeAs) {
                Predicate = predicate;
                ExpectedState = expectedState;
                ActualState = actualState;
                TypeAs = typeAs;
            }

            public Expression<Func<T>> Predicate { get; }
            public T ExpectedState { get; }
            public T ActualState { get; }
            public Func<bool> TypeAs { get; }
            public override string ToString() => $"\t(x => x.{Predicate.GetName(),-8}) Expected: {ExpectedState,-10} Actual: {ActualState}";
        }

        public static StateMachineTests<T> For(T originalState) => new StateMachineTests<T>(originalState);

        private readonly T _originalState;
        private readonly List<TestCase> _testCases = new List<TestCase>();
        private T _newState;
        private Expression<Func<T>> _predicate;

        private StateMachineTests(T originalState) => _originalState = originalState;

        public IStateMachineWhen<T> And() => this;

        public void Assert() {
            var failedMessage = new StringBuilder();
            var failedTestCases = _testCases.Where(tc => !tc.TypeAs()).ToList();

            failedMessage.AppendLine($"{_originalState} State Machine failed to transistion to:");
            failedTestCases.ForEach(tc => failedMessage.AppendLine(tc.ToString()));

            Xunit.Assert.False(failedTestCases.Any(), failedMessage.ToString());
        }

        public void Invoke() { }

        public IStateMachineAnd<T> TransitionTo<TConcreteType>(Func<TConcreteType> create) where TConcreteType : class, T {
            var testState = _newState.DeepClone();
            _testCases.Add(new TestCase(_predicate, create(), testState, () => testState.GetType() == typeof(TConcreteType)));
            return this;
        }

        public IStateMachineTransition<T> When(Expression<Func<T>> predicate) {
            _predicate = predicate;
            _newState = predicate.Compile().Invoke();
            return this;
        }
    }
}