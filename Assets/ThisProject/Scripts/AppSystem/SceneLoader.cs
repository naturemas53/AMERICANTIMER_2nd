using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

using static SceneChanger;
public class SceneLoader
{
    static readonly ReadOnlyDictionary<EScene, string> sceneNameMap = new ReadOnlyDictionary<EScene, string>( new Dictionary<EScene, string>() 
    {
        { EScene.Boot, "BootScene" },
        { EScene.PlayerEntry, "EntryScene" },
        { EScene.RoundSetting, "RoundSettingScene" },
        { EScene.Timer, "TimerScene" },
        { EScene.RoundResult, "RoundResultScene" },
        { EScene.TotalResult, "TotalResultScene" },
        { EScene.RoundLog, "RoundLogScene" },
    } );

    UnityAction onLoadedScene;

    public SceneLoader()
    {
        onLoadedScene = null;
    }

    public void Initialize()
    {
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
    public void LoadScene( EScene loadScene, UnityAction callBackToLoadedScene = null )
    {
        onLoadedScene = callBackToLoadedScene;

        SceneManager.LoadScene( sceneNameMap[loadScene], LoadSceneMode.Single );
    }

}
