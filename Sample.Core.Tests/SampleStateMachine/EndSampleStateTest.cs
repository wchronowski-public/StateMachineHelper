using System;
using Sample.Core.SampleStateMachine;
using Test.Utilities;
using Test.Utilities.StateMachine;
using Xunit;

namespace Sample.Core.Tests.SampleStateMachine
{
    public class EndSampleStateTest
    {
        private static readonly Func<EndSampleState> END = () => StateMachine.Create<EndSampleState>();        

        [Fact]
        public void Start_ChangeStates()
        {
            var state = END();

            StateMachineTests<ISampleState>
                .For(state)
                .When(() => state.Start()).TransitionTo(END).And()
                .When(() => state.First()).TransitionTo(END).And()
                .When(() => state.Middle()).TransitionTo(END).And()
                .When(() => state.Last()).TransitionTo(END).And()
                .When(() => state.End()).TransitionTo(END)
                .Assert();
        }
    }
}
