using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NamePlate : MonoBehaviour
{
    [SerializeField]
    GameObject inputPanel;
    [SerializeField]
    GameObject displayPanel;

    // Start is called before the first frame update
    void Start()
    {
        inputPanel.gameObject.SetActive(true);
        displayPanel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
