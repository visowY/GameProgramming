using UniRx;
using UnityEngine;

namespace UniRxLearn.Chapter1
{
    public class Chapter1Start : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Observable.EveryUpdate()                      //开启了Update的事件监听
                .Where(_ => Input.GetMouseButtonDown(0))  //过滤
                .First()                                  //只处理第一次情况
                .Subscribe(_ => { Debug.Log("Mouse left First clicked"); });  //回调函数处理
        }
    }
}
