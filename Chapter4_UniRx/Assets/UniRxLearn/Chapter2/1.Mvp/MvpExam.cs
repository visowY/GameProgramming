using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UniRxLearn.Chapter2
{
    public class MvpExam : MonoBehaviour
    {
        // view
        [SerializeField] private Button _btnAttack;
        [SerializeField] private Text _txtAttack;
        
        EnemyModel _enemyModel = new EnemyModel(200);
        
        // control presenter
        private void Start()
        {
            _btnAttack.OnClickAsObservable()
                .Subscribe(_ => { _enemyModel.HP.Value -= 20; });

            _enemyModel.HP.SubscribeToText(_txtAttack);
            _enemyModel.IsDead
                .Where(isDead=>isDead)
                .Select(isDead =>!isDead)
                .SubscribeToInteractable(_btnAttack);
        }
    }


    
    //model
    public class EnemyModel
    {
        public ReactiveProperty<long> HP;
        public ReactiveProperty<bool> IsDead;

        public EnemyModel(long initialHp)
        {
            HP = new ReactiveProperty<long>(initialHp);
            IsDead = new ReactiveProperty<bool>(HP.Value<=0);
        }
    }
}