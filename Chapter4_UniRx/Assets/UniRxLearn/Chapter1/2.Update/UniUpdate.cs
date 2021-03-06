using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace UniRxLearn.Chapter1
{
    public class UniUpdate : MonoBehaviour
    {
        private void Start()
        {
            Observable.EveryUpdate()
                .Subscribe(_ =>
                {
                    
                });
        }
    }
}