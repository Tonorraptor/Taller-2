using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyHolder : MonoBehaviour
{
    public event EventHandler OnKeysChange;

    private List<key.KeyType> keyList;

    private void Awake()
    {
    
        keyList = new List<key.KeyType>();
    }

    public List<key.KeyType> GetKeyList()
    {
        return keyList;
    }

    public void addKey(key.KeyType keyType)
    {
        Debug.Log("ADded Key: " + keyType);
        keyList.Add(keyType);
        OnKeysChange?.Invoke(this, EventArgs.Empty);
    }

    public void removeKey(key.KeyType keyType)
    {
        keyList.Remove(keyType);
        OnKeysChange?.Invoke(this, EventArgs.Empty);
    }

    public bool ContainsKey(key.KeyType keyType)
    {
        return keyList.Contains(keyType);
    }


    private void OnTriggerEnter2D(Collider2D colider)
    {
        key key = colider.GetComponent<key> (); 
        if (key != null)
        {
            addKey(key.GetKeyType());
            Destroy(key.gameObject);
        }

        keyDoor  keyDoor = colider.GetComponent<keyDoor> ();
        if (keyDoor != null)
        {
            if (ContainsKey(keyDoor.GetKeyType()))
            {
                removeKey(keyDoor.GetKeyType());
                keyDoor.OpenDoor();
                
            }
        }
    }

}
