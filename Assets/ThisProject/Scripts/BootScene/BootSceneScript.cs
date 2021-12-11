using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootSceneScript : MonoBehaviour
{
    [SerializeField]
    GameObject singletonObject = null;

    // Start is called before the first frame update
    void Start()
    {
        // TODO: 必要に応じてマネージャ等の初期化
        DontDestroyOnLoad( singletonObject );

        // TODO: 共通定義とかからシーン名引っ張ってシーンをロード
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
