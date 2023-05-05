using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recupera : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("player"))
        {
            other.GetComponent<vida>().Curar(3);
            Destroy(gameObject);
        }
    }













}
