using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(CanvasGroup))]
public class FadePanel : SingletonMonoBehaviour<FadePanel>
{
    CanvasGroup canvasGroup;

    public enum EFade
    {
        In, // こっちが明るくしていく方
        Out // こっちは暗くしていく方
    }

    Coroutine   currentFade;
    EFade       currenFadeType;
    UnityAction onCompletedFade;

    protected override void Initialize()
    {
        currentFade     = null;
        currenFadeType  = EFade.In;
        onCompletedFade = null;

        // 上記で強制しているので必ずある　はず.
        canvasGroup = GetComponent<CanvasGroup>();
        InitializeFadePanel();
    }

    /// <summary>
    /// フェード表示を初期化します.
    /// </summary>
    void InitializeFadePanel()
    {
        canvasGroup.alpha = 0.0f;
        canvasGroup.blocksRaycasts = false;
    }

    /// <summary>
    /// フェード実行
    /// </summary>
    /// <param name="fadeType">インアウト選択</param>
    /// <param name="time">フェード時間</param>
    /// <param name="fadeCompletedCallBack">フェード終了時のコールバック</param>
    public void ExcuteFade( EFade fadeType, float time, UnityAction fadeCompletedCallBack = null )
    {
        if( currentFade != null )
        {
            EndFade();
        }

        currenFadeType = fadeType;
        onCompletedFade = fadeCompletedCallBack;

        currentFade = StartCoroutine( CoFade( time ) );
    }

    /// <summary>
    /// フェードコルーチン（引数は上記と同じ.）
    /// </summary>
    /// <param name="fadeType"></param>
    /// <param name="time"></param>
    /// <param name="fadeCompletedCallBack"></param>
    /// <returns></returns>
    IEnumerator CoFade(float time)
    {
        canvasGroup.blocksRaycasts = true;

        float startAlpha = (currenFadeType == EFade.In) ? 1.0f : 0.0f;
        float endAlpha   = (currenFadeType == EFade.In) ? 0.0f : 1.0f;

        float elapsedTime = 0.0f;
        while( elapsedTime < time )
        {
            elapsedTime += Time.deltaTime;

            float t = elapsedTime / time;
            float currentAlpha = Mathf.Lerp( startAlpha, endAlpha, t );

            canvasGroup.alpha = currentAlpha;

            yield return new WaitForEndOfFrame();
        }

        EndFade();
    }

    /// <summary>
    /// フェード終了.
    /// </summary>
    void EndFade()
    {
        canvasGroup.alpha = (currenFadeType == EFade.In) ? 0.0f : 1.0f;
        canvasGroup.blocksRaycasts = (currenFadeType == EFade.Out);

        if (onCompletedFade != null)
        {
            onCompletedFade();
        }
        onCompletedFade = null;

        currentFade = null;
    }
}
