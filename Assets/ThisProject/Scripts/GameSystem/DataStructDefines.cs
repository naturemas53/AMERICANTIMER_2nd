using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// プレイヤーの情報.
public struct PlayerData
{
    public string playerName;
    public Color playerColor;
}

// 各ラウンドの情報.
public struct RoundData
{
    public float RemainTime; // 設定した試合時間
    public float Multiplayer; // 倍率
    public float DuelTime; // ２人になってから試合した時間
    public List<PlayerData> targetPlayers; // ペナルティを受ける人
    public List<MissionData> appearMissions; // 発生したミッションのデータ
}

// ミッション情報.
public struct MissionData
{ 
    public float AppearTime; // ミッション発生時の時間.
    public float ApplyTime; // ミッション発生時間.
    public string overViewText; // ミッションの簡単な概要.

    // HACK: もしかしたら、対象者については、
    //       結果に統合した方がいいかも...?
    public List<string> targetPlayers; // 対象者.

    // ミッションの結果 で結果情報と時間を取得できる何か
}