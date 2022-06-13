using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static CommonDefine;

public class PlayerList : SingletonMonoBehaviour<PlayerList>
{
    List<PlayerPropety> playerPropeties;

    public List<PlayerPropety> PlayerPropeties
    { 
        get
        {
            // なんかあったらいやなので、コピーで渡します.
            return new List<PlayerPropety>( this.playerPropeties );
        } 
    }

    protected override void Initialize()
    {
        playerPropeties = new List<PlayerPropety>();
        playerPropeties.Clear();
    }

    /// <summary>
    /// 新しいプレイヤーを生成します。
    /// </summary>
    /// <returns>正常に生成できるとtrue それ以外はfalseが返ります.</returns>
    public bool AddPlayer( string playerName )
    {
        Color color = new Color(Random.value, Random.value, Random.value, 1.0f);
        PlayerPropeties.Add( new PlayerPropety( playerName, color ) );

        return true;
    }

    /// <summary>
    /// プレイヤーを削除します.
    /// </summary>
    /// <param name="playerPropety">削除対象のプレイヤーデータ</param>
    public void RemovePlayer( PlayerPropety playerPropety )
    {
        if (playerPropeties.Contains(playerPropety))
        {
            playerPropeties.Remove(playerPropety);
        }
    }
}
