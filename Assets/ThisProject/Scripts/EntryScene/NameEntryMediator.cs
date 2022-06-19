using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameEntryMediator : MonoBehaviour
{
    [SerializeField]
    NamePlate namePlate;

    // Start is called before the first frame update
    void Start()
    {
        DestroyAllNamePlate();
        AddNamePlate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // プレイヤー登録を行います.
    public bool RegistPlayer( string playerName, out PlayerData putedData )
    {
        bool retValue = PlayerSet.Instance.AddPlayer( playerName, out putedData );

        if (retValue)
        {
            AddNamePlate();
        }

        return retValue;
    }

    // プレイヤー削除を行います.
    public void RemovePlayer( PlayerData targetPlayerData )
    {
        PlayerSet.Instance.RemovePlayer( targetPlayerData );
    }

    /// <summary>
    /// 生成したネームプレートをすべて削除します.
    /// </summary>
    void DestroyAllNamePlate()
    {
        int childCount = this.transform.childCount;
        for( int i = 0; i < childCount; ++i )
        {
            GameObject childObject = this.transform.GetChild(0).gameObject;
            Destroy( childObject );
        }
    }

    // 新しいネームプレートの生成.
    void AddNamePlate()
    {
        NamePlate addedPlate = Instantiate( namePlate.gameObject, this.transform ).GetComponent<NamePlate>();
        addedPlate.Initialize( this );
    }
}
