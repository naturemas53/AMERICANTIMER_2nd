using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneLoader : SingletonMonoBehaviour<SceneLoader>
{
    public enum EScene
    {
        Boot,         // 起動
        PlayerEntry,  // プレイヤー登録
        RoundSetting, // ラウンド設定
        Timer,        // タイマー
        RoundResult,  // ラウンド結果
        TotalResult,  // 最終結果
    }

    static readonly ReadOnlyDictionary<EScene, string> sceneNameMap = new ReadOnlyDictionary<EScene, string>( new Dictionary<EScene, string>() 
    {
        { EScene.Boot, "BootScene" },
        { EScene.PlayerEntry, "BootScene" },
        { EScene.RoundSetting, "BootScene" },
        { EScene.Timer, "BootScene" },
        { EScene.RoundResult, "BootScene" },
        { EScene.TotalResult, "BootScene" },
    } );

    UnityAction onLoadedScene;

    protected override void Initialize()
    {
        onLoadedScene = null;

        SceneManager.sceneLoaded += this.OnSceneLoaded;
        SceneManager.activeSceneChanged += this.OnActiveSceneChanged;
    }

    // シーン変更時のデリゲート　多分使わない.
    void OnActiveSceneChanged(Scene prevScene, Scene nextScene)
    {
        
    }

    /// <summary>
    /// シーン読み込み時のデリゲート
    /// もし遷移待ちの処理がある場合、ここで呼ばれる
    /// </summary>
    /// <param name="scene"></param>
    /// <param name="mode"></param>
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if( onLoadedScene != null )
        {
            onLoadedScene();
            onLoadedScene = null;
        }
    }

    // シーン読み込み.
    public void LoadScene( EScene loadScene, UnityAction callBackToLoadedScene )
    {
        onLoadedScene = callBackToLoadedScene;

        SceneManager.LoadScene( sceneNameMap[loadScene], LoadSceneMode.Single );
    }

}
