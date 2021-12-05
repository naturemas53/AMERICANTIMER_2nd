using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerControllerButtonLabel : MonoBehaviour
{
    [SerializeField]
    Text playPauseButtonLabel = null;
    [SerializeField]
    Text duelTimerButtonLabel = null;

    [SerializeField]
    GameTimer timer = null;
    [SerializeField]
    DuelTimer duelTimer = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if( playPauseButtonLabel != null )
        {
            string labelText = "Label1";

            if( timer != null ) labelText = (timer.IsNowCounting) ? "Pause" : "Resume";

            playPauseButtonLabel.text = labelText;
        }

        if (duelTimerButtonLabel != null)
        {
            string labelText = "Label2";

            if (duelTimer != null) labelText = (duelTimer.IsCountUp) ? "Duel\nReset" : "Duel\nStart";

            duelTimerButtonLabel.text = labelText;
        }
    }
}
