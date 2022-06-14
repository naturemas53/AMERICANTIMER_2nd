using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingManager : SingletonMonoBehaviour<RankingManager>
{
    // プレイヤーデータを含めた、ランキング配列
    // (出来れば常にソートしている状態...　にしておきたい...)
    List<PlayerRankData> playerRankDatas;

    public List<PlayerRankData> CurrentRanking
    {
        get
        {
            // 例によってコピー
            return new List<PlayerRankData>( playerRankDatas );
        }
    }

    protected override void Initialize()
    {
        playerRankDatas = new List<PlayerRankData>();
        playerRankDatas.Clear();
    }

    /// <summary>
    /// ランキングの初期化を行います.
    /// </summary>
    public void InitializeRanking()
    {
        playerRankDatas.Clear();
    }

    /// <summary>
    /// ランキングを更新します.
    /// HACK: もしかしたらちょっと重い処理かも
    /// </summary>
    public void UpdateRanking()
    {
        InitializeRanking();

        // TODO: なんやかんやあって取得.

        ExcuteSortOfRankData();
    }

    /// <summary>
    /// プレイヤーデータを並べ替えます
    /// （事前に何らかの方法で、playerRankDatasにすでにデータが入っていることが前提です。）
    /// </summary>
    void ExcuteSortOfRankData()
    {
        playerRankDatas.Sort((a, b) =>
        {
            float timeA = a.playerScore.penaltyTime;
            float timeB = b.playerScore.penaltyTime;

            if (timeA > timeB) return -1;
            if (timeA < timeB) return 1;

            // ここまで来たら、同じだった ということになる
            return 0;
        });

        for (int i = 0; i < playerRankDatas.Count; ++i)
        {
            PlayerRankData rankData = playerRankDatas[i];
            rankData.playerScore.position = (i + 1);
            playerRankDatas[i] = rankData;
        }
    }
}
