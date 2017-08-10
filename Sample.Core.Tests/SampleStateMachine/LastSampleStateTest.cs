using System;
using Sample.Core.SampleStateMachine;
using Test.Utilities;
using Test.Utilities.StateMachine;
using Xunit;

namespace Sample.Core.Tests.SampleStateMachine
{
    public class LastSampleStateTest
    {
        private static readonly Func<LastSampleState> LAST = () => StateMachine.Create<LastSampleState>();
        private static readonly Func<EndSampleState> END = () => StateMachine.Create<EndSampleState>();

        [Fact]
        public void Start_ChangeStates()
        {
            var state = LAST();

            StateMachineTests<ISampleState>
                .For(state)
                .When(() => state.Start()).TransitionTo(LAST).And()
                .When(() => state.First()).TransitionTo(LAST).And()
                .When(() => state.Middle()).TransitionTo(LAST).And()
                .When(() => state.Last()).TransitionTo(LAST).And()
                .When(() => state.End()).TransitionTo(END)
                .Assert();
        }
    }
}
