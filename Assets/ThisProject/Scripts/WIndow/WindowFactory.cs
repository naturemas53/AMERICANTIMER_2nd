using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowFactory : SingletonMonoBehaviour<WindowFactory>
{
    public enum CreateType
    { 
        TextWindow,
        MemberSelect,

        Max
    }

    [SerializeField]
    Transform parentCanvas;

    [SerializeField]
    List<WindowBase> originWindows;

    protected override void Initialize()
    {
    }

    /// <summary>
    /// ウィンドウを生成します
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public WindowBase CreateWindow( CreateType type )
    {
        WindowBase retValue = null;

        if(type >= CreateType.Max)
        {
            Debug.LogError("範囲外が参照されました。");
            return retValue;
        }

        retValue = Instantiate( originWindows[(int)type], parentCanvas ).GetComponent< WindowBase >();


        return retValue;
    }
}
