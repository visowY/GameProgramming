using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BindableProperty<T>
{
   public delegate void ValueChangeHandler(T oldValue, T newVlaue);

   public ValueChangeHandler OnValueChanged;

   private T _value;

   private T Value
   {
      get { return _value; }
      set
      {
         if (!object.Equals(_value, value))
         {
            T old = _value;
            _value = value;
            ValueChanged(old, _value);
         }
      }
   }

   private void ValueChanged(T oldValue, T newValue)
   {
      OnValueChanged?.Invoke(oldValue,newValue);
   }

   public override string ToString()
   {
      return (Value != null ? Value.ToString() : "null");
   }
}
