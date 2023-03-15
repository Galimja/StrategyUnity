using System;
using UnityEngine;

namespace UserControlSystem.UI.Model
{
    public abstract class GameObjectValue<T> : ScriptableObject, IAwaitable<T>
    {
        public class NewValueNotifier<TAwaited> : AwaiterBase<TAwaited>
        {
            private readonly GameObjectValue<TAwaited> _scriptableObjectValueBase;

            public NewValueNotifier(GameObjectValue<TAwaited> scriptableObjectValueBase)
            {
                _scriptableObjectValueBase = scriptableObjectValueBase;
                _scriptableObjectValueBase.OnSelected += onNewValue;
            }

            private void onNewValue(TAwaited obj)
            {
                _scriptableObjectValueBase.OnSelected -= onNewValue;
                onWaitFinish(obj);
            }
           

        }

        public T CurrentValue { get; private set; }
        public event Action<T> OnSelected;

        public void SetValue(T value)
        {
            CurrentValue = value;
            OnSelected?.Invoke(value);
        }

        public IAwaiter<T> GetAwaiter()
        {
            return new NewValueNotifier<T>(this);
        }
    }
}