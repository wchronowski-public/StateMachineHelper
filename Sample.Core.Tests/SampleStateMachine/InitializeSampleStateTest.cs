using System;
using Sample.Core.SampleStateMachine;
using Test.Utilities;
using Test.Utilities.StateMachine;
using Xunit;

namespace Sample.Core.Tests.SampleStateMachine
{
    public class InitializeSampleStateTest
    {
        private static readonly Func<InitializeSampleState> INITIALIZE = () => StateMachine.Create<InitializeSampleState>();
        private static readonly Func<StartSampleState> START = () => StateMachine.Create<StartSampleState>();

        [Fact]
        public void Start_ChangeStates()
        {
            var state = INITIALIZE();

            StateMachineTests<ISampleState>
                .For(state)
                .When(() => state.Start()).TransitionTo(START).And()
                .When(() => state.First()).TransitionTo(INITIALIZE).And()
                .When(() => state.Middle()).TransitionTo(INITIALIZE).And()
                .When(() => state.Last()).TransitionTo(INITIALIZE).And()
                .When(() => state.End()).TransitionTo(INITIALIZE)
                .Assert();
        }
    }
}
