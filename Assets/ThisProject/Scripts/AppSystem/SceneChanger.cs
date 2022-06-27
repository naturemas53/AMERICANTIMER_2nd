using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SceneChanger : SingletonMonoBehaviour<SceneChanger>
{
    public enum EScene
    {
        Boot,         // 起動
        PlayerEntry,  // プレイヤー登録
        RoundSetting, // ラウンド設定
        Timer,        // タイマー
        RoundResult,  // ラウンド結果
        TotalResult,  // 最終結果
        RoundLog,     // 各ラウンドのログ
    }

    SceneLoader sceneLoader;

    public UnityEvent OnCompletedSceneChange { get; private set; }

    protected override void Initialize()
    {
        sceneLoader = new SceneLoader();
        sceneLoader.Initialize();

        OnCompletedSceneChange = new UnityEvent();
    }

    /// <summary>
    /// シーン変更を行います.
    /// </summary>
    /// <param name="targetScene"></param>
    /// <param name="onChangedSceneCallBack"></param>
    public void ChangeScene(EScene targetScene, UnityAction onChangedSceneCallBack = null)
    {
        if( onChangedSceneCallBack != null)
        {
            OnCompletedSceneChange.AddListener(onChangedSceneCallBack);
        }

        FadePanel.Instance.ExcuteFade( FadePanel.EFade.Out, CommonDefine.SCENE_FADE_TIME, () =>
        {
            sceneLoader.LoadScene( targetScene, OnLoadedNextScene );
        });
    }

    /// <summary>
    /// 次のシーンをロードした際に呼ばれます.
    /// </summary>
    void OnLoadedNextScene()
    {
        FadePanel.Instance.ExcuteFade(FadePanel.EFade.In, CommonDefine.SCENE_FADE_TIME, () =>
         {
             OnCompletedSceneChange.Invoke();
             OnCompletedSceneChange.RemoveAllListeners();
         });
    }
}
