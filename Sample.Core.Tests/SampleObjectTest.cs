using Sample.Core.Mocks.SampleStateMachine;
using Xunit;

namespace Sample.Core.Tests {
    public class SampleObjectTest {
        [Fact]
        public void Initialize() {
            var sampleObject = new SampleObject(new MockSampleState());

            Assert.NotNull(sampleObject);
        }

        [Fact]
        public void Start() {
            var state = new MockSampleState();
            var sampleObject = new SampleObject(state);

            sampleObject.Start();

            state.VerifyStartCalled();
        }

        [Fact]
        public void First() {
            var state = new MockSampleState();
            var sampleObject = new SampleObject(state);

            sampleObject.First();

            state.VerifyFirstCalled();
        }

        [Fact]
        public void Middle() {
            var state = new MockSampleState();
            var sampleObject = new SampleObject(state);

            sampleObject.Middle();

            state.VerifyMiddleCalled();
        }

        [Fact]
        public void Last() {
            var state = new MockSampleState();
            var sampleObject = new SampleObject(state);

            sampleObject.Last();

            state.VerifyLastCalled();
        }

        [Fact]
        public void End() {
            var state = new MockSampleState();
            var sampleObject = new SampleObject(state);

            sampleObject.End();

            state.VerifyEndCalled();
        }
    }
}