using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntrySceneScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// スタートボタンが押された時のコールバック
    /// </summary>
    public void OnPressedStart()
    {
        if( IsCanGame() )
        {
            // TODO: フェードを兼ねたシーン遷移処理.
        }
    }

    /// <summary>
    /// ゲームを開始できる設定か.
    /// </summary>
    bool IsCanGame()
    {
        if(PlayerSet.Instance.PlayerCount <= 1)
        {
            // TODO: エラーダイアログの表示
            return false;
        }

        // TODO: 数値を取得する処理 できなかったらエラーダイアログ.

        int inputedRound = 0;

        if( inputedRound <= 0 )
        {
            // TODO: エラーダイアログの表示
            return false;
        }

        GameParamaters.Instance.SetMaxRound( (uint)inputedRound );

        return true;
    }
}
