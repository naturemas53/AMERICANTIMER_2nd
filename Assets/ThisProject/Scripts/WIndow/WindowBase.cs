using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// ウィンドウのインターフェース
/// </summary>
public abstract class WindowBase : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI textUI;
    [SerializeField]
    Button decideButton;

    UnityEvent CallbackToDecide = new UnityEvent();

    private void Start()
    {
        decideButton.onClick.AddListener( OnPressedDecideButton );
    }

    /// <summary>
    /// 決定ボタン押下時の選択結果を取得
    /// 
    /// </summary>
    /// <returns></returns>
    public abstract bool GetResult<T>(out T result) where T : class;
    /// <summary>
    /// 質問文の設定
    /// </summary>
    /// <param name="text"></param>
    public void SetText(string text)
    {
        textUI.text = text;
    }

    /// <summary>
    /// OKボタン等、決定押下時のコールバック
    /// </summary>
    /// <param name="registCallback"></param>
    public void RegistCallbackToDecide(UnityAction registCallback)
    {
        CallbackToDecide.AddListener( registCallback );
    }

    /// <summary>
    /// 決定ボタン押下時のコールバック.
    /// </summary>
    void OnPressedDecideButton()
    {
        OnDecideCallBackImpl();

        CallbackToDecide.Invoke();
        CallbackToDecide.RemoveAllListeners();

        Destroy( gameObject );
    }

    /// <summary>
    /// 決定ボタン押された時のコールバック(派生クラスでの処理用).
    /// </summary>
    protected abstract void OnDecideCallBackImpl();
}
