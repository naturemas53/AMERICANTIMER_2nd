using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NamePlate : MonoBehaviour
{
    [SerializeField]
    GameObject actionButton;
    [SerializeField]
    InputField inputField;
    [SerializeField]
    GameObject inputPanel;
    [SerializeField]
    TextMeshProUGUI displayPanel;

    PlayerData selfData;
    Text actionButtonLabel;

    NameEntryMediator parentScript;

    // Start is called before the first frame update
    void Start()
    {
        selfData = null;
        parentScript = null;
        inputPanel.gameObject.SetActive(true);
        displayPanel.gameObject.SetActive(false);

        actionButtonLabel = actionButton.GetComponent<Text>();
        Button button = actionButton.GetComponent<Button>();
        button.onClick.AddListener(OnPressedActionButton);
    }

    public void Initialize( NameEntryMediator parent )
    {
        parentScript = parent;
    }

    void OnPressedActionButton()
    {
        if ( selfData == null )
        {
            TryAddPlayer();
        }
        else
        {
            RemoveSelfPlayer();
        }
    }

    void TryAddPlayer()
    {
        parentScript.RegistPlayer( inputField.text, out selfData );

        if( selfData != null )
        {
            displayPanel.text = selfData.playerName;
            displayPanel.outlineColor = selfData.playerColor;

            inputPanel.gameObject.SetActive(false);
            displayPanel.gameObject.SetActive(true);

            actionButtonLabel.text = "Remove";
        }
    }

    void RemoveSelfPlayer()
    {
        parentScript.RemovePlayer( selfData );
        Destroy(gameObject);
    }
    
}
