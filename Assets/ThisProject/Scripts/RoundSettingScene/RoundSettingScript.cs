using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RoundSettingScript : MonoBehaviour
{
    readonly string HEADER_TEXT = " ROUND SETTING";

    [SerializeField]
    TextMeshProUGUI titleText;
    [SerializeField]
    TimeSetting timeSetting;
    [SerializeField]
    InputField multiplayerInput;

    // Start is called before the first frame update
    void Start()
    {
        // ここで終わりにするのおかしくね？と思うかもだが、
        // ゲームの流れや情報保持タイミングの関係上、
        // 次ラウンド開始時のここでラウンド終了とした方が何かと都合がいい
        GameParamaters.Instance.OnFinishedRound();

        string titleTextBase = HEADER_TEXT;
        int thisRound = (int)GameParamaters.Instance.CurrentRound;
        string titleHeader = (GameParamaters.Instance.IsFinalRound) ? "FINAL" : thisRound + CommonHelper.GetNumberOrdinal( thisRound );

        titleText.text = titleHeader + titleTextBase;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // スタートボタン押下時
    public void OnPressedStart()
    {
        int multiplayer = 0;

        if( !int.TryParse( multiplayerInput.text, out multiplayer ) )
        {
            var window = WindowFactory.Instance.CreateWindow(WindowFactory.CreateType.TextWindow);

            window.SetText("倍率が正しく設定されていません。\n半角数字以外を入力しないでください。");
            return;
        }

        if( multiplayer <= 0 )
        {
            var window = WindowFactory.Instance.CreateWindow(WindowFactory.CreateType.TextWindow);

            window.SetText("倍率について\nちょっと何言ってるかわかんない（半ギレ）");
            return;
        }

        RoundOption option = new RoundOption();
        option.gameTime = timeSetting.CurrentTime;
        option.multiplayer = (float)multiplayer;

        GameParamaters.Instance.SetRoundOption( option );

        SceneChanger.Instance.ChangeScene(SceneChanger.EScene.Timer);
    }
}
