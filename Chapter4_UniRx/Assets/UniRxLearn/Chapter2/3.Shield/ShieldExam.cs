using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class ShieldExam : MonoBehaviour
{
    [SerializeField] private Button _btn1;
    [SerializeField] private Button _btn2;
    [SerializeField] private Button _btn3;

    private void Start()
    {
       var stream1 =  _btn1.OnClickAsObservable().Select(_=>"stream1");
       var stream2 =  _btn2.OnClickAsObservable().Select(_=>"stream2");
       var stream3 =  _btn3.OnClickAsObservable().Select(_=>"stream3");

       Observable.Merge(stream1, stream2, stream3)
//           .First()
           .Subscribe(_ =>
           {
               Debug.Log("BtnClicked " + _);
           })
           .AddTo(this);
    }
}
