using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    /// <summary>
    /// 10分(=600秒) * 9 = 5400
    /// 1分　　　　　* 9 =  540
    ///                  +   59
    /// ========================
    ///                    5999  
    /// </summary>
    public readonly float MAX_REMAIN_TIME = 5999.0f;

    /// <summary>
    /// 残り時間
    /// </summary>
    public float RemainTime { get; private set; } = 0.0f;

    /// <summary>
    /// カウント中か（≒再生中か）
    /// </summary>
    public bool IsNowCounting { get; private set; } = false;

    // Start is called before the first frame update
    void Start()
    {
        IsNowCounting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsNowCounting) return;

        RemainTime = Mathf.Clamp( RemainTime, 0.0f, RemainTime - Time.deltaTime );
    }

    /// <summary>
    /// 再生・一時停止中　の状態を切り替えます.
    /// </summary>
    public void TogglePlayState()
    {
        if ( IsNowCounting ) PauseTimer();
        else                 ResumeTimer();
    }

    /// <summary>
    /// 残り時間を設定します.
    /// </summary>
    public void SetRemainTime(float setTime)
    {
        RemainTime = Mathf.Clamp( setTime, 0.0f, MAX_REMAIN_TIME );
    }

    /// <summary>
    /// タイマーを稼働させます.
    /// </summary>
    public void PlayTimer()
    {
        IsNowCounting = true;
    }

    /// <summary>
    /// タイマーを途中から稼働させます.
    /// </summary>
    public void ResumeTimer()
    {
        IsNowCounting = true;
    }

    /// <summary>
    /// タイマーを止めます.
    /// </summary>
    public void StopTimer()
    {
        RemainTime = 0;
        IsNowCounting = false;
    }

    /// <summary>
    /// タイマーを途中で止めます.
    /// </summary>
    public void PauseTimer()
    {
        IsNowCounting = false;
    }
}
