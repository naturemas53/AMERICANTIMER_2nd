using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameTimer))]
public class DuelTimer : MonoBehaviour
{
    // 試合時間.
    public float DuelTime { get; private set; } = 0;
    // 計測中か.
    public bool IsCountUp { get; private set; } = false;
    // 倍率
    public float Multiplayer { get; private set; } = 1.0f;

    GameTimer timer = null;
    // 試合時間計測開始痔の時間
    float countStartedRemainTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        // 上記のRequireなんたらで存在は保証されているのでOK.
        timer = GetComponent<GameTimer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsCountUp) return;

        float elapsedTime = countStartedRemainTime - timer.RemainTime;

        DuelTime = elapsedTime * Multiplayer;
    }

    /// <summary>
    /// 試合時間の操作ボタンが押されたときのコールバックです
    /// (ボタン以外でも呼ばれるかも）
    /// </summary>
    public void OnClickDuelTimeControllerButton()
    {
        if (IsCountUp) ResetDuelTime();
        else           StartDuelTime();
    }

    /// <summary>
    /// 倍率設定
    /// </summary>
    public void SetMultiplayer( float multiplayer )
    {
        Multiplayer = multiplayer;
    }

    /// <summary>
    /// 計測開始
    /// </summary>
    public void StartDuelTime()
    {
        IsCountUp = true;
        DuelTime = 0;
        countStartedRemainTime = timer.RemainTime;
    }

    /// <summary>
    /// 計測停止＆リセット
    /// </summary>
    public void ResetDuelTime()
    {
        IsCountUp = false;
    }
}
