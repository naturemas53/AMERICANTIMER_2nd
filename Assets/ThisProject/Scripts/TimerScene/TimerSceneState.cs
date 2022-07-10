using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerSceneState : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RoundOption roundOption = GameParamaters.Instance.CurrentRoundOption;

        GameTimer timer = GetComponent< GameTimer >();
        if( timer != null )
        {
            timer.StopTimer();
            timer.SetRemainTime( roundOption.gameTime );
        }

        DuelTimer duelTimer = GetComponent<DuelTimer>();
        if( duelTimer != null )
        {
            duelTimer.SetMultiplayer( roundOption.multiplayer );
        }

        SceneChanger.Instance.OnCompletedSceneChange.AddListener(OnReadySelfScene);
    }

    /// <summary>
    /// 自シーンの準備が出来た時に呼ばれるコールバック
    /// </summary>
    void OnReadySelfScene()
    {
        Debug.Log("はい　よーいスタート");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
