using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace UniRxLearn.Chapter1
{
    public class TimerExample : MonoBehaviour
    {
        private void Start()
        {
            Observable.Timer(TimeSpan.FromSeconds(5.0f))
                .Subscribe(_ =>
                {
                    Debug.Log("do something");
                });
        }
    }
}
