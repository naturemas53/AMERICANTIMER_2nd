using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RemainTimeView: MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI timeText = null;
    [SerializeField]
    GameTimer timer = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeText == null || timer == null) return;

        timeText.text = Common.BuildTimeText(timer.RemainTime);
    }
}
