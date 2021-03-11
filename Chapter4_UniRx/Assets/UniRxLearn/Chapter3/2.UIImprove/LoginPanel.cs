using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class LoginPanel: MonoBehaviour
{
    [SerializeField] private InputField _inputName;
    [SerializeField] private InputField _inputPassword;
    [SerializeField] private Button _btnLogin;
    [SerializeField] private Button _btnRegister;
    
    private string _myName;
    private string _myPassword;

    private void Start()
    {
        _btnLogin.OnClickAsObservable().Subscribe(_ =>
        {
            Debug.Log("Login btn clicked");
            Debug.Log($"myName: {_myName} \nmyPassword {_myPassword}");
        });

        _inputName.OnEndEditAsObservable().Subscribe(_ =>
        {
            _myName = _;
            _inputPassword.Select();
        });
        _inputPassword.OnEndEditAsObservable().Subscribe(_ =>
        {
            _myPassword = _;
            _btnLogin.onClick.Invoke();
        });

        _btnRegister.OnClickAsObservable().Subscribe(_ => { });
    }
}
