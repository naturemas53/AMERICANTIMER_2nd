using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextWindow : WindowBase
{
    public override bool GetResult<T>( out T result )
    {
        // 特に返す結果はない...
        result = null;
        return true;
    }

    protected override void OnDecideCallBackImpl()
    {
        // 特になにも必要ない...
    }
}
