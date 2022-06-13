using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundLogSet : SingletonMonoBehaviour<RoundLogSet>
{
    List<RoundData> roundDatas;

    public List<RoundData> LogDatas
    {
        get
        {
            // なんかあった時ようにコピーで渡します.
            return new List<RoundData>(roundDatas);
        }
    }

    public int LogCount
    {
        get { return roundDatas.Count; }
    }

    protected override void Initialize()
    {
        roundDatas = new List<RoundData>();
        roundDatas.Clear();

        throw new System.NotImplementedException();
    }

    /// <summary>
    /// 試合結果を追加します.
    /// </summary>
    /// <param name="roundData"> 追加する試合結果 </param>
    public void AddRoundLog(RoundData roundData)
    {
        roundDatas.Add( roundData );
    }

    /// <summary>
    /// 試合結果をすべて消去します
    /// </summary>
    public void ClearLog()
    {
        roundDatas.Clear();
    }
}
