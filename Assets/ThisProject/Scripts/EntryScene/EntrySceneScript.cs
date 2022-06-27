using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntrySceneScript : MonoBehaviour
{
    [SerializeField]
    InputField roundInput;

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
            SceneChanger.Instance.ChangeScene( SceneChanger.EScene.RoundSetting );
        }
    }

    /// <summary>
    /// ゲームを開始できる設定か.
    /// </summary>
    bool IsCanGame()
    {
        if(PlayerSet.Instance.PlayerCount < 2)
        {
            var window = WindowFactory.Instance.CreateWindow(WindowFactory.CreateType.TextWindow);
            window.SetText("さすがにプレイヤーが少なすぎます\r\nもうちょっと友達を作りましょう");
            return false;
        }

        int inputedRound = 0;
        string roundStr = roundInput.text;
        int.TryParse( roundStr , out inputedRound );

        if ( inputedRound < 1 )
        {
            var window = WindowFactory.Instance.CreateWindow(WindowFactory.CreateType.TextWindow);
            window.SetText("不正なラウンド数 or 数字そのものでない\r\nものが入力されています。");
            return false;
        }

        GameParamaters.Instance.SetMaxRound( (uint)inputedRound );

        return true;
    }
}
