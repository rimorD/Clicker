using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Definitions : MonoBehaviour
{
    private static Definitions _instance;

    public static Definitions Instance
    {
        get
        {
            if (_instance == null)
                _instance = Instantiate(Resources.Load<Definitions>("Prefabs/Definitions"));
            return _instance;
        }
    }

    public Transform damagePopupPrefab;
}
