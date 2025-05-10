using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable]
public struct KeyAttributes
{
    public string keyName;
    public GameObject keyObject;
    public bool haveKey;
}

public class KeyManager : MonoBehaviour
{
    public static KeyManager Instance;
    public KeyAttributes keys;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public void IHaveTheKey()
    {
        keys.haveKey = true;

        GameObject tempKeyobject = keys.keyObject;
        Destroy(tempKeyobject);
    }
}
