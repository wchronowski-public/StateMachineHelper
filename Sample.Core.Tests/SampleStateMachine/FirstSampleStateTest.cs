using System;
using Sample.Core.SampleStateMachine;
using Test.Utilities;
using Test.Utilities.StateMachine;
using Xunit;

namespace Sample.Core.Tests.SampleStateMachine
{
    public class FirstSampleStateTest
    {
        private static readonly Func<FirstSampleState> FIRST = () => StateMachine.Create<FirstSampleState>();
        private static readonly Func<MiddleSampleState> MIDDLE = () => StateMachine.Create<MiddleSampleState>();

        [Fact]
        public void Start_ChangeStates()
        {
            var state = FIRST();

            StateMachineTests<ISampleState>
                .For(state)
                .When(() => state.Start()).TransitionTo(FIRST).And()
                .When(() => state.First()).TransitionTo(FIRST).And()
                .When(() => state.Middle()).TransitionTo(MIDDLE).And()
                .When(() => state.Last()).TransitionTo(FIRST).And()
                .When(() => state.End()).TransitionTo(FIRST)
                .Assert();
        }
    }
}
