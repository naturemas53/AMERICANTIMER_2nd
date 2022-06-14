using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonPrefabScript : SingletonMonoBehaviour<SingletonPrefabScript>
{
    protected override void Initialize()
    {
        limitObject = true;
     }
}
