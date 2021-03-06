using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using UnityEngine.UI;

namespace UniRxLearn.Chapter1
{
    public class UGUIExam : MonoBehaviour
    {
        [SerializeField] private Button _btnTest;
        [SerializeField] private Image _imgTest;

        private void Awake()
        {
            _btnTest.OnClickAsObservable()
                .Subscribe(_ => Debug.Log("Test Button"));

            _imgTest.OnBeginDragAsObservable()
                .Subscribe(_ =>
                {
                    Debug.Log("begin drag");
                });
            _imgTest.OnDragAsObservable()
                .Subscribe(_ => Debug.Log("Dragging"));
            _imgTest.OnEndDragAsObservable()
                .Subscribe(_ => Debug.Log("EndDrag"));
        }
    }
}
