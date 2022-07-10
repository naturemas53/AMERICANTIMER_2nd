using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeSetting : MonoBehaviour
{
    // 99分 ～ 1分まで
    readonly float MAX_TIME = 60 * 99;
    readonly float MIN_TIME = 60;

    [SerializeField]
    TextMeshProUGUI timerText;
    [SerializeField]
    List<TimeChangeCallBack> timeChangeButtons;

    public float CurrentTime { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        CurrentTime = MIN_TIME;
        UpdateTimeText();

        foreach( var callBackButton in timeChangeButtons  )
        {
            callBackButton.RegistCallBack( OnPressedTimeChangeButton );
        }
    }

    /// <summary>
    /// 制限時間変動のボタンが押されたときのコールバック
    /// </summary>
    void OnPressedTimeChangeButton( float changeTime )
    {
        CurrentTime = Mathf.Clamp( CurrentTime + changeTime, MIN_TIME, MAX_TIME );
        UpdateTimeText();
    }

    void UpdateTimeText()
    {
        timerText.text = CommonHelper.BuildTimeText( CurrentTime );
    }
}
