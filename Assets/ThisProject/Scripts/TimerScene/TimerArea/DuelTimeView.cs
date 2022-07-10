using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DuelTimeView : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI timeText = null;
    [SerializeField]
    DuelTimer timer = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeText == null || timer == null) return;

        timeText.text = CommonHelper.BuildTimeText(timer.DuelTime, false, true, true );
    }
}
