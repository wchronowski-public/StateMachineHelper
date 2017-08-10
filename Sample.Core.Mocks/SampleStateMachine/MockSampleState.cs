using Moq;
using Sample.Core.SampleStateMachine;

namespace Sample.Core.Mocks.SampleStateMachine {
    public class MockSampleState : ISampleState {
        private readonly Mock<ISampleState> _mock = new Mock<ISampleState>();

        public ISampleState DeepClone() => _mock.Object.DeepClone();
        public ISampleState Start() => _mock.Object.Start();
        public ISampleState First() => _mock.Object.First();
        public ISampleState Middle() => _mock.Object.Middle();
        public ISampleState Last() => _mock.Object.Last();
        public ISampleState End() => _mock.Object.End();

        public void VerifyStartCalled(int times = 1) {
            _mock.Verify(m => m.Start(), Times.Exactly(times));
        }

        public void VerifyFirstCalled(int times = 1) {
            _mock.Verify(m => m.First(), Times.Exactly(times));
        }

        public void VerifyMiddleCalled(int times = 1) {
            _mock.Verify(m => m.Middle(), Times.Exactly(times));
        }

        public void VerifyLastCalled(int times = 1) {
            _mock.Verify(m => m.Last(), Times.Exactly(times));
        }

        public void VerifyEndCalled(int times = 1) {
            _mock.Verify(m => m.End(), Times.Exactly(times));
        }

        public void VerifyDeepCloneCalled(int times = 1) {
            _mock.Verify(m => m.DeepClone(), Times.Exactly(times));
        }
    }
}