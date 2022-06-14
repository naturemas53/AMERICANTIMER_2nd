using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// プレイヤーの情報.
public struct PlayerData
{
    public string playerName;
    public Color playerColor;
}

// ラウンドの設定値.
public struct RoundOption
{
    public float remainTime; // 設定した試合時間
    public float multiplayer; // 倍率
}

// 各ラウンドの結果.
public struct RoundLog
{
    public RoundOption roundOption; // そのラウンドの設定値
    public float duelTime; // ２人になってから試合した時間
    public List<PlayerData> targetPlayers; // ペナルティを受ける人
    public List<MissionData> appearMissions; // 発生したミッションのデータ
}

// ミッション情報.
public struct MissionData
{ 
    public float appearTime; // ミッション発生時の時間.
    public float applyTime; // ミッション発生時間.
    public string overViewText; // ミッションの簡単な概要.

    // HACK: もしかしたら、対象者については、
    //       結果に統合した方がいいかも...?
    public List<string> targetPlayers; // 対象者.

    // ミッションの結果 で結果情報と時間を取得できる何か
}

/// <summary>
/// プレイヤーの得点などの情報（どれくらい時間くったかのアレ）.
/// </summary>
public struct PlayerScore
{
    public float penaltyTime; // ペナルティ時間
    public int position; // 現在の順位
}

/// <summary>
/// プレイヤーデータも欲しい場合はこちら.
/// </summary>
public struct PlayerRankData
{
    public PlayerData playerData;
    public PlayerScore playerScore;
}
