using System;
using UnityEngine;

namespace UserControlSystem.UI.Model
{
    public abstract class GameObjectValue<T> : ScriptableObject
    {
        public T CurrentValue { get; private set; }
        public event Action<T> OnSelected;

        public void SetValue(T value)
        {
            CurrentValue = value;
            OnSelected?.Invoke(value);
        }
    }
}