using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// HACK:見事に神クラスのような命名ですけど大丈夫ですかね...
/// 何ラウンド目か や 次のラウンドの情報 等を保持します
/// ...もしかして２つ以上の役割を持ってしまっている?
/// </summary>
public class GameParamaters : SingletonMonoBehaviour< GameParamaters >
{
    public uint MaxRound     { get; private set; }
    public uint CurrentRound { get; private set; }
    public RoundOption CurrentRoundOption { get; private set; }

    /// <summary>
    /// 最終ラウンド？
    /// </summary>
    public bool IsFinalRound
    {
        get { return CurrentRound >= MaxRound; }
    }

    protected override void Initialize()
    {
        MaxRound = 0;
        CurrentRound = 1;
    }

    /// <summary>
    /// ラウンド終了時に呼ばれる関数
    /// </summary>
    public void OnFinishedRound()
    {
        CurrentRound++;
        CurrentRoundOption = new RoundOption();
    }

    /// <summary>
    /// 何ラウンドを最大とするか　を設定します.
    /// </summary>
    /// <param name="maxRound"></param>
    public void SetMaxRound( uint maxRound )
    {
        CurrentRound = 0;
        MaxRound = maxRound;
    }

    /// <summary>
    /// ラウンドの設定値（制限時間等）を保持します.
    /// </summary>
    public void SetRoundOption( RoundOption roundOption )
    {
        CurrentRoundOption = roundOption;
    }
}
