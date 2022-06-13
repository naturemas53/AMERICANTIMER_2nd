using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CommonDefine 
{
    // プレイヤー情報の集まり.
    // (null返せるようにclassにしておきます)
    public class PlayerPropety
    {
        public string name; // プレイヤー名
        public Color color; // プレイヤーカラー

        public PlayerPropety()
        {
            name = "";
            color = new Color();
        }

        public PlayerPropety( string name, Color color )
        {
            this.name  = name;
            this.color = color;
        }
    }

}
