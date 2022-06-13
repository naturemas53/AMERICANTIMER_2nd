using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerList : SingletonMonoBehaviour<PlayerList>
{
    List<PlayerData> playerPropeties;

    public List<PlayerData> PlayerPropeties
    { 
        get
        {
            // なんかあったらいやなので、コピーで渡します.
            return new List<PlayerData>( this.playerPropeties );
        } 
    }

    protected override void Initialize()
    {
        playerPropeties = new List<PlayerData>();
        playerPropeties.Clear();
    }

    /// <summary>
    /// 新しいプレイヤーを生成します。
    /// </summary>
    /// <returns>正常に生成できるとtrue それ以外はfalseが返ります.</returns>
    public bool AddPlayer( string playerName )
    {
        PlayerData player = new PlayerData();

        player.playerColor = new Color(Random.value, Random.value, Random.value, 1.0f);
        player.playerName = playerName;

        PlayerPropeties.Add(player);

        return true;
    }

    /// <summary>
    /// プレイヤーを削除します.
    /// </summary>
    /// <param name="playerPropety">削除対象のプレイヤーデータ</param>
    public void RemovePlayer( PlayerData playerPropety )
    {
        if (playerPropeties.Contains(playerPropety))
        {
            playerPropeties.Remove(playerPropety);
        }
    }
}
