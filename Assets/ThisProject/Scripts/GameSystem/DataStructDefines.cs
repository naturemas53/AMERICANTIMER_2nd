using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// プレイヤーの情報.
public class PlayerData
{
    public string playerName = "";
    public Color playerColor = new Color();
}

// 各ラウンドの情報.
public class RoundData
{
    public float RemainTime = 0.0f; // 設定した試合時間
    public float Multiplayer = 0.0f; // 倍率
    public float DuelTime = 0.0f; // ２人になってから試合した時間
    public List<PlayerData> targetPlayers = null; // ペナルティを受ける人
    public List<MissionData> appearMissions = null; // 発生したミッションのデータ
}

// ミッション情報.
public class MissionData
{ 
    public float AppearTime = 0.0f; // ミッション発生時の時間.
    public string overViewText =""; // ミッションの簡単な概要.

    // HACK: もしかしたら、対象者については、
    //       結果に統合した方がいいかも...?
    public List<string> targetPlayers = null; // 対象者.

    // ミッションの結果 で結果情報と時間を取得できる何か
}