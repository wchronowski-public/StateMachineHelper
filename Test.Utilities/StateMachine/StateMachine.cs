using System;

namespace Test.Utilities.StateMachine {
    public static class StateMachine {
        public static T Create<T, TParam>(TParam param1) where T : class where TParam : class => (T) Activator.CreateInstance(typeof(T), param1);
        public static T Create<T, TParam>() where T : class where TParam : class => (T) Activator.CreateInstance(typeof(T), Activator.CreateInstance<TParam>());
        public static T Create<T>() where T : class => Activator.CreateInstance<T>();
    }
}