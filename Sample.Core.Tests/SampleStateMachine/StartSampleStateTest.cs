using System;
using Sample.Core.SampleStateMachine;
using Test.Utilities;
using Test.Utilities.StateMachine;
using Xunit;

namespace Sample.Core.Tests.SampleStateMachine
{
    public class StartSampleStateTest
    {
        private static readonly Func<StartSampleState> START = () => StateMachine.Create<StartSampleState>();
        private static readonly Func<FirstSampleState> FIRST = () => StateMachine.Create<FirstSampleState>();        

        [Fact]
        public void Start_ChangeStates()
        {            
            var state = START();

            StateMachineTests<ISampleState>
                .For(state)
                .When(() => state.Start()).TransitionTo(START).And()
                .When(() => state.First()).TransitionTo(FIRST).And()
                .When(() => state.Middle()).TransitionTo(START).And()
                .When(() => state.Last()).TransitionTo(START).And()
                .When(() => state.End()).TransitionTo(START)
                .Assert();
        }
    }
}
