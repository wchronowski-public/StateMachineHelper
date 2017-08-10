using System;
using Sample.Core.SampleStateMachine;
using Test.Utilities;
using Test.Utilities.StateMachine;
using Xunit;

namespace Sample.Core.Tests.SampleStateMachine
{
    public class MiddleSampleStateTest
    {
        private static readonly Func<MiddleSampleState> MIDDLE = () => StateMachine.Create<MiddleSampleState>();
        private static readonly Func<LastSampleState> LAST = () => StateMachine.Create<LastSampleState>();

        [Fact]
        public void Start_ChangeStates()
        {
            var state = MIDDLE();

            StateMachineTests<ISampleState>
                .For(state)
                .When(() => state.Start()).TransitionTo(MIDDLE).And()
                .When(() => state.First()).TransitionTo(MIDDLE).And()
                .When(() => state.Middle()).TransitionTo(MIDDLE).And()
                .When(() => state.Last()).TransitionTo(LAST).And()
                .When(() => state.End()).TransitionTo(MIDDLE)
                .Assert();
        }
    }
}
