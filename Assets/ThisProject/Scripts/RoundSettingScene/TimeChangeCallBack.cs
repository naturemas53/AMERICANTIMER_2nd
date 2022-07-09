using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class TimeChangeCallBack : MonoBehaviour
{
    // なんかUnityEvent、継承しないと使えないっぽいので
    // 取り急ぎ継承...
    class FloatUnityEvent :  UnityEvent<float>{ }

    [SerializeField]
    float changeSecond = 0.0f;

    UnityEvent<float> onPressedCallBack;

    // Start is called before the first frame update
    void Start()
    {
        onPressedCallBack = new FloatUnityEvent();

        Button button = this.GetComponent<Button>();
        button.onClick.AddListener(OnClickedButton);
    }

    void OnClickedButton()
    {
        onPressedCallBack.Invoke( changeSecond );
    }

    public void RegistCallBack( UnityAction<float> registCallBack )
    {
        onPressedCallBack.AddListener( registCallBack );
    }
}
