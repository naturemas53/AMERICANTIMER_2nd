using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static CommonDefine;

public class RankingManager : SingletonMonoBehaviour<RankingManager>
{
    /// <summary>
    /// 各順位のデータ.
    /// </summary>
    public struct RankData
    {
        public string playerName; // プレイヤー名
        public float penaltyTime; // ペナルティ時間
        public int position; // 現在の順位
    }

    protected override void Initialize()
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// ランキングの初期化を行います.
    /// </summary>
    public void InitializeRanking()
    {

    }

    /// <summary>
    /// ランキングを更新します.
    /// </summary>
    public void UpdateRanking()
    {

    }
}
