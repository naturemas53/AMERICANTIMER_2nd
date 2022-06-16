using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootSceneScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        // そんなにFPSいらない　はず
        Application.targetFrameRate = 60;

        // TODO: フェードも考慮するロードを後に使うように
        SceneChanger.Instance.ChangeScene( SceneChanger.EScene.PlayerEntry );
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
