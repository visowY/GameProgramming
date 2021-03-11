using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class RegisterPanel : MonoBehaviour
{
    [SerializeField] private InputField _inputName;
    [SerializeField] private InputField _inputPass1;
    [SerializeField] private InputField _inputPass2;
    [SerializeField] private Button _btnRegister;

    private string _name;
    private string _password;

    private void Start()
    {
        _inputName.OnEndEditAsObservable().Subscribe(result =>
        {
            _inputPass1.Select();
        });

        _inputPass1.OnEndEditAsObservable().Subscribe(result =>
        {
            _inputPass2.Select();
        });

        _inputPass2.OnEndEditAsObservable().Subscribe(result =>
        {
            _btnRegister.onClick.Invoke();
        });
    }
}
