using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerSceneState : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameTimer timer = GetComponent< GameTimer >();
        if( timer != null )
        {
            timer.StopTimer();
            timer.SetRemainTime( 30 );
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
