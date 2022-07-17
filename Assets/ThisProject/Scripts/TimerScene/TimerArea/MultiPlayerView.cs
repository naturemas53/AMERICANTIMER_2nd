using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MultiPlayerView : MonoBehaviour
{
    [SerializeField]
    DuelTimer duelTimer;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine( CoLateStart() );
    }

    IEnumerator CoLateStart()
    {
        yield return new WaitForEndOfFrame();

        TextMeshProUGUI tproText = GetComponent<TextMeshProUGUI>();

        if (tproText != null)
        {
            tproText.text = "x" + duelTimer.Multiplayer.ToString();
        }
    }
}
