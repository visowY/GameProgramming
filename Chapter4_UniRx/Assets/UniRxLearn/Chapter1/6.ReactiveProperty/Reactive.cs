using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace UniRxLearn.Chapter1
{
    public class Reactive : MonoBehaviour
    {
        //响应式属性
        
        public ReactiveProperty<int> Age = new ReactiveProperty<int>(10);

        private void Start()
        {
            Age.Subscribe(age => Debug.Log($"inner age changed {age}"));

            Age.Value = 20;
        }
    }
}
